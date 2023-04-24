
using BlogManagment.Application;
using BlogManagment.Application.Contract.Article;
using BlogManagment.Application.Contract.ArticleCategory;
using BlogManagment.Domain.Article;
using BlogManagment.Domain.ArticleCategoryAgg;
using BlogManagment.Infrastucure.EfCore;
using BlogManagment.Infrastucure.EfCore.Repository;
using BookCity.Query.Contract.Article;
using BookCity.Query.Contract.ArticleCategory;
using BookCity.Query.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagment.Infrastucure.Configuration
{
    public class BlogManagmentBootsrapper
    {
        public static void Configure(IServiceCollection services,string connenctionString)
        {
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();


            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();


            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

            services.AddDbContext<BlogContext>(x=>x.UseSqlServer(connenctionString));
        }
    }
}
