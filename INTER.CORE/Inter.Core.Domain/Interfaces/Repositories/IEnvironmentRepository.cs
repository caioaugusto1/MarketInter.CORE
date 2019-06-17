using Inter.Core.Domain.Entities;
using System;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IEnvironmentRepository : IRepository<SystemEnvironment>
    {
        SystemEnvironment GetByCode(string code);

        SystemEnvironment GetEnvironmentByIdIncludeDependencys(Guid id);
    }
}
