using BlogManagment.Application.Contract.Article;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebHost.Areas.Admin.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel searchModel;
        public List<ArticleViewModel> Articles { get; set; }

        public SelectList ArticleCategories { get; set; }

        private readonly IArticleApplication _articleApplication;

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            Articles = _articleApplication.Search(searchModel);

            ArticleCategories = new SelectList(_articleApplication.articleCategories(),"Id","Name");
        }



    }
}
