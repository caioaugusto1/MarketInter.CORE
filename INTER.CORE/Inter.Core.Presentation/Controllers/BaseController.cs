using Inter.Core.Domain.Entities;
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
        
        public async Task<ApplicationUser> GetUser(UserManager<ApplicationUser> _userManager)
        {
            var user = await _userManager.Users.Include(x => x.Environment).FirstOrDefaultAsync(x => x.Id == GetUserId());

            return user;
        }
    }
}