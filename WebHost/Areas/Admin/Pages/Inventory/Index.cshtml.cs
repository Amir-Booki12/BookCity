
using InventoryManagment.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using ShopManagment.Application.Contract.Product;
using IInventoryApplication = InventoryManagment.Application.Contract.Inventory.IInventoryApplication;

namespace WebHost.Areas.Admin.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        public InventorySearchModel searchModel;
        public List<InventoryViewModel> Inventories { get; set; }
        public List<InventoryOperationViewModel> Operations { get; set; }
        public SelectList Products { get; set; }

        private readonly IInventoryApplication _iInventoryApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication, IInventoryApplication iInventoryApplication)
        {

            _productApplication = productApplication;
            _iInventoryApplication = iInventoryApplication;
        }

        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Inventories = _iInventoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var inventory = new CreateInventory
            {
                Products = _productApplication.GetProducts(),
            };
            return Partial("./Create", inventory);
        }

        public JsonResult OnPostCreate(CreateInventory command)
        {
           var result= _iInventoryApplication.Create(command);
            
            return new JsonResult(result);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _iInventoryApplication.GetDetails(id);
            command.Products = _productApplication.GetProducts();
            return Partial("./Edit",command);
        }

        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _iInventoryApplication.Edit(command);
            return new JsonResult(result);

        }

        public IActionResult OnGetIncrease(long id)
        {
            var command = new Increase()
            {
                InventoryId = id
            };
           
            return Partial("./Increase", command);
        }

        public JsonResult OnPostIncrease(Increase command)
        {
            var result = _iInventoryApplication.Increase(command);
            return new JsonResult(result);

        }

        public IActionResult OnGetReduce(long id)
        {
            var command = new Reduce()
            {
                InventoryId = id
            };

            return Partial("./Reduce", command);
        }

        public JsonResult OnPostReduce(Reduce command)
        {
            var result = _iInventoryApplication.Reduce(command);
            return new JsonResult(result);

        }

        public IActionResult OnGetLogOperation(long id)
        {
            var log = _iInventoryApplication.GetInventoryOperation(id);

            return Partial("./LogOperation",log);
        }


    }
}
