using Inter.Core.App.Enumerables;
using Inter.Core.App.Intefaces;
using Inter.Core.App.Intefaces.Identity;
using Inter.Core.App.ViewModel;
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
    //[Authorize(Roles = "Admin, Manager, Student")]
    public class StudentController : BaseController
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IStudentAppService _studentAppService;
        private readonly IEnvironmentAppService _environmentAppService;

        public StudentController(IStudentAppService studentAppService, IEnvironmentAppService environmentAppService,
            IApplicationUserAppService applicationUserAppService)
        {
            _studentAppService = studentAppService;
            _environmentAppService = environmentAppService;
            _applicationUserAppService = applicationUserAppService;

        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            var studentsVM = _studentAppService.GetAll(user.EnvironmentId);
            return View(studentsVM);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            var studentViewModel = _studentAppService.GetById(user.EnvironmentId, id);

            if (studentViewModel == null)
                return NotFound();

            return View(studentViewModel);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            ViewBag.EnvironmentId = user.EnvironmentId;

            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _applicationUserAppService.GetById(userId);

                if (user != null)
                    studentViewModel = _studentAppService.Add(user.EnvironmentId, studentViewModel);

                if (!studentViewModel.ValidationResult.Any())
                    return Json(new { studentName = studentViewModel.FullName, statusCode = HttpStatusCode.OK });

                return Json(Conflict(studentViewModel.ValidationResult));
            }

            return Json(Conflict());
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null && user.EnvironmentViewModel == null)
                return NotFound();

            StudentViewModel studentViewModel = _studentAppService.GetById(user.EnvironmentId, id);

            if (studentViewModel == null)
                return NotFound();

            return View(studentViewModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _applicationUserAppService.GetById(userId);

                if (user == null)
                    return NotFound();

                _studentAppService.Update(user.EnvironmentId, studentViewModel);

                return RedirectToAction("Index", "Student");
            }

            //ViewData["CollegeId"] = new SelectList(_context.Set<CollegeViewModel>(), "Id", "Id", studentViewModel.CollegeId);
            return View(studentViewModel);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _applicationUserAppService.GetById(userId);

            if (user == null)
                return NotFound();

            var studentViewModel = _studentAppService.GetById(user.EnvironmentId, id);

            if (studentViewModel == null)
                return NotFound();

            return View(studentViewModel);
        }

        public async Task<JsonResult> DeleteConfirmed(Guid studentId)
        {
            if (studentId == Guid.Empty)
                return Json(NotFound());

            _studentAppService.Delete(studentId);

            return Json(Ok());
        }

        //public async Task<IActionResult> ReadNames()
        //{
        //    string sFileName = @"";

        //    FileInfo file = new FileInfo(Path.Combine(sFileName));

        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var user = _applicationUserAppService.GetById(userId);

        //    try
        //    {
        //        using (ExcelPackage package = new ExcelPackage(file))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

        //            int rowCount = worksheet.Dimension.Rows;
        //            int ColCount = worksheet.Dimension.Columns;

        //            for (int row = 2; row <= rowCount; row++)
        //            {
        //                Gender gender = Gender.Female;
        //                if (worksheet.Cells[row, 4].Value.ToString() == "Male")
        //                {
        //                    gender = Gender.Male;
        //                }

        //                StudentViewModel student = new StudentViewModel();

        //                student.CustomerId = worksheet.Cells[row, 1].Value.ToString();
        //                student.FullName = worksheet.Cells[row, 2].Value.ToString();
        //                student.Email = worksheet.Cells[row, 3].Value.ToString();
        //                student.Gender = gender;
        //                student.MobileNumber = worksheet.Cells[row, 5].Value.ToString();
        //                student.DateOfBirthday = Convert.ToDateTime(worksheet.Cells[row, 6].Value.ToString());
        //                student.Address = worksheet.Cells[row, 7].Value.ToString();
        //                student.City = worksheet.Cells[row, 8].Value.ToString();
        //                student.Country = worksheet.Cells[row, 9].Value.ToString();
        //                student.Nationality = worksheet.Cells[row, 10].Value.ToString();
        //                student.PassportDateOfIssue = DateTime.MinValue;
        //                student.PassportNumber = worksheet.Cells[row, 12].Value.ToString();
        //                student.PassportDateOfExpiry = DateTime.MinValue;
        //                student.EnviromentId = user.EnvironmentId;

        //                _studentAppService.Add(student.EnviromentId, student);
        //            }
        //        };
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return Ok();
        //}

    }
}
