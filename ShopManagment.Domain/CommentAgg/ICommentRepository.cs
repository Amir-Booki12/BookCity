using _01_Framework.Domain;
using ShopManagment.Application.Contract.Comment;

namespace ShopManagment.Domain.CommentAgg
{
    public interface ICommentRepository:IRepository<long,Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}
