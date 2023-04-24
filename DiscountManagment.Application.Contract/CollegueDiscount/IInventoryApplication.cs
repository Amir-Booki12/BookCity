using _01_Framework.Application;

namespace DiscountManagment.Application.Contract.CollegueDiscount
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateCollegueDiscount command);
        OperationResult Edit(EditCollegueDiscount command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditCollegueDiscount GetDetails(long id);
        List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel);


    }
}
