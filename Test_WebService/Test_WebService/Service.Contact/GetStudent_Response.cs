using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Test_WebService.Service.Contact
{
    [Serializable]
    [XmlRoot("result")]
    public class GetStudent_Response
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public List<Subject> ListSubject { get; set; }
        public int Total
        {
            get
            {
                return ListSubject.Sum(p => p.Mark);
            }
        }
    }
    
}