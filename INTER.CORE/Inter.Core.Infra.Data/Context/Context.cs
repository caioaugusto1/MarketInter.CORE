using Microsoft.EntityFrameworkCore;
using System;

namespace Inter.Core.Infra.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }


        public DbSet<Inter.Core.Domain.Entities.Environment> Environment { get; set; }
        public DbSet<Inter.Core.Domain.Entities.College> College { get; set; }
        public DbSet<Inter.Core.Domain.Entities.CulturalExchange> CulturalExchange { get; set; }
        public DbSet<Inter.Core.Domain.Entities.Student> Student { get; set; }
        public DbSet<Inter.Core.Domain.Entities.Advisor> Advisor { get; set; }
        public DbSet<Inter.Core.Domain.Entities.Accomodation> Accomodation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            // ambiene  de desenvolvimento
            string strCon = "Data Source=.\\SQLEXPRESS;Initial Catalog=INTERCORE;Integrated Security=True;";
            
            return strCon;
        }
    }
}
