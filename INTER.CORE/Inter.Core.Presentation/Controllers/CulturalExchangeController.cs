using Inter.Core.App.Intefaces;
using Inter.Core.App.Intefaces.Identity;
using Inter.Core.App.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin, Manager, CulturalExchange")]
    public class CulturalExchangeController : Controller
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly ICulturalExchangeAppService _culturalExchangeAppService;
        private readonly IStudentAppService _studentAppService;
        private readonly ICollegeAppService _collegeAppService;
        private readonly ICollegeTimeAppService _collegeTimeAppService;
        private readonly IEnvironmentAppService _environmentAppService;
        private readonly IAccomodationAppService _accomodationAppService;
        private readonly IReceivePaymentCulturalExchangeAppService _receivePaymentAppService;

        //private readonly UserManager<ApplicationUserViewModel> _userManager;

        public CulturalExchangeController(/*UserManager<ApplicationUserViewModel> userManager,*/
            IApplicationUserAppService applicationUserAppService,
            ICulturalExchangeAppService culturalExchangeAppService,
            IStudentAppService studentAppService, ICollegeAppService collegeAppService,
            IEnvironmentAppService environmentAppService, IAccomodationAppService accomodationAppService,
            ICollegeTimeAppService collegeTimeAppService, IReceivePaymentCulturalExchangeAppService receivePaymentAppService
            )
        {
            _applicationUserAppService = applicationUserAppService;
            _culturalExchangeAppService = culturalExchangeAppService;
            _studentAppService = studentAppService;
            _collegeAppService = collegeAppService;
            _collegeTimeAppService = collegeTimeAppService;
            //_userManager = userManager;
            _environmentAppService = environmentAppService;
            _accomodationAppService = accomodationAppService;
            _receivePaymentAppService = receivePaymentAppService;
        }

        // GET: CulturalExchange
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            ViewBag.EnvironmentId = user.EnvironmentId;
            ViewBag.Colleges = _collegeAppService.GetAll(user.EnvironmentId);
            ViewBag.Accomodations = _accomodationAppService.GetAll(user.EnvironmentId);

            List<CulturalExchangeViewModel> culturalExchangeList = _culturalExchangeAppService.GetAll(user.EnvironmentId, true);

            return View("~/Views/CulturalExchange/Index.cshtml", culturalExchangeList);
        }

        public async Task<IActionResult> FindByFilter(string startArrivalDate, string finishArrivalDate, Guid collegeId, Guid accomodationId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            var culturalExchangeList = _culturalExchangeAppService.GetAllByFilter(user.EnvironmentId, startArrivalDate, finishArrivalDate, collegeId, accomodationId);

            return PartialView("~/Views/CulturalExchange/_partial/_List.cshtml", culturalExchangeList);
        }

        // GET: CulturalExchange/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var culturalExchangeViewModel = _culturalExchangeAppService.GetById(id);

            if (culturalExchangeViewModel == null)
                return NotFound();

            return View(culturalExchangeViewModel);
        }

        // GET: CulturalExchange/Create
        public async Task<IActionResult> Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            ViewBag.EnvironmentId = user.EnvironmentId;
            ViewBag.Students = _studentAppService.GetStudentsNotEnroled(user.EnvironmentId);
            ViewBag.Colleges = _collegeAppService.GetAll(user.EnvironmentId);
            ViewBag.Accomodations = _accomodationAppService.GetAllAvaliable(user.EnvironmentId);

            return View();
        }

        // POST: CulturalExchange/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int noHaveParam)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnCreate(CulturalExchangeViewModel culturalExchangeViewModel)
        {
            if (ModelState.IsValid)
            {
                culturalExchangeViewModel = _culturalExchangeAppService.Add(culturalExchangeViewModel.EnviromentId, culturalExchangeViewModel);

                if (!culturalExchangeViewModel.ValidationResult.Any())
                    return Json(Ok());

                return Json(Conflict(culturalExchangeViewModel.ValidationResult));
            }

            return Json(Conflict(ModelState.Values.SelectMany(x => x.Errors)));
        }

        // GET: CulturalExchange/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var culturalExchangeViewModel = _culturalExchangeAppService.GetById(id);

            if (culturalExchangeViewModel == null)
                return NotFound();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            ViewBag.EnvironmentId = user.EnvironmentId;
            ViewBag.Colleges = _collegeAppService.GetAll(user.EnvironmentId);
            ViewBag.Accomodations = _accomodationAppService.GetAll(user.EnvironmentId);

            return View(culturalExchangeViewModel);
        }

        // POST: CulturalExchange/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CulturalExchangeViewModel culturalExchangeViewModel)
        {
            if (id == Guid.Empty)
                return NotFound();

            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _applicationUserAppService.GetById(userId);

                if (user == null)
                    return NotFound();

                _culturalExchangeAppService.Update(user.EnvironmentId, culturalExchangeViewModel);

                return RedirectToAction("Index", "CulturalExchange");
            }
            return View(culturalExchangeViewModel);
        }

        // GET: CulturalExchange/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var culturalExchangeViewModel = _culturalExchangeAppService.GetById(id);

            if (culturalExchangeViewModel == null)
                return NotFound();

            return View(culturalExchangeViewModel);
        }

        public async Task<IActionResult> PaymentDetails(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var payments = _receivePaymentAppService.GetByCulturalExchangeId(id);

            return View(payments);
        }

        public async Task<IActionResult> DetailsFilesUpload(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var culturalExchangeFilesUpload = _culturalExchangeAppService.GetById(id);

            return View(culturalExchangeFilesUpload);

        }

        public async Task<IActionResult> Inactive(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var culturalExchangeFilesUpload = _culturalExchangeAppService.Inactive(id);

            return Json(Ok());
        }

        public IActionResult GetCustomerIdByCulturalExchangeId(Guid id)
        {
            if (id == Guid.Empty)
                return Conflict();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            var culturalExchange = _culturalExchangeAppService.GetById(id);

            return Json(culturalExchange.StudentViewModel.CustomerId);
        }

        //// POST: CulturalExchange/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var culturalExchangeViewModel = await _context.CulturalExchangeViewModel.FindAsync(id);
        //    _context.CulturalExchangeViewModel.Remove(culturalExchangeViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CulturalExchangeViewModelExists(int id)
        //{
        //    return _context.CulturalExchangeViewModel.Any(e => e.Id == id);
        //}
    }
}
