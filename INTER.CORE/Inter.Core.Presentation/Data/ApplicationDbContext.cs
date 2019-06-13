using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inter.Core.Presentation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SystemEnvironment> Environment { get; set; }
        public DbSet<College> College { get; set; }
        public DbSet<CulturalExchange> CulturalExchange { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Advisor> Advisor { get; set; }
        public DbSet<Accomodation> Accomodation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfiguration(new EnvironmentConfig());
        }
    }
}
