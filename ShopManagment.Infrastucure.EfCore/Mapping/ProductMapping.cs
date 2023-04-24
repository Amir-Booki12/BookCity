using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastucure.EfCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x=>x.Code).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.Description).IsRequired();
            builder.Property(x=>x.Picture).HasMaxLength(800);
            builder.Property(x=>x.PictureTitle).HasMaxLength(300);
            builder.Property(x=>x.PictureAlt).HasMaxLength(300);
            builder.Property(x=>x.ShortDescription).HasMaxLength(300).IsRequired();
            builder.Property(x=>x.Slug).HasMaxLength(300).IsRequired();
            builder.Property(x=>x.MetaDescription).HasMaxLength(300).IsRequired();
            builder.Property(x=>x.Keyword).HasMaxLength(80).IsRequired();
            
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x=>x.productPictures)
                .WithOne(x=>x.product)
                .HasForeignKey(x=>x.ProductId);

            builder.HasMany(x=>x.Comments)
                .WithOne(x=>x.Product)
                .HasForeignKey(x=>x.ProductId);
            
        }
    }
}
