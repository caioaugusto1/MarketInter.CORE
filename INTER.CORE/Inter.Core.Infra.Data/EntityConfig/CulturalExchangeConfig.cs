using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter.Core.Infra.Data.EntityConfig
{
    public class CulturalExchangeConfig : IEntityTypeConfiguration<CulturalExchange>
    {
        public void Configure(EntityTypeBuilder<CulturalExchange> builder)
        {
            builder.Property(x => x.Company)
                .HasMaxLength(20);

            builder.Property(x => x.FlightNumber)
                .HasMaxLength(10);

            builder.Property(x => x.SalesMen)
                .IsRequired()
                .HasMaxLength(30);

            builder.ToTable("CulturalExchange");
        }
    }
}
