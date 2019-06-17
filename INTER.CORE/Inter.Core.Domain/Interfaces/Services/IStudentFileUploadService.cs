using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICulturalExchangeFileUploadService
    {
        CulturalExchangeFileUpload Add(CulturalExchangeFileUpload file);

        List<CulturalExchangeFileUpload> GetAllByCulturalExchangeId(Guid studentId);

        CulturalExchangeFileUpload GetById(Guid id);

        CulturalExchangeFileUpload Update(CulturalExchangeFileUpload file);

        void Delete(Guid id);
    }
}
