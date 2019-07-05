using Inter.Core.App.Enumerables;
using Inter.Core.App.ViewModel.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class PaymentCulturalExchangeViewModel : BaseViewModel
    {
        [Required]
        public float Value { get; set; }

        [Display(Name = "Date of Payment")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.DateTime, ErrorMessage = "Incorrect Format")]
        public DateTime DateOfPayment { get; set; }

        public string FileName { get; set; }

        [Required]
        public string Status { get; set; }

        public IFormFile File { get; set; }

        public DateTime UploadDate { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public Guid CulturalExchangeId { get; set; }

        public virtual CulturalExchangeViewModel CulturalExchangeViewModel { get; set; }
    }
}
