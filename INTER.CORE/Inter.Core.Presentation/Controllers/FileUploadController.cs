using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    public class FileUploadController : BaseController
    {
        private readonly IStudentFileUploadAppService _studentFileUploadAppService;

        public FileUploadController(IStudentFileUploadAppService studentFileUploadAppService)
        {
            _studentFileUploadAppService = studentFileUploadAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            string fileName = Guid.NewGuid().ToString() + ".pdf";

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<IActionResult> Download(string fileName)
        {
            if (fileName == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return Json(Ok());

            //return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        [HttpGet]
        public async Task<IActionResult> GetModalStudentUploadFile()
        {
            return PartialView("~/Views/FileUpload/_partial/_modal_student_upload_file.cshtml");
        }

        [HttpPost]
        public async Task<JsonResult> GetModalStudentUploadFile(StudentFileUploadViewModel fileUploadViewModel)
        {
            var fileName = await UploadFile(fileUploadViewModel.File);

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                fileUploadViewModel.FileName = fileName;

                _studentFileUploadAppService.Add(fileUploadViewModel);
                return Json(Ok());
            }

            return Json(Conflict());
        }

        public async Task<IActionResult> GetStudentsFileDetails(int studentId)
        {
            if (studentId == 0)
                return Json(NotFound());

            return PartialView("~/Views/FileUpload/_partial/_get_students_file_details.cshtml", _studentFileUploadAppService.GetAllByStudentId(studentId));
        }
    }
}