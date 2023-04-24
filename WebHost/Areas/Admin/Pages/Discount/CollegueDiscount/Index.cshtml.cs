using DiscountManagment.Application.Contract.CollegueDiscount;
using DiscountManagment.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using ShopManagment.Application.Contract.Product;



namespace WebHost.Areas.Admin.Pages.Discount.CollegueDiscount
{
    public class IndexModel : PageModel
    {
        public CollegueDiscountSearchModel searchModel;
        public List<CollegueDiscountViewModel> CollegueDiscounts { get; set; }
        public SelectList Products { get; set; }

        private readonly IInventoryApplication _collegueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication, IInventoryApplication collegueDiscountApplication)
        {

            _productApplication = productApplication;
            _collegueDiscountApplication = collegueDiscountApplication;
        }

        public void OnGet(CollegueDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            CollegueDiscounts = _collegueDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var CollegueDiscount = new CreateCollegueDiscount
            {
                Products = _productApplication.GetProducts(),
            };
            return Partial("./Create", CollegueDiscount);
        }

        public JsonResult OnPostCreate(CreateCollegueDiscount command)
        {
           var result= _collegueDiscountApplication.Create(command);
            
            return new JsonResult(result);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _collegueDiscountApplication.GetDetails(id);
            command.Products = _productApplication.GetProducts();
            return Partial("./Edit",command);
        }

        public JsonResult OnPostEdit(EditCollegueDiscount command)
        {
            var result = _collegueDiscountApplication.Edit(command);
            return new JsonResult(result);

        }
        public IActionResult OnGetRemove(long id)
        {
            _collegueDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _collegueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }



    }
}
