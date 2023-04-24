using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contract.Product;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Infrastucure.EfCore.Repository
{
    public class ProductRepository : Repository<long, Product>, IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProduct? GetDetails(long id)
        {
            return _shopContext.products.Select(x => new EditProduct
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
               
                ShortDescription = x.ShortDescription,
                Slug = x.Slug

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _shopContext.products.Select(x=>new ProductViewModel { Id = x.Id, Name = x.Name,}).ToList();
        }

        public Product GetProductWithCategory(long id)
        {
            return _shopContext.products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _shopContext.products.Include(X=>X.Category).Select(x => new ProductViewModel
            {
                
                Id = x.Id,
                Name = x.Name,
                 
                Picture = x.Picture,
                Code = x.Code,
                CategoryId = x.CategoryId,
                Category = x.Category.Name,
                CreationDate=x.CreationDate.ToFarsiFull()

            });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query= query.Where(x=>x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if(searchModel.CategoryId > 0)
                query=query.Where(x=>x.CategoryId==searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();  

        }
    }
}
