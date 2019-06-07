using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IAccomodationService
    {
        Accomodation Add(Accomodation accomodation);

        List<Accomodation> GetAll(int idEnvironment);

        Accomodation GetById(int id);

        Accomodation Update(Accomodation accomodation);
    }
}
