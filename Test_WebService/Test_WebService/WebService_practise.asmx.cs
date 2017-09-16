using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Test_WebService.Service.Contact;

namespace Test_WebService
{
    /// <summary>
    /// Summary description for WebService_practise
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]`
    public class WebService_practise : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public GetStudent_Response GetStudent(GetStudent_Request request)
        {
            var response = new GetStudent_Response()
            {
                Age = request.Age,
                Name = request.Name,
                Phone = request.Phone,
                ListSubject = new List<Subject>()
            };
            response.ListSubject.AddRange(request.ListSubject);
            return response;
        }

        [WebMethod]
        public GetStudent_Response GetStudent2()
        {
            var response = new GetStudent_Response()
            {
                Age = "1",
                Name = "aaaaaaaa",
                Phone = "000000000"
            };
            return response;
        }
    }
}
