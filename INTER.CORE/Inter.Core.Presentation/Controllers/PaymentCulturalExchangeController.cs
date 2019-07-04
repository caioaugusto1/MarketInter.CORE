using Inter.Core.App.Intefaces;
using Inter.Core.App.Intefaces.Identity;
using Inter.Core.App.ViewModel;
using Inter.Core.Presentation.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin, Manager, PaymentCulturalExchange")]
    public class PaymentCulturalExchangeController : Controller
    {
        private readonly IOptions<AppSettings> _appSetttings;
        private readonly IFileUploadAppService _fileUploadAppService;
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IPaymentCulturalExchangeAppService _paymentCulturalExchangeAppService;
        private readonly ICulturalExchangeAppService _culturalExchangeAppService;

        public PaymentCulturalExchangeController(
            IOptions<AppSettings> appSetttings,
            IFileUploadAppService fileUploadAppService,
            ICulturalExchangeAppService culturalExchangeAppService,
            IApplicationUserAppService applicationUserAppService,
            IPaymentCulturalExchangeAppService paymentCulturalExchangeAppService)
        {
            _appSetttings = appSetttings;
            _fileUploadAppService = fileUploadAppService;
            _culturalExchangeAppService = culturalExchangeAppService;
            _applicationUserAppService = applicationUserAppService;
            _paymentCulturalExchangeAppService = paymentCulturalExchangeAppService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            var paymentsList = _paymentCulturalExchangeAppService.GetAll(user.EnvironmentId);

            return View(paymentsList);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var payment = _paymentCulturalExchangeAppService.GetById(id);

            return View(payment);
        }

        public async Task<IActionResult> Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            ViewBag.EnvironmentId = user.EnvironmentId;
            ViewBag.CulturalExchange = _culturalExchangeAppService.GetAll(user.EnvironmentId, true);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCulturalExchangeViewModel paymentCulturalExchangeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var culturalExchange = _culturalExchangeAppService.GetById(paymentCulturalExchangeViewModel.CulturalExchangeId);

                    paymentCulturalExchangeViewModel.FileName = await _fileUploadAppService.Upload(
                        _appSetttings.Value.UploadFilePath + culturalExchange.Id, null, paymentCulturalExchangeViewModel.File);

                    paymentCulturalExchangeViewModel = _paymentCulturalExchangeAppService.Add(paymentCulturalExchangeViewModel);

                    if (!paymentCulturalExchangeViewModel.ValidationResult.Any())
                        return RedirectToAction("Index", "ReceivePaymentCulturalExchange");
                }

                return Json(Conflict());
            }
            catch (Exception ex)
            {
                _fileUploadAppService.Delete(_appSetttings.Value.UploadFilePath, paymentCulturalExchangeViewModel.FileName);
                return Json(BadRequest());
            }
        }

        //private async Task<string> UploadFile(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return null;

        //    string fileName = Guid.NewGuid().ToString() + ".pdf";

        //    var pathFolder = _appSetttings.Value.UploadFilePath;

        //    var pathCombine = Path.Combine(
        //        pathFolder,
        //                fileName);

        //    if (!Directory.Exists(pathFolder))
        //        Directory.CreateDirectory(pathFolder);

        //    using (var stream = new FileStream(pathCombine, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    return fileName;
        //}

        //private void DeleteFile(string fileName)
        //{
        //    var path = Path.Combine(_appSetttings.Value.UploadFilePath,
        //               fileName);

        //    if (System.IO.File.Exists(path))
        //        System.IO.File.Delete(path);
        //}
    }
}