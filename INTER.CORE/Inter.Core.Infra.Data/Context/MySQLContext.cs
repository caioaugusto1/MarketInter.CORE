using Inter.Core.Domain.Entities;
using Inter.Core.Infra.Data.EntityConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inter.Core.Infra.Data.Context
{
    public class MySQLContext : IdentityDbContext<ApplicationUser>
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<SystemEnvironment> Environment { get; set; }
        public DbSet<College> College { get; set; }
        public DbSet<CollegeTime> CollegeTime { get; set; }
        public DbSet<CulturalExchange> CulturalExchange { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<CulturalExchangeFileUpload> CulturalExchangeFileUpload { get; set; }
        public DbSet<ReceivePaymentCulturalExchange> ReceivePaymentCulturalExchange { get; set; }
        public DbSet<PaymentCulturalExchange> PaymentCulturalExchange { get; set; }
        //public DbSet<Advisor> Advisor { get; set; }
        public DbSet<Accomodation> Accomodation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EnvironmentConfig());
        }

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
