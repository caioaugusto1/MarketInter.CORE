using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICollegeTimeService
    {
        List<CollegeTime> GetAll(Guid idCollege);

        CollegeTime Add(CollegeTime collegeTime);

        void Delete(CollegeTime collegeTime);

        CollegeTime GetById(Guid id);

        CollegeTime Update(CollegeTime collegeTime);
    }
}
