
using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscount;
using ShopManagment.Infrastucure.EfCore;

namespace DiscountManagment.Infrastucure.EfCore.Repository
{
    public class CustomerDiscountRepository : Repository<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;


        public CustomerDiscountRepository(DiscountContext discountContext, ShopContext shopContext) : base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount? GetDetails(long id)
        {
            return _discountContext.CustomerDicounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
                Reason = x.Reason,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),


            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _discountContext.CustomerDicounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Reason = x.Reason,
                StartDate = x.StartDate.ToFarsi(),
                StartDateGr = x.StartDate,
                EndDateGr = x.EndDate,
                EndDate = x.EndDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
                query = query.Where(x => x.StartDateGr > searchModel.StartDate.ToGeorgianDateTime());

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
                query = query.Where(x => x.EndDateGr < searchModel.EndDate.ToGeorgianDateTime());

            var dicount = query.OrderByDescending(x => x.Id).ToList();

            dicount.ForEach(x => x.Product = products.FirstOrDefault(s => s.Id == x.ProductId)?.Name);
            return dicount;

        }
    }
}
