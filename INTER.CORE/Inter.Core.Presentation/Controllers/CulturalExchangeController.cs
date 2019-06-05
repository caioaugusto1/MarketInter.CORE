using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    public class CulturalExchangeController : BaseController
    {
        private readonly ICulturalExchangeAppService _culturalExchangeAppService;
        private readonly IStudentAppService _studentAppService;
        private readonly ICollegeAppService _collegeAppService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CulturalExchangeController(ICulturalExchangeAppService culturalExchangeAppService,
            IStudentAppService studentAppService, ICollegeAppService collegeAppService, UserManager<ApplicationUser> userManager)
        {
            _culturalExchangeAppService = culturalExchangeAppService;
            _studentAppService = studentAppService;
            _collegeAppService = collegeAppService;
            _userManager = userManager;
        }

        // GET: CulturalExchange
        public async Task<IActionResult> Index()
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            return View(_culturalExchangeAppService.GetAll(user.EnvironmentId));
        }

        // GET: CulturalExchange/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
                return NotFound();

            var culturalExchangeViewModel = _culturalExchangeAppService.GetById(id);

            if (culturalExchangeViewModel == null)
                return NotFound();

            return View(culturalExchangeViewModel);
        }

        // GET: CulturalExchange/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetUser(_userManager);

            if (user == null)
                return NotFound();

            ViewBag.Students = _studentAppService.GetAll(user.EnvironmentId);
            ViewBag.Colleges = _collegeAppService.GetAll(user.EnvironmentId);
            ViewBag.EnvironmentId = user.EnvironmentId;

            return View();
        }

        // POST: CulturalExchange/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CulturalExchangeViewModel culturalExchangeViewModel)
        {
            if (ModelState.IsValid)
            {
                _culturalExchangeAppService.Add(culturalExchangeViewModel.EnviromentId, culturalExchangeViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(culturalExchangeViewModel);
        }

        // GET: CulturalExchange/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var culturalExchangeViewModel = _culturalExchangeAppService.GetById(id);

            if (culturalExchangeViewModel == null)
                return NotFound();

            return View(culturalExchangeViewModel);
        }

        // POST: CulturalExchange/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CulturalExchangeViewModel culturalExchangeViewModel)
        {
            if (id != culturalExchangeViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _culturalExchangeAppService.Update(culturalExchangeViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(culturalExchangeViewModel);
        }

        // GET: CulturalExchange/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var culturalExchangeViewModel = _culturalExchangeAppService.GetById(id);

            if (culturalExchangeViewModel == null)
                return NotFound();

            return View(culturalExchangeViewModel);
        }

        //// POST: CulturalExchange/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var culturalExchangeViewModel = await _context.CulturalExchangeViewModel.FindAsync(id);
        //    _context.CulturalExchangeViewModel.Remove(culturalExchangeViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CulturalExchangeViewModelExists(int id)
        //{
        //    return _context.CulturalExchangeViewModel.Any(e => e.Id == id);
        //}
    }
}
