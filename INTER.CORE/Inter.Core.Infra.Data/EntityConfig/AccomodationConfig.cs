using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter.Core.Infra.Data.EntityConfig
{
    public class AccomodationConfig : IEntityTypeConfiguration<Accomodation>
    {
        public void Configure(EntityTypeBuilder<Accomodation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Identifier)
             .IsRequired()
             .HasMaxLength(30);

            builder.Property(x => x.Address)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(x => x.ContactName)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(x => x.ContactNumber)
             .IsRequired()
             .HasMaxLength(13);

            builder.ToTable("Accomodation");

        }
    }
}
