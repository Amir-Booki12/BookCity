
using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using InventoryManagment.Application.Contract.Inventory;
using InventoryManagment.Domain.InventoryAgg;
using ShopManagment.Infrastucure.EfCore;

namespace InventoryManagment.Infrasctucure.EfCore.Repository
{
    public class InventoryRepository : Repository<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }

        public Inventory GetByProductId(long productId)
        {
            return _inventoryContext.Inventory.First(x => x.ProductId == productId);
        }

        public EditInventory? GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryOperationViewModel> GetInventoryOperation(long inventoryId)
        {
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.Id == inventoryId);
            return inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Operation = x.Operation,
                Operator = "مدیر سایت",
                OperatorId = x.OperationId,
                OrderId = x.OrderId,
                OperationDate = x.OperationDate.ToFarsi()

            }).OrderByDescending(x=>x.Id).ToList();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                CurrentCount = x.CalculateCurrentCount(),
                ProductId = x.ProductId,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.InStock == true)
                query = query.Where(x => !x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(x => x.Product = products.FirstOrDefault(s => s.Id == x.ProductId)?.Name);

            return inventory;
        }
    }
}
