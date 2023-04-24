
using _01_Framework.Application;

namespace InventoryManagment.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(Increase command );
        OperationResult Reduce(Reduce command );
        OperationResult Reduce(List<Reduce> command );
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetInventoryOperation(long inventoryId);
    }
}
