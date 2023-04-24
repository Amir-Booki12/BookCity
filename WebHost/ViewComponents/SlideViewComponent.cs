using BookCity.Query.Contract.Slides;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.ViewComponents
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

       
        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
           var slide = _slideQuery.GetSlides();
            return View(slide);
        }
    }
}
