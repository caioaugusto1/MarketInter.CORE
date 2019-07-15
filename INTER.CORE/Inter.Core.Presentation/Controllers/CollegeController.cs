using Inter.Core.App.Enumerables;
using Inter.Core.App.Intefaces;
using Inter.Core.App.Intefaces.Identity;
using Inter.Core.App.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    //[Route("admin-college")]
    [Authorize(Roles = "Admin, Manager, College")]
    public class CollegeController : Controller
    {
        private readonly ICollegeAppService _collegeAppService;
        private readonly ICollegeTimeAppService _collegeTimeAppService;
        //private readonly UserManager<ApplicationUserViewModel> _userManager;
        private readonly IApplicationUserAppService _applicationUserAppService;

        public CollegeController(IApplicationUserAppService applicationUserAppService,
            ICollegeAppService collegeAppService,
            ICollegeTimeAppService collegeTimeAppService)
        {
            _applicationUserAppService = applicationUserAppService;
            _collegeAppService = collegeAppService;
            _collegeTimeAppService = collegeTimeAppService;
            //_userManager = userManager;
        }

        #region College

        // GET: College
        public async Task<IActionResult> Index()
        {
            //var user = await GetUser(_userManager);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            return View(_collegeAppService.GetAll(user.EnvironmentId));
        }


        // GET: College/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
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
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _applicationUserAppService.GetById(userId);
                //var user = await GetUser(_userManager);

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
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
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
        public async Task<IActionResult> Edit(CollegeViewModel collegeViewModel)
        {
            if (ModelState.IsValid)
            {
                _collegeAppService.Update(collegeViewModel);

                return RedirectToAction("Index", "College");
            }
            return View(collegeViewModel);
        }

        // GET: College/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var collegeViewModel = _collegeAppService.GetById(id);

            if (collegeViewModel == null)
                return NotFound();

            return View(collegeViewModel);
        }

        // POST: College/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
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
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _applicationUserAppService.GetById(userId);

                if (user == null)
                    return NotFound();

                _collegeTimeAppService.Add(collegeTime);

                return Json(Ok());
            }

            return Json(Conflict());
        }

        public async Task<IActionResult> GetPartialCreateCollegeTime(Guid collegeId)
        {
            ViewBag.CollegeId = collegeId;

            return PartialView("~/Views/College/_partial/_modal_create_timeCollege.cshtml");
        }

        public async Task<IActionResult> LoadingPartialEditCollegeTime(Guid idCollegeTime)
        {
            if (idCollegeTime == Guid.Empty)
                return NotFound();

            var collegeTime = _collegeTimeAppService.GetById(idCollegeTime);

            return PartialView("~/Views/College/_partial/_edit_collegeTime.cshtml", collegeTime);
        }

        public async Task<JsonResult> GetCollegeTimeByCollegeId(Guid collegeId)
        {
            if (collegeId == Guid.Empty)
                return Json(NotFound());

            var collegeTime = _collegeTimeAppService.GetAllByCollegeId(collegeId);

            return Json(collegeTime);

        }

        public async Task<JsonResult> PostEditCollegeTime(CollegeTimeViewModel collegeTime)
        {
            if (ModelState.IsValid)
            {
                _collegeTimeAppService.Update(collegeTime);
                return Json(Ok());
            }

            return Json(Conflict(ModelState.Values.SelectMany(x => x.Errors)));
        }

        public async Task<JsonResult> DeleteConfirmedTimeCollege(Guid id)
        {
            if (id != Guid.Empty)
            {
                _collegeTimeAppService.Delete(id);

                return Json(Ok());
            }

            return Json(Conflict());


            #endregion
        }

        //public async Task<IActionResult> SaveExcel()
        //{
        //    string sFileName = @"C:\Users\Caio's PC\Desktop\CollegesFees.xlsx";

        //    FileInfo file = new FileInfo(Path.Combine(sFileName));

        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var user = _applicationUserAppService.GetById(userId);

        //    var linhaErro = 1;

        //    try
        //    {
        //        using (ExcelPackage package = new ExcelPackage(file))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[3];

        //            int rowCount = worksheet.Dimension.Rows;
        //            int colCount = worksheet.Dimension.Columns;

        //            var lastCollege = string.Empty;

        //            for (int linha = 2; linha <= rowCount; linha++)
        //            {
        //                linhaErro = linha;
        //                CollegeViewModel college = new CollegeViewModel();

        //                if (lastCollege == worksheet.Cells[linha, 1].Value.ToString())
        //                    continue;

        //                college.Name = worksheet.Cells[linha, 1].Value.ToString();
        //                lastCollege = college.Name;

        //                college.Address = "Dublin";
        //                college.City = worksheet.Cells[linha, 3].Value.ToString();
        //                college.Country = "Ireland";
        //                college.PhoneNumber = "353";
        //                college.ContactName = "NCC";
        //                college.Email = "NCC";
        //                college.EnviromentId = user.EnvironmentId;

        //                college = _collegeAppService.Add(user.EnvironmentId, college);

        //                college.CollegeTimeViewModel = new System.Collections.Generic.List<CollegeTimeViewModel>();
        //                if (worksheet.Cells[linha, 2].Value.ToString() == "Morning")
        //                {
        //                    CollegeTimeViewModel time = new CollegeTimeViewModel();

        //                    time.StartTime = TimeSpan.Parse("09:00");
        //                    time.FinishTime = TimeSpan.Parse("12:20");
        //                    time.DaysOfWeek = 5;
        //                    time.GrossPrice = Convert.ToDecimal(worksheet.Cells[linha, 4].Value.ToString());
        //                    time.Period = PeriodClass.Morning;
        //                    time.BookPrice = worksheet.Cells[linha, 6].Value != null ? Convert.ToDecimal(worksheet.Cells[linha, 6].Value.ToString()) : 0;
        //                    time.ExamPrice = worksheet.Cells[linha, 7].Value != null ? Convert.ToDecimal(worksheet.Cells[linha, 7].Value.ToString()) : 0;
        //                    time.InsurancePrice = worksheet.Cells[linha, 8].Value != null ? Convert.ToDecimal(worksheet.Cells[linha, 8].Value.ToString()) : 0;
        //                    time.AccomodationPrice = worksheet.Cells[linha, 9].Value != null ? Convert.ToDecimal(worksheet.Cells[linha, 9].Value.ToString()) : 0;
        //                    time.PercentagePrice = worksheet.Cells[linha, 11].Value != null ? Convert.ToInt32(worksheet.Cells[linha, 11].Value.ToString()) : 0;
        //                    time.NetPrice = worksheet.Cells[linha, 12].Value != null ? Convert.ToDecimal(worksheet.Cells[linha, 12].Value.ToString()) : 0;
        //                    time.Price = worksheet.Cells[linha, 13].Value != null ? Convert.ToDecimal(worksheet.Cells[linha, 13].Value.ToString()) : 0;
        //                    time.RenewPrice = worksheet.Cells[linha, 13].Value != null ? Convert.ToDecimal(worksheet.Cells[linha, 13].Value.ToString()) : 0;
        //                    time.Note = worksheet.Cells[linha, 17].Value != null ? Convert.ToString(worksheet.Cells[linha, 17].Value.ToString()) : "DONT HAVE";

        //                    college.CollegeTimeViewModel.Add(time);

        //                    time.College = college;
        //                    time.CollegeId = college.Id;

        //                    _collegeTimeAppService.Add(time);

        //                }

        //                if (lastCollege == worksheet.Cells[linha + 1, 1].Value.ToString())
        //                {
        //                    var linhaabaixo = linha + 1;

        //                    CollegeTimeViewModel time2 = new CollegeTimeViewModel();

        //                    time2.StartTime = TimeSpan.Parse("13:45");
        //                    time2.FinishTime = TimeSpan.Parse("17:00");
        //                    time2.DaysOfWeek = 5;
        //                    time2.GrossPrice = Convert.ToDecimal(worksheet.Cells[linhaabaixo, 4].Value.ToString());
        //                    time2.Period = PeriodClass.Afternoon;
        //                    //Enrol = ""
        //                    time2.BookPrice = worksheet.Cells[linhaabaixo, 6].Value != null ? Convert.ToDecimal(worksheet.Cells[linhaabaixo, 6].Value.ToString()) : 0;
        //                    time2.ExamPrice = worksheet.Cells[linhaabaixo, 7].Value != null ? Convert.ToDecimal(worksheet.Cells[linhaabaixo, 7].Value.ToString()) : 0;
        //                    time2.InsurancePrice = worksheet.Cells[linhaabaixo, 8].Value != null ? Convert.ToDecimal(worksheet.Cells[linhaabaixo, 8].Value.ToString()) : 0;
        //                    time2.AccomodationPrice = worksheet.Cells[linhaabaixo, 9].Value != null ? Convert.ToDecimal(worksheet.Cells[linhaabaixo, 9].Value.ToString()) : 0;
        //                    time2.PercentagePrice = worksheet.Cells[linhaabaixo, 11].Value != null ? Convert.ToInt32(worksheet.Cells[linhaabaixo, 11].Value.ToString()) : 0;
        //                    time2.NetPrice = worksheet.Cells[linhaabaixo, 12].Value != null ? Convert.ToDecimal(worksheet.Cells[linhaabaixo, 12].Value.ToString()) : 0;
        //                    time2.Price = worksheet.Cells[linhaabaixo, 13].Value != null ? Convert.ToDecimal(worksheet.Cells[linhaabaixo, 13].Value.ToString()) : 0;
        //                    time2.RenewPrice = worksheet.Cells[linhaabaixo, 13].Value != null ? Convert.ToDecimal(worksheet.Cells[linhaabaixo, 13].Value.ToString()) : 0;
        //                    time2.Note = worksheet.Cells[linhaabaixo, 17].Value != null ? Convert.ToString(worksheet.Cells[linhaabaixo, 17].Value.ToString()) : "DONT HAVE";

        //                    time2.College = college;
        //                    time2.CollegeId = college.Id;

        //                    _collegeTimeAppService.Add(time2);
        //                }
        //            }
        //        }

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}