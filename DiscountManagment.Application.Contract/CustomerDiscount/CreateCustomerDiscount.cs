﻿

using ShopManagment.Application.Contract.Product;

namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public class CreateCustomerDiscount
    {
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
