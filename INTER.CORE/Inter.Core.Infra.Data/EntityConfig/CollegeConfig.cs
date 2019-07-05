using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter.Core.Infra.Data.EntityConfig
{
    public class CollegeConfig : IEntityTypeConfiguration<College>
    {
        public void Configure(EntityTypeBuilder<College> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Environment)
                .WithMany(x => x.Colleges)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Address)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.City)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.Country)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

            builder.Property(x => x.ContactName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(40);

            builder.ToTable("College");
        }
    }
}
