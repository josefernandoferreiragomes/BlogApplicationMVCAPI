using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogApplication.WebSite.Models
{
    public class ProductModel
    {        
        public int Id { get; set; }
     
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}