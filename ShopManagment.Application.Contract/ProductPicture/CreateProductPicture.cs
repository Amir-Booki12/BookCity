using Microsoft.AspNetCore.Http;
using ShopManagment.Application.Contract.Product;

using System.ComponentModel.DataAnnotations;


namespace ShopManagment.Application.Contract.ProductPicture
{
    public class CreateProductPicture
    {
       
        public IFormFile Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public long ProductId { get;  set; }

      public List<ProductViewModel> Products { get; set; }
    }
}
