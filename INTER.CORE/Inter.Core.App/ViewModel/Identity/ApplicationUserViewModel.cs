using Inter.Core.App.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Inter.Core.Presentation.Models.Identity
{
    public class ApplicationUserViewModel : IdentityUser
    {
        public int EnvironmentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }
    }
}
