


using _01_Framework.Domain;
using ShopManagment.Application.Contract.ProductPicture;
using ShopManagment.Domain.ProductPictureAgg;

namespace ShopManagment.Domain.ProductPicture
{
    public interface IProductPictureRepository : IRepository<long, ProductPictureAgg.ProductPicture>
    {
        EditProductPicture? GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);

       ProductPictureAgg.ProductPicture GetWithProductAndCategory(long id);
    }
}
