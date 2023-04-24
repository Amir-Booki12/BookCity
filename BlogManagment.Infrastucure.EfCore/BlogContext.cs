
using BlogManagment.Domain.Article;
using BlogManagment.Domain.ArticleCategoryAgg;
using BlogManagment.Infrastucure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BlogManagment.Infrastucure.EfCore
{
    public class BlogContext:DbContext
    {

        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
