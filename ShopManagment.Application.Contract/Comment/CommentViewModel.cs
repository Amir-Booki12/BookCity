

namespace ShopManagment.Application.Contract.Comment
{
    public class CommentViewModel
    {
        public long ProductId { get; set; }
        public long Id { get; set; }
        public string Massege { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CommentDate { get; set; }
        public string ProductName { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }

    }
}
