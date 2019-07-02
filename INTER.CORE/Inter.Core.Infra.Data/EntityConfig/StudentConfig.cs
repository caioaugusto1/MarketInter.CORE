using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter.Core.Infra.Data.EntityConfig
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Environment)
                .WithMany(x => x.Students)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CustomerId)
               .IsRequired()
               .HasMaxLength(10);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasMaxLength(6);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.MobileNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.PassportNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.ToTable("Student");
        }
    }
}
