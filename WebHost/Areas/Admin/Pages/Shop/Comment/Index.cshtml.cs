using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contract.Comment;


namespace WebHost.Areas.Admin.Pages.Shop.Comment
{
    public class IndexModel : PageModel
    {
        public CommentSearchModel searchModel { get; set; }
        public List<CommentViewModel> Comments { get; set; }

        private readonly ICommentApplication _commentApplication;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet(CommentSearchModel searchModel)
        {

            Comments = _commentApplication.Search(searchModel);
        }
        public IActionResult OnGetCancel(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./Index");
        }

    }
}
