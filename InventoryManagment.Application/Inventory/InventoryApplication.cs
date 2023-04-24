

using _01_Framework.Application;
using InventoryManagment.Application.Contract.Inventory;
using InventoryManagment.Domain.InventoryAgg;

namespace InventoryManagment.Application.Inventory
{
    
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            var operation = new OperationResult();
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var inventory = new Domain.InventoryAgg.Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Add(inventory);
            _inventoryRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.GetBy(command.Id);
            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId&&x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            inventory.Edit(command.ProductId, command.UnitPrice);
            _inventoryRepository.Save();
            return operation.Succedded();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public List<InventoryOperationViewModel> GetInventoryOperation(long inventoryId)
        {
            return _inventoryRepository.GetInventoryOperation(inventoryId);
        }

        public OperationResult Increase(Increase command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.GetBy(command.InventoryId);
            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            const long operationId = 1;
            inventory.Increase(command.Count, operationId, command.Description);
            _inventoryRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Reduce(Reduce command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.GetBy(command.InventoryId);
            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            const long operationId = 1;
            inventory.Reduce(command.Count,operationId,command.Description,0);
            _inventoryRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Reduce(List<Reduce> command)
        {
            var operation = new OperationResult();
            const long operationId = 1;
            
            foreach(var item in command)
            {
                var inventory = _inventoryRepository.GetByProductId(item.ProductId);
                inventory.Reduce(item.Count,operationId,item.Description,item.OrderId);   
            }
            _inventoryRepository.Save();
            return operation.Succedded();

        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }
    }
}
