
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.ServiceInterface;
using Inter.Core.Domain.Specification.Student;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Inter.Core.Domain.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICulturalExchangeFileUploadRepository _studentFileUploadRepository;
        private readonly IEnvironmentRepository _environmentRepository;

        public StudentService(IStudentRepository studentRepository, IEnvironmentRepository environmentRepository, ICulturalExchangeFileUploadRepository studentFileUploadRepository)
        {
            _studentRepository = studentRepository;
            _environmentRepository = environmentRepository;
            _studentFileUploadRepository = studentFileUploadRepository;
        }

        public Student Add(SystemEnvironment environment, Student student)
        {
            student.Environment = environment;

            student.ValidationResult = new List<ValidationResult>();

            bool studentOver18YearsOld = new StudentOver18YearsOld()
                .IsSatisfiedBy(student);

            if (!studentOver18YearsOld)
                student.ValidationResult.Add(new ValidationResult("Student Under 18 years old"));

            if (!student.ValidationResult.Any())
            {
                environment.Students.Add(student);
                _studentRepository.Insert(student);
            }

            return student;
        }

        public void Delete(int id)
        {
            var studentEntity = _studentRepository.GetById(id);

            _studentRepository.Delete(studentEntity);
        }

        public List<Student> GetAll(int idEnvironment)
        {
            return _studentRepository.FindByFilter(x => x.EnvironmentId == idEnvironment);
        }

        public Student GetById(int idEnvironment, int id)
        {
            return _studentRepository.GetById(id);
        }

        public List<Student> GetNotEnroled(int idEnvironment)
        {
            List<Student> students = new List<Student>();
            var environment = _environmentRepository.GetEnvironmentByIdIncludeDependencys(idEnvironment);

            environment.Students.ForEach(student =>
            {
                if (environment.CulturalExchange.FirstOrDefault(culturalExchange => culturalExchange.StudentId == student.Id) == null)
                {
                    students.Add(student);
                }
            });

            return students;
        }

        public Student Update(int idEnvironment, Student student)
        {
            return _studentRepository.Update(student);
        }
    }
}
