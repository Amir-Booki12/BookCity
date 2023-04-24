
namespace BookCity.Query.Contract.Products
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetProducts();
        List<ProductQueryModel> Search(string value);
        ProductQueryModel GetDetails(string slug);

    }
}
