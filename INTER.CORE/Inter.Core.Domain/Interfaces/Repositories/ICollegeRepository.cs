using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface ICollegeRepository : IRepository<College>
    {
        College GetByIdIncluedTimeCollege(Guid collegeId);
    }
}
