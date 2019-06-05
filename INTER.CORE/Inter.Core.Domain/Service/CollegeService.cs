using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

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
            college.Environment = environment;

            return _collegeRepository.Insert(college);
        }

        public List<College> GetAll(int idEnvironment)
        {
            return _collegeRepository.GetAll().Where(x => x.EnvironmentId == idEnvironment).ToList();
        }

        public College GetById(int id)
        {
            return _collegeRepository.GetById(id);
        }

        public College GetCollegeTimeByCollegeId(int id)
        {
            return _collegeRepository.GetCollegeTimeByCollegeId(id);
        }

        public College.CollegeTime GetCollegeTimeById(int idCollegeTime)
        {
            return _collegeRepository.GetCollegeTimeById(idCollegeTime);
        }

        public College Update(College college)
        {
            return _collegeRepository.Update(college);
        }
    }
}
