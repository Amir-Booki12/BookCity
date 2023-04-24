using BlogManagment.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Admin.Pages.Blog.ArticleCategory
{
    public class EditModel : PageModel
    {

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public EditArticleCategory command { get; set; }
        public void OnGet(long id)
        {
            command=_articleCategoryApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditArticleCategory command)
        {
            var result = _articleCategoryApplication.Edit(command);

            return RedirectToPage("./Index");
        }
    }
}
