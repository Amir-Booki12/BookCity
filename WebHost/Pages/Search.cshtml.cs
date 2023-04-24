using BookCity.Query.Contract.Products;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IProductQuery _productQuery;

        public SearchModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        public string Value;
        public List<ProductQueryModel> Products { get; set; }

        public void OnGet(string value)
        {
            Value = value;
            Products =_productQuery.Search(value);
        }
    }
}
