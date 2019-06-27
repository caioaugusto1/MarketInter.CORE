using Inter.Core.App.Intefaces;
using Inter.Core.App.Intefaces.Identity;
using Inter.Core.App.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin, Manager, Student")]
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
    }
}
