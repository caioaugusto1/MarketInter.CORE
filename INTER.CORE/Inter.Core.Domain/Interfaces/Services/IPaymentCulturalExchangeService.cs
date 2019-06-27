using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IPaymentCulturalExchangeService
    {
        PaymentCulturalExchange Add(PaymentCulturalExchange payment);

        List<PaymentCulturalExchange> GetAll(Guid idEnvironment);

        PaymentCulturalExchange GetById(Guid id);

        PaymentCulturalExchange Update(Guid idEnvironment, PaymentCulturalExchange payment);
    }
}
