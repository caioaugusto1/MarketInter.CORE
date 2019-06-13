using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class CollegeTimeService : ICollegeTimeService
    {
        private readonly ICollegeTimeRepository _collegeTimeRepository;

        public CollegeTimeService(ICollegeTimeRepository collegeTimeRepository)
        {
            _collegeTimeRepository = collegeTimeRepository;
        }

        public CollegeTime Add(CollegeTime collegeTime)
        {
            return _collegeTimeRepository.Insert(collegeTime);
        }

        public void Delete(CollegeTime collegeTime)
        {
            _collegeTimeRepository.Delete(collegeTime);
        }

        public List<CollegeTime> GetAll(int collegeId)
        {
            return _collegeTimeRepository.FindByFilter(x => x.CollegeId == collegeId);
        }

        public CollegeTime GetById(int id)
        {
            return _collegeTimeRepository.GetById(id);
        }

        public CollegeTime Update(CollegeTime collegeTime)
        {
            return _collegeTimeRepository.Update(collegeTime);
        }
    }
}
