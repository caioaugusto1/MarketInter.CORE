using System.Collections.Generic;

namespace Inter.Core.App.ViewModel
{
    public class CollegeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public virtual List<CollegeTimeViewModel> CollegeTimeViewModel { get; set; }

        public string EnviromentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }
        
    }

    public class CollegeTimeViewModel
    {
        public int Id { get; set; }

        public string Time { get; set; }

        public string TimeForWeek { get; set; }

        public string Period { get; set; }

        public int CollegeId { get; set; }

        public virtual CollegeViewModel College { get; set; }
    }

}
