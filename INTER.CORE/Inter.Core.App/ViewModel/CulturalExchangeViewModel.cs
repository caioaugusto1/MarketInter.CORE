﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class CulturalExchangeViewModel : BaseViewModel
    {
        public CulturalExchangeViewModel()
        {
            StudentViewModel = new StudentViewModel();
            CollegeViewModel = new CollegeViewModel();
            AccomodationViewModel = new AccomodationViewModel();
            EnvironmentViewModel = new EnvironmentViewModel();
            CollegeTimeViewModel = new CollegeTimeViewModel();
            CulturalExchangeFileUploadVM = new List<CulturalExchangeFileUploadViewModel>();
        }


        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student")]
        [DisplayName("Selected Student")]
        public virtual StudentViewModel StudentViewModel { get; set; }

        public int CollegeId { get; set; }

        [Required(ErrorMessage = "College")]
        [DisplayName("Selected College")]
        public virtual CollegeViewModel CollegeViewModel { get; set; }

        public int CollegeTimeId { get; set; }

        [Required(ErrorMessage = "College Time")]
        [DisplayName("Selected College Time")]
        public virtual CollegeTimeViewModel CollegeTimeViewModel { get; set; }

        public int AccomodationId { get; set; }

        [Required(ErrorMessage = "Accomodation")]
        [DisplayName("Selected Accomodation")]
        public virtual AccomodationViewModel AccomodationViewModel { get; set; }

        [Required(ErrorMessage = "QuantityDaysOfAccomodation")]
        [DisplayName("Quantity Days Of Accomodation")]
        public int QuantityDaysOfAccomodation { get; set; }

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

        [Required(ErrorMessage = "Company")]
        [MaxLength(7, ErrorMessage = "Max {0} caracteres")]
        [MinLength(4, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Company")]
        public string FlightNumber { get; set; }

        [DisplayName("College Payment")]
        public bool CollegePayment { get; set; }

        [Required(ErrorMessage = "Total Value")]
        [DisplayName("Total Value")]
        public decimal TotalValue { get; set; }

        public int EnviromentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }

        public virtual List<CulturalExchangeFileUploadViewModel> CulturalExchangeFileUploadVM { get; set; }

    }
}
