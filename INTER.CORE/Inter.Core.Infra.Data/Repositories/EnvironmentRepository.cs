using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inter.Core.Infra.Data.Repositories
{
    public class EnvironmentRepository : RepositoryBase<SystemEnvironment>, IEnvironmentRepository
    {
        private readonly DbContextOptions<MySQLContext> _OptionsBuilder;

        public EnvironmentRepository()
        {
            _OptionsBuilder = new DbContextOptions<MySQLContext>();
        }

        public SystemEnvironment GetByCode(string code)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.SystemEnvironment.FirstOrDefault(x => x.CompanyCode == code);
            }
        }
    }
}
