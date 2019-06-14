using System;

namespace Inter.Core.Domain.Entities
{
    public class ReceivePaymentCulturalExchangeFileUpload
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string Type { get; set; }

        public DateTime UploadDate { get; set; }

        public string Note { get; set; }

        public Guid ReceivePaymentCulturalExchangeId { get; set; }

        public virtual ReceivePaymentCulturalExchange ReceivePaymentCulturalExchange { get; set; }
    }
}
