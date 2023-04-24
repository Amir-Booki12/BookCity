using _01_Framework.Domain;
using InventoryManagment.Application.Contract.Inventory;

namespace InventoryManagment.Domain.InventoryAgg
{
    public interface IInventoryRepository:IRepository<long,Inventory>
    {
        EditInventory? GetDetails(long id);
        Inventory GetByProductId(long productId);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetInventoryOperation(long inventoryId);
    }
}
