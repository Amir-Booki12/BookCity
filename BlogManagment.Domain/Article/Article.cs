


using _01_Framework.Domain;
using BlogManagment.Domain.ArticleCategoryAgg;

namespace BlogManagment.Domain.Article
{
    public class Article:EntityBase
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDesctiption { get; private set; }
        public string CannicalAddress { get; private set; }
        public DateTime PublishDate { get; private set; }

        public long CategoryId { get; private set; }
        public ArticleCategory Category { get; private set; }

        public Article(string title, string description, string shortDescription, 
            string picture, string pictureAlt, string pictureTitle, string slug, string keyword,
            string metaDesctiption, string cannicalAddress, long categoryId, DateTime publishDate)
        {
            Title = title;
            Description = description;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keyword = keyword;
            MetaDesctiption = metaDesctiption;
            CannicalAddress = cannicalAddress;
            CategoryId = categoryId;
            PublishDate = publishDate;
        }

        public void Edit(string title, string description, string shortDescription,
           string picture, string pictureAlt, string pictureTitle, string slug, string keyword,
           string metaDesctiption, string cannicalAddress, long categoryId, DateTime publishDate)
        {
            Title = title;
            Description = description;
            ShortDescription = shortDescription;

            if(!string.IsNullOrWhiteSpace(Picture))
            Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keyword = keyword;
            MetaDesctiption = metaDesctiption;
            CannicalAddress = cannicalAddress;
            CategoryId = categoryId;
            PublishDate = publishDate;
        }
    }
}
