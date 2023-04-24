namespace DiscountManagment.Application.Contract.CollegueDiscount
{
    public class CollegueDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemove { get; set; }

    }
}
