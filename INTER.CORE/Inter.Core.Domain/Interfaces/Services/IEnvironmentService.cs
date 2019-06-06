using Inter.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IEnvironmentService
    {
        void Add(SystemEnvironment environment);

        List<SystemEnvironment> GetAll();

        SystemEnvironment GetById(int id);

        SystemEnvironment GetByCode(string code);

        SystemEnvironment GetStudentsNotEnroled(int idEnvironment);

        void Update(SystemEnvironment environment);
    }
}
