using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin, Manager, CulturalExchange")]
    public class CulturalExchangeController : BaseController
    {
        private readonly ICulturalExchangeAppService _culturalExchangeAppService;
        private readonly IStudentAppService _studentAppService;
        private readonly ICollegeAppService _collegeAppService;
        private readonly ICollegeTimeAppService _collegeTimeAppService;
        private readonly IEnvironmentAppService _environmentAppService;
        private readonly IAccomodationAppService _accomodationAppService;
        private readonly IReceivePaymentCulturalExchangeAppService _receivePaymentAppService;

        private readonly UserManager<ApplicationUser> _userManager;

        public CulturalExchangeController(UserManager<ApplicationUser> userManager,
            ICulturalExchangeAppService culturalExchangeAppService,
            IStudentAppService studentAppService, ICollegeAppService collegeAppService,
            IEnvironmentAppService environmentAppService, IAccomodationAppService accomodationAppService,
            ICollegeTimeAppService collegeTimeAppService, IReceivePaymentCulturalExchangeAppService receivePaymentAppService
            )
        {
            _culturalExchangeAppService = culturalExchangeAppService;
            _studentAppService = studentAppService;
            _collegeAppService = collegeAppService;
            _collegeTimeAppService = collegeTimeAppService;
            _userManager = userManager;
            _environmentAppService = environmentAppService;
            _accomodationAppService = accomodationAppService;
            _receivePaymentAppService = receivePaymentAppService;
        }

        // GET: CulturalExchange
        public async Task<IActionResult> Index()
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            ViewBag.EnvironmentId = user.EnvironmentId;
            ViewBag.Colleges = _collegeAppService.GetAll(user.EnvironmentId);
            ViewBag.Accomodations = _accomodationAppService.GetAll(user.EnvironmentId);

            var culturalExchangeList = _culturalExchangeAppService.GetAll(user.EnvironmentId);

            return View(culturalExchangeList);
        }

        public async Task<IActionResult> FindByFilter(string startArrivalDate, string finishArrivalDate, Guid collegeId, Guid accomodationId)
        {
            var user = await GetUser(_userManager);

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
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            ViewBag.EnvironmentId = user.EnvironmentId;
            ViewBag.Students = _studentAppService.GetStudentsNotEnroled(user.EnvironmentId);
            ViewBag.Colleges = _collegeAppService.GetAll(user.EnvironmentId);
            ViewBag.Accomodations = _accomodationAppService.GetAll(user.EnvironmentId);

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

            var user = await GetUser(_userManager);

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
                _culturalExchangeAppService.Update(culturalExchangeViewModel);

                return RedirectToAction(nameof(Index));
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
