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

        public string CustomerCode { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date Finish")]
        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }

        public virtual List<ApplicationUserViewModel> ApplicationUserViewModel { get; set; }

        public virtual List<StudentViewModel> StudentViewModel { get; set; }

        public virtual List<AccomodationViewModel> AccomodationViewModel { get; set; }

        public virtual List<AdvisorViewModel> AdvisorViewModel { get; set; }

        public virtual List<CollegeViewModel> CollegeViewModel { get; set; }
        
        public virtual List<CulturalExchangeViewModel> CulturalExchangeViewModel { get; set; }
    }
}
