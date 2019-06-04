using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inter.Core.Infra.Data.Repositories
{
    public class CollegeRepository : RepositoryBase<College>, ICollegeRepository
    {
        private readonly DbContextOptions<MySQLContext> _OptionsBuilder;

        public CollegeRepository()
        {
            _OptionsBuilder = new DbContextOptions<MySQLContext>();
        }

        public College GetCollegeTimeByCollegeId(int id)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.Set<College>().Include(x => x.TimeCollege).FirstOrDefault();
            }
        }
    }
}
