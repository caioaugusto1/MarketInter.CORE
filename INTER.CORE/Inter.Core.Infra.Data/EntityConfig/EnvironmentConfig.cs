using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter.Core.Infra.Data.EntityConfig
{
    public class EnvironmentConfig : IEntityTypeConfiguration<SystemEnvironment>
    {
        public void Configure(EntityTypeBuilder<SystemEnvironment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Accomodations)
                .WithOne(x => x.Environment)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Environment)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Students)
            .WithOne(x => x.Environment)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Colleges)
                .WithOne(x => x.Environment)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CulturalExchange)
                .WithOne(x => x.Environment)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ReceivePaymentsCulturalExchanges)
                .WithOne(x => x.Environment)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CompanyCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.ToTable("Environment");
        }
    }
}
