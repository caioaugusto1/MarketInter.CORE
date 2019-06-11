using DomainValidation.Interfaces.Specification;
using Inter.Core.Domain.Interfaces.Repositories;

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
            var accomodation = _accomodationRepository.GetById(entity.AccomodationId);

            return true;
        }
    }
}
