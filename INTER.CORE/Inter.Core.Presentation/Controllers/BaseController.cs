using Microsoft.AspNetCore.Mvc;

namespace Inter.Core.Presentation.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}