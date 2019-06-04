using System.Collections.Generic;

namespace Inter.Core.Domain.Entities
{
    public class College
    {
        public College()
        {
            TimeCollege = new List<CollegeTime>();
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

        public virtual List<CollegeTime> TimeCollege { get; set; }

        public virtual SystemEnvironment Environment { get; set; }


        public class CollegeTime
        {
            public int Id { get; set; }

            public string Time { get; set; }

            public int TimeForWeek { get; set; }

            public string Period { get; set; }

            public decimal TotalPrice { get; set; }

            public decimal BookPrice { get; set; }

            public decimal ExamPrice { get; set; }

            public decimal InsurancePrice { get; set; }

            public decimal AccomodationPrice { get; set; }

            public virtual College College { get; set; }
        }
    }
}
