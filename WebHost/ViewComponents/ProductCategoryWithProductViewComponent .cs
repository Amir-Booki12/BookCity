using BookCity.Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.ViewComponents
{
    public class ProductCategoryWithProductViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryWithProductViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var productCategory = _productCategoryQuery.GetProductCategoryWithProduct();
            return View(productCategory);
        }
    }
}
