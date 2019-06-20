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
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserAppService(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUserViewModel user, string roleName)
        {
            ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(user);

            return await _userManager.AddToRoleAsync(applicationUser, roleName);
        }

        public ApplicationUser Converter(ApplicationUserViewModel t)
        {
            return _mapper.Map<ApplicationUser>(t);
        }

        public List<ApplicationUserViewModel> GetAll(Guid environmentId)
        {
            return _mapper.Map<List<ApplicationUserViewModel>>(_userManager.Users.Where(x => x.EnvironmentId == environmentId));
        }

        public ApplicationUserViewModel GetById(string id)
        {
            return _mapper.Map<ApplicationUserViewModel>(_userManager.Users.FirstOrDefault(x => x.Id == id));
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
