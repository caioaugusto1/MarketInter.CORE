using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Models.Identity
{
    public class ApplicationUserViewModel : IdentityUser
    {
        public int EnvironmentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }
    }
}
