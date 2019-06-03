using Inter.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetAllNotEnroled();
    }
}
