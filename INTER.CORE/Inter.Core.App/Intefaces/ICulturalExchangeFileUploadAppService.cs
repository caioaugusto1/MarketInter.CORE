using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICulturalExchangeFileUploadAppService
    {
        CulturalExchangeFileUploadViewModel Add(CulturalExchangeFileUploadViewModel file);

        List<CulturalExchangeFileUploadViewModel> GetAllByCulturalExchangeId(Guid culturalExchangeId);

        CulturalExchangeFileUploadViewModel GetById(Guid id);

        CulturalExchangeFileUploadViewModel Update(CulturalExchangeFileUploadViewModel file);

        void Delete(Guid id);
    }
}
