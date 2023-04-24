using BookCity.Query.Contract.Slides;
using ShopManagment.Infrastucure.EfCore;

namespace BookCity.Query.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryViewModel> GetSlides()
        {
            return _context.Slides.Select(x => new SlideQueryViewModel
            {
                BtnText = x.BtnText,
                Header = x.Header,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Link = x.Link,
                Title = x.Title,

            }).ToList();

        }
    }
}
