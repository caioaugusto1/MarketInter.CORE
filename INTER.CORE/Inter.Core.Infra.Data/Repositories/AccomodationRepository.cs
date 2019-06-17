using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Infra.Data.Repositories
{
    public class AccomodationRepository : RepositoryBase<Accomodation>, IAccomodationRepository
    {
        public List<Accomodation> VacancyAvailability(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
