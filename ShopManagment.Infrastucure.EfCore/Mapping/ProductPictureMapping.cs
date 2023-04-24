using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductPictureAgg;

namespace ShopManagment.Infrastucure.EfCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Picture).HasMaxLength(800).IsRequired();
            builder.Property(x=>x.PictureAlt).HasMaxLength(400).IsRequired();
            builder.Property(x=>x.PictureTitle).HasMaxLength(400).IsRequired();

            builder.HasOne(x=>x.product)
                .WithMany(x=>x.productPictures)
                .HasForeignKey(x=>x.ProductId);
            
        }
    }
}
