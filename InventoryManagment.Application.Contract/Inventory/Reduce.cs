
namespace InventoryManagment.Application.Contract.Inventory
{
    public class Reduce
    {
        public long InventoryId { get; set; }
        public long ProductId { get; set; }
        public long Count { get; set; }
        public long OrderId { get; set; }
        public string Description { get; set; }
    }
}
