

using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using BlogManagment.Application.Contract.Article;
using BlogManagment.Application.Contract.ArticleCategory;
using BlogManagment.Domain.Article;
using BlogManagment.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagment.Infrastucure.EfCore.Repository
{
    public class ArticleRepository : Repository<long, Article>, IArticleRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public List<ArticleCategoryViewModel> articleCategories()
        {
            return _blogContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public EditArticle GetDetails(long id)
        {
            return _blogContext.Articles.Select(x => new EditArticle
            {
                Id = x.Id,
                Title = x.Title,
                CannicalAddress = x.CannicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDesctiption = x.MetaDesctiption,

                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToString(),
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,

            }).FirstOrDefault(x => x.Id == id);
        }

        public Article GetWithCategorySlug(long id)
        {
            return _blogContext.Articles.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var result = _blogContext.Articles.Include(x => x.Category).Select(x => new ArticleViewModel
            {
                Picture = x.Picture,
                CategoryId = x.CategoryId,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + "...",
                Title = x.Title,
                CategoryName = x.Category.Name,
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                result = result.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId > 0)
                result = result.Where(x => x.CategoryId == searchModel.CategoryId);


            return result.OrderByDescending(x => x.Id).ToList();
        }
    }
}
