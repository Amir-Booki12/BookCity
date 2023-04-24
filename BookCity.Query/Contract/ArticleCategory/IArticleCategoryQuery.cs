

namespace BookCity.Query.Contract.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        List<ArticleCategoryQueryModel> GetCategoriesForShow();

        ArticleCategoryQueryModel GetArticleCategory(string slug);
    }
}
