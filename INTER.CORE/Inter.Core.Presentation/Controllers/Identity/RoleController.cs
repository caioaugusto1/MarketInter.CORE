using Inter.Core.App.Intefaces.Identity;
using Inter.Core.App.ViewModel.Identity;
using Inter.Core.Presentation.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers.Identity
{
    [Authorize(Roles = "Admin, Manager")]
    public class RoleController : BaseController
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

        public RoleController(IApplicationUserAppService applicationUserAppService, RoleManager<IdentityRole> roleManager, UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _applicationUserAppService = applicationUserAppService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUserViewModel> userManager)
        //{
        //    _roleManager = roleManager;
        //    _userManager = userManager;
        //}

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.Where(x => x.Name != "Admin");

            return View(roles);
        }

        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<ApplicationUserViewModel> members = new List<ApplicationUserViewModel>();
            List<ApplicationUserViewModel> nonMember = new List<ApplicationUserViewModel>();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var getUser = _applicationUserAppService.GetById(userId);

            foreach (ApplicationUserViewModel user in _applicationUserAppService.GetAll(getUser.EnvironmentId))
            {
                var list = await _applicationUserAppService.IsInRoleAsync(user, role.Name)
                    ? members
                    : nonMember;
                list.Add(user);
            }

            return View(new EditRoleViewModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMember
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModifyRoleViewModel modifyRole)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                IdentityRole role = await _roleManager.FindByIdAsync(modifyRole.RoleId);
                role.Name = modifyRole.RoleName;
                result = await _roleManager.UpdateAsync(role);
                //if (!result.Succeeded)
                //{
                //    AddErrors(result);
                //}

                foreach (string userId in modifyRole.IdsToAdd ?? new string[] { })
                {
                    //ApplicationUserViewModel user = _applicationUserAppService.GetById(userId);
                    var user = _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user.Result, modifyRole.RoleName);

                        //if (!result.Succeeded)
                        //{
                        //    AddErrors(result);
                        //}
                    }
                }

                foreach (string userId in modifyRole.IdsToRemove ?? new string[] { })
                {
                    //ApplicationUserViewModel user = _applicationUserAppService.GetById(userId);

                    var user = _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        //result = await _applicationUserAppService.RemoveFromRoleAsync(user, modifyRole.RoleName);

                        result = await _userManager.RemoveFromRoleAsync(user.Result, modifyRole.RoleName);

                        if (!result.Succeeded)
                        {
                            //AddErrors(result);
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(modifyRole.RoleId);
        }
    }
}