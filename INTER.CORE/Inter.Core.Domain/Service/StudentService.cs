
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.ServiceInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student Add(Environment environment, Student student)
        {
            student.Environment = environment;
            
            return _studentRepository.Insert(student);
        }

        public List<Student> GetAll(int idEnvironment)
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int idEnvironment, int id)
        {
            return _studentRepository.GetById(id);
        }

        public Student Update(int idEnvironment, Student student)
        {
            return _studentRepository.Update(student);
        }
    }
}
