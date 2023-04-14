using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogApplication.DB.Data
{    
    public class ErrorDB
    {
 
        public int ErrorCode { get; set; }
 
        public string Message { get; set; }
    }
}