using _01_Framework.Domain;
using ShopManagment.Application.Contract.ProductCategory;


namespace ShopManagment.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {
        EditProductCategory? GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategoryViewModel> GetProductCategories();
        string GetBySlug(long id);
    }
}
