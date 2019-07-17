using DomainValidation.Interfaces.Specification;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Inter.Core.Domain.Specification.CulturalExchange
{
    public class CulturalExchangeValidateAccomodationDateAvailable : ISpecification<Inter.Core.Domain.Entities.CulturalExchange>
    {
        private readonly IAccomodationRepository _accomodationRepository;

        public CulturalExchangeValidateAccomodationDateAvailable(IAccomodationRepository accomodationRepository)
        {
            _accomodationRepository = accomodationRepository;
        }

        public bool IsSatisfiedBy(Entities.CulturalExchange entity)
        {
            if (!entity.OurAccomodation || !entity.AccomodationId.HasValue)
                return false;

            Accomodation accomodation = _accomodationRepository.GetById(entity.AccomodationId.Value);

            entity.DaysOfAccomodation = ((TimeSpan)(entity.StartAccomodation - entity.FinishAccomodation)).Days * 100;

            var culturalExchangeInAccomodation = _accomodationRepository.GetAccomodationAndCulturalExchangeList(entity.AccomodationId.Value);

            var reservations = culturalExchangeInAccomodation.CulturalExchanges.Where(x => x.StartAccomodation <= entity.StartAccomodation
            && x.FinishAccomodation >= entity.FinishAccomodation
            && x.OurAccomodation).ToList();

            if (reservations.Count >= accomodation.NumberOfPlaces)
                entity.ValidationResult.Add(new ValidationResult("Date Start Accomodation invalid"));

            return true;
        }
    }
}
