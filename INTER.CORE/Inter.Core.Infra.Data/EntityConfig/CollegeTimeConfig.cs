﻿using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter.Core.Infra.Data.EntityConfig
{
    public class CollegeTimeConfig : IEntityTypeConfiguration<CollegeTime>
    {
        public void Configure(EntityTypeBuilder<CollegeTime> builder)
        {
            builder.HasOne(x => x.College)
                .WithMany(x => x.CollegeTime)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.BookPrice)
                .HasColumnType("decimal(6,4)");

            builder.ToTable("CollegeTime");

        }
    }
}
