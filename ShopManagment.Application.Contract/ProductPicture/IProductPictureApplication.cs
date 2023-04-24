
using _01_Framework.Application;

namespace ShopManagment.Application.Contract.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);

        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
