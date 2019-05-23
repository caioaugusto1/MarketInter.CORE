using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Domain.ServiceInterface
{
    public interface IStudentService 
    {
        void Add(Student student);
        
        List<Student> GetAll();

        Student GetById(int id);

        Student Update(Student student);
    }
}
