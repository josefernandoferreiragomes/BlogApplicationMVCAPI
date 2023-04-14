using BlogApplication.DB.Data;
using BlogApplication.DB.Interfaces;
using BlogApplication.WCF.DataContract;
using BlogApplication.WCF.Interfaces;
using LoanManagement.Platform.Container;
using LoanManagement.Platform.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.WCF.Repository
{
    public class ProductRepository:IProductRepository
    {
        DB.Interfaces.IProductsDatabaseExecuter _productsExecuter;

        public ProductRepository()
        {
            _productsExecuter = ApplicationContainer.Resolve<DB.Interfaces.IProductsDatabaseExecuter>();
        }
        public ProductRepository(IProductsDatabaseExecuter productsRepository)
        {
            _productsExecuter = productsRepository;
        }

        public PageOfProductServiceOut GetPageOfProducts(PageOfProductServiceIn objDbIn)
        {
            PageOfProductServiceOut objDbOut = new PageOfProductServiceOut();
            ProductPageRequest request = CustomMapper.Map<PageOfProductServiceIn, ProductPageRequest>(objDbIn);
            
            List<ProductDB> products = _productsExecuter.StoredProcedureCall(request);
            objDbOut.ListOfProducts = CustomMapper.Map<List<ProductDB>,List<PageOfProductServiceOutItem>>(products);
            return objDbOut;

        }

       
    }
}
