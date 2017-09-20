using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoke_Webservice.service.contract
{
    public class GetStudent_Res
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }       
        public int Total { get; set; }
    }
    
}