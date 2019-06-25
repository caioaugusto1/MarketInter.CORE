using Inter.Core.App.Intefaces;
using Inter.Core.App.Intefaces.Identity;
using Inter.Core.App.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin, Manager, Accomodation")]
    public class AccomodationController : Controller
    {
        //private readonly UserManager<ApplicationUserViewModel> _userManager;
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IAccomodationAppService _accomodationAppService;
        private readonly ICulturalExchangeAppService _culturalExchangeAppService;

        public AccomodationController(IApplicationUserAppService applicationUserAppService,
            IAccomodationAppService accomodationAppService,
            ICulturalExchangeAppService culturalExchangeAppService)
        {
            //_userManager = userManager;
            _applicationUserAppService = applicationUserAppService;
            _accomodationAppService = accomodationAppService;
            _culturalExchangeAppService = culturalExchangeAppService;
        }

        // GET: Accomodation
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            return View(_accomodationAppService.GetAll(user.EnvironmentId));
        }

        // GET: Accomodation/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var accomodationViewModel = _accomodationAppService.GetById(id);

            if (accomodationViewModel == null)
                return NotFound();

            return View(accomodationViewModel);
        }

        // GET: Accomodation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accomodation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccomodationViewModel accomodationViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _applicationUserAppService.GetById(userId);

                if (user != null)
                    _accomodationAppService.Add(user.EnvironmentId, accomodationViewModel);

                return RedirectToAction("Index", "Accomodation");
            }

            return View(accomodationViewModel);
        }

        // GET: Accomodation/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var accomodationViewModel = _accomodationAppService.GetById(id);

            if (accomodationViewModel == null)
                return NotFound();

            return View(accomodationViewModel);
        }

        // POST: Accomodation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AccomodationViewModel accomodationViewModel)
        {
            if (ModelState.IsValid)
            {
                _accomodationAppService.Update(accomodationViewModel);

                return RedirectToAction("Index", "Accomodation");
            }

            return View(accomodationViewModel);
        }

        public async Task<IActionResult> DetailsReservation(Guid accomodationId)
        {
            if (accomodationId == Guid.Empty)
                return Json(Conflict());

            AccomodationViewModel accomodationVM = _accomodationAppService.GetAccomodationAndCulturalExchangeList(accomodationId);

            return View(accomodationVM);
        }

        public async Task<IActionResult> GetModalUpdateDate(Guid culturalExchangeId)
        {
            if (culturalExchangeId == Guid.Empty)
                return null;

            var culturalExchange = _culturalExchangeAppService.GetById(culturalExchangeId);

            return PartialView("~/Views/Accomodation/_partial/_modal_edit_date_accomodation.cshtml", culturalExchange);
        }

        public async Task<IActionResult> UpdateDateStartAndFinish(Guid culturalExchangeId, DateTime start, DateTime finish)
        {
            if (culturalExchangeId == Guid.Empty)
                return null;

            var culturalExchange = _culturalExchangeAppService.UpdateDateStartAndFinish(culturalExchangeId, start, finish);

            if (!culturalExchange.ValidationResult.Any())
                return Json(Ok());

            return Json(Conflict());
        }

        // GET: Accomodation/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var accomodationViewModel = _accomodationAppService.GetById(id);

            if (accomodationViewModel == null)
                return NotFound();

            return View(accomodationViewModel);
        }

        // POST: Accomodation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var accomodationViewModel = _accomodationAppService.GetById(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool AccomodationViewModelExists(int id)
        //{
        //    return _context.AccomodationViewModel.Any(e => e.Id == id);
        //}
    }
}
