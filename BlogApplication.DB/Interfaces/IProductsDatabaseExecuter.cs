using BlogApplication.DB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.DB.Interfaces
{
    public interface IProductsDatabaseExecuter
    {
        List<ProductDB> StoredProcedureCall(ProductPageRequest request);
    }
}
