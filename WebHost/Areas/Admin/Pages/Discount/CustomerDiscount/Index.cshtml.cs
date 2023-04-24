using DiscountManagment.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using ShopManagment.Application.Contract.Product;



namespace WebHost.Areas.Admin.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        public CustomerDiscountSearchModel searchModel;
        public List<CustomerDiscountViewModel> CustomerDiscounts { get; set; }
        public SelectList Products { get; set; }

        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(ICustomerDiscountApplication customerDiscountApplication, IProductApplication productApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var customerDiscount = new CreateCustomerDiscount
            {
                Products = _productApplication.GetProducts(),
            };
            return Partial("./Create", customerDiscount);
        }

        public JsonResult OnPostCreate(CreateCustomerDiscount command)
        {
           var result= _customerDiscountApplication.Create(command);
            
            return new JsonResult(result);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _customerDiscountApplication.GetDetails(id);
            command.Products = _productApplication.GetProducts();
            return Partial("./Edit",command);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);

        }

       

    }
}
