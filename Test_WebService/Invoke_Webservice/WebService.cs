using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Invoke_Webservice
{
    public class WebService
    {
        public string Url => "http://localhost:41462/WebService_practise.asmx";
        public string Method { get; private set; }
        public Dictionary<string, Object> Params = new Dictionary<string, Object>();
        public XDocument ResponseSOAP = XDocument.Parse("<root/>");
        public XDocument ResultXML = XDocument.Parse("<root/>");
        public string ResultString = String.Empty;
        public Object RequestParam { get; set; }
        public WebService()
        {
            Method = String.Empty;
        }

        public WebService(string methodName)
        {

            Method = methodName;
        }
        public WebService(string methodName, Object request_param)
        {
            RequestParam = request_param;
            Method = methodName;
            Params.Add("request", RequestParam);
        }

        // Public API

        /// <summary>
        /// Adds a parameter to the WebMethod invocation.
        /// </summary>
        /// <param name="name">Name of the WebMethod parameter (case sensitive)</param>
        /// <param name="value">Value to pass to the paramenter</param>
        public void AddParameter(string name, string value)
        {
            Params.Add(name, value);
        }

        public void Invoke()
        {
            Invoke(Method, true);
        }

        /// <summary>
        /// Using the base url, invokes the WebMethod with the given name
        /// </summary>
        /// <param name="methodName">Web Method name</param>
        public void Invoke(string methodName)
        {
            Invoke(methodName, true);
        }

        /// <summary>
        /// Cleans all internal data used in the last invocation, except the WebService's URL.
        /// This avoids creating a new WebService object when the URL you want to use is the same.
        /// </summary>
        public void CleanLastInvoke()
        {
            ResponseSOAP = ResultXML = null;
            ResultString = Method = String.Empty;
            Params = new Dictionary<string, Object>();
        }

        /// <summary>
        /// Checks if the WebService's URL and the WebMethod's name are valid. If not, throws ArgumentNullException.
        /// </summary>
        /// <param name="methodName">Web Method name (optional)</param>
        private void AssertCanInvoke(string methodName = "")
        {
            if (Url == String.Empty)
                throw new ArgumentNullException("You tried to invoke a webservice without specifying the WebService's URL.");
            if ((methodName == "") && (Method == String.Empty))
                throw new ArgumentNullException("You tried to invoke a webservice without specifying the WebMethod.");
        }

        /// <summary>
        /// Invokes a Web Method, with its parameters encoded or not.
        /// </summary>
        /// <param name="methodName">Name of the web method you want to call (case sensitive)</param>
        /// <param name="encode">Do you want to encode your parameters? (default: true)</param>
        private void Invoke(string methodName, bool encode)
        {
            AssertCanInvoke(methodName);
            string soapStr =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                  "<soap:Body>" +
                    "<{0} xmlns=\"http://tempuri.org/\">" +
                      "{1}"+
                    "</{0}>" +
                  "</soap:Body>" +
                "</soap:Envelope>";
            //"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            //"<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
            //  "<soap:Body>"+
            //    "<GetStudent xmlns=\"http://tempuri.org/\">"+
            //      "<request>"+
            //        "<Name>bbb</Name>"+
            //        "<Age>34</Age>"+
            //        "<Phone>fffffff</Phone>"+
            //      "</request>"+
            //    "</GetStudent>"+
            //  "</soap:Body>"+
            //"</soap:Envelope>";
           
             XDocument _postParamXml = RequestParam != null ? Utils.RemoveNamespaces(Utils.CreateXML(RequestParam)) : new XDocument();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
            req.Headers.Add("SOAPAction", "\"http://tempuri.org/" + methodName + "\"");
            req.ContentType = "text/xml;charset=\"utf-8\"";
            req.Accept = "text/xml";
            req.Method = "POST";
            soapStr = string.Format(soapStr, methodName, _postParamXml.ToString());

            using (Stream stm = req.GetRequestStream())
            {
                using (StreamWriter stmw = new StreamWriter(stm))
                {
                    stmw.Write(soapStr);
                }
            }

            using (StreamReader responseReader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                string result = responseReader.ReadToEnd();
                ResponseSOAP = XDocument.Parse(Utils.UnescapeString(result));
            }

        }
    }
}