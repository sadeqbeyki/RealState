﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.Domain.Entities.SlideAgg;

namespace RS.Infrastructure.Configurations;

public class SlideConfig : IEntityTypeConfiguration<Slide>
{
    public void Configure(EntityTypeBuilder<Slide> builder)
    {
        builder.ToTable("Slides");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Picture).HasMaxLength(500).IsRequired();
        builder.Property(x => x.PictureAlt).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Heading).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(255);
        builder.Property(x => x.Text).HasMaxLength(255);
        builder.Property(x => x.BtnText).HasMaxLength(50).IsRequired();
    }
}
