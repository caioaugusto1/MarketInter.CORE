using Inter.Core.App.ViewModel.Base;
using System;

namespace Inter.Core.App.ViewModel
{
    public class ReceivePaymentCulturalExchangeFileUploadViewModel : BaseViewModel
    {
        public ReceivePaymentCulturalExchangeFileUploadViewModel()
        {
            ReceivePaymentCulturalExchangeId = Guid.NewGuid();
        }

        public string FileName { get; set; }

        public string Type { get; set; }

        public DateTime UploadDate { get; set; }

        public string Note { get; set; }

        public Guid ReceivePaymentCulturalExchangeId { get; set; }

        public virtual ReceivePaymentCulturalExchangeViewModel ReceivePaymentCulturalExchange { get; set; }
    }
}
