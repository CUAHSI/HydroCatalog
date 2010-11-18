using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace WFSTest
{
    class HttpGetRequest : HttpRequest
    {

        public HttpGetRequest(string endpointUrl)
            : base(endpointUrl)
        {
        }


        public string RequestURI {
            get
            {
                StringBuilder p = new StringBuilder();
                foreach (string key in paramTable.Keys)
                {
                    if (paramTable[key] != null)
                    {
                        p.Append(key);
                        p.Append("=");
                        p.Append(HttpUtility.UrlEncode(paramTable[key].ToString()));
                        p.Append("&");
                    }
                }

                return EndpointUrl + '?' + p.ToString();
            }
        
        
        }

        public override HttpWebResponse IssueRequest()
        {

            // Build a string with all the params, properly encoded.
            StringBuilder p = new StringBuilder();
            foreach (string key in paramTable.Keys)
            {
                if (paramTable[key] != null)
                {
                    p.Append(key);
                    p.Append("=");
                    p.Append(HttpUtility.UrlEncode(paramTable[key].ToString()));
                    p.Append("&");
                }
            }

            HttpWebRequest req = WebRequest.Create(EndpointUrl+'?'+p.ToString()) as HttpWebRequest;
         
            try
            {
                HttpWebResponse response = req.GetResponse() as HttpWebResponse;
                return response;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
                
        }
    }
}
