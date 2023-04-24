

using _0_Framework.Application;
using _01_Framework.Application;
using ShopManagment.Application.Contract.ProductCategory;
using ShopManagment.Domain.ProductCategoryAgg;

namespace ShopManagment.Application.ProductCategory
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepositort, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepositort;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var opration = new OperationResult();

            if (_productCategoryRepository.Exists(x => x.Name == command.Name ))
                return opration.Failed("قبلا با این اسم گروه تعریف شده است !");

            var slug = GenerateSlug.Slugify(command.Slug);
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            var productCategory = new Domain.ProductCategoryAgg.ProductCategory(command.Name
                , pictureName, command.PictureTitle,command.PictureAlt, slug,
                command.MetaDescription,command.Keywords,command.Description);

            _productCategoryRepository.Add(productCategory);
            _productCategoryRepository.Save();
            return opration.Succedded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var opration = new OperationResult();

            var ProductCategory = _productCategoryRepository.GetBy(command.Id);

            if (ProductCategory == null)
                return opration.Failed("گروه مورد نظر یافت نشد!");

            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return opration.Failed("قبلا با این اسم گروه تعریف شده است !");

            var slug = GenerateSlug.Slugify(command.Slug);
            var pictureName = _fileUploader.Upload(command.Picture, command.Slug);
            ProductCategory.Edit(command.Name, pictureName, command.PictureTitle
                ,command.PictureAlt, slug, command.MetaDescription,command.Keywords, command.Description);

            _productCategoryRepository.Save();
            return opration.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}
