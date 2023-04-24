using _01_Framework.Domain;
using BlogManagment.Application.Contract.Article;
using BlogManagment.Application.Contract.ArticleCategory;
using BlogManagment.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Domain.Article
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        EditArticle GetDetails(long id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);

        List<ArticleCategoryViewModel> articleCategories();
        Article GetWithCategorySlug(long id);
    }
}
