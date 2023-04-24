﻿using _0_Framework.Application;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;


namespace ShopManagment.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        [MaxFileSize(maxFileSize: 3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxLenght)]

         public IFormFile Picture { get;  set; }
        public string PictureTitle { get;  set; }
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
         public string Slug { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
         public string Keywords { get;  set; }
    }
}