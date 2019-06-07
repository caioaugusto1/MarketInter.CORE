using DomainValidation.Interfaces.Specification;
using Inter.Core.Domain.Interfaces.Repositories;

namespace Inter.Core.Domain.Specification.CulturalExchange
{
    public class CulturalExchangeValueHigherThanCourseValue : ISpecification<Inter.Core.Domain.Entities.CulturalExchange>
    {
        private readonly ICulturalExchangeRepository _culturalExchangeRepository;
        private readonly ICollegeTimeRepository _collegeTimeRepository;

        public CulturalExchangeValueHigherThanCourseValue(
            ICulturalExchangeRepository culturalExchangeRepository,
            ICollegeTimeRepository collegeTimeRepository)
        {
            _culturalExchangeRepository = culturalExchangeRepository;
            _collegeTimeRepository = collegeTimeRepository;
        }

        public bool IsSatisfiedBy(Entities.CulturalExchange entity)
        {
            return false;
        }
    }
}
