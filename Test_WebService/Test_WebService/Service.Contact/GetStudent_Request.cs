using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Test_WebService.Service.Contact
{
    [Serializable]
    public class GetStudent_Request
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }

        [XmlElement("ListSubject")]
        public List<Subject> ListSubject { get; set; }
        public Subject Subject { get; set; }
        public List<string> StrArray { get; set; }
    }
}