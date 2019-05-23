using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace Inter.Core.Infra.Data.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ContextDB context)
        {
        }

        public List<Student> GetAllNotEnroled()
        {
            throw new NotImplementedException();
        }
    }
}
