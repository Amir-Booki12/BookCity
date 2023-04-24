

namespace BookCity.Query.Contract.Article
{
    public class ArticlesQueryModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string PublishDate { get; set; }    
        public string Description { get;  set; }   
        public string Keyword { get;  set; }
        public List<string> KeywordList { get;  set; }
        public string MetaDesctiption { get;  set; }
        public string CannicalAddress { get;  set; }    
        public long CategoryId { get;  set; }
        public string CategoryName { get;  set; }
    }
    
}
