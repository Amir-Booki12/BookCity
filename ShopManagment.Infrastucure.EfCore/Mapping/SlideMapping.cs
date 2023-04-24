using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastucure.EfCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Picture).HasMaxLength(700);
            builder.Property(x=>x.PictureTitle).HasMaxLength(700).IsRequired();
            builder.Property(x=>x.PictureAlt).HasMaxLength(700).IsRequired();
            builder.Property(x=>x.Text).HasMaxLength(250).IsRequired();
            builder.Property(x=>x.Header).HasMaxLength(250).IsRequired();
            builder.Property(x=>x.BtnText).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Title).HasMaxLength(250).IsRequired();
            builder.Property(x=>x.Link).HasMaxLength(400).IsRequired();
        }
    }
}
