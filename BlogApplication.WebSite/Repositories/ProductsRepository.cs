using BlogApplication.WebSite.BlogApplicationService;
using BlogApplication.WebSite.Factories;
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
        ServiceClientFactory<ProductServiceClient> _serviceClientFactory;
        public ProductsRepository()
        {
            //_productServiceClient = new ProductServiceClient("BasicHttpBinding_IProductService");
            _serviceClientFactory = new ServiceClientFactory<ProductServiceClient>();
            _productServiceClient = _serviceClientFactory.GetClient();
        }

        public ProductsRepository(ProductServiceClient productServiceClient)
        {
            _productServiceClient = productServiceClient;
        }

        public List<Product> GetPageOfProducts(int pageSize, int pageIndex, string filter)
        {

            List<Product> model = new List<Product>();

            PageOfProductServiceIn objIn = new PageOfProductServiceIn();
            objIn.RowsPerPage=pageSize;
            objIn.PageNumber=pageIndex;
            objIn.TextFilter=filter;
            PageOfProductServiceOut objOut = _productServiceClient.GetPageOfProducts(objIn);

            //temporary manual mapping
            foreach(PageOfProductServiceOutItem item in objOut.ListOfProducts)
            {
                Product product = new Product
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