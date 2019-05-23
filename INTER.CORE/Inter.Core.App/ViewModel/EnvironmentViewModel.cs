using Inter.Core.Presentation.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class EnvironmentViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Company { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public virtual List<ApplicationUserViewModel> ApplicationUserViewModel { get; set; }

        public virtual List<StudentViewModel> StudentViewModel { get; set; }

        public virtual List<AccomodationViewModel> AccomodationViewModel { get; set; }

        public virtual List<AdvisorViewModel> AdvisorViewModel { get; set; }

        public virtual List<CollegeViewModel> CollegeViewModel { get; set; }
        
        public virtual List<CulturalExchangeViewModel> CulturalExchangeViewModel { get; set; }
    }
}
