using Inter.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Inter.Core.Presentation.Models;

namespace Inter.Core.Presentation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Inter.Core.Domain.Entities.Environment> Environment { get; set; }
        public DbSet<Inter.Core.Domain.Entities.College> College { get; set; }
        public DbSet<Inter.Core.Domain.Entities.CulturalExchange> CulturalExchange { get; set; }
        public DbSet<Inter.Core.Domain.Entities.Student> Student { get; set; }
        public DbSet<Inter.Core.Domain.Entities.Advisor> Advisor { get; set; }
        public DbSet<Inter.Core.Domain.Entities.Accomodation> Accomodation { get; set; }
        
    }
}
