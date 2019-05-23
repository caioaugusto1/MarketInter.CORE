using System.Collections.Generic;

namespace Inter.Core.Domain.Entities
{
    public class College
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        
        public virtual List<CollegeTime> Time { get; set; }

        public virtual Environment Environment { get; set; }


        public class CollegeTime
        {
            public int Id { get; set; }

            public string Time { get; set; }

            public int TimeForWeek { get; set; }

            public string Period { get; set; }

            public virtual College College { get; set; }
        }
    }
}
