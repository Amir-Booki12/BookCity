

using BlogManagment.Domain.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagment.Infrastucure.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x=>x.Description).IsRequired(false);
            builder.Property(x=>x.ShortDescription).IsRequired(false).HasMaxLength(600);
            builder.Property(x=>x.Picture).IsRequired(false).HasMaxLength(600);
            builder.Property(x=>x.PictureAlt).IsRequired(false).HasMaxLength(250);
            builder.Property(x=>x.PictureTitle).IsRequired(false).HasMaxLength(250);
            builder.Property(x=>x.Slug).IsRequired().HasMaxLength(320);
            builder.Property(x=>x.MetaDesctiption).IsRequired(false).HasMaxLength(600);
            builder.Property(x=>x.Keyword).IsRequired(false).HasMaxLength(600);
            builder.Property(x=>x.CannicalAddress).IsRequired(false).HasMaxLength(600);


            builder.HasOne(x=>x.Category)
                .WithMany(x=>x.Articles)
                .HasForeignKey(x=>x.CategoryId);
        }
    }
}
