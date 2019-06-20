using Inter.Core.App.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;

namespace Inter.Core.Presentation.Models.Identity
{
    public class ApplicationUserViewModel : IdentityUser
    {
        public Guid EnvironmentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }
    }
}
