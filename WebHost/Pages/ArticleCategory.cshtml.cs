using BookCity.Query.Contract.Article;
using BookCity.Query.Contract.ArticleCategory;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {

        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly IArticleQuery _articleQuery;

        public ArticleCategoryModel(IArticleCategoryQuery articleCategoryQuery, IArticleQuery articleQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
            _articleQuery = articleQuery;
        }

        public ArticleCategoryQueryModel ArticleCategory { get; set; }

        public List<LatestArticleQueryModel> LatestArticles { get; set; }
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }

        public void OnGet(string id)
        {
            ArticleCategory = _articleCategoryQuery.GetArticleCategory(id);
            LatestArticles = _articleQuery.GetLatestArticels();
            ArticleCategories = _articleCategoryQuery.GetCategoriesForShow();
        }
    }
}
