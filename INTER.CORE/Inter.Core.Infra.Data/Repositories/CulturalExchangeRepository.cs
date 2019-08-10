using System.Collections.Generic;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;

namespace Inter.Core.Infra.Data.Repositories
{
    public class CulturalExchangeRepository : RepositoryBase<CulturalExchange>, ICulturalExchangeRepository
    {
        public List<CulturalExchange> GetAllByDapper()
        {
            string sql = "SELECT * FROM Intercore.CulturalExchange";

            return new List<CulturalExchange>();
        }
    }
}
