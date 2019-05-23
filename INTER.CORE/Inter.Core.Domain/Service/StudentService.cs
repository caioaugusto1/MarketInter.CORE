
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.ServiceInterface;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Add(Student student)
        {
            _studentRepository.Insert(student);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public Student Update(Student student)
        {
            return _studentRepository.Update(student);
        }
    }
}
