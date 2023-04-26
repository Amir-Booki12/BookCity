

namespace BookCity.Query.Contract.Products
{
    public class ProductQueryModel
    {
        public long Id  { get; set; }
        public string Name  { get; set; }
        public string Picture  { get; set; }
        public string PictureTitle  { get; set; }
        public string PictureAlt  { get; set; }
        public int DiscountRate  { get; set; }
        public string price  { get; set; }
        public string priceWithDiscount  { get; set; }
        public string Category  { get; set; }
        public string CategorySlug  { get; set; }
        public string Slug  { get; set; }
        public string Keywords  { get; set; }
        public string Description  { get; set; }
        public string ShortDescription  { get; set; }
        public string ExpireDate { get; set; }
        public string Code { get; set; }
        public bool HasDicount  { get; set; }
        public bool IsInStock  { get; set; }

        public List<PictureProducts> Pictures { get; set; }
        public List<CommentProduct> Comments { get; set; }
    }


    public class PictureProducts
    {
        public long Id { get; set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public long ProductId { get;  set; }
    }

    public class CommentProduct
    {
        public long OwnerRecordId { get;  set; }
        public long Id { get;  set; }
        public string Massege { get;  set; }
        public string Email { get;  set; }
        public string Name { get;  set; }
        public string CreationDate { get;  set; }
        public string ParentName{ get;  set; }
        public long? ParentId{ get;  set; }
    }
    
}
