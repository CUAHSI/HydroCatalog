using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.Web;
using System.IO;

namespace WFSTest
{
    class HttpPostRequest : HttpRequest
    {
       

        public HttpPostRequest(string endpointUrl) : base(endpointUrl)
        {
            
        }

        public override HttpWebResponse IssueRequest()
        {
            HttpWebRequest req = WebRequest.Create(new Uri(EndpointUrl)) as HttpWebRequest;

            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

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

            // Encode the parameters as form data:
            byte[] formData = UTF8Encoding.UTF8.GetBytes(p.ToString());
            req.ContentLength = formData.Length;

            // Send the request:
            using (Stream post = req.GetRequestStream())
            {
                post.Write(formData, 0, formData.Length);
            }

            //Return the response:
            return req.GetResponse() as HttpWebResponse;

        }

        
    }
}
