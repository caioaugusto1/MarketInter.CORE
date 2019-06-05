using Microsoft.AspNetCore.Identity;

namespace Inter.Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int EnvironmentId { get; set; }
        public virtual SystemEnvironment Environment { get; set; }
    }
}
