

using CommentApplication.Application.Contracts.Comment;

using CommentManagment.Domain.CommentAgg;
using CommentManagment.Infrastucure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Infrastucure.EfCore.Repository;

namespace CommentManagment.Infrastucure.Configuration
{
    public class CommentManagmentBootsrapper
    {
        public static void Configure(IServiceCollection service,string connecttionString)
        {
            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<ICommentApplication, CommentApplication.Application.Comment.CommentApplication>();


            service.AddDbContext<CommentContext>(x=>x.UseSqlServer(connecttionString));
        }
    }
}
