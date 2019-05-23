using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IEnvironmentService
    {
        void Add(Inter.Core.Domain.Entities.Environment environment);

        Task<List<Inter.Core.Domain.Entities.Environment>> GetAll();

        Inter.Core.Domain.Entities.Environment GetById(int id);

        Inter.Core.Domain.Entities.Environment GetByCode(string code);
        
        void Update(Inter.Core.Domain.Entities.Environment environment);
    }
}
