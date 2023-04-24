
using _01_Framework.Application;

namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Create(CreateCustomerDiscount Command);
        OperationResult Edit(EditCustomerDiscount Command);
        EditCustomerDiscount GetDetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);


    }
}
