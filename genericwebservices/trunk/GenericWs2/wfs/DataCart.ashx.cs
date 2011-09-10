using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericWebservice
{
    /// <summary>
    /// Summary description for DataCart
    /// </summary>
    public class DataCart : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}