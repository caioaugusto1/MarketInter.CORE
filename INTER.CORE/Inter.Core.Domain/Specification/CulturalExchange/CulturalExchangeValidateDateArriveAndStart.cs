using DomainValidation.Interfaces.Specification;

namespace Inter.Core.Domain.Specification.CulturalExchange
{
    public class CulturalExchangeValidateDateArriveAndStart : ISpecification<Entities.CulturalExchange>
    {
        public bool IsSatisfiedBy(Entities.CulturalExchange entity)
        {
            if (entity.ArrivalDateTime <= entity.StartDate)
                return false;

            return true;
        }
    }
}
