using Microsoft.AspNetCore.Http;
using ShopManagment.Application.Contract.ProductCategory;
using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string Code { get; set; }

  
        public string Description { get; set; }
        public string ShortDescription { get; set; }

       
        public IFormFile Picture { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public long CategoryId { get; set; }

        public List<ProductCategoryViewModel> ProductsCategories { get; set; }
    }
}
