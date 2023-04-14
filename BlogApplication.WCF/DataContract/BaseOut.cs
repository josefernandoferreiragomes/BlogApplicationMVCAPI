using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogApplication.WCF.DataContract
{
    [DataContract]
    public class BaseOut
    {
        [DataMember]
        public List<Error> Errors;
    }
}