using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin, Manager, Student")]
    public class StudentController : BaseController
    {
        private readonly IStudentAppService _studentAppService;
        private readonly IEnvironmentAppService _environmentAppService;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(IStudentAppService studentAppService, IEnvironmentAppService environmentAppService,
            UserManager<ApplicationUser> userManager)
        {
            _studentAppService = studentAppService;
            _environmentAppService = environmentAppService;
            _userManager = userManager;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var user = await GetUser(_userManager);

            if (user == null || user.Environment == null)
                return NotFound();

            var studentsVM = _studentAppService.GetAll(user.Environment.Id);
            return View(studentsVM);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
                return NotFound();

            var user = await GetUser(_userManager);

            if (user == null && user.Environment == null)
                return NotFound();

            var studentViewModel = _studentAppService.GetById(user.Environment.Id, id);

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
                var user = await GetUser(_userManager);

                if (user != null && user.Environment != null)
                    studentViewModel = _studentAppService.Add(user.Environment.Id, studentViewModel);

                if (!studentViewModel.ValidationResult.Any())
                    return Json(new { studentName = studentViewModel.FullName, statusCode = HttpStatusCode.OK });
                
                return Json(Conflict(studentViewModel.ValidationResult));
            }

            return Json(Conflict());
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id.Value == 0)
                return NotFound();

            var user = await GetUser(_userManager);

            if (user == null && user.Environment == null)
                return NotFound();

            StudentViewModel studentViewModel = _studentAppService.GetById(user.Environment.Id, id.Value);

            if (studentViewModel == null)
                return NotFound();

            return View(studentViewModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentViewModel studentViewModel)
        {
            if (id != studentViewModel.Id || id == 0)
                return NotFound();

            if (ModelState.IsValid)
            {
                var user = await GetUser(_userManager);

                if (user == null && user.Environment == null)
                    return NotFound();

                _studentAppService.Update(user.Environment.Id, studentViewModel);

                return RedirectToAction(nameof(Index));
            }

            //ViewData["CollegeId"] = new SelectList(_context.Set<CollegeViewModel>(), "Id", "Id", studentViewModel.CollegeId);
            return View(studentViewModel);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id.Value == 0)
                return NotFound();

            var user = await GetUser(_userManager);

            if (user == null && user.Environment == null)
                return NotFound();

            var studentViewModel = _studentAppService.GetById(user.Environment.Id, id.Value);

            if (studentViewModel == null)
                return NotFound();

            return View(studentViewModel);
        }

        public async Task<JsonResult> DeleteConfirmed(int studentId)
        {
            if (studentId == 0)
                return Json(NotFound());

            _studentAppService.Delete(studentId);

            return Json(Ok());
        }
    }
}
