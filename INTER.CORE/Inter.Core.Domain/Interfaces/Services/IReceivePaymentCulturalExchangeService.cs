using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IReceivePaymentCulturalExchangeService
    {
        ReceivePaymentCulturalExchange Add(ReceivePaymentCulturalExchange payment);

        List<ReceivePaymentCulturalExchange> GetAll(int idEnvironment);

        List<ReceivePaymentCulturalExchange> GetAllIncludedDependency(int idEnviroment);

        ReceivePaymentCulturalExchange GetById(Guid id);

        ReceivePaymentCulturalExchange Update(int idEnvironment, ReceivePaymentCulturalExchange payment);
    }
}
