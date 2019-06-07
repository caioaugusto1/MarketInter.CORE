using Inter.Core.App.Enumerables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class CollegeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name")]
        [MaxLength(100, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address")]
        [MaxLength(100, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City")]
        [MaxLength(100, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country")]
        [MaxLength(100, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone Number")]
        [MaxLength(100, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Contac tName")]
        [MaxLength(100, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Email")]
        [MaxLength(100, ErrorMessage = "Max {0} caracteres")]
        [EmailAddress(ErrorMessage = "Min um E-mail válido")]
        [DisplayName("Email")]
        public string Email { get; set; }

        public virtual List<CollegeTimeViewModel> CollegeTimeViewModel { get; set; }

        public string EnviromentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }

    }

    public class CollegeTimeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time, ErrorMessage = "Incorrect Time")]
        [Required(ErrorMessage = "Start Time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Finish Time")]
        [DataType(DataType.Time, ErrorMessage = "Incorrect Time")]
        [Required(ErrorMessage = "Finish Time")]
        public DateTime FinishTime { get; set; }

        [Display(Name = "Days of Week")]
        [Required(ErrorMessage = "Days of Week")]
        public int DaysOfWeek { get; set; }

        public string TimeForWeek { get; set; }

        [Display(Name = "Period Time")]
        [Required(ErrorMessage = "Period Time")]
        public PeriodClass Period { get; set; }

        [Display(Name = "Total Price")]
        [Required(ErrorMessage = "Total Price")]
        public decimal Price { get; set; }

        [Display(Name = "Book Price")]
        [Required(ErrorMessage = "Book Price")]
        public decimal BookPrice { get; set; }

        [Display(Name = "Exam Price")]
        [Required(ErrorMessage = "Exam Price")]
        public decimal ExamPrice { get; set; }

        [Display(Name = "Insurance Price")]
        [Required(ErrorMessage = "Insurance Price")]
        public decimal InsurancePrice { get; set; }

        [Display(Name = "Accomodation Price")]
        [Required(ErrorMessage = "Accomodation Price")]
        public decimal AccomodationPrice { get; set; }

        public int CollegeId { get; set; }

        public virtual CollegeViewModel College { get; set; }
    }

}
