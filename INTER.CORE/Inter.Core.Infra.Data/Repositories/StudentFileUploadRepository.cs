using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inter.Core.Infra.Data.Repositories
{
    public class StudentFileUploadRepository : RepositoryBase<StudentFileUpload>, IStudentFileUploadRepository
    {
        private readonly DbContextOptions<MySQLContext> _OptionsBuilder;

        public StudentFileUploadRepository()
        {
            _OptionsBuilder = new DbContextOptions<MySQLContext>();
        }

        public List<StudentFileUpload> GetAllByStudentId(int studentId)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.StudentFileUpload.Where(x => x.StudentId == studentId).ToList();
            }
        }
    }
}
