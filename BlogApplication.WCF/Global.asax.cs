using LoanManagement.Platform.Container;
using LoanManagement.Platform.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Routing;
using Unity;

namespace BlogWebAPI
{
    public class WCFApplication
    {
        protected void Application_Start()
        {
            
            ApplicationContainer.GetContainer().RegisterSingleton<BlogApplication.DB.Interfaces.IProductsDatabaseExecuter, BlogApplication.DB.DBExecuter.ProductsDatabaseExecuter>();
            ApplicationContainer.GetContainer().RegisterSingleton<BlogApplication.WCF.Interfaces.IProductRepository, BlogApplication.WCF.Repository.ProductRepository>();

            CustomMapper.RegisterMapping<BlogApplication.DB.Data.ProductDB, BlogApplication.WCF.DataContract.PageOfProductServiceOutItem>();
            CustomMapper.RegisterMapping<List<BlogApplication.DB.Data.ProductDB>, List<BlogApplication.WCF.DataContract.PageOfProductServiceOut>>();

            CustomMapper.RegisterMapping<BlogApplication.WCF.DataContract.PageOfProductServiceIn, BlogApplication.DB.Data.ProductPageRequest>();

        }
    }
}
