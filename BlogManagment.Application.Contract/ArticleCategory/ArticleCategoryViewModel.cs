namespace BlogManagment.Application.Contract.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public int ArticleCount { get; set; }
    }
}
