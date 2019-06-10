using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface ICulturalExchangeFileUploadRepository : IRepository<CulturalExchangeFileUpload>
    {
        List<CulturalExchangeFileUpload> GetAllByCulturalExchangeId(int culturalExchangeId);
    }
}
