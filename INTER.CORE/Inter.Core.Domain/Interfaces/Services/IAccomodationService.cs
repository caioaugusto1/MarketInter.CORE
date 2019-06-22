using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IAccomodationService
    {
        Accomodation Add(Accomodation accomodation);

        List<Accomodation> GetAll(Guid idEnvironment);

        List<Accomodation> GetAllAvaliable(Guid idEnvironment);

        Accomodation GetAccomodationAndCulturalExchangeList(Guid id);

        Accomodation GetById(Guid id);

        Accomodation Update(Accomodation accomodation);
    }
}
