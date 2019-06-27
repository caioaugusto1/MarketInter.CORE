using Inter.Core.App.ViewModel.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class StudentViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "CustomerId")]
        [MaxLength(7, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Customer Id")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "FullName")]
        [MaxLength(100, ErrorMessage = "Max {0} caracteres")]
        [DisplayName("FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email")]
        [MaxLength(100, ErrorMessage = "Max {0} caracteres")]
        [EmailAddress(ErrorMessage = "Min um E-mail válido")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "MobileNumber")]
        [MaxLength(7, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Date of Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Required(ErrorMessage = "DateOfBirthday")]
        public DateTime DateOfBirthday { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nationality")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Passport Number")]
        public string PassportNumber { get; set; }

        [Display(Name = "Passport Date Of Inssue")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime PassportDateOfIssue { get; set; }

        [Display(Name = "Passport Date Of Expiry")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime PassportDateOfExpiry { get; set; }

    }
}
