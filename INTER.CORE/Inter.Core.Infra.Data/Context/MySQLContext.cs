using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inter.Core.Infra.Data.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
        {

        }

        public DbSet<SystemEnvironment> SystemEnvironment { get; set; }
        public DbSet<College> College { get; set; }
        public DbSet<CollegeTime> CollegeTime { get; set; }
        public DbSet<CulturalExchange> CulturalExchange { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Advisor> Advisor { get; set; }
        public DbSet<Accomodation> Accomodation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(GetStringConectionConfig());
            
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            return "server=localhost;database=INTERCORE;user=root;password=admin";
        }
    }
}
