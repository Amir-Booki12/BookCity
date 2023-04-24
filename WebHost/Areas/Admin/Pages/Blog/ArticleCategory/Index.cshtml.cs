using BlogManagment.Application.Contract.ArticleCategory;

using Microsoft.AspNetCore.Mvc.RazorPages;



namespace WebHost.Areas.Admin.Pages.Blog.ArticleCategory
{
    public class IndexModel : PageModel
    {
        public ArticleCategorySearchModel searchModel;
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ArticleCategories = _articleCategoryApplication.Search(searchModel);
        }



    }
}
