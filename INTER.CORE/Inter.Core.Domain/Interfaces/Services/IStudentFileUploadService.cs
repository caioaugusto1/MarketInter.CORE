using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICulturalExchangeFileUploadService
    {
        CulturalExchangeFileUpload Add(CulturalExchangeFileUpload file);

        List<CulturalExchangeFileUpload> GetAllByCulturalExchangeId(int studentId);

        CulturalExchangeFileUpload GetById(int id);

        CulturalExchangeFileUpload Update(CulturalExchangeFileUpload file);

        void Delete(int id);
    }
}
