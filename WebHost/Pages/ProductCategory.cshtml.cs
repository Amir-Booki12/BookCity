
using BookCity.Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public  ProductCategoryQueryViewModel Category { get; set; }
        public void OnGet(string id)
        {
            Category = _productCategoryQuery.GetProductCategoryWithProductBy(id);
        }
    }
}
