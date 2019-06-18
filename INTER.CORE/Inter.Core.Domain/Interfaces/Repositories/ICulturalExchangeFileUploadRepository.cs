using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface ICulturalExchangeFileUploadRepository : IRepository<CulturalExchangeFileUpload>
    {
        List<CulturalExchangeFileUpload> GetAllByCulturalExchangeId(Guid culturalExchangeId);
    }
}
