
using BookCity.Query.Contract.Products;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contract.Comment;

namespace WebHost.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;
        public ProductDetailsModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }
        public ProductQueryModel Products { get; set; }

        public void OnGet(string id)
        {
            Products = _productQuery.GetDetails(id);  
        }

        public IActionResult OnPost(AddComment commend,string productSlug)
        {
            var result = _commentApplication.Add(commend);

            return RedirectToPage("./ProductDetails", new {Id= productSlug });
        } 
    }
}
