using Inter.Core.Domain.Entities;
using static Inter.Core.Domain.Entities.College;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface ICollegeRepository : IRepository<College>
    {
        College GetCollegeTimeByCollegeId(int id);

        CollegeTime GetCollegeTimeById(int collegeTimeId);
    }
}
