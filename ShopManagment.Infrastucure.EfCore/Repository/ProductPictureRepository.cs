using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contract.ProductPicture;
using ShopManagment.Domain.ProductPicture;
using ShopManagment.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastucure.EfCore.Repository
{
    public class ProductPictureRepository : Repository<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _shopContext;

        public ProductPictureRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductPicture? GetDetails(long id)
        {
            return _shopContext.productPictures.Select(x => new EditProductPicture
            {
                Id = id,
              
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).FirstOrDefault(x => x.Id == id);
        }

        public ProductPicture GetWithProductAndCategory(long id)
        {
            return _shopContext.productPictures
                .Include(x => x.product)
                .ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _shopContext.productPictures.Include(x => x.product)
                .Select(x => new ProductPictureViewModel
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    ProductId = x.ProductId,
                    IsRemove = x.IsRemove,
                    CreationDate = x.CreationDate.ToFarsiFull(),
                    Product = x.product.Name,
                     
                });

            if(searchModel.ProductId > 0 )
                query = query.Where(x=>x.ProductId== searchModel.ProductId);

            if(searchModel.IsRemove==true)
                query =query.Where(x=>x.IsRemove== true);

            return query.OrderByDescending(x=>x.Id).ToList();   
        }
    }
}
