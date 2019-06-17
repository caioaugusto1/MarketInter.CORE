using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EnvironmentController : Controller
    {
        private readonly IEnvironmentAppService _environmentAppService;

        public EnvironmentController(IEnvironmentAppService environmentApp)
        {
            _environmentAppService = environmentApp;
        }

        // GET: Environment
        public async Task<IActionResult> Index()
        {
            return View(_environmentAppService.GetAll());
        }

        // GET: Environment/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var environmentViewModel = _environmentAppService.GetById(id);

            if (environmentViewModel == null)
                return NotFound();

            return View(environmentViewModel);
        }

        // GET: Environment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Environment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnvironmentViewModel environmentViewModel)
        {
            if (ModelState.IsValid)
            {
                _environmentAppService.Add(environmentViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(environmentViewModel);
        }

        // GET: Environment/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var environmentViewModel = _environmentAppService.GetById(id);

            if (environmentViewModel == null)
                return NotFound();

            return View(environmentViewModel);
        }

        // POST: Environment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EnvironmentViewModel environmentViewModel)
        {
            if (id != environmentViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _environmentAppService.Update(environmentViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(environmentViewModel);
        }

        // GET: Environment/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var environmentViewModel = _environmentAppService.GetById(id);

            if (environmentViewModel == null)
                return NotFound();

            return View(environmentViewModel);
        }

        // POST: Environment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var environmentViewModel = _environmentAppService.GetById(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool EnvironmentViewModelExists(int id)
        //{
        //    return _context.Environment.Any(e => e.Id == id);
        //}
    }
}
