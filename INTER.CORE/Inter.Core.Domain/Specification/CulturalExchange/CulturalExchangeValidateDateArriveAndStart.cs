using DomainValidation.Interfaces.Specification;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.Domain.Specification.CulturalExchange
{
    public class CulturalExchangeValidateDateArriveAndStart : ISpecification<Entities.CulturalExchange>
    {
        public bool IsSatisfiedBy(Entities.CulturalExchange entity)
        {
            if (entity.ArrivalDateTime <= DateTime.Now)
                entity.ValidationResult.Add(new ValidationResult("Date arrival incorrect"));

            if (entity.ArrivalDateTime >= entity.StartDate)
                entity.ValidationResult.Add(new ValidationResult("Date arrival and start incorrect"));

            if (entity.StartAccomodation > entity.FinishAccomodation)
                entity.ValidationResult.Add(new ValidationResult("Date Start Accomodation invalid"));

            return false;
        }
    }
}
