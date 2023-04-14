using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogApplication.WCF.DataContract
{
    [DataContract]
    public class BaseIn
    {
        [DataMember]
        public int PageNumber { get;set; }
        [DataMember]
        public int RowsPerPage { get;set; }        
    }
}