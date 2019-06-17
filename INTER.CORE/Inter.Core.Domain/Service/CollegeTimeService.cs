using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
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
            //collegeTime.College = _collegeRepository.GetById(collegeTime.CollegeId);

            return _collegeTimeRepository.Update(collegeTime);
        }
    }
}
