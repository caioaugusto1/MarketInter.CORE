using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter.Core.Infra.Data.EntityConfig
{
    public class CulturalExchangeFIleUploadConfig : IEntityTypeConfiguration<CulturalExchangeFileUpload>
    {
        public void Configure(EntityTypeBuilder<CulturalExchangeFileUpload> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Note)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("CulturalExchangeFileUpload");
        }
    }
}
