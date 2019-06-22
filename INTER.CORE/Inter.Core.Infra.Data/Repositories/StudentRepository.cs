using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inter.Core.Infra.Data.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private readonly DbContextOptions<MySQLContext> _OptionsBuilder;

        public StudentRepository()
        {
            _OptionsBuilder = new DbContextOptions<MySQLContext>();
        }

        public bool ValidationCustomerId(string customerId)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.Student.Any(x => x.CustomerId == customerId);
            }
        }
    }
}
