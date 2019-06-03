using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IEnvironmentService
    {
        void Add(Inter.Core.Domain.Entities.SystemEnvironment environment);

        Task<List<Inter.Core.Domain.Entities.SystemEnvironment>> GetAll();

        Inter.Core.Domain.Entities.SystemEnvironment GetById(int id);

        Task<Inter.Core.Domain.Entities.SystemEnvironment> GetByCode(string code);
        
        void Update(Inter.Core.Domain.Entities.SystemEnvironment environment);
    }
}
