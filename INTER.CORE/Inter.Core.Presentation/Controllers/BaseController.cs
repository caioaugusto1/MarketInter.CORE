using Inter.Core.Presentation.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers
{
    public class BaseController : Controller
    {
        private string GetUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        
        public async Task<ApplicationUserViewModel> GetUser(UserManager<ApplicationUserViewModel> _userManager)
        {
            var user = await _userManager.Users.Include(x => x.EnvironmentViewModel).FirstOrDefaultAsync(x => x.Id == GetUserId());

            return user;
        }
    }
}