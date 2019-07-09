using DomainValidation.Interfaces.Specification;
using Inter.Core.Domain.Interfaces.Repositories;
using System;
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
            Entities.CollegeTime collegeTime = _collegeTimeRepository.GetById(entity.CollegeTimeId);

            if (entity.WeekNumber == 25 && !entity.Renew)
            {
                var sumValueWithPercentage = (double)collegeTime.NetPrice + ((double)collegeTime.NetPrice * collegeTime.PercentagePrice) / 100;

                if (sumValueWithPercentage >= (double)entity.TotalValue)
                    entity.ValidationResult.Add(new ValidationResult("Course value incorrect"));
            }
            else if (entity.Renew)
            {
                if (collegeTime.RenewPrice < (decimal)entity.TotalValue)
                    entity.ValidationResult.Add(new ValidationResult("Course value incorrect"));

                entity.ArrivalDateTime = null;
                entity.FlightNumber = null;
                entity.Company = null;
            }

            return false;
        }
    }
}
