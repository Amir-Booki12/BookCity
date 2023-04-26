using _01_Framework.Domain;

using ShopManagment.Domain.ProductCategoryAgg;


namespace ShopManagment.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        public Product()
        {
            productPictures = new List<ProductPictureAgg.ProductPicture>();
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
      
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public string Slug { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDescription { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }

        public List<ProductPictureAgg.ProductPicture> productPictures { get; private set; }
       

        public Product(string name, string code, string description, string shortDescription, 
            string picture, string pictureTitle, string pictureAlt, string slug, string keyword, 
            string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
          
            Description = description;
            ShortDescription = shortDescription;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Slug = slug;
            Keyword = keyword;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }
        public void Edit(string name, string code, string description, string shortDescription,
           string picture, string pictureTitle, string pictureAlt, string slug, string keyword,
           string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
          
            Description = description;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Slug = slug;
            Keyword = keyword;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }
    }
}
