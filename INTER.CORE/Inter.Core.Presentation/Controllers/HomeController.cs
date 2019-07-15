using Inter.Core.App.Intefaces.Identity;
using Inter.Core.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.Diagnostics;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Inter.Core.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IApplicationUserAppService _applicationUserAppService;

        public HomeController(IApplicationUserAppService applicationUserAppService)
        {
            _applicationUserAppService = applicationUserAppService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var entity = _applicationUserAppService.GetById(userId);

            //ViewBag.RolesList = await _userManager.GetRolesAsync(user);

            return View(entity);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ReadExcel()
        {
            string sFileName = @"C:/Users/Caio's PC/Desktop/nodejsexcel/names.xlsx";

            FileInfo file = new FileInfo(Path.Combine(sFileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;
                bool bHeaderRow = true;
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= ColCount; col++)
                    {
                        if (bHeaderRow)
                        {
                            //sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                        }
                        else
                        {
                            //sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                        }
                    }
                    //sb.Append(Environment.NewLine);
                }
            };

            return Ok();
        }
    }
}
