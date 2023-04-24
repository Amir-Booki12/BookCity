
using _01_Framework.Domain;
using DiscountManagment.Application.Contract.CustomerDiscount;

namespace DiscountManagment.Domain.CustomerDiscount
{
    public interface ICustomerDiscountRepository:IRepository<long,CustomerDiscount>
    {
        EditCustomerDiscount? GetDetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}
