using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BlogApplication.WebSite.Models
{
    public class AddProductViewModel
    {        
        public Product ProductItem { get; set; }
        
        public List<SelectListItem> ListOfProductTypes { get; set; }
        public string ValidationMessage { get; set; }
    }
}