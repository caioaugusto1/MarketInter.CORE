﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inter.Core.Presentation.Data;
using Inter.Core.Presentation.Models;
using Inter.Core.Domain.ServiceInterface;

namespace Inter.Core.Presentation.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Student.Include(s => s.College);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentViewModel = await _context.Student
                .Include(s => s.College)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentViewModel == null)
            {
                return NotFound();
            }

            return View(studentViewModel);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["CollegeId"] = new SelectList(_context.Set<CollegeViewModel>(), "Id", "Id");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,CollegeId,FullName,Email,MobileNumber,DateOfBirthday,Address,City,Country,Nationality,PassaportNumber,EnviromentId")] StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollegeId"] = new SelectList(_context.Set<CollegeViewModel>(), "Id", "Id", studentViewModel.CollegeId);
            return View(studentViewModel);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentViewModel = await _context.Student.FindAsync(id);
            if (studentViewModel == null)
            {
                return NotFound();
            }
            ViewData["CollegeId"] = new SelectList(_context.Set<CollegeViewModel>(), "Id", "Id", studentViewModel.CollegeId);
            return View(studentViewModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,CollegeId,FullName,Email,MobileNumber,DateOfBirthday,Address,City,Country,Nationality,PassaportNumber,EnviromentId")] StudentViewModel studentViewModel)
        {
            if (id != studentViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentViewModelExists(studentViewModel.Id))
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
            ViewData["CollegeId"] = new SelectList(_context.Set<CollegeViewModel>(), "Id", "Id", studentViewModel.CollegeId);
            return View(studentViewModel);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentViewModel = await _context.Student
                .Include(s => s.College)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentViewModel == null)
            {
                return NotFound();
            }

            return View(studentViewModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentViewModel = await _context.Student.FindAsync(id);
            _context.Student.Remove(studentViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentViewModelExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}