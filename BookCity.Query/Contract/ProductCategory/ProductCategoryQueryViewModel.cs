using BookCity.Query.Contract.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCity.Query.Contract.ProductCategory
{
    public class ProductCategoryQueryViewModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Picture { get;  set; }
        
        public string PictureTitle { get;  set; }
        public string PictureAlt { get;  set; }
        public string Slug { get;  set; }
        public string MetaDescraption { get;  set; }
        public string Keywords { get;  set; }
        public string Description { get;  set; }
       

        public List<ProductQueryModel> Products { get; set; }
    }
}
