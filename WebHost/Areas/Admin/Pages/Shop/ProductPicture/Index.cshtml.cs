using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using ShopManagment.Application.Contract.Product;
using ShopManagment.Application.Contract.ProductCategory;
using ShopManagment.Application.Contract.ProductPicture;

namespace WebHost.Areas.Admin.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        public ProductPictureSearchModel searchModel;
        public List<ProductPictureViewModel> productPicture { get; set; }
        public SelectList Products { get; set; }

        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            productPicture = _productPictureApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
           var productPicture= new CreateProductPicture()
            {
               Products  = _productApplication.GetProducts(),              
            };
            return Partial("./Create", productPicture);
        }

        public JsonResult OnPostCreate(CreateProductPicture command)
        {
           var result= _productPictureApplication.Create(command);
            
            return new JsonResult(result);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _productPictureApplication.GetDetails(id);
            command.Products = _productApplication.GetProducts();
            return Partial("./Edit",command);
        }

        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);

        }

        public IActionResult OnGetRemove(long id)
        {
            _productPictureApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _productPictureApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
