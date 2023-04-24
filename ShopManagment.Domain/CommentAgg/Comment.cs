using _01_Framework.Domain;
using ShopManagment.Domain.ProductAgg;


namespace ShopManagment.Domain.CommentAgg
{
    public class Comment:EntityBase
    {
       

        public long ProductId { get; private set; }
        public string Massege { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public Product Product { get; private set; }

        public Comment(long productId, string massege, string email, string name)
        {
            ProductId = productId;
            Massege = massege;
            Email = email;
            Name = name;
        }

        public void Cancel()
        {
            IsCanceled = true;
            
        }
        public void Confirm()
        {
            IsConfirmed = true;
            
        }
    }
}
