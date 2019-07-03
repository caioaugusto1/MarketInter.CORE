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
            culturalExchange.Id = Guid.NewGuid();
            culturalExchange.Available = true;

            if (culturalExchange.AccomodationId == Guid.Empty)
                culturalExchange.AccomodationId = null;

            culturalExchange.ValidationResult = new List<ValidationResult>();

            bool ValueHigherThanCourseValue = new CulturalExchangeValueHigherThanCourseValue(_culturalExchangeRepository, _collegeTimeRepository)
                .IsSatisfiedBy(culturalExchange);

            bool validateDateArriveAndStart = new CulturalExchangeValidateDateArriveAndStart().IsSatisfiedBy(culturalExchange);

            if (!culturalExchange.ValidationResult.Any())
                _culturalExchangeRepository.Insert(culturalExchange);
            else
                return culturalExchange;

            bool accomodationDateAvailable = new CulturalExchangeValidateAccomodationDateAvailable(_accomodationRepository)
                .IsSatisfiedBy(culturalExchange);

            if (!accomodationDateAvailable)
            {
                if (culturalExchange.ValidationResult.Count == 1)
                    culturalExchange.ValidationResult.Add(new ValidationResult("Cultural exchange included but: Accomodation FULL for dates"));
            }

            return culturalExchange;
        }

        public List<CulturalExchange> GetAll(Guid idEnvironment, bool active)
        {
            var culturalExchangeEntity = _culturalExchangeRepository
                .FindByFilter(x => x.Environment.Id == idEnvironment && x.Available == active);

            culturalExchangeEntity.ForEach(x =>
            {
                x.College = _collegeRepository.GetById(x.CollegeId);

                if (x.AccomodationId.HasValue)
                    x.Accomodation = _accomodationRepository.GetById(x.AccomodationId.Value);

                x.Student = _studentRepository.GetById(x.StudentId);
                x.CollegeTime = _collegeTimeRepository.GetById(x.CollegeTimeId);
            });

            return culturalExchangeEntity;
        }

        public List<CulturalExchange> GetAllByFilter(Guid idEnvironment, DateTime startArrivalDateTime, DateTime finishArrivalDateTime, Guid collegeId, Guid accomodationId)
        {
            List<CulturalExchange> culturalExchangeEntity = new List<CulturalExchange>();

            if (startArrivalDateTime != DateTime.MinValue && finishArrivalDateTime != DateTime.MinValue)
            {
                if (startArrivalDateTime > finishArrivalDateTime)
                    return null;
            }

            culturalExchangeEntity = _culturalExchangeRepository.FindByFilter(x => x.EnvironmentId == idEnvironment);

            if (startArrivalDateTime != DateTime.MinValue)
                culturalExchangeEntity = culturalExchangeEntity.Where(x => x.ArrivalDateTime.Value.Date >= startArrivalDateTime).ToList();

            if (finishArrivalDateTime != DateTime.MinValue)
                culturalExchangeEntity = culturalExchangeEntity.Where(x => x.ArrivalDateTime.Value.Date <= finishArrivalDateTime).ToList();

            if (collegeId != Guid.Empty)
                culturalExchangeEntity = culturalExchangeEntity.Where(x => x.CollegeId == collegeId).ToList();

            if (accomodationId != Guid.Empty)
                culturalExchangeEntity = culturalExchangeEntity.Where(x => x.AccomodationId == accomodationId).ToList();

            culturalExchangeEntity.ForEach(x =>
            {
                x.College = _collegeRepository.GetById(x.CollegeId);
                x.Accomodation = _accomodationRepository.GetById(x.AccomodationId.Value);
                x.Student = _studentRepository.GetById(x.StudentId);
                x.CollegeTime = _collegeTimeRepository.GetById(x.CollegeTimeId);
            });

            return culturalExchangeEntity;
        }

        public CulturalExchange GetById(Guid id)
        {
            var culturalExchangeEntity = _culturalExchangeRepository.GetById(id);

            culturalExchangeEntity.CollegeTime = _collegeTimeRepository.GetById(culturalExchangeEntity.CollegeTimeId);
            culturalExchangeEntity.College = _collegeRepository.GetById(culturalExchangeEntity.CollegeId);
            culturalExchangeEntity.Accomodation = _accomodationRepository.GetById(culturalExchangeEntity.AccomodationId.Value);
            culturalExchangeEntity.Student = _studentRepository.GetById(culturalExchangeEntity.StudentId);
            culturalExchangeEntity.CulturalExchangeFileUpload = _culturalExchangeFileUploadRepository.GetAllByCulturalExchangeId(id);

            return culturalExchangeEntity;
        }

        public CulturalExchange Inactive(Guid id)
        {
            var entity = _culturalExchangeRepository.GetById(id);
            entity.Available = false;

            return _culturalExchangeRepository.Update(entity);
        }

        public CulturalExchange Update(Guid idEnvironment, CulturalExchange culturalExchange)
        {
            if (culturalExchange.AccomodationId == Guid.Empty)
                culturalExchange.AccomodationId = null;

            culturalExchange.ValidationResult = new List<ValidationResult>();

            bool ValueHigherThanCourseValue = new CulturalExchangeValueHigherThanCourseValue(_culturalExchangeRepository, _collegeTimeRepository)
                .IsSatisfiedBy(culturalExchange);

            bool validateDateArriveAndStart = new CulturalExchangeValidateDateArriveAndStart().IsSatisfiedBy(culturalExchange);

            if (!culturalExchange.ValidationResult.Any())
                _culturalExchangeRepository.Update(culturalExchange);
            else
                return culturalExchange;

            bool accomodationDateAvailable = new CulturalExchangeValidateAccomodationDateAvailable(_accomodationRepository)
                .IsSatisfiedBy(culturalExchange);

            if (!accomodationDateAvailable)
            {
                if (culturalExchange.ValidationResult.Count == 1)
                    culturalExchange.ValidationResult.Add(new ValidationResult("Cultural exchange included but: Accomodation FULL for dates"));
            }

            return culturalExchange;
        }

        public CulturalExchange UpdateDateStartAndFinish(Guid id, DateTime start, DateTime finish)
        {
            var entity = _culturalExchangeRepository.GetById(id);
            entity.StartAccomodation = start;
            entity.FinishAccomodation = finish;

            return _culturalExchangeRepository.Update(entity);
        }
    }
}
