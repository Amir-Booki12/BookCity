using BookCity.Query.Contract.ProductCategory;
using BookCity.Query.Contract.Products;
using BookCity.Query.Contract.Slides;
using BookCity.Query.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ShopManagment.Application.Contract.Product;
using ShopManagment.Application.Contract.ProductCategory;
using ShopManagment.Application.Contract.ProductPicture;
using ShopManagment.Application.Contract.slide;
using ShopManagment.Application.Product;
using ShopManagment.Application.ProductCategory;
using ShopManagment.Application.ProductPicture;
using ShopManagment.Application.Slide;

using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Domain.ProductPicture;
using ShopManagment.Domain.SlideAgg;
using ShopManagment.Infrastucure.EfCore;
using ShopManagment.Infrastucure.EfCore.Repository;

namespace ShopManagment.Infrastucure.Configoration
{
    public class ShopManagmentBootsrapper
    {
        public static void Configure(IServiceCollection service,string connectionString)
        {
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductApplication, ProductApplication>();

            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();

            service.AddTransient<ISlideQuery, SlideQuery>();

            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            service.AddTransient<IProductQuery, ProductQuery>();

            service.AddTransient<ISlideRepository, SlideRepository>();
            service.AddTransient<ISlideApplication, SlideApplication>();

          

            service.AddDbContext<ShopContext>(x=>x.UseSqlServer(connectionString));
        }
    }
}