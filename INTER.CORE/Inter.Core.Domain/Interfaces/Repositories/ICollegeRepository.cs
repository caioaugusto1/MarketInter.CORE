using Inter.Core.Domain.Entities;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface ICollegeRepository : IRepository<College>
    {
        College GetCollegeTimeByCollegeId(int id);
    }
}
