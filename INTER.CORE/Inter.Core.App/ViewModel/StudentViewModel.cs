using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        [Display(Name = "Date of Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DateOfBirthday { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Nationality { get; set; }

        public string PassaportNumber { get; set; }

        public int EnviromentId { get; set; }

        public virtual EnvironmentViewModel Environment { get; set; }

        //public virtual List<IFormFile> Files { get; set; }
    }
}
