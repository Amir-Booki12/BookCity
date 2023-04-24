

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contract.slide
{
    public class CreateSlide
    {
        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string Text { get;  set; }

        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string Header { get;  set; }

        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string BtnText { get;  set; }

        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "این مقدار نمیتواند خالی باشد")]
        public string Link { get; set; }

        
        public IFormFile Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
    }
}
