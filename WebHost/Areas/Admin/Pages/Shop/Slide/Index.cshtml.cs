using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contract.slide;

namespace WebHost.Areas.Admin.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {
        public SlideSearchModel searchModel;
        public List<SlideViewModel> Slides { get; set; }

        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet(SlideSearchModel searchModel)
        {

            Slides = _slideApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
          
            return Partial("./Create", new CreateSlide());
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
           var result= _slideApplication.Create(command);
            
            return new JsonResult(result);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _slideApplication.GetDetails(id);
            
            return Partial("./Edit",command);
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);

        }

        public IActionResult OnGetRemove(long id)
        {
            _slideApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _slideApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
