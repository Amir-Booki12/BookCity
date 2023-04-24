

using _01_Framework.Application;
using BlogManagment.Domain.Article;
using BlogManagment.Infrastucure.EfCore;
using BookCity.Query.Contract.Article;
using BookCity.Query.Contract.ArticleCategory;
using Microsoft.EntityFrameworkCore;

namespace BookCity.Query.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public ArticleCategoryQueryModel GetArticleCategory(string slug)
        {
            var result =  _blogContext.ArticleCategories.Select(x => new ArticleCategoryQueryModel
            {

                Slug = slug,
                Keyword = x.Keyword,
                Name = x.Name,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CannicalAddress = x.CannicalAddress,
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 100)) + "...",
                Articles = MapArticle(x.Articles)

            }).FirstOrDefault(x => x.Slug == slug);

            result.KeywordList = result.Keyword.Split(",").ToList();

            return result;
        }

        private static List<ArticlesQueryModel> MapArticle(List<Article> articles)
        {
            return articles.Select(x => new ArticlesQueryModel
            {
                Slug = x.Slug,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 100)) + "...",
                Title = x.Title
            }).ToList();
        }

        public List<ArticleCategoryQueryModel> GetCategoriesForShow()
        {
            return _blogContext.ArticleCategories.Include(x => x.Articles).Select(x => new ArticleCategoryQueryModel
            {
                Slug = x.Slug,
                Name = x.Name,
                ArticleCount = x.Articles.Count
            }).ToList();
        }
    }
}
