using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ugtuapi.Models
{
    public partial class Person
    {        
        public string PhotoUrl
        {
            get { return string.Format("http://localhost/ugtuapi/photo/{0}", nCode); }
        }
    }
}