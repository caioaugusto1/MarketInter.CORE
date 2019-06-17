using Inter.Core.App.ViewModel.Base;
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

        public string From { get; set; }

        public string To { get; set; }

        public virtual ReceivePaymentCulturalExchangeFileUploadViewModel ReceivePaymentCulturalExchangeFileUploadViewModel { get; set; }

        public Guid CulturalExchangeId { get; set; }

        public virtual CulturalExchangeViewModel CulturalExchange { get; set; }
    }
}
