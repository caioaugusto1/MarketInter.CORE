using System;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IEnvironmentRepository : IRepository<Inter.Core.Domain.Entities.Environment>
    {
        Task<Inter.Core.Domain.Entities.Environment> GetByCode(string code);
    }
}
