using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using Inter.Core.Domain.Specification.CollegeTime;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class CollegeTimeService : ICollegeTimeService
    {
        private readonly ICollegeTimeRepository _collegeTimeRepository;
        private readonly ICollegeRepository _collegeRepository;

        public CollegeTimeService(ICollegeTimeRepository collegeTimeRepository, ICollegeRepository collegeRepository)
        {
            _collegeTimeRepository = collegeTimeRepository;
            _collegeRepository = collegeRepository;
        }

        public CollegeTime Add(CollegeTime collegeTime)
        {
            collegeTime.Id = Guid.NewGuid();

            bool hoursValidation = new CollegeTimeValidateSumHoursPerWeek()
              .IsSatisfiedBy(collegeTime);

            return _collegeTimeRepository.Insert(collegeTime);

        }

        public void Delete(CollegeTime collegeTime)
        {
            _collegeTimeRepository.Delete(collegeTime);
        }

        public List<CollegeTime> GetAll(Guid collegeId)
        {
            return _collegeTimeRepository.FindByFilter(x => x.CollegeId == collegeId);
        }

        public CollegeTime GetById(Guid id)
        {
            return _collegeTimeRepository.GetById(id);
        }

        public CollegeTime Update(CollegeTime collegeTime)
        {
            bool hoursValidation = new CollegeTimeValidateSumHoursPerWeek()
             .IsSatisfiedBy(collegeTime);

            return _collegeTimeRepository.Update(collegeTime);
        }
    }
}
