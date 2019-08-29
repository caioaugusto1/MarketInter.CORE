using Inter.Core.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Entities
{
    public class College : EntityBase
    {
        public College()
        {
            CollegeTime = new List<CollegeTime>();
            Environment = new SystemEnvironment();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string ContactName { get; set; }

        public string Email { get; set; }

        public Guid DestinationId { get; set; }

        public Destination Destination { get; set; }

        public virtual List<CollegeTime> CollegeTime { get; set; }

    }
}
