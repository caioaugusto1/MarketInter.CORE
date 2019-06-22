using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inter.Core.Infra.Data.Repositories
{
    public class AccomodationRepository : RepositoryBase<Accomodation>, IAccomodationRepository
    {
        private readonly DbContextOptions<MySQLContext> _OptionsBuilder;

        public AccomodationRepository()
        {
            _OptionsBuilder = new DbContextOptions<MySQLContext>();
        }

        public Accomodation GetAccomodationAndCulturalExchangeList(Guid id)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.Accomodation.Include(x => x.CulturalExchanges)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Accomodation> VacancyAvailability(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
