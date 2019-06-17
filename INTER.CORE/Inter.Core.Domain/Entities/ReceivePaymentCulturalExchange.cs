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

        public virtual ReceivePaymentCulturalExchangeFileUpload ReceivePaymentCulturalExchangeFileUpload { get; set; }

        public Guid CulturalExchangeId { get; set; }

        public virtual CulturalExchange CulturalExchange { get; set; }
    }
}
