using Inter.Core.Domain.Entities;
using Inter.Core.Presentation.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.App.Intefaces.Identity
{
    public interface IApplicationUserAppService
    {
        ApplicationUserViewModel GetById(string id);

        List<ApplicationUserViewModel> GetAll(Guid environmentId);

        Task<bool> IsInRoleAsync(ApplicationUserViewModel user, string role);

        Task<IdentityResult> RemoveFromRoleAsync(ApplicationUserViewModel user, string role);

        Task<IdentityResult> AddToRoleAsync(ApplicationUserViewModel user, string roleName);

        ApplicationUser Converter(ApplicationUserViewModel t);

    }
}
