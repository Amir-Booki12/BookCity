
using _01_Framework.Application;

namespace ShopManagment.Application.Contract.slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditSlide GetDetails(long id);
        List<SlideViewModel> Search(SlideSearchModel searchModel);
    }
}
