using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inter.Core.Infra.Data.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB()
        {

        }

        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        
        public DbSet<Inter.Core.Domain.Entities.Environment> Environment { get; set; }
        public DbSet<College> College { get; set; }
        public DbSet<CulturalExchange> CulturalExchange { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Advisor> Advisor { get; set; }
        public DbSet<Accomodation> Accomodation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            // ambiene  de desenvolvimento
            string strCon = "Data Source=.\\SQLEXPRESS;Initial Catalog=INTERCORE;Integrated Security=True;MultipleActiveResultSets=true;";
            
            return strCon;
        }
    }
}
