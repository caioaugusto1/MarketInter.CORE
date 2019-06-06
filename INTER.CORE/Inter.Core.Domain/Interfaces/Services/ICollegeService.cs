using Inter.Core.Domain.Entities;
using System.Collections.Generic;
using static Inter.Core.Domain.Entities.College;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICollegeService
    {
        List<College> GetAll(int idEnvironment);

        College Add(SystemEnvironment environment, College college);

        College GetById(int id);

        College GetCollegeTimeByCollegeId(int id);

        College Update(College college);

        CollegeTime GetCollegeTimeById(int idCollegeTime);

        CollegeTime UpdateCollegeTime(CollegeTime collegeTime);
    }
}
