using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICulturalExchangeService
    {
        CulturalExchange Add(CulturalExchange student);

        List<CulturalExchange> GetAll(int idEnvironment);

        List<CulturalExchange> GetAllByFilter(int idEnvironment, DateTime startArrivalDateTime, DateTime finishArrivalDateTime, int collegeId, int accomodationId);

        CulturalExchange GetById(int id);

        CulturalExchange Update(int idEnvironment, CulturalExchange student);
    }
}
