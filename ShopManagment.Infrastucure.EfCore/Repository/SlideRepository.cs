using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using ShopManagment.Application.Contract.slide;
using ShopManagment.Domain.SlideAgg;


namespace ShopManagment.Infrastucure.EfCore.Repository
{
    public class SlideRepository : Repository<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _shopContext;

        public SlideRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditSlide? GetDetails(long id)
        {
            return _shopContext.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                BtnText = x.BtnText,
                Header = x.Header,
                Title = x.Title,
                Link = x.Link,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> Search(SlideSearchModel searchModel)
        {
            var query = _shopContext.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Header = x.Header,
                Title = x.Title,
                Link = x.Link,
                Picture = x.Picture,
                IsRemove = x.IsRemove,
                CreationDate = x.CreationDate.ToFarsiFull()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Header))
                query = query.Where(x => x.Header.Contains(searchModel.Header));
            if (searchModel.IsRemove == true)
                query = query.Where(x => x.IsRemove == true);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
