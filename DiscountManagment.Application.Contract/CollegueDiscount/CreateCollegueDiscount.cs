using ShopManagment.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagment.Application.Contract.CollegueDiscount
{
    public class CreateCollegueDiscount
    {

        public long ProductId { get;  set; }
        public int DiscountRate { get;  set; }
        public string Reason { get;  set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
