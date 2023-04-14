using BlogApplication.DB.Data;
using BlogApplication.DB.DBExecuter;
using BlogApplication.WCF;
using LoanManagement.Platform.Container;
using LoanManagement.Platform.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Unity;

namespace BlogWebAPI.Tests.WCF
{
    [TestClass]
    public class WCFTest
    {
       
        [TestMethod]
        public void GivenPageOfProductServiceIn_When_ExecuterInvoked_Then_PageOfProductServiceOutIsObtained()
        {
            ApplicationContainer.GetContainer().RegisterSingleton<BlogApplication.DB.Interfaces.IProductsDatabaseExecuter, BlogApplication.DB.DBExecuter.ProductsDatabaseExecuter>();
            ApplicationContainer.GetContainer().RegisterSingleton<BlogApplication.WCF.Interfaces.IProductRepository, BlogApplication.WCF.Repository.ProductRepository>();

            CustomMapper.RegisterMapping<BlogApplication.DB.Data.BaseResponseDB, BlogApplication.WCF.DataContract.BaseOut>();
            CustomMapper.RegisterMapping<BlogApplication.DB.Data.ErrorDB, BlogApplication.WCF.DataContract.Error>();

            CustomMapper.RegisterMapping<BlogApplication.DB.Data.ProductDB, BlogApplication.WCF.DataContract.PageOfProductServiceOutItem>();
            CustomMapper.RegisterMapping<BlogApplication.DB.Data.ProductListResponseDB, BlogApplication.WCF.DataContract.PageOfProductServiceOut>();            

            CustomMapper.RegisterMapping<BlogApplication.WCF.DataContract.BaseIn, BlogApplication.DB.Data.ProductPageRequestBase>();
            CustomMapper.RegisterMapping<BlogApplication.WCF.DataContract.PageOfProductServiceIn, BlogApplication.DB.Data.ProductPageRequest>();

            CustomMapper.CloseMappingRegistration();

            BlogApplication.WCF.ProductService executer = new ProductService();
            BlogApplication.WCF.DataContract.PageOfProductServiceIn objSvIn= new BlogApplication.WCF.DataContract.PageOfProductServiceIn();
            objSvIn.PageNumber = 1;
            objSvIn.RowsPerPage = 1;
            objSvIn.TextFilter = "MOUSE";

            BlogApplication.WCF.DataContract.PageOfProductServiceOut products = executer.GetPageOfProducts(objSvIn);
            Assert.IsNotNull(products);
        }
       
    }
}
