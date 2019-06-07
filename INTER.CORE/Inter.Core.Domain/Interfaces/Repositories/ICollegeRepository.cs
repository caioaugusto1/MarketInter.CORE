using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface ICollegeRepository : IRepository<College>
    {
        College GetByIdIncluedTimeCollege(int collegeId);
    }
}
