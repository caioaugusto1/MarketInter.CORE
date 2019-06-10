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
        private readonly ICulturalExchangeFileUploadAppService _studentFileUploadAppService;

        public FileUploadController(ICulturalExchangeFileUploadAppService studentFileUploadAppService)
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

            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/pdf");
        }

        [HttpGet]
        public async Task<IActionResult> GetModalCulturalExchangeUploadFile()
        {
            return PartialView("~/Views/FileUpload/_partial/_modal_culturalExchange_upload_file.cshtml");
        }

        [HttpPost]
        public async Task<JsonResult> PostModalStudentUploadFile(CulturalExchangeFileUploadViewModel fileUploadViewModel)
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
    }
}