
using _0_Framework.Application;
using _01_Framework.Application;
using ShopManagment.Application.Contract.Product;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCategoryAgg;

namespace ShopManagment.Application.Product
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productrepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ProductApplication(IProductRepository repository, IFileUploader fileUploader, IProductCategoryRepository productCategoryRepository)
        {
            _productrepository = repository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();


            if (_productrepository.Exists(x => x.Name == command.Name))
                return operation.Failed("قبلا با این اسم گروه تعریف شده است !");

            var slug = GenerateSlug.Slugify(command.Slug);
            var category = _productCategoryRepository.GetBySlug(command.CategoryId);
            var path = $"{category}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);

            var product = new Domain.ProductAgg.Product(command.Name,command.Code,
                command.Description,command.ShortDescription, pictureName, command.PictureTitle,
                command.PictureAlt, slug, command.Keyword,command.MetaDescription,command.CategoryId);

            _productrepository.Add(product);
            _productrepository.Save();
            return operation.Succedded();

        }


        public OperationResult Edit(EditProduct command)
        {
            var opration = new OperationResult();

            var Product = _productrepository.GetProductWithCategory(command.Id);

            if (Product == null)
                return opration.Failed("گروه مورد نظر یافت نشد!");

            if (_productrepository.Exists(x => x.Name == command.Name &&
              x.Id!=command.Id))
                return opration.Failed("قبلا با این اسم گروه تعریف شده است !");

            var slug = GenerateSlug.Slugify(command.Slug);
            var path = $"{Product.Category.Slug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            Product.Edit(command.Name, command.Code,
                command.Description, command.ShortDescription, pictureName, command.PictureTitle,
                command.PictureAlt, slug, command.Keyword, command.MetaDescription, command.CategoryId);

            _productrepository.Save();
            return opration.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productrepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productrepository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
           return _productrepository.Search(searchModel);
        }
    }
}
