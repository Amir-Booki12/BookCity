using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopManagment.Application.Contract.ProductCategory;

namespace WebHost.Areas.Admin.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel searchModel;
        public List<ProductCategoryViewModel> productCategories { get; set; }

        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            productCategories = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create",new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
           var result= _productCategoryApplication.Create(command);
            return new JsonResult(result);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _productCategoryApplication.GetDetails(id);

            return Partial("./Edit",command);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);

        }

    }
}
