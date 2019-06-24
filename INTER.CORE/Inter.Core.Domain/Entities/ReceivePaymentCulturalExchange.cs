using Inter.Core.Domain.Entities.Base;
using System;

namespace Inter.Core.Domain.Entities
{
    public class ReceivePaymentCulturalExchange : EntityBase
    {
        public float Value { get; set; }

        public DateTime DateOfPayment { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string FileName { get; set; }

        public string Type { get; set; }

        public DateTime UploadDate { get; set; }

        public string Note { get; set; }
        
        public Guid CulturalExchangeId { get; set; }

        public virtual CulturalExchange CulturalExchange { get; set; }
    }
}
