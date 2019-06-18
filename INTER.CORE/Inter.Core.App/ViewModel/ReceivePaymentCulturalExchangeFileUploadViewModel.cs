using Inter.Core.App.ViewModel.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class ReceivePaymentCulturalExchangeFileUploadViewModel : BaseViewModel
    {
        public ReceivePaymentCulturalExchangeFileUploadViewModel()
        {
            ReceivePaymentCulturalExchangeId = Guid.NewGuid();
        }

        public string FileName { get; set; }

        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string Type { get; set; }

        public DateTime UploadDate { get; set; }

        [Required]
        public string Note { get; set; }

        public Guid ReceivePaymentCulturalExchangeId { get; set; }

        public virtual ReceivePaymentCulturalExchangeViewModel ReceivePaymentCulturalExchange { get; set; }
    }
}
