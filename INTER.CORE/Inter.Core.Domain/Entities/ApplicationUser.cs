using Microsoft.AspNetCore.Identity;
using System;

namespace Inter.Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Guid EnvironmentId { get; set; }
        public virtual SystemEnvironment Environment { get; set; }
    }
}
