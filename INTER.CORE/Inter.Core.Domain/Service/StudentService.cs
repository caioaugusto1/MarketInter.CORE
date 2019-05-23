
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

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
            // regra de negócio aqui
            throw new NotImplementedException();
        }
    }
}
