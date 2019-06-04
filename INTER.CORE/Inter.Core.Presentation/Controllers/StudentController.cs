using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
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

            if (user == null && user.Environment == null)
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
        public async Task<IActionResult> Create(int id)
        {
            return Json(Conflict());
        }

        public async Task<JsonResult> OnCreate(StudentViewModel studentViewModel, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                //if (!files.Any())
                //    return Json(Conflict());

                //long size = files.Sum(f => f.Length);

                //var filePath = Path.Combine(Directory.GetCurrentDirectory());

                //foreach (var formFile in files)
                //{
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await formFile.CopyToAsync(stream);
                //    }
                //}

                var user = await GetUser(_userManager);

                if (user != null && user.Environment != null)
                    _studentAppService.Add(user.Environment.Id, studentViewModel);

                return Json(Ok());
            }

            return Json(Ok());
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
            if (id == null)
                return NotFound();

            var user = await GetUser(_userManager);

            if (user == null && user.Environment == null)
                return NotFound();

            var studentViewModel = _studentAppService.GetById(user.Environment.Id, id.Value);

            if (studentViewModel == null)
                return NotFound();

            return View(studentViewModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var studentViewModel = await _context.Student.FindAsync(id);
            //_context.Student.Remove(studentViewModel);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return NotFound();
        }

        //private bool StudentViewModelExists(int id)
        //{ 
        //    return _studentService.GetById(id);
        //}
    }
}
