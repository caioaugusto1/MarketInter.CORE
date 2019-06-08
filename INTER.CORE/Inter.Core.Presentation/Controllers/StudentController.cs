using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
                    _studentAppService.Add(user.Environment.Id, studentViewModel);

                return Json(new { studentName = studentViewModel.FullName, HttpStatusCode.OK });
            }

            return Json(Conflict());
        }

        //[HttpPost]
        //public async Task<IActionResult> ImageInclude(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);

        //    // full path to file in temp location
        //    string filePath = @"C:\Users\Caio's PC\Documents\";

        //    if (!Directory.Exists(filePath))
        //        Directory.CreateDirectory(filePath);

        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            using (FileStream fs = System.IO.File.Create(filePath))
        //            {
        //                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
        //                // Add some information to the file.
        //                fs.Write(info, 0, info.Length);
        //            }
        //        }
        //    }

        //    // process uploaded files
        //    // Don't rely on or trust the FileName property without validation.

        //    return Ok(new { count = files.Count, size, filePath });
        //}


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
