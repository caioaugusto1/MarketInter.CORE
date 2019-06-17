using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IReceivePaymentCulturalExchangeRepository : IRepository<ReceivePaymentCulturalExchange>
    {
        List<ReceivePaymentCulturalExchange> GetAllIncludedDependencys(Guid environmentId);

        List<ReceivePaymentCulturalExchange> GetAllIncludedDependencysByCulturalExchangeId(Guid culturalExchangeId);

        ReceivePaymentCulturalExchange GetByIdIncludedDependency(Guid id);
    }
}
