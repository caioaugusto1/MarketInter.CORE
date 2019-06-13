using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICollegeTimeService
    {
        List<CollegeTime> GetAll(int idCollege);

        CollegeTime Add(CollegeTime collegeTime);

        void Delete(CollegeTime collegeTime);

        CollegeTime GetById(int id);

        CollegeTime Update(CollegeTime collegeTime);
    }
}
