using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Inter.Core.Infra.Data.Repositories
{
    public class EnvironmentRepository : RepositoryBase<SystemEnvironment>, IEnvironmentRepository
    {
        private readonly DbContextOptions<ContextDB> _OptionsBuilder;

        public EnvironmentRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextDB>();
        }

        public async Task<Domain.Entities.SystemEnvironment> GetByCode(string code)
        {
            using (var db = new ContextDB(_OptionsBuilder))
            {
               var ect = await db.Environment.Include(x => x.Students).FirstOrDefaultAsync(x => x.Id == 1);
                return ect;
            }
        }
    }
}
