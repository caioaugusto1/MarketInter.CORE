using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeRepository _collegeRepository;

        public CollegeService(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public College Add(SystemEnvironment environment, College college)
        {
            college.Id = Guid.NewGuid();
            college.Environment = environment;

            return _collegeRepository.Insert(college);
        }

        public List<College> GetAll(Guid idEnvironment)
        {
            return _collegeRepository.FindByFilter(x => x.EnvironmentId == idEnvironment);
        }

        public College GetById(Guid id)
        {
            return _collegeRepository.GetByIdIncluedTimeCollege(id);
        }

        public College Update(College college)
        {
            return _collegeRepository.Update(college);
        }
    }
}
