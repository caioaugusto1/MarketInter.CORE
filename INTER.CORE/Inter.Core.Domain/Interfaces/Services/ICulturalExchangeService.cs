using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICulturalExchangeService
    {
        CulturalExchange Add(CulturalExchange student);

        List<CulturalExchange> GetAll(Guid idEnvironment);

        List<CulturalExchange> GetAllByFilter(Guid idEnvironment, DateTime startArrivalDateTime, DateTime finishArrivalDateTime, Guid collegeId, Guid accomodationId);

        CulturalExchange GetById(Guid id);

        CulturalExchange Update(Guid idEnvironment, CulturalExchange student);
    }
}
