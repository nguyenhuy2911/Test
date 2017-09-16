using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Invoke_Webservice.service.contract
{
    [Serializable]
    [XmlRoot("request")]
    public class GetStudent_Req
    {
        public GetStudent_Req()
        {

        }
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("Phone")]
        public string Phone { get; set; }

        [XmlElement("ListSubject")]
        public  List<Subject> Subjects { get; set; }

        [XmlElement("Subject")]
        public Subject Subject { get; set; }

        public List<string> StrArray { get; set; }
    }


}