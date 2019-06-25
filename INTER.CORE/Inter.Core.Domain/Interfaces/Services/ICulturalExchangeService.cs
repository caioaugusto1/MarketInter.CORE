using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICulturalExchangeService
    {
        CulturalExchange Add(CulturalExchange culturalExchange);

        List<CulturalExchange> GetAll(Guid idEnvironment, bool active);

        List<CulturalExchange> GetAllByFilter(Guid idEnvironment, DateTime startArrivalDateTime, DateTime finishArrivalDateTime, Guid collegeId, Guid accomodationId);

        CulturalExchange UpdateDateStartAndFinish(Guid id, DateTime start, DateTime finish);

        CulturalExchange Inactive(Guid id);

        CulturalExchange GetById(Guid id);

        CulturalExchange Update(Guid idEnvironment, CulturalExchange student);
    }
}
