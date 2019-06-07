using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICollegeTimeService
    {
        List<CollegeTime> GetAll(int idCollege);

        CollegeTime Add(CollegeTime collegeTime);

        CollegeTime GetById(int id);

        CollegeTime Update(CollegeTime college);
    }
}
