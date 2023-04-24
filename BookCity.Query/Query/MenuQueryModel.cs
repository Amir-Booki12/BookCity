

using BookCity.Query.Contract.ArticleCategory;
using BookCity.Query.Contract.ProductCategory;

namespace BookCity.Query.Query
{
    public class MenuQueryModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public List<ProductCategoryQueryViewModel> ProductCategories { get; set; }
    }
}
