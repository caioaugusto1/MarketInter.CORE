using Inter.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Domain.ServiceInterface
{
    public interface IStudentService 
    {
        Student Add(Environment environment, Student student);
        
        List<Student> GetAll(int idEnvironment);

        Student GetById(int idEnvironment, int id);

        Student Update(int idEnvironment, Student student);
    }
}
