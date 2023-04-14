using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.DB.Data
{
    public class ProductPageRequest:ProductPageRequestBase
    {    
        public string TextFilter { get; set; } 
    }
}
