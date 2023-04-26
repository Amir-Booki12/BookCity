using _01_Framework.Domain;
using CommentApplication.Application.Contracts.Comment;

namespace CommentManagment.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}
