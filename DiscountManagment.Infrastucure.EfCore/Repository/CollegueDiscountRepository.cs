using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using DiscountManagment.Application.Contract.CollegueDiscount;
using DiscountManagment.Domain.CollegueDiscount;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Infrastucure.EfCore;

namespace DiscountManagment.Infrastucure.EfCore.Repository
{
    public class CollegueDiscountRepository : Repository<long, CollegueDiscount>, ICollegueDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;

        public CollegueDiscountRepository(DiscountContext discountContext, ShopContext shopContext) : base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditCollegueDiscount? GetDetails(long id)
        {
            return _discountContext.CollegueDiscounts.Select(x => new EditCollegueDiscount
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
                Reason = x.Reason

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel)
        {
            var products = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _discountContext.CollegueDiscounts.Select(x => new CollegueDiscountViewModel
            {
                Id = x.Id,
                Reason = x.Reason,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemove = x.IsRemove,
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);


            var dicount = query.OrderByDescending(x => x.Id).ToList();

            dicount.ForEach(x => x.Product = products.FirstOrDefault(s => s.Id == x.ProductId)?.Name);
            return dicount;
        }
    }
}
