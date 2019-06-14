using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    //[Authorize(Roles = "Admin, Manager, ReceivePaymentCulturalExchange")]
    public class ReceivePaymentCulturalExchangeController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReceivePaymentCulturalExchangeAppService _receivePaymentCulturalExchangeAppService;
        private readonly ICulturalExchangeAppService _culturalExchangeAppService;

        public ReceivePaymentCulturalExchangeController(
            UserManager<ApplicationUser> userManager,
            IReceivePaymentCulturalExchangeAppService receivePaymentCulturalExchangeAppService,
            ICulturalExchangeAppService culturalExchangeAppService)
        {
            _userManager = userManager;
            _receivePaymentCulturalExchangeAppService = receivePaymentCulturalExchangeAppService;
            _culturalExchangeAppService = culturalExchangeAppService;
        }

        // GET: ReceivePaymentCulturalExchange
        public async Task<IActionResult> Index()
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            var paymentsList = _receivePaymentCulturalExchangeAppService.GetAllIncludedDependency(user.EnvironmentId);

            return View(paymentsList);
        }

        // GET: ReceivePaymentCulturalExchange/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ReceivePaymentCulturalExchange/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            ViewBag.EnvironmentId = user.EnvironmentId;
            ViewBag.CulturalExchange = _culturalExchangeAppService.GetAll(user.EnvironmentId);

            return View();
        }

        // POST: ReceivePaymentCulturalExchange/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceivePaymentCulturalExchangeViewModel receivePaymentVM)
        {
            if (ModelState.IsValid)
            {
                receivePaymentVM = _receivePaymentCulturalExchangeAppService.Add(receivePaymentVM);

                if (!receivePaymentVM.ValidationResult.Any())
                    return RedirectToAction("Index", "ReceivePaymentCulturalExchange");
            }

            return View();
        }

        // GET: ReceivePaymentCulturalExchange/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReceivePaymentCulturalExchange/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReceivePaymentCulturalExchange/Delete/5
        public IActionResult Delete(int id)
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