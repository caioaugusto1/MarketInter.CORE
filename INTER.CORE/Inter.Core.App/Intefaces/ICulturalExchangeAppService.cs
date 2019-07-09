using Inter.Core.App.JsonModels;
using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICulturalExchangeAppService
    {
        CulturalExchangeViewModel Add(Guid idEnvironment, CulturalExchangeViewModel culturalExchangeViewModel);

        List<CulturalExchangeViewModel> GetAll(Guid idEnvironment, bool active);

        List<CulturalExchangeViewModel> GetAllPaymentFinished(Guid idEnvironment);

        HomeDashoboardInfoJson GetAllLast12Month(Guid idEnvironment);

        List<CulturalExchangeViewModel> GetAllByFilter(Guid idEnvironment, string startArrivalDate, string finishArrivalDate, string startDate, string startDateFinish, Guid collegeId, Guid accomodationId);

        CulturalExchangeViewModel GetById(Guid id);

        CulturalExchangeViewModel Inactive(Guid id);

        CulturalExchangeViewModel UpdateDateStartAndFinish(Guid id, DateTime start, DateTime finish);

        CulturalExchangeViewModel Update(Guid idEnvironment, CulturalExchangeViewModel culturalExchangeViewModel);
    }
}
