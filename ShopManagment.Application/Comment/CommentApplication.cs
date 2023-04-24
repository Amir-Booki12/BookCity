

using _01_Framework.Application;
using ShopManagment.Application.Contract.Comment;
using ShopManagment.Domain.CommentAgg;


namespace ShopManagment.Application.Comment
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult Add(AddComment command)
        {
            var operation = new OperationResult();
            var comment = new Domain.CommentAgg.Comment(command.ProductId, command.Massege,
                command.Email, command.Name);

            _commentRepository.Add(comment);
            _commentRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.GetBy(id);
            if (comment == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            comment.Cancel();
            _commentRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.GetBy(id);
            if (comment == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            comment.Confirm();
            _commentRepository.Save();
            return operation.Succedded();
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            return _commentRepository.Search(searchModel);
        }
    }
}
