using BookCity.Query.Contract.Article;
using BookCity.Query.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    
    public class ArticleModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public ArticlesQueryModel Article { get; set; }
        public List<LatestArticleQueryModel> LatestArticles { get; set; }
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public void OnGet(string id)
        {
            Article = _articleQuery.GetDetails(id);
            LatestArticles = _articleQuery.GetLatestArticels();
            ArticleCategories = _articleCategoryQuery.GetCategoriesForShow();
        }
    }
}
