using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICulturalExchangeService
    {
        CulturalExchange Add(CulturalExchange culturalExchange);

        List<CulturalExchange> GetAll(Guid idEnvironment, bool active);

        List<CulturalExchange> GetAllByFilter(Guid idEnvironment, DateTime startArrivalDateTime, DateTime finishArrivalDateTime, DateTime courseStartDate, DateTime courseStartDateFinish, Guid collegeId, Guid accomodationId);

        List<CulturalExchange> GetAllPaymentFinished(Guid idEnvironment);

        List<CulturalExchange> GetAllLast12Month(Guid idEnvironment);

        CulturalExchange UpdateDateStartAndFinish(Guid id, DateTime start, DateTime finish);

        CulturalExchange Inactive(Guid id);

        CulturalExchange GetById(Guid id);

        CulturalExchange Update(Guid idEnvironment, CulturalExchange student);
    }
}
