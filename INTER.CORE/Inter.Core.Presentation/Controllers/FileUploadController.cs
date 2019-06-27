using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Presentation.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    //[Authorize(Roles = "Admin, Users")]
    public class FileUploadController : Controller
    {
        private readonly IOptions<AppSettings> _appSetttings;
        private readonly IFileUploadAppService _fileUploadAppService;
        private readonly ICulturalExchangeFileUploadAppService _culturalExchangeFileUploadAppService;

        public FileUploadController(
            IOptions<AppSettings> appSetttings,
            ICulturalExchangeFileUploadAppService culturalExchangeAppService,
            IFileUploadAppService fileUploadAppService)
        {
            _appSetttings = appSetttings;
            _fileUploadAppService = fileUploadAppService;
            _culturalExchangeFileUploadAppService = culturalExchangeAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Download(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return Content("filename not present");

            var path = Path.Combine(_appSetttings.Value.UploadFilePath, fileName);

            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/pdf");
        }

        public async Task<IActionResult> CulturalExchangeDeleteFile(Guid id, string fileName)
        {
            try
            {
                if (id != Guid.Empty && !string.IsNullOrWhiteSpace(fileName))
                {
                    _culturalExchangeFileUploadAppService.Delete(id);
                    _fileUploadAppService.Delete(_appSetttings.Value.UploadFilePath, fileName);

                    return Json(Ok());
                }

                return Json(Conflict());
            }
            catch (Exception ex)
            {
                return Json(BadRequest());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetModalCulturalExchangeUploadFile(Guid culturalExchangeId)
        {
            CulturalExchangeFileUploadViewModel culturalExchangeFileUploadViewModel = new CulturalExchangeFileUploadViewModel();
            culturalExchangeFileUploadViewModel.CulturalExchangeId = culturalExchangeId;

            return PartialView("~/Views/FileUpload/_partial/_modal_culturalExchange_upload_file.cshtml", culturalExchangeFileUploadViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> PostModalCulturalExchangeUploadFile(CulturalExchangeFileUploadViewModel fileUploadViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fileUploadViewModel.FileName = await _fileUploadAppService.Upload(_appSetttings.Value.UploadFilePath, null, fileUploadViewModel.File);

                    if (!string.IsNullOrWhiteSpace(fileUploadViewModel.FileName))
                    {
                        _culturalExchangeFileUploadAppService.Add(fileUploadViewModel);
                        return Json(Ok());
                    }
                }

                return Json(Conflict());
            }
            catch (Exception ex)
            {
                _fileUploadAppService.Delete(_appSetttings.Value.UploadFilePath, fileUploadViewModel.FileName);

                return Json(BadRequest());
            }
        }

    }
}
