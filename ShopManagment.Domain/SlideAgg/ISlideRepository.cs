using _01_Framework.Domain;
using ShopManagment.Application.Contract.slide;

namespace ShopManagment.Domain.SlideAgg
{
    public interface ISlideRepository:IRepository<long,Slide>
    {
        EditSlide? GetDetails(long id);
        List<SlideViewModel> Search(SlideSearchModel searchModel);
    }
}
