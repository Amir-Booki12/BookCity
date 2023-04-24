

namespace BookCity.Query.Contract.Article
{
    public class LatestArticleQueryModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string PublishDate { get; set; }  
    }
    
}
