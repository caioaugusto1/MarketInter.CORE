using Inter.Core.Domain.Entities;
using Inter.Core.Presentation.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Inter.Core.App.ViewModel.Identity
{
    public class EditRoleViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUserViewModel> Members { get; set; }
        public IEnumerable<ApplicationUserViewModel> NonMembers { get; set; }
    }
}
