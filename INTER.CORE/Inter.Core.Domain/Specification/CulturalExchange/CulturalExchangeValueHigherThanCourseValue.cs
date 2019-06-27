using DomainValidation.Interfaces.Specification;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.Domain.Specification.CulturalExchange
{
    public class CulturalExchangeValueHigherThanCourseValue : ISpecification<Entities.CulturalExchange>
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
            if (entity.WeekNumber == 25)
            {
                CollegeTime collegeTime = _collegeTimeRepository.GetById(entity.CollegeTimeId);

                var sumValueWithPercentage = collegeTime.Price * collegeTime.PercentagePrice;

                if (sumValueWithPercentage >= (decimal)entity.TotalValue)
                    entity.ValidationResult.Add(new ValidationResult("Course value incorrect"));
            }

            return false;
        }
    }
}
