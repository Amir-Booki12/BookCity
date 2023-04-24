using _01_Framework.Application;
using BookCity.Query.Contract.ProductCategory;
using BookCity.Query.Contract.Products;
using DiscountManagment.Infrastucure.EfCore;
using InventoryManagment.Infrasctucure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Infrastucure.EfCore;

namespace BookCity.Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductCategoryQuery(ShopContext context, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryQueryViewModel> GetProductCategory()
        {
            return _context.productCategories.Select(x => new ProductCategoryQueryViewModel
            {
                Id = x.Id,

                Keywords = x.Keywords,
                MetaDescraption = x.MetaDescraption,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,

            }).ToList();
        }

        public List<ProductCategoryQueryViewModel> GetProductCategoryWithProduct()
        {
            var inventory = _inventoryContext.Inventory
                .Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var discounts = _discountContext.CustomerDicounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.ProductId, x.DiscountRate }).ToList();

            var categories = _context.productCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,

                    Products = MapProduct(x.Products),

                }).AsNoTracking().ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (inventory != null)
                    {
                        var price = productInventory.UnitPrice;
                        product.price = price.ToString("#,00");

                        var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                        if (discount != null)
                        {
                            int disCountRate = discount.DiscountRate;
                            product.DiscountRate = disCountRate;
                            product.HasDicount = disCountRate > 0;
                            var dicountAmount = (price * disCountRate) / 100;
                            product.priceWithDiscount = (price - dicountAmount).ToString("#,00");
                        }
                    }

                }
            }


            return categories;
        }

        public ProductCategoryQueryViewModel GetProductCategoryWithProductBy(string slug)
        {
            var inventory = _inventoryContext.Inventory
                .Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var discounts = _discountContext.CustomerDicounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.ProductId, x.DiscountRate, x.EndDate }).ToList();

            var categories = _context.productCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug,
                    Description = x.Description,

                    Products = MapProduct(x.Products),

                }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);


            foreach (var product in categories.Products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (inventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.price = price.ToString("#,00");

                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        int disCountRate = discount.DiscountRate;
                        product.DiscountRate = disCountRate;
                        product.ExpireDate = discount.EndDate.ToDiscountFormat();
                        product.HasDicount = disCountRate > 0;
                        var dicountAmount = (price * disCountRate) / 100;
                        product.priceWithDiscount = (price - dicountAmount).ToString("#,00");
                    }
                }

            }



            return categories;
        }



        private static List<ProductQueryModel> MapProduct(List<Product> products)
        {
            return products.Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                PictureTitle = x.PictureTitle,
                Category = x.Category.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                ShortDescription = x.ShortDescription,
                Slug= x.Slug,
            }).ToList();


        }


    }
}
