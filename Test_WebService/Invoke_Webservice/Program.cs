using Invoke_Webservice.service.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoke_Webservice
{
    class Program
    {
        static void Main(string[] args)
        {
            var liststring = new List<string>();
            liststring.Add("sas");
            liststring.Add("fdfdfd");
            var serviceClient = new WebService("GetStudent", new GetStudent_Req
            {
                Age = 20,
                Name = "bbbbbbb",
                Phone = "1111111111",
                Subjects = (new List<Subject> { new Subject { SubjectName = "Toán", Mark = "10" } }),
                Subject = new Subject { SubjectName = "Lý", Mark = "10" },
                StrArray = liststring

            });
            serviceClient.Invoke();
            Console.WriteLine(serviceClient.ResponseSOAP);
            Console.ReadLine();
        }
    }
}
