using System.Collections.Generic;

namespace Inter.Core.Domain.Entities
{
    public class College
    {
        public College()
        {
            CollegeTime = new List<CollegeTime>();
            Environment = new SystemEnvironment();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string ContactName { get; set; }

        public string Email { get; set; }

        public virtual List<CollegeTime> CollegeTime { get; set; }

        public int EnvironmentId { get; set; }

        public virtual SystemEnvironment Environment { get; set; }

    }
}
