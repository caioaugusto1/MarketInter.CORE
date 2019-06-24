using Inter.Core.App.Enumerables;
using Inter.Core.App.ViewModel.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class ReceivePaymentCulturalExchangeViewModel : BaseViewModel
    {
        public float Value { get; set; }

        [Display(Name = "Date of Payment")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.DateTime, ErrorMessage = "Incorrect Format")]
        public DateTime DateOfPayment { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        public string FileName { get; set; }

        [Required]
        public IFormFile File { get; set; }

        [Required]
        public ReceivePaymentCulturalExchangeTypeUpload Type { get; set; }

        public DateTime UploadDate { get; set; }

        [Required]
        public string Note { get; set; }

        public Guid CulturalExchangeId { get; set; }

        public virtual CulturalExchangeViewModel CulturalExchange { get; set; }
    }
}
