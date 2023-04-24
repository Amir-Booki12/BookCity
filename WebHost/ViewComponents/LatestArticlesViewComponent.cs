using BookCity.Query.Contract.Article;

using Microsoft.AspNetCore.Mvc;

namespace WebHost.ViewComponents
{
    public class LatestArticlesViewComponent : ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public LatestArticlesViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            var articles = _articleQuery.GetLatestArticels();
            return View(articles);
        }
    }
}
