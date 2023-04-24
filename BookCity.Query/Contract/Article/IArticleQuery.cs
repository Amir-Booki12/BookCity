

namespace BookCity.Query.Contract.Article
{
    public interface IArticleQuery
    {
        List<LatestArticleQueryModel> GetLatestArticels();

        ArticlesQueryModel GetDetails(string slug);
    }
}
