using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
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
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
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
                _accomodationAppService.Add(accomodationViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(accomodationViewModel);
        }

        // GET: Accomodation/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
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
        public async Task<IActionResult> Edit(int id, AccomodationViewModel accomodationViewModel)
        {
            if (id != accomodationViewModel.Id || id == 0)
                return NotFound();

            if (ModelState.IsValid)
            {
                _accomodationAppService.Update(accomodationViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(accomodationViewModel);
        }

        // GET: Accomodation/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var accomodationViewModel = _accomodationAppService.GetById(id);

            if (accomodationViewModel == null)
                return NotFound();

            return View(accomodationViewModel);
        }

        // POST: Accomodation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
