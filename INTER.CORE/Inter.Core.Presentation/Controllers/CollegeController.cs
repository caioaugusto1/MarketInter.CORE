using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    //[Route("admin-college")]
    [Authorize(Roles = "Admin, Manager, College")]
    public class CollegeController : BaseController
    {
        private readonly ICollegeAppService _collegeAppService;
        private readonly ICollegeTimeAppService _collegeTimeAppService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CollegeController(UserManager<ApplicationUser> userManager,
            ICollegeAppService collegeAppService,
            ICollegeTimeAppService collegeTimeAppService)
        {
            _collegeAppService = collegeAppService;
            _collegeTimeAppService = collegeTimeAppService;
            _userManager = userManager;
        }

        #region College

        // GET: College
        public async Task<IActionResult> Index()
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            return View(_collegeAppService.GetAll(user.EnvironmentId));
        }


        // GET: College/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
                return NotFound();

            var collegeViewModel = _collegeAppService.GetById(id);

            if (collegeViewModel == null)
                return NotFound();

            return View(collegeViewModel);
        }

        // GET: College/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: College/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CollegeViewModel collegeViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await GetUser(_userManager);

                if (user == null)
                    return NotFound();

                collegeViewModel = _collegeAppService.Add(user.EnvironmentId, collegeViewModel);

                if (!collegeViewModel.ValidationResult.Any())
                    return Json(new { collegeName = collegeViewModel.Name, statusCode = HttpStatusCode.OK });

                return Json(Conflict(collegeViewModel.ValidationResult));
            }

            return View(collegeViewModel);
        }

        // GET: College/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var collegeViewModel = _collegeAppService.GetById(id);

            if (collegeViewModel == null)
                return NotFound();

            return View(collegeViewModel);
        }

        // POST: College/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City,Country,EnviromentId")] CollegeViewModel collegeViewModel)
        {
            if (id != collegeViewModel.Id || id == 0)
                return NotFound();

            if (ModelState.IsValid)
            {
                _collegeAppService.Update(collegeViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(collegeViewModel);
        }

        // GET: College/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var collegeViewModel = _collegeAppService.GetById(id);

            if (collegeViewModel == null)
                return NotFound();

            return View(collegeViewModel);
        }

        // POST: College/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collegeViewModel = _collegeAppService.GetById(id);

            return RedirectToAction(nameof(Index));
        }

        //private bool CollegeViewModelExists(int id)
        //{
        //    return _context.CollegeViewModel.Any(e => e.Id == id);
        //}

        #endregion

        #region CollegeTime 

        [HttpPost]
        public async Task<IActionResult> CreateTimeCollege(CollegeTimeViewModel collegeTime)
        {
            if (ModelState.IsValid)
            {
                var user = await GetUser(_userManager);

                if (user == null)
                    return NotFound();

                _collegeTimeAppService.Add(collegeTime);

                return Ok();
            }

            return Conflict();
        }

        public async Task<IActionResult> GetPartialCreateCollegeTime(int collegeId)
        {
            ViewBag.CollegeId = collegeId;

            return PartialView("~/Views/College/_partial/_modal_create_timeCollege.cshtml");
        }

        public async Task<IActionResult> LoadingPartialEditCollegeTime(int idCollegeTime)
        {
            if (idCollegeTime == 0)
                return NotFound();

            var collegeTime = _collegeTimeAppService.GetById(idCollegeTime);

            return PartialView("~/Views/College/_partial/_edit_collegeTime.cshtml", collegeTime);
        }

        public async Task<JsonResult> GetCollegeTimeByCollegeId(int collegeId)
        {
            if (collegeId == 0)
                return Json(NotFound());

            var collegeTime = _collegeTimeAppService.GetAllByCollegeId(collegeId);

            return Json(collegeTime);

        }

        public async Task<IActionResult> PostEditCollegeTime(CollegeTimeViewModel collegeTime)
        {
            if (ModelState.IsValid)
            {
                _collegeTimeAppService.Update(collegeTime);
                return Ok();
            }

            return PartialView(ModelState);
        }
        #endregion
    }
}
