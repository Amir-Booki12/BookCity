using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using CommentApplication.Application.Contracts.Comment;
using CommentManagment.Domain.CommentAgg;
using CommentManagment.Infrastucure.EfCore;




namespace ShopManagment.Infrastucure.EfCore.Repository
{
    public class CommentRepository : Repository<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _commentContext;

        public CommentRepository(CommentContext commentContext) : base(commentContext)
        {
            _commentContext = commentContext;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _commentContext.Comments.Select(x => new CommentViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Massege = x.Massege,
                Name = x.Name,
                IsCanceled = x.IsCanceled,
                IsConfirmed = x.IsConfirmed,
                Website = x.Website,
                OwnerRecordId = x.OwnerRecordId,
                 
                CommentDate = x.CreationDate.ToFarsi()

            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}

