

using _01_Framework.Application;
using BlogManagment.Infrastucure.EfCore;
using BookCity.Query.Contract.Article;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BookCity.Query.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public ArticlesQueryModel GetDetails(string slug)
        {
            var result= _blogContext.Articles.Include(x => x.Category).Select(x => new ArticlesQueryModel
            {
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                CannicalAddress = x.CannicalAddress,
                CategoryId = x.CategoryId,
                Keyword = x.Keyword,
                MetaDesctiption = x.MetaDesctiption,
                CategoryName = x.Category.Name,
                Slug = x.Slug,
                Title = x.Title,
                PublishDate = x.PublishDate.ToFarsi()
            }).FirstOrDefault(x => x.Slug == slug);

            result.KeywordList = result.Keyword.Split(",").ToList();

            return result;
        }

        public List<LatestArticleQueryModel> GetLatestArticels()
        {
            return _blogContext.Articles.Where(x => x.PublishDate < DateTime.Now).Select(x => new LatestArticleQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 100)) + "...",
                Slug = x.Slug,
                Title = x.Title,
                PublishDate = x.PublishDate.ToFarsi()
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
