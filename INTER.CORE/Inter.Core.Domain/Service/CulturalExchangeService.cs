using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using Inter.Core.Domain.Specification.CulturalExchange;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Inter.Core.Domain.Service
{
    public class CulturalExchangeService : ICulturalExchangeService
    {
        private readonly ICulturalExchangeRepository _culturalExchangeRepository;
        private readonly ICollegeRepository _collegeRepository;
        private readonly ICollegeTimeRepository _collegeTimeRepository;

        public CulturalExchangeService(ICulturalExchangeRepository culturalExchangeRepository, ICollegeRepository collegeRepository,
            ICollegeTimeRepository collegeTimeRepository)
        {
            _culturalExchangeRepository = culturalExchangeRepository;
            _collegeRepository = collegeRepository;
            _collegeTimeRepository = collegeTimeRepository;
        }

        public CulturalExchange Add(CulturalExchange culturalExchange)
        {
            College college = _collegeRepository.GetById(culturalExchange.College.Id);

            culturalExchange.ValidationResult = new List<ValidationResult>();

            bool ValueHigherThanCourseValue = new CulturalExchangeValueHigherThanCourseValue(_culturalExchangeRepository, _collegeTimeRepository)
                .IsSatisfiedBy(culturalExchange);

            if (!ValueHigherThanCourseValue)
                culturalExchange.ValidationResult.Add(new ValidationResult("Value incorrect"));

            if (!culturalExchange.ValidationResult.Any())
                _culturalExchangeRepository.Insert(culturalExchange);

            return culturalExchange;
        }

        public List<CulturalExchange> GetAll(int idEnvironment)
        {
            return _culturalExchangeRepository.GetAll().Where(x => x.Environment.Id == idEnvironment).ToList();
        }

        public CulturalExchange GetById(int idEnvironment, int id)
        {
            throw new System.NotImplementedException();
        }

        public CulturalExchange Update(int idEnvironment, CulturalExchange student)
        {
            throw new System.NotImplementedException();
        }
    }
}
