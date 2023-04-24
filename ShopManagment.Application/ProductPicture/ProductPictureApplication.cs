
using _0_Framework.Application;
using _01_Framework.Application;
using ShopManagment.Application.Contract.ProductPicture;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductPicture;


namespace ShopManagment.Application.ProductPicture
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProductRepository productRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();

            var product = _productRepository.GetProductWithCategory(command.ProductId);
            var path = $"{product.Category.Slug}/{product.Slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            var productPicture = new Domain.ProductPictureAgg.ProductPicture(pictureName, command.PictureAlt,
                command.PictureTitle,command.ProductId);

            _productPictureRepository.Add(productPicture);
            _productPictureRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var product = _productPictureRepository.GetWithProductAndCategory(command.Id);

            if(product == null) 
            return operation.Failed("گزینه مورد نظر یافت نشد");

            var path = $"{product.product.Category.Slug}/{product.product.Slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);

            product.Edit(pictureName, command.PictureAlt,
                command.PictureTitle, command.ProductId);
            _productPictureRepository.Save();

            return operation.Succedded();
        }

        

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);    
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var product = _productPictureRepository.GetBy(id);

            if (product == null)
                return operation.Failed("گزینه مورد نظر یافت نشد");


            product.Remove();

            _productPictureRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var product = _productPictureRepository.GetBy(id);

            if (product == null)
                return operation.Failed("گزینه مورد نظر یافت نشد");


            product.Restore();

            _productPictureRepository.Save();

            return operation.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
