
using _01_Framework.Application;
using BookCity.Query.Contract.Products;
using DiscountManagment.Infrastucure.EfCore;
using InventoryManagment.Infrasctucure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.CommentAgg;
using ShopManagment.Domain.ProductPictureAgg;
using ShopManagment.Infrastucure.EfCore;


namespace BookCity.Query.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductQuery(ShopContext context, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public ProductQueryModel GetDetails(string slug)
        {
            var inventory = _inventoryContext.Inventory
               .Select(x => new { x.ProductId, x.UnitPrice, x.InStock }).ToList();

            var discounts = _discountContext.CustomerDicounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.ProductId, x.DiscountRate, x.EndDate }).ToList();


            var Products = _context.products
                .Include(x => x.Category)
                .Include(x => x.productPictures)
                .Include(x => x.Comments)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PictureTitle = x.PictureTitle,
                    Category = x.Category.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    Slug = x.Slug,
                    Keywords = x.Keyword,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    CategorySlug = x.Category.Slug,
                    Code = x.Code,

                    Pictures = MapPictures(x.productPictures),
                    Comments = MapComment(x.Comments)

                }).FirstOrDefault(x => x.Slug == slug);



            var productInventory = inventory.FirstOrDefault(x => x.ProductId == Products.Id);
            if (inventory != null)
            {
                var price = productInventory.UnitPrice;
                Products.IsInStock = productInventory.InStock;
                Products.price = price.ToString("#,00");

                var discount = discounts.FirstOrDefault(x => x.ProductId == Products.Id);
                if (discount != null)
                {
                    int disCountRate = discount.DiscountRate;
                    Products.DiscountRate = disCountRate;
                    Products.ExpireDate = discount.EndDate.ToDiscountFormat();
                    Products.HasDicount = disCountRate > 0;
                    var dicountAmount = (price * disCountRate) / 100;
                    Products.priceWithDiscount = (price - dicountAmount).ToString("#,00");
                }
            }


            return Products;
        }

        private static List<CommentProduct> MapComment(List<Comment> comments)
        {
            return comments.Where(x => x.IsConfirmed).Select(x => new CommentProduct
            {
                Id = x.Id,
                Email = x.Email,
                Massege = x.Massege,
                Name = x.Name,
                ProductId = x.ProductId
            }).OrderByDescending(x => x.Id).ToList();
        }

        private static List<PictureProducts> MapPictures(List<ProductPicture> productPictures)
        {
            return productPictures.Where(x => !x.IsRemove).Select(x => new PictureProducts
            {
                Id = x.Id,
                Picture = x.Picture,
                ProductId = x.ProductId,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,


            }).ToList();
        }

        public List<ProductQueryModel> GetProducts()
        {
            var inventory = _inventoryContext.Inventory
               .Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var discounts = _discountContext.CustomerDicounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.ProductId, x.DiscountRate }).ToList();


            var Products = _context.products
                .Include(x => x.Category)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PictureTitle = x.PictureTitle,
                    Category = x.Category.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    Slug = x.Slug,
                    Keywords = x.Keyword

                }).AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToList();


            foreach (var product in Products)
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
            return Products;
        }

        public List<ProductQueryModel> Search(string value)
        {
            var inventory = _inventoryContext.Inventory
             .Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var discounts = _discountContext.CustomerDicounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.ProductId, x.DiscountRate }).ToList();


            var query = _context.products
                .Include(x => x.Category)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PictureTitle = x.PictureTitle,
                    Category = x.Category.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    Slug = x.Slug,
                    Keywords = x.Keyword,
                    ShortDescription = x.ShortDescription

                }).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));

            var Products = query.OrderByDescending(x => x.Id).Take(6).ToList();

            foreach (var product in Products)
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
            return Products;
        }
    }
}
