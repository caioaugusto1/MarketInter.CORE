using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IReceivePaymentCulturalExchangeRepository : IRepository<ReceivePaymentCulturalExchange>
    {
        List<ReceivePaymentCulturalExchange> GetAllIncludedDependencys(int environmentId);
    }
}
