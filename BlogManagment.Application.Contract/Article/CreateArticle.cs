using _01_Framework.Application;
using BlogManagment.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagment.Application.Contract.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        public string Keyword { get; set; }
        public string MetaDesctiption { get; set; }
        public string CannicalAddress { get; set; }
        public string PublishDate { get; set; }


        [Range(1,1000,ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }


       public List<ArticleCategoryViewModel> GetArticleCategories { get; set; }
    }
}
