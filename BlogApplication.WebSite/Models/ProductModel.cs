using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApplication.WebSite.Models
{
    public class ProductModel
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Description is mandatory")]        
        public string Description { get; set; }

        [Required(ErrorMessage = "Product Price is mandatory")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Date is mandatory")]
        [DisplayName("Product Date")]
        public DateTime ProductDate { get; set; }

        public string ValidationMessage { get; set; }
    }
}