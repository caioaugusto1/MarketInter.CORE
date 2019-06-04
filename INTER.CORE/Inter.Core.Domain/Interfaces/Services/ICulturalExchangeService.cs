using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICulturalExchangeService
    {
        CulturalExchange Add(CulturalExchange student);

        List<CulturalExchange> GetAll(int idEnvironment);

        CulturalExchange GetById(int idEnvironment, int id);

        CulturalExchange Update(int idEnvironment, CulturalExchange student);
    }
}
