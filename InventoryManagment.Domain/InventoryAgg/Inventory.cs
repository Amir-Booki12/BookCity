using _01_Framework.Domain;


namespace InventoryManagment.Domain.InventoryAgg
{
    public class Inventory:EntityBase
    {
        public long ProductId { get; private set; }
        public int UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, int unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }
        public void Edit(long productId, int unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            
        }

        public  long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x=>x.Count);
            var mines = Operations.Where(x => !x.Operation).Sum(x=>x.Count);

            return plus - mines;
        }

        public void Increase(long count,long operatorId,string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            
            var operation = new InventoryOperation(count, true, operatorId, currentCount,0,description,Id);
            Operations.Add(operation);
            if(currentCount > 0)
            {
                InStock = true;
            }
            else
            {
                InStock = false;
            }

        }
        public void Reduce(long count, long operatorId, string description,long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            
            var operation = new InventoryOperation(count, false, operatorId, currentCount, orderId, description, Id);
            Operations.Add(operation);
            if (currentCount > 0)
            {
                InStock = true;
            }
            else
            {
                InStock = false;
            }
        }
    }


    public class InventoryOperation
    {
        public long Id { get; private set; }
        public long Count { get; private set; }
        public bool Operation { get; private set; }
        public long OperationId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public long OrderId { get; private set; }
        public string Description { get; private set; }
        public long InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }

        public InventoryOperation(long count, bool operation, long operationId, long currentCount,
            long orderId, string description, long inventoryId)
        {
          
            Count = count;
            Operation = operation;
            OperationId = operationId;
            CurrentCount = currentCount;
            OrderId = orderId;
            Description = description;
            InventoryId = inventoryId;
            OperationDate = DateTime.Now;
        }
    }
}
