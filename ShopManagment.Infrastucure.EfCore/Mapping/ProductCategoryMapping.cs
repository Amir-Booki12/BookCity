using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastucure.EfCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(800).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(600).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(600).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(600).IsRequired();
            builder.Property(x => x.MetaDescraption).HasMaxLength(600).IsRequired();
            builder.Property(x => x.Keywords).HasMaxLength(80).IsRequired();
           
            builder.HasMany(x=>x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
