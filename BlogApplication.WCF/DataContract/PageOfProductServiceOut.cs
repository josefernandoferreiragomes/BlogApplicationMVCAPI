using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogApplication.WCF.DataContract
{
    [DataContract]
    public class PageOfProductServiceOut : BaseOut
    {
        [DataMember]
        public List<PageOfProductServiceOutItem> ListOfProducts;
    }
    
}