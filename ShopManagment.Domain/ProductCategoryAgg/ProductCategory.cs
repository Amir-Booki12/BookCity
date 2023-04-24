using _01_Framework.Domain;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string Description { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public string Slug { get; private set; }
        public string MetaDescraption { get; private set; }
        public string Keywords { get; private set; }
        public List<Product> Products { get; private set; }


        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public ProductCategory(string name, string picture, string pictureTitle, string pictureAlt, string slug,
            string metaDescraption, string keywords, string description)
        {
            Name = name;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Slug = slug;
            MetaDescraption = metaDescraption;
            Keywords = keywords;
            Description = description;
        }

        public void Edit(string name, string picture, string pictureTitle, string pictureAlt, string slug, 
            string metaDescraption, string keywords, string description)
        {
            Name = name;
            if(!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Slug = slug;
            MetaDescraption = metaDescraption;
            Keywords = keywords;
            Description = description;
        }
    }
}
