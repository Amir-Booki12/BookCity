

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.CommentAgg;

namespace ShopManagment.Infrastucure.EfCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Email).HasMaxLength(400).IsRequired();
            builder.Property(x=>x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x=>x.Massege).HasMaxLength(1000).IsRequired();

            builder.HasOne(x=>x.Product)
                .WithMany(x=>x.Comments)
                .HasForeignKey(x=>x.ProductId);
        }
    }
}
