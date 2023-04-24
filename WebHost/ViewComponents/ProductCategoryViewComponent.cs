using BookCity.Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.ViewComponents
{
    public class ProductCategoryViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var productCategory = _productCategoryQuery.GetProductCategory();
            return View(productCategory);
        }
    }
}
