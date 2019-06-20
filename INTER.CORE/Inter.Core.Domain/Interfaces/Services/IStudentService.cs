using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        Student Add(SystemEnvironment environment, Student student);

        List<Student> GetAll(Guid idEnvironment);

        List<Student> GetNotEnroled(Guid idEnvironment);
        
        Student GetById(Guid idEnvironment, Guid id);

        Student Update(Guid idEnvironment, Student student);

        void Delete(Guid id);
    }
}
