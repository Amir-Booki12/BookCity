using BookCity.Query.Contract.Article;
using BookCity.Query.Contract.ArticleCategory;
using CommentApplication.Application.Contracts.Comment;
using CommentManagment.Infrastucure.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    
    public class ArticleModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
            _commentApplication = commentApplication;
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


        public IActionResult OnPost(AddComment commend, string articleSlug)
        {
            commend.Type = CommentType.Article;
            var result = _commentApplication.Add(commend);

            return RedirectToPage("./Article", new { Id = articleSlug });
        }
    }
}
