using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Presentation.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Infra.Data.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Student> GetAllNotEnroled()
        {
            throw new NotImplementedException();
        }
    }
}
