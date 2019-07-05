using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter.Core.Infra.Data.EntityConfig
{
    public class PaymentCulturalExchangeConfig : IEntityTypeConfiguration<PaymentCulturalExchange>
    {
        public void Configure(EntityTypeBuilder<PaymentCulturalExchange> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Note)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
