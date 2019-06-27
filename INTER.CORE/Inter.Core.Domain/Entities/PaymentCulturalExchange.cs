using Inter.Core.Domain.Entities.Base;
using System;

namespace Inter.Core.Domain.Entities
{
    public class PaymentCulturalExchange : EntityBase
    {
        public float Value { get; set; }

        public DateTime DateOfPayment { get; set; }

        public string FileName { get; set; }

        public string Status { get; set; }

        public DateTime UploadDate { get; set; }

        public string Note { get; set; }

        public Guid CulturalExchangeId { get; set; }

        public virtual CulturalExchange CulturalExchange { get; set; }
    }
}
