using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using InventoryManagment.Application.Contract.Inventory;
using InventoryManagment.Domain.InventoryAgg;
using ShopManagment.Infrastucure.EfCore;

namespace InventoryApplication.Infrastucure.EfCore.Repository
{
    public class InventoryRepository : Repository<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventorycontext;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext inventorycontext, ShopContext shopContext) : base(inventorycontext)
        {
            _inventorycontext = inventorycontext;
            _shopContext = shopContext;
        }

        public Inventory GetByProductId(long productId)
        {
            return _inventorycontext.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory? GetDetails(long id)
        {
            return _inventorycontext.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _inventorycontext.Inventory.Select(x => new InventoryViewModel
            {

                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                CreationDate = x.CreationDate.ToFarsi(),
                InStock = x.InStock,
                CurrentCount = x.CalculateCurrentCount(),
            });

            if(searchModel.ProductId > 0)
                query = query.Where(x=>x.ProductId == searchModel.ProductId);

            if (searchModel.InStock)
                query = query.Where(x => x.InStock == false);

            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(x => x.Product = products.FirstOrDefault(s => s.Id == x.ProductId)?.Name);

            return inventory;

        }
    }
}
