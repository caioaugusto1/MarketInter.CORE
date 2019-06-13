using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using Inter.Core.Domain.Specification.CulturalExchange;
using System;
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
        private readonly IAccomodationRepository _accomodationRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICulturalExchangeFileUploadRepository _culturalExchangeFileUploadRepository;

        public CulturalExchangeService(ICulturalExchangeRepository culturalExchangeRepository, ICollegeRepository collegeRepository,
            ICollegeTimeRepository collegeTimeRepository, IAccomodationRepository accomodationRepository, IStudentRepository studentRepository,
            ICulturalExchangeFileUploadRepository culturalExchangeFileUploadRepository)
        {
            _culturalExchangeRepository = culturalExchangeRepository;
            _collegeRepository = collegeRepository;
            _collegeTimeRepository = collegeTimeRepository;
            _accomodationRepository = accomodationRepository;
            _studentRepository = studentRepository;
            _culturalExchangeFileUploadRepository = culturalExchangeFileUploadRepository;
        }

        public CulturalExchange Add(CulturalExchange culturalExchange)
        {
            College college = _collegeRepository.GetById(culturalExchange.College.Id);

            culturalExchange.ValidationResult = new List<ValidationResult>();

            bool ValueHigherThanCourseValue = new CulturalExchangeValueHigherThanCourseValue(_culturalExchangeRepository, _collegeTimeRepository)
                .IsSatisfiedBy(culturalExchange);

            if (!ValueHigherThanCourseValue)
                culturalExchange.ValidationResult.Add(new ValidationResult("Value incorrect"));

            bool accomodationDateAvailable = new CulturalExchangeValidateAccomodationDateAvailable(_accomodationRepository)
                .IsSatisfiedBy(culturalExchange);

            if (!accomodationDateAvailable)
                culturalExchange.ValidationResult.Add(new ValidationResult("Accomodation FULL"));

            bool validateDateArriveAndStart = new CulturalExchangeValidateDateArriveAndStart().IsSatisfiedBy(culturalExchange);

            if (!validateDateArriveAndStart)
                culturalExchange.ValidationResult.Add(new ValidationResult("Dates invaliable"));

            bool countDatesAccomodation = new CulturalExchangeCountDaysAccomodation().IsSatisfiedBy(culturalExchange);

            if (!culturalExchange.ValidationResult.Any())
                _culturalExchangeRepository.Insert(culturalExchange);

            return culturalExchange;
        }

        public List<CulturalExchange> GetAll(int idEnvironment)
        {
            var culturalExchangeEntity = _culturalExchangeRepository.FindByFilter(x => x.Environment.Id == idEnvironment);

            culturalExchangeEntity.ForEach(x =>
            {
                x.CollegeTime = _collegeTimeRepository.GetById(x.CollegeTimeId);
                x.College = _collegeRepository.GetById(x.CollegeId);
                x.Accomodation = _accomodationRepository.GetById(x.AccomodationId);
                x.Student = _studentRepository.GetById(x.StudentId);
                x.CollegeTime = _collegeTimeRepository.GetById(x.CollegeTimeId);
            });

            return culturalExchangeEntity;
        }

        public List<CulturalExchange> GetAllByFilter(int idEnvironment, DateTime startArrivalDateTime, DateTime finishArrivalDateTime, int collegeId, int accomodationId)
        {
            var culturalExchangeEntity = _culturalExchangeRepository.FindByFilter(x => x.EnvironmentId == idEnvironment);

            if (startArrivalDateTime <= finishArrivalDateTime)
                culturalExchangeEntity = culturalExchangeEntity.Where(x => x.ArrivalDateTime.Date >= startArrivalDateTime
                && x.ArrivalDateTime <= finishArrivalDateTime).ToList();

            if (collegeId != 0)
                culturalExchangeEntity = culturalExchangeEntity.Where(x => x.CollegeId == collegeId).ToList();

            if (accomodationId != 0)
                culturalExchangeEntity = culturalExchangeEntity.Where(x => x.AccomodationId == accomodationId).ToList();

            culturalExchangeEntity.ForEach(x =>
            {
                x.CollegeTime = _collegeTimeRepository.GetById(x.CollegeTimeId);
                x.College = _collegeRepository.GetById(x.CollegeId);
                x.Accomodation = _accomodationRepository.GetById(x.AccomodationId);
                x.Student = _studentRepository.GetById(x.StudentId);
                x.CollegeTime = _collegeTimeRepository.GetById(x.CollegeTimeId);
            });

            return culturalExchangeEntity;
        }

        public CulturalExchange GetById(int id)
        {
            var culturalExchangeEntity = _culturalExchangeRepository.GetById(id);

            culturalExchangeEntity.CollegeTime = _collegeTimeRepository.GetById(culturalExchangeEntity.CollegeTimeId);
            culturalExchangeEntity.College = _collegeRepository.GetById(culturalExchangeEntity.CollegeId);
            culturalExchangeEntity.Accomodation = _accomodationRepository.GetById(culturalExchangeEntity.AccomodationId);
            culturalExchangeEntity.Student = _studentRepository.GetById(culturalExchangeEntity.StudentId);
            culturalExchangeEntity.CulturalExchangeFileUpload = _culturalExchangeFileUploadRepository.GetAllByCulturalExchangeId(id);

            return culturalExchangeEntity;
        }

        public CulturalExchange Update(int idEnvironment, CulturalExchange student)
        {
            throw new System.NotImplementedException();
        }
    }
}
