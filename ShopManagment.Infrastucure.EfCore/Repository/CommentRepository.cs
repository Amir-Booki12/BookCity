using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contract.Comment;
using ShopManagment.Domain.CommentAgg;


namespace ShopManagment.Infrastucure.EfCore.Repository
{
    public class CommentRepository : Repository<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _shopContext;

        public CommentRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _shopContext.Comments.Include(x => x.Product).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Massege = x.Massege,
                Name = x.Name,
                IsCanceled = x.IsCanceled,
                IsConfirmed = x.IsConfirmed,
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                CommentDate = x.CreationDate.ToFarsi()

            });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query=query.Where(x=>x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));

            return query.OrderByDescending(x=>x.Id).ToList();   
        }
    }
}

