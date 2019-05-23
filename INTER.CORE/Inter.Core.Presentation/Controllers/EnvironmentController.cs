using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inter.Core.App.ViewModel;
using Inter.Core.Presentation.Data;

namespace Inter.Core.Presentation.Controllers
{
    public class EnvironmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnvironmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Environment
        public async Task<IActionResult> Index()
        {
            return View(await _context.Environment.ToListAsync());
        }

        // GET: Environment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var environmentViewModel = await _context.Environment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (environmentViewModel == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create([Bind("Id,Company,StartDate,FinishDate")] EnvironmentViewModel environmentViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(environmentViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(environmentViewModel);
        }

        // GET: Environment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var environmentViewModel = await _context.Environment.FindAsync(id);
            if (environmentViewModel == null)
            {
                return NotFound();
            }
            return View(environmentViewModel);
        }

        // POST: Environment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Company,StartDate,FinishDate")] EnvironmentViewModel environmentViewModel)
        {
            if (id != environmentViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(environmentViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvironmentViewModelExists(environmentViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(environmentViewModel);
        }

        // GET: Environment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var environmentViewModel = await _context.Environment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (environmentViewModel == null)
            {
                return NotFound();
            }

            return View(environmentViewModel);
        }

        // POST: Environment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var environmentViewModel = await _context.Environment.FindAsync(id);
            _context.Environment.Remove(environmentViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvironmentViewModelExists(int id)
        {
            return _context.Environment.Any(e => e.Id == id);
        }
    }
}
