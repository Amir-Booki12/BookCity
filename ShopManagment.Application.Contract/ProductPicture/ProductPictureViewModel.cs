namespace ShopManagment.Application.Contract.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public bool IsRemove { get; set; }
        public string CreationDate { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }

    }
}
