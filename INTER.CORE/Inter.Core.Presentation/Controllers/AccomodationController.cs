using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize(Roles = "Admin, Manager, Accomodation")]
    public class AccomodationController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccomodationAppService _accomodationAppService;

        public AccomodationController(UserManager<ApplicationUser> userManager,
            IAccomodationAppService accomodationAppService)
        {
            _userManager = userManager;
            _accomodationAppService = accomodationAppService;
        }

        // GET: Accomodation
        public async Task<IActionResult> Index()
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            return View(_accomodationAppService.GetAll(user.EnvironmentId));
        }

        // GET: Accomodation/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var accomodationViewModel = _accomodationAppService.GetById(id);

            if (accomodationViewModel == null)
                return NotFound();

            return View(accomodationViewModel);
        }

        // GET: Accomodation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accomodation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccomodationViewModel accomodationViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await GetUser(_userManager);

                if (user != null && user.Environment != null)
                    _accomodationAppService.Add(user.EnvironmentId, accomodationViewModel);

                return RedirectToAction("Index", "Accomodation");
            }

            return View(accomodationViewModel);
        }

        // GET: Accomodation/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var accomodationViewModel = _accomodationAppService.GetById(id);

            if (accomodationViewModel == null)
                return NotFound();

            return View(accomodationViewModel);
        }

        // POST: Accomodation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AccomodationViewModel accomodationViewModel)
        {
            if (id != accomodationViewModel.Id || id == Guid.Empty)
                return NotFound();

            if (ModelState.IsValid)
            {
                _accomodationAppService.Update(accomodationViewModel);

                return RedirectToAction("Index", "Accomodation");
            }

            return View(accomodationViewModel);
        }

        // GET: Accomodation/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var accomodationViewModel = _accomodationAppService.GetById(id);

            if (accomodationViewModel == null)
                return NotFound();

            return View(accomodationViewModel);
        }

        // POST: Accomodation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var accomodationViewModel = _accomodationAppService.GetById(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool AccomodationViewModelExists(int id)
        //{
        //    return _context.AccomodationViewModel.Any(e => e.Id == id);
        //}
    }
}
