using BlogManagment.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Admin.Pages.Blog.ArticleCategory
{
   
    public class CreateModel : PageModel
    { 
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public CreateArticleCategory command { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateArticleCategory command)
        { 
            var result = _articleCategoryApplication.Create(command);

            return RedirectToPage("./Index");
        }
    }
}
