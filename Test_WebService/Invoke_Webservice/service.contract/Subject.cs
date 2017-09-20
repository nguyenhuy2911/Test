
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoke_Webservice.service.contract
{
    [Serializable]    
    public class Subject
    {
        [XmlElement("SubjectName")]
        public string SubjectName { get; set; }

        [XmlElement("Mark")]
        public string Mark { get; set; }
    }
}
