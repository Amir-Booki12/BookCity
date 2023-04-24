
using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using BlogManagment.Application.Contract.ArticleCategory;
using BlogManagment.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagment.Infrastucure.EfCore.Repository
{
    public class ArticleCategoryRepository : Repository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public string GetBySlug(long id)
        {
            return _blogContext.ArticleCategories.Select(x => new { x.Id, x.Slug })
                .FirstOrDefault(x => x.Id == id).Slug;
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _blogContext.ArticleCategories.Select(x => new EditArticleCategory
            {

                Id = x.Id,
                Name = x.Name,
                CannicalAddress = x.CannicalAddress,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,

                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var result = _blogContext.ArticleCategories.Include(x => x.Articles).Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleCount = x.Articles.Count

            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                result = result.Where(x => x.Name.Contains(searchModel.Name));

            return result.OrderByDescending(x => x.Id).ToList();
        }
    }
}
