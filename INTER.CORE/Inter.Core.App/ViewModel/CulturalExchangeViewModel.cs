using Inter.Core.App.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class CulturalExchangeViewModel : BaseViewModel
    {
        public CulturalExchangeViewModel()
        {
            //StudentViewModel = new StudentViewModel();
            //CollegeViewModel = new CollegeViewModel();
            //AccomodationViewModel = new AccomodationViewModel();
            //EnvironmentViewModel = new EnvironmentViewModel();
            //CollegeTimeViewModel = new CollegeTimeViewModel();
            //CulturalExchangeFileUploadVM = new List<CulturalExchangeFileUploadViewModel>();
        }

        [Required(ErrorMessage = "Student")]
        [DisplayName("Selected Student")]
        public Guid StudentId { get; set; }

        public virtual StudentViewModel StudentViewModel { get; set; }

        [Required(ErrorMessage = "College")]
        [DisplayName("Selected College")]
        public Guid CollegeId { get; set; }

        public virtual CollegeViewModel CollegeViewModel { get; set; }

        [Required(ErrorMessage = "College Time")]
        [DisplayName("Selected College Time")]
        public Guid CollegeTimeId { get; set; }

        public virtual CollegeTimeViewModel CollegeTimeViewModel { get; set; }

        [Required(ErrorMessage = "Accomodation")]
        [DisplayName("Selected Accomodation")]
        public Guid AccomodationId { get; set; }

        public virtual AccomodationViewModel AccomodationViewModel { get; set; }

        public int QuantityDaysOfAccomodation { get; set; }

        [Display(Name = "Start Accomodation*")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime, ErrorMessage = "Incorrect Format")]
        public DateTime StartAccomodation { get; set; }

        [Display(Name = "Finish Accomodation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime, ErrorMessage = "Incorrect Format")]
        public DateTime FinishAccomodation { get; set; }

        // After sprint, put class Insurance and crud create and edit insurance
        [DisplayName("INSUR?")]
        public bool INSUR { get; set; }

        [DisplayName("Transfer?")]
        public bool Transfer { get; set; }

        [DisplayName("Support?")]
        public bool Support { get; set; }

        [DisplayName("Kit?")]
        public bool Kit { get; set; }

        [DisplayName("Sim Card?")]
        public bool SimCard { get; set; }

        [Display(Name = "Date of Arrival")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime, ErrorMessage = "Incorrect Format")]
        [Required(ErrorMessage = "Arrival Date")]
        public DateTime ArrivalDateTime { get; set; }

        [Display(Name = "Date of Start class")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Incorrect Format")]
        [Required(ErrorMessage = "Date of Start class")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Company")]
        [MaxLength(7, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "FlightNumber")]
        [MaxLength(7, ErrorMessage = "Max {0} caracteres")]
        [MinLength(4, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("FlightNumber")]
        public string FlightNumber { get; set; }

        [DisplayName("College Payment")]
        public bool CollegePayment { get; set; } = false;

        [Required(ErrorMessage = "Total Value")]
        [DisplayName("Total Value")]
        public decimal TotalValue { get; set; }

        [Required(ErrorMessage = "Sales Man")]
        [DisplayName("Sales Value")]
        public string SalesMan { get; set; }

        public bool Available { get; set; }

        public virtual List<CulturalExchangeFileUploadViewModel> CulturalExchangeFileUploadVM { get; set; }

    }
}
