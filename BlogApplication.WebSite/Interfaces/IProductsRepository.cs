using BlogApplication.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.WebSite.Interfaces
{
    public interface IProductsRepository
    {
        List<ProductModel> GetPageOfProducts(int pageSize, int pageIndex, string filter);
    }
}