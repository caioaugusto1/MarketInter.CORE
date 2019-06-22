using DomainValidation.Interfaces.Specification;
using System.ComponentModel.DataAnnotations;
using System;

namespace Inter.Core.Domain.Specification.CulturalExchange
{
    public class CulturalExchangeValidateDateArriveAndStart : ISpecification<Entities.CulturalExchange>
    {
        public bool IsSatisfiedBy(Entities.CulturalExchange entity)
        {
            if (entity.ArrivalDateTime <= DateTime.Now)
                entity.ValidationResult.Add(new ValidationResult("Date arrival incorrect"));

            if (entity.ArrivalDateTime <= entity.StartDate)
                entity.ValidationResult.Add(new ValidationResult("Date arrival and start incorrect"));

            if(entity.IncludeAccomodation)
                entity.DaysOfAccomodation = Convert.ToInt32(Math.Abs(entity.StartAccomodation.Subtract(entity.FinishAccomodation).TotalDays));

            return true;
        }
    }
}
