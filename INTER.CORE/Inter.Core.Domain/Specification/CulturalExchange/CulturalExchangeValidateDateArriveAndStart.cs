using DomainValidation.Interfaces.Specification;
using System.ComponentModel.DataAnnotations;
using System;

namespace Inter.Core.Domain.Specification.CulturalExchange
{
    public class CulturalExchangeValidateDateArriveAndStart : ISpecification<Entities.CulturalExchange>
    {
        public bool IsSatisfiedBy(Entities.CulturalExchange entity)
        {
            //if (entity.ArrivalDateTime <= DateTime.Now)
            //    entity.ValidationResult.Add(new ValidationResult("Date arrival incorrect"));

            //if (entity.ArrivalDateTime <= entity.StartDate)
            //    return false;

            return true;
        }
    }
}
