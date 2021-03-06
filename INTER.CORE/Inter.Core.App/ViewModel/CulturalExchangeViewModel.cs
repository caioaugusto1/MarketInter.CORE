﻿using Inter.Core.App.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class CulturalExchangeViewModel : BaseViewModel
    {
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

        public string AccomodationId { get; set; }

        public virtual AccomodationViewModel AccomodationViewModel { get; set; }

        public int QuantityDaysOfAccomodation { get; set; }

        [Required(ErrorMessage = "Weeks Numbers")]
        public int WeekNumber { get; set; }

        [Display(Name = "Start Accomodation*")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? StartAccomodation { get; set; }

        [Display(Name = "Finish Accomodation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? FinishAccomodation { get; set; }

        [Display(Name = "Sale Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Incorrect Format")]
        public DateTime SaleDate { get; set; }

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

        [DisplayName("Renew Card?")]
        public bool Renew { get; set; }

        [DisplayName("Have fly ticket?")]
        public bool HaveFlyTicket { get; set; }

        [Display(Name = "Date of Arrival")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ArrivalDateTime { get; set; }

        [Display(Name = "Date of Start class")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Incorrect Format")]
        [Required(ErrorMessage = "Date of Start class")]
        public DateTime StartDate { get; set; }

        [DisplayName("Company")]
        public string Company { get; set; }

        [DisplayName("FlightNumber")]
        public string FlightNumber { get; set; }

        [DisplayName("College Payment")]
        public bool CollegePayment { get; set; } = false;

        [DisplayName("Our Accomodation")]
        public bool OurAccomodation { get; set; }

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
