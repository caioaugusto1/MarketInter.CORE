using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using static Inter.Core.Domain.Entities.College;

namespace Inter.Core.Domain.Service
{
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeRepository _collegeRepository;

        public CollegeService(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public College Add(College college, List<CollegeTime> collegeTimes)
        {
            return _collegeRepository.Insert(college);
        }

        public List<College> GetAll()
        {
            return _collegeRepository.GetAll();
        }

        public College GetById(int id)
        {
            return _collegeRepository.GetById(id);
        }

        public College Update(College college)
        {
            return _collegeRepository.Update(college);
        }
    }
}
