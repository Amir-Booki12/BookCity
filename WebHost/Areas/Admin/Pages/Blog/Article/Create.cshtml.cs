using BlogManagment.Application.Contract.Article;
using BlogManagment.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebHost.Areas.Admin.Pages.Blog.Article
{
   
    public class CreateModel : PageModel
    { 
        private readonly IArticleApplication _articleApplication;

        public CreateModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public CreateArticle command { get; set; }
        public SelectList ArticleCategories { get; set; }


        public void OnGet()
        {

            ArticleCategories = new SelectList(_articleApplication.articleCategories(),"Id","Name");
  
        }

        public IActionResult OnPost(CreateArticle command)
        { 
            var result = _articleApplication.Create(command);

            
            return RedirectToPage("./Index");
        }
    }
}
