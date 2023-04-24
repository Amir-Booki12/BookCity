using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contract.ProductCategory;
using ShopManagment.Domain.ProductCategoryAgg;


namespace ShopManagment.Infrastucure.EfCore.Repository
{
    public class ProductCategoryRepository : Repository<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;
        public ProductCategoryRepository(ShopContext ShopContext) : base(ShopContext)
        {
            _shopContext = ShopContext;
        }

        public string GetBySlug(long id)
        {
            return _shopContext.productCategories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        }

        public EditProductCategory? GetDetails(long id)
        {
            return _shopContext.productCategories.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name,
               
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescraption,
                Slug = x.Slug,
                Description = x.Description
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _shopContext.productCategories.Select(x=>new ProductCategoryViewModel
            {
                Id=x.Id,
                Name=x.Name,
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _shopContext.productCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsiFull(),
                Picture = x.Picture,
            }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
