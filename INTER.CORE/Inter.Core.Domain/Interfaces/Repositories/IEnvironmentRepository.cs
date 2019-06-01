using Inter.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IEnvironmentRepository : IRepository<Inter.Core.Domain.Entities.SystemEnvironment>
    {
        Task<SystemEnvironment> GetByCode(string code);
    }
}
