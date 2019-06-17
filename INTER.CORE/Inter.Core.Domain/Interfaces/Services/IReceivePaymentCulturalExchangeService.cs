using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IReceivePaymentCulturalExchangeService
    {
        ReceivePaymentCulturalExchange Add(ReceivePaymentCulturalExchange payment);

        List<ReceivePaymentCulturalExchange> GetAll(Guid idEnvironment);

        List<ReceivePaymentCulturalExchange> GetAllIncludedDependency(Guid idEnviroment);

        ReceivePaymentCulturalExchange GetById(Guid id);

        ReceivePaymentCulturalExchange Update(Guid idEnvironment, ReceivePaymentCulturalExchange payment);
    }
}
