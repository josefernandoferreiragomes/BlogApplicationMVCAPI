using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BlogApplication.WebSite.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Description is mandatory")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product Price is mandatory")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Date is mandatory")]
        [DisplayName("Product Date")]
        public DateTime ProductDate { get; set; }
        [DisplayName("Product Category")]
        public int ProductTypeId { get; set; }
    }
}