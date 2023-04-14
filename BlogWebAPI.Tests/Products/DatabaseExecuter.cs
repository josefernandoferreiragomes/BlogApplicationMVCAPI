
using BlogApplication.DB.Data;
using BlogApplication.DB.DBExecuter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BlogWebAPI.Tests.Products
{
    [TestClass]
    public class DatabaseExecuter
    {
        [TestMethod]
        public void GivenPageAndPageNumber_When_ExecuterInvoked_Then_ProductListIsObtained()
        {
            ProductsDatabaseExecuter executer = new ProductsDatabaseExecuter();
            ProductPageRequest request = new ProductPageRequest
            {
                PageNumber = 1,
                RowsPerPage = 1,
                TextFilter=""
                
            };
            List<ProductDB> products = executer.StoredProcedureCall(request);
            Assert.IsNotNull(products);
        }
    }
}
