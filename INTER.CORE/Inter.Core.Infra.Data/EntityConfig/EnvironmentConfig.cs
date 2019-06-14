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
