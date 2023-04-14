using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogApplication.WCF.DataContract
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}