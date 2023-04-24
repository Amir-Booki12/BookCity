using BookCity.Query.Contract.ArticleCategory;
using BookCity.Query.Contract.ProductCategory;
using BookCity.Query.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public MenuViewComponent(IProductCategoryQuery productCategoryQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuQueryModel()
            {
                ProductCategories = _productCategoryQuery.GetProductCategory(),
                 ArticleCategories = _articleCategoryQuery.GetCategoriesForShow()
            };
            return View(result);
        }
    }
}
