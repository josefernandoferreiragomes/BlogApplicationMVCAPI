using BlogApplication.DB.Data;
using BlogApplication.DB.Interfaces;
using BlogApplication.WCF.DataContract;
using LoanManagement.Platform.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BlogApplication.WCF
{
    
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        Interfaces.IProductRepository _productsRepository;

        public ProductService()
        {
            _productsRepository = ApplicationContainer.Resolve<Interfaces.IProductRepository>();
        }
        public ProductService(Interfaces.IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public PageOfProductServiceOut GetPageOfProducts(PageOfProductServiceIn objDbIn)
        {
            PageOfProductServiceOut objDbOut = new PageOfProductServiceOut();
            objDbOut = _productsRepository.GetPageOfProducts(objDbIn);                
            return objDbOut;
            
        }
    }
}
