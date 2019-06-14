using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICulturalExchangeAppService
    {
        CulturalExchangeViewModel Add(int idEnvironment, CulturalExchangeViewModel culturalExchangeViewModel);

        List<CulturalExchangeViewModel> GetAll(int idEnvironment);

        List<CulturalExchangeViewModel> GetAllByFilter(int idEnvironment, string startArrivalDate, string finishArrivalDate, int collegeId, int accomodationId);

        CulturalExchangeViewModel GetById(int id);

        CulturalExchangeViewModel Update(CulturalExchangeViewModel culturalExchangeViewModel);
    }
}
