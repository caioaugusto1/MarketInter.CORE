using Inter.Core.Domain.Entities.Base;
using System;

namespace Inter.Core.Domain.Entities
{
    public class ReceivePaymentCulturalExchange
    {
        public Guid Id { get; set; }

        public float Value { get; set; }

        public DateTime DateOfPayment { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public virtual ReceivePaymentCulturalExchangeFileUpload ReceivePaymentCulturalExchangeFileUpload { get; set; }

        public int CulturalExchangeId { get; set; }

        public virtual CulturalExchange CulturalExchange { get; set; }

        public int EnvironmentId { get; set; }

        public virtual SystemEnvironment Environment { get; set; }
    }
}
