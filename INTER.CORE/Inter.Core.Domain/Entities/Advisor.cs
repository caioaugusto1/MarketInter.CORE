using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Domain.Entities
{
    public class Advisor
    {
        public int AdvisorId { get; set; }

        public string Name { get; set; }
        
        public virtual SystemEnvironment Environment { get; set; }
    }
}
