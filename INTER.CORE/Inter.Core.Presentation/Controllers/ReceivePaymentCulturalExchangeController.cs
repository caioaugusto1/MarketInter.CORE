using Inter.Core.App.Intefaces;
using Inter.Core.App.Intefaces.Identity;
using Inter.Core.App.ViewModel;
using Inter.Core.Presentation.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin, Manager, ReceivePaymentCulturalExchange")]
    public class ReceivePaymentCulturalExchangeController : Controller
    {
        private readonly IOptions<AppSettings> _appSetttings;
        private readonly IFileUploadAppService _fileUploadAppService;
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IReceivePaymentCulturalExchangeAppService _receivePaymentCulturalExchangeAppService;
        private readonly ICulturalExchangeAppService _culturalExchangeAppService;
        private readonly ICollegeTimeAppService _collegeTimeAppService;
        private readonly ICollegeAppService _collegeAppService;

        public ReceivePaymentCulturalExchangeController(
            IOptions<AppSettings> appSetings,
            IFileUploadAppService fileUploadAppService,
            IApplicationUserAppService applicationUserAppService,
            IReceivePaymentCulturalExchangeAppService receivePaymentCulturalExchangeAppService,
            ICulturalExchangeAppService culturalExchangeAppService,
            ICollegeTimeAppService collegeTimeAppService,
            ICollegeAppService collegeAppService)
        {
            _appSetttings = appSetings;
            _fileUploadAppService = fileUploadAppService;
            _applicationUserAppService = applicationUserAppService;
            _collegeTimeAppService = collegeTimeAppService;
            _collegeAppService = collegeAppService;
            _receivePaymentCulturalExchangeAppService = receivePaymentCulturalExchangeAppService;
            _culturalExchangeAppService = culturalExchangeAppService;
        }

        // GET: ReceivePaymentCulturalExchange
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            var paymentsList = _receivePaymentCulturalExchangeAppService.GetAllIncludedDependency(user.EnvironmentId);

            return View(paymentsList);
        }

        // GET: ReceivePaymentCulturalExchange/Details/5
        public IActionResult Details(Guid id)
        {
            var receivePayments = _receivePaymentCulturalExchangeAppService.GetById(id);

            if (receivePayments == null)
                return NotFound();

            return View(receivePayments);
        }

        // GET: ReceivePaymentCulturalExchange/Create
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

        // POST: ReceivePaymentCulturalExchange/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceivePaymentCulturalExchangeViewModel receivePaymentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    receivePaymentVM.FileName = Guid.NewGuid().ToString() + ".pdf";

                    IFormFile formFile = receivePaymentVM.File;

                    receivePaymentVM = _receivePaymentCulturalExchangeAppService.Add(receivePaymentVM);

                    if (!receivePaymentVM.ValidationResult.Any())
                    {
                        receivePaymentVM.FileName = await _fileUploadAppService.Upload(_appSetttings.Value.UploadFilePath, receivePaymentVM.FileName, formFile);
                        return RedirectToAction("Index", "ReceivePaymentCulturalExchange");
                    }

                    return View(ModelState);
                }

                return Json(Conflict());
            }
            catch (Exception ex)
            {
                _fileUploadAppService.Delete(_appSetttings.Value.UploadFilePath, receivePaymentVM.FileName);
                return Json(BadRequest());
            }
        }

        // GET: ReceivePaymentCulturalExchange/Edit/5
        public IActionResult Edit(Guid id)
        {
            var culturalExchangeViewModel = _receivePaymentCulturalExchangeAppService.GetById(id);

            if (culturalExchangeViewModel == null)
                return NotFound();

            return View(culturalExchangeViewModel);
        }

        // POST: ReceivePaymentCulturalExchange/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ReceivePaymentCulturalExchangeViewModel paymentReceiveVM)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                _receivePaymentCulturalExchangeAppService.Update(user.EnvironmentId, paymentReceiveVM);

                return RedirectToAction("Details", "ReceivePaymentCulturalExchange");
            }

            return View(ModelState);
        }

        // GET: ReceivePaymentCulturalExchange/Delete/5
        public IActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: ReceivePaymentCulturalExchange/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}