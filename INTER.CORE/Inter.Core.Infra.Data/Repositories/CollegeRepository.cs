using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Inter.Core.Domain.Entities.College;

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

        public CollegeTime GetCollegeTimeById(int collegeTimeId)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.Set<CollegeTime>().FirstOrDefault(x => x.Id == collegeTimeId);
            }
        }

        public CollegeTime UpdateCollegeTime(CollegeTime collegeTime)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                var entity = db.CollegeTime.Update(collegeTime);
                db.SaveChanges();

                return entity.Entity;
            }
        }
    }
}
