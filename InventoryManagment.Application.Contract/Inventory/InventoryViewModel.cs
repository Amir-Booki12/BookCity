
namespace InventoryManagment.Application.Contract.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int UnitPrice { get; set; }
        public bool InStock { get; set; }
        public string CreationDate { get; set; }
        public long CurrentCount { get; set; }
    }
}
