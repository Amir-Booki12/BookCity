using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using ShopManagment.Application.Contract.Product;
using ShopManagment.Application.Contract.ProductCategory;

namespace WebHost.Areas.Admin.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel searchModel;
        public List<ProductViewModel> products { get; set; }
        public SelectList ProductCategories { get; set; }

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
           var product= new CreateProduct()
            {
                ProductsCategories = _productCategoryApplication.GetProductCategories(),              
            };
            return Partial("./Create", product);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
           var result= _productApplication.Create(command);
            
            return new JsonResult(result);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _productApplication.GetDetails(id);
            command.ProductsCategories = _productCategoryApplication.GetProductCategories();
            return Partial("./Edit",command);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);

        }

    }
}
