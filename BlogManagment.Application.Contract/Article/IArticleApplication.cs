

using _01_Framework.Application;
using BlogManagment.Application.Contract.ArticleCategory;

namespace BlogManagment.Application.Contract.Article
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticle command);
        OperationResult Edit(EditArticle command);

        EditArticle GetDetails(long id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);

        List<ArticleCategoryViewModel> articleCategories();
    }
}
