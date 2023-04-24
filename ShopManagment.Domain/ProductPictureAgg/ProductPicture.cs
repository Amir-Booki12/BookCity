using _01_Framework.Domain;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Domain.ProductPictureAgg
{
    public class ProductPicture:EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemove { get; private set; }

        public long ProductId { get; private set; }

        public Product product { get; private set; }

        public ProductPicture(string picture, string pictureAlt, string pictureTitle, long productId)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ProductId = productId;
            IsRemove = false;
        }

        public void Edit(string picture, string pictureAlt, string pictureTitle, long productId)
        {
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ProductId = productId;
        }

        public void Remove()
        {
            IsRemove = true;
        }
        public void Restore()
        {
            IsRemove=false;
        }

    }
}
