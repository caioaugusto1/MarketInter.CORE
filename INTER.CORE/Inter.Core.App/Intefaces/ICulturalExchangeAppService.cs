using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICulturalExchangeAppService
    {
        CulturalExchangeViewModel Add(Guid idEnvironment, CulturalExchangeViewModel culturalExchangeViewModel);

        List<CulturalExchangeViewModel> GetAll(Guid idEnvironment);

        List<CulturalExchangeViewModel> GetAllByFilter(Guid idEnvironment, string startArrivalDate, string finishArrivalDate, Guid collegeId, Guid accomodationId);

        CulturalExchangeViewModel GetById(Guid id);

        CulturalExchangeViewModel Update(CulturalExchangeViewModel culturalExchangeViewModel);
    }
}
