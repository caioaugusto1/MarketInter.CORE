using Inter.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Domain.ServiceInterface
{
    public interface IStudentService 
    {
        void Add(Student student);
        
        Task<List<Student>> GetAll();

        Student GetById(int id);

        void Update(Student student);
    }
}
