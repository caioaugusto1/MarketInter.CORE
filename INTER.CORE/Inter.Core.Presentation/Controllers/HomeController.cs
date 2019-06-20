using Inter.Core.App.Intefaces.Identity;
using Inter.Core.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

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
    }
}
