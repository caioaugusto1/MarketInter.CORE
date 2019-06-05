using Inter.Core.Domain.Entities;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IEnvironmentRepository : IRepository<SystemEnvironment>
    {
        SystemEnvironment GetByCode(string code);
    }
}
