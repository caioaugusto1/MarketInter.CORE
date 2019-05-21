using Microsoft.AspNetCore.Identity;

namespace Inter.Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int EnviromentId { get; set; }

        public virtual Environment Environment { get; set; }
    }
}
