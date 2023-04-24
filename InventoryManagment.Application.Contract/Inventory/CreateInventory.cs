



using ShopManagment.Application.Contract.Product;

namespace InventoryManagment.Application.Contract.Inventory
{
    public class CreateInventory
    {
        public long ProductId { get;  set; }
        public int UnitPrice { get;  set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
