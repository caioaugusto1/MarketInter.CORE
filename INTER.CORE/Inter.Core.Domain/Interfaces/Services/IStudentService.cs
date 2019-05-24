using Inter.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Domain.ServiceInterface
{
    public interface IStudentService 
    {
        Student Add(Student student);
        
        List<Student> GetAll();

        Student GetById(int id);

        Student Update(Student student);
    }
}
