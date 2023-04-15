using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.WebSite.Models
{
    public class ProductViewModel
    {
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
        public string TextFilter { get; set; }
       
        public List<ProductModel> Products { get; set; }
    }
}