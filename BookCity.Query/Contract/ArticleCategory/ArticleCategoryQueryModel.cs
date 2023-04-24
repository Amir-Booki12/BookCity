

using BookCity.Query.Contract.Article;

namespace BookCity.Query.Contract.ArticleCategory
{
    public class ArticleCategoryQueryModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string Keyword { get; set; }
        public List<string> KeywordList { get; set; }
        public string MetaDescription { get; set; }
        public string CannicalAddress { get; set; }
        public int ArticleCount { get; set; }
        public List<ArticlesQueryModel> Articles { get; set; }


    }
}
