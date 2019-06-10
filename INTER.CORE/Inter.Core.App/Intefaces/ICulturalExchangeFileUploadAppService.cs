using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICulturalExchangeFileUploadAppService
    {
        CulturalExchangeFileUploadViewModel Add(CulturalExchangeFileUploadViewModel file);

        List<CulturalExchangeFileUploadViewModel> GetAllByCulturalExchangeId(int culturalExchangeId);

        CulturalExchangeFileUploadViewModel GetById(int id);

        CulturalExchangeFileUploadViewModel Update(CulturalExchangeFileUploadViewModel file);

        void Delete(int id);
    }
}
