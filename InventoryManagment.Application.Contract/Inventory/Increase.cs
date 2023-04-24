
namespace InventoryManagment.Application.Contract.Inventory
{
    public class Increase
    {
        public long InventoryId { get; set;}
        public long Count { get; set;}
        public string Description { get; set;}
    }
}
