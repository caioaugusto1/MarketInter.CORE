using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Inter.Core.App.ViewModel.Identity
{
    public class EditRoleViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}
