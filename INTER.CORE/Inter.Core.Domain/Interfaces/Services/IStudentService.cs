using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.ServiceInterface
{
    public interface IStudentService
    {
        Student Add(SystemEnvironment environment, Student student);

        List<Student> GetAll(int idEnvironment);

        List<Student> GetNotEnroled(int idEnvironment);
        
        Student GetById(int idEnvironment, int id);

        Student Update(int idEnvironment, Student student);

        void Delete(int id);
    }
}
