using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.CommentAgg;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Domain.ProductPictureAgg;
using ShopManagment.Domain.SlideAgg;
using ShopManagment.Infrastucure.EfCore.Mapping;


namespace ShopManagment.Infrastucure.EfCore
{
    public class ShopContext:DbContext
    {
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductPicture> productPictures { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
