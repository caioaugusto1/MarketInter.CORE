﻿using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Core.Infra.Data.Context
{
    public class MySQLContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
            : base(options)
        {

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
        public DbSet<Destination> Destination { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new EnvironmentConfig());
            builder.ApplyConfiguration(new CulturalExchangeConfig());
            builder.ApplyConfiguration(new StudentConfig());
            builder.ApplyConfiguration(new CollegeTimeConfig());
            builder.ApplyConfiguration(new AccomodationConfig());
            builder.ApplyConfiguration(new CollegeConfig());
            builder.ApplyConfiguration(new CulturalExchangeFIleUploadConfig());
            builder.ApplyConfiguration(new PaymentCulturalExchangeConfig());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(GetStringConectionConfig());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            //return "server=intercore.mysql.database.azure.com;database=INTERCORE;user=intercore@intercore;password=U8Hw2n<nZr#RrN@<";
            return "server=localhost;database=INTERCORE;user=root;password=admin";
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(en => en.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
