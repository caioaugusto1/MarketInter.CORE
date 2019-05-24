using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    public class CollegeController : Controller
    {
        private readonly ICollegeAppService _collegeAppService;

        public CollegeController(ICollegeAppService collegeAppService)
        {
            _collegeAppService = collegeAppService;
        }

        // GET: College
        public async Task<IActionResult> Index()
        {
            return View(_collegeAppService.GetAll());
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
        public async Task<IActionResult> Create([Bind("Id,Name,Address,City,Country,EnviromentId")] CollegeViewModel collegeViewModel)
        {
            if (ModelState.IsValid)
            {
                _collegeAppService.Add(collegeViewModel);

                return RedirectToAction(nameof(Index));
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
    }
}
