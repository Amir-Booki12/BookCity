using BookCity.Query.Query;

namespace BookCity.Query.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryViewModel> GetProductCategory();
        List<ProductCategoryQueryViewModel> GetProductCategoryWithProduct();
        ProductCategoryQueryViewModel GetProductCategoryWithProductBy(string slug);
       
    }
}
