using DomainValidation.Interfaces.Specification;

namespace Inter.Core.Domain.Specification.CulturalExchange
{
    public class CulturalExchangeCountDaysAccomodation : ISpecification<Entities.CulturalExchange>
    {
        public bool IsSatisfiedBy(Entities.CulturalExchange entity)
        {
            if (!entity.IncludeAccomodation)
                return true;

            return true;
        }
    }
}
