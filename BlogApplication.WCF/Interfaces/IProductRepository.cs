using BlogApplication.WCF.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.WCF.Interfaces
{
    public interface IProductRepository
    {
        PageOfProductServiceOut GetPageOfProducts(PageOfProductServiceIn objDbIn);
    }
}
