

using BlogManagment.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagment.Infrastucure.EfCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.Id);  

            builder.Property(x=>x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x=>x.Picture).HasMaxLength(800).IsRequired(false);
            builder.Property(x => x.PictureAlt).HasMaxLength(800).IsRequired(false);
            builder.Property(x => x.PictureTitle).HasMaxLength(800).IsRequired(false);
            builder.Property(x => x.ShortDescription).HasMaxLength(350).IsRequired(false);
            builder.Property(x=>x.Slug).HasMaxLength(350).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(400).IsRequired(false);
            builder.Property(x => x.Keyword).HasMaxLength(100).IsRequired();
            builder.Property(x => x.CannicalAddress).HasMaxLength(700).IsRequired(false);


            builder.HasMany(x=>x.Articles)
                .WithOne(x=>x.Category)
                .HasForeignKey(x=>x.CategoryId);


        }
    }
}
