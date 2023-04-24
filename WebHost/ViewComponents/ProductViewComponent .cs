
using BookCity.Query.Contract.Products;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public ProductViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productQuery.GetProducts();
            return View(products);
        }
    }
}
