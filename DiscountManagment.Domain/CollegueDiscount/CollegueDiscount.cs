

using _01_Framework.Domain;

namespace DiscountManagment.Domain.CollegueDiscount
{
    public class CollegueDiscount:EntityBase
    {
      
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }     
        public string Reason { get; private set; }
        public bool IsRemove { get; private set; }

        public CollegueDiscount(long productId, int discountRate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            Reason = reason;
        }
        public void Edit(long productId, int discountRate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            Reason = reason;
        }

        public void Remove()
        {
            IsRemove = true;
        }
        public void Restore()
        {
            IsRemove = false;
        }
    }
}
