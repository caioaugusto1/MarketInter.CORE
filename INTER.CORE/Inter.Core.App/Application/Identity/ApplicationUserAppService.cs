using AutoMapper;
using Inter.Core.App.Intefaces.Identity;
using Inter.Core.Domain.Entities;
using Inter.Core.Presentation.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Core.App.ViewModel.Identity
{
    public class ApplicationUserAppService : IApplicationUserAppService
    {
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserAppService(IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUserViewModel user, string roleName)
        {
            ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(user);

            var result = await _userManager.AddToRoleAsync(applicationUser, roleName);

            return result;
        }

        public List<ApplicationUserViewModel> GetAll(Guid environmentId)
        {
            return _mapper.Map<List<ApplicationUserViewModel>>(_userManager.Users.Where(x => x.EnvironmentId == environmentId));
        }

        public ApplicationUserViewModel GetById(string id)
        {
            var user = _userManager.FindByIdAsync(id);

            if (user != null)
                return _mapper.Map<ApplicationUserViewModel>(user.Result);

            return null;
        }

        public async Task<bool> IsInRoleAsync(ApplicationUserViewModel user, string role)
        {
            var userEntity = _mapper.Map<ApplicationUser>(user);

            return await _userManager.IsInRoleAsync(userEntity, role);
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(ApplicationUserViewModel user, string role)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(user);

            return await _userManager.RemoveFromRoleAsync(applicationUser, role);
        }
    }
}
