using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using static Inter.Core.Domain.Entities.College;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICollegeService
    {
        College Add(SystemEnvironment environment, College college);

        List<College> GetAll(int idEnvironment);

        CollegeTime GetCollegeTimeById(int idCollegeTime);

        College GetById(int id);

        College GetCollegeTimeByCollegeId(int id);

        College Update(College college);
    }
}
