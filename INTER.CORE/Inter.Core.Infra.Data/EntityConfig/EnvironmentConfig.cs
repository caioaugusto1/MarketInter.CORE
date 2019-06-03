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

            builder.Property(x => x.Company)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnType("varchar");
            
            builder.ToTable("Environment");
        }
    }
}
