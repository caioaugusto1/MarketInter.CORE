using Inter.Core.App.ViewModel.Identity;
using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Controllers.Identity
{
    [Authorize(Roles = "Admin, Manager")]
    public class RoleController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.Where(x => x.Name != "Admin");

            return View(roles);
        }

        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMember = new List<ApplicationUser>();

            var getUser = await GetUser(_userManager);

            foreach (ApplicationUser user in _userManager.Users.Where(x => x.EnvironmentId == getUser.EnvironmentId))
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)
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
                    ApplicationUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, modifyRole.RoleName);
                        //if (!result.Succeeded)
                        //{
                        //    AddErrors(result);
                        //}
                    }
                }

                foreach (string userId in modifyRole.IdsToRemove ?? new string[] { })
                {
                    ApplicationUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, modifyRole.RoleName);
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