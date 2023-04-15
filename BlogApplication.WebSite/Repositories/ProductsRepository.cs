using BlogApplication.WebSite.BlogApplicationService;
using BlogApplication.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.WebSite.Interfaces
{
    public class ProductsRepository: IProductsRepository
    {
        ProductServiceClient _productServiceClient;

        public ProductsRepository()
        {
            _productServiceClient = new ProductServiceClient("BasicHttpBinding_IProductService");
        }

        public ProductsRepository(ProductServiceClient productServiceClient)
        {
            _productServiceClient = productServiceClient;
        }

        public List<ProductModel> GetPageOfProducts(int pageSize, int pageIndex, string filter)
        {

            List<ProductModel> model = new List<ProductModel>();

            PageOfProductServiceIn objIn = new PageOfProductServiceIn();
            objIn.RowsPerPage=pageSize;
            objIn.PageNumber=pageIndex;
            objIn.TextFilter=filter;
            PageOfProductServiceOut objOut = _productServiceClient.GetPageOfProducts(objIn);

            //temporary manual mapping
            foreach(PageOfProductServiceOutItem item in objOut.ListOfProducts)
            {
                ProductModel product = new ProductModel
                {
                    Id = item.Id,
                    Description = item.Description,
                    Price = item.Price
                };
                model.Add(product);
            }
            return model;
        }
    }
}