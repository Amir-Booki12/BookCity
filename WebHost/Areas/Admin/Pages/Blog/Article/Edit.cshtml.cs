using BlogManagment.Application.Contract.Article;
using BlogManagment.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebHost.Areas.Admin.Pages.Blog.Article
{
    public class EditModel : PageModel
    {

        private readonly IArticleApplication _articleApplication;

        public EditModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public EditArticle command { get; set; }
        public SelectList ArticleCategories { get; set; }
        public void OnGet(long id)
        {
            command= _articleApplication.GetDetails(id);
            ArticleCategories = new SelectList(_articleApplication.articleCategories(),"Id", "Name");
        }

        public IActionResult OnPost(EditArticle command)
        {
            var result = _articleApplication.Edit(command);

            return RedirectToPage("./Index");
        }
    }
}
