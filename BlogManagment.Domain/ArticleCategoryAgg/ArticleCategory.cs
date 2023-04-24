

using _01_Framework.Domain;
using BlogManagment.Domain.Article;

namespace BlogManagment.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:EntityBase
    {
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDescription { get; private set; }
        public string CannicalAddress { get; private set; }
        public List<Article.Article> Articles { get; private set; }


        public ArticleCategory(string name, string shortDescription, string picture, string pictureAlt,
            string pictureTitle, string slug, string keyword, string metaDescription, string cannicalAddress)
        {
            Name = name;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keyword = keyword;
            MetaDescription = metaDescription;
            CannicalAddress = cannicalAddress;
        }
        public void Edit(string name, string shortDescription, string picture, string pictureAlt,
           string pictureTitle, string slug, string keyword, string metaDescription, string cannicalAddress)
        {
            Name = name;
            ShortDescription = shortDescription;

            if(!string.IsNullOrWhiteSpace(Picture)) 
            Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keyword = keyword;
            MetaDescription = metaDescription;
            CannicalAddress = cannicalAddress;
        }
    }
}
