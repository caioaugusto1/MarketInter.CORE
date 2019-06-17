using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class AccomodationService : IAccomodationService
    {
        private readonly IAccomodationRepository _accomodationRepository;

        public AccomodationService(IAccomodationRepository accomodationRepository)
        {
            _accomodationRepository = accomodationRepository;
        }

        public Accomodation Add(Accomodation accomodation)
        {
            accomodation.Id = Guid.NewGuid();

            return _accomodationRepository.Insert(accomodation);
        }

        public List<Accomodation> GetAll(Guid idEnvironment)
        {
            return _accomodationRepository.FindByFilter(x => x.EnvironmentId == idEnvironment);
        }

        public Accomodation GetById(Guid id)
        {
            return _accomodationRepository.GetById(id);
        }

        public Accomodation Update(Accomodation accomodation)
        {
            return _accomodationRepository.Update(accomodation);
        }
    }
}
