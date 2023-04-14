using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.DB.Data
{
    public class ProductPageRequestBase
    {
        public int PageNumber { get; set; }
        public int RowsPerPage { get;set; }       
    }
}
