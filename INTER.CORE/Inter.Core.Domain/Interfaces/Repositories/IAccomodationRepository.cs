using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IAccomodationRepository : IRepository<Accomodation>
    {
        List<Accomodation> VacancyAvailability(Guid id);

        Accomodation GetAccomodationAndCulturalExchangeList(Guid id);
    }
}
