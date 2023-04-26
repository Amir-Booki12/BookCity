using CommentApplication.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace WebHost.Areas.Admin.Pages.Comment
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
