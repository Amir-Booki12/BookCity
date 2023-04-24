using _01_Framework.Domain;
using BlogManagment.Application.Contract.ArticleCategory;

namespace BlogManagment.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository:IRepository<long,ArticleCategory>
    {
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);

        string GetBySlug(long id);
    }
}
