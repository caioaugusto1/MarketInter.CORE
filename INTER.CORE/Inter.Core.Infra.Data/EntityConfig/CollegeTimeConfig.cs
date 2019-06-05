using Inter.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static Inter.Core.Domain.Entities.College;

namespace Inter.Core.Infra.Data.EntityConfig
{
    public class CollegeTimeConfig : IEntityTypeConfiguration<CollegeTime>
    {
        public void Configure(EntityTypeBuilder<CollegeTime> builder)
        {
            builder.Property(x => x.BookPrice)
                .HasColumnType("decimal(6,4)");
                
        }
    }
}
