using _01_Framework.Domain;
using ShopManagment.Application.Contract.Product;

namespace ShopManagment.Domain.ProductAgg
{
    public interface IProductRepository:IRepository<long,Product>
    {
        EditProduct? GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetProducts();

        Product GetProductWithCategory(long id);
       
    }
}
