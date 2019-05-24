using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentService;
        private readonly IEnvironmentAppService _environmentAppService;

        private readonly UserManager<ApplicationUser> _userManager;

        //private readonly ApplicationDbContext _context;

        public StudentController(IStudentAppService studentAppService, IEnvironmentAppService environmentAppService)
        {
            _studentService = studentAppService;
            _environmentAppService = environmentAppService;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var studentsVM = _studentService.GetAll();
            return View(studentsVM);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
                return NotFound();

            var studentViewModel = _studentService.GetById(id);

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
                _studentService.Add(studentViewModel);

                return RedirectToAction(nameof(Index));
            }

            //ViewData["CollegeId"] = new SelectList(_context.Set<CollegeViewModel>(), "Id", "Id", studentViewModel.CollegeId);
            return View(studentViewModel);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id.Value == 0)
                return NotFound();

            var studentViewModel = _studentService.GetById(id.Value);

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
                _studentService.Update(studentViewModel);
                
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

            var studentViewModel = _studentService.GetById(id.Value);

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
