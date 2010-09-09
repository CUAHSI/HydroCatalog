using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Net;

using System.Data.SqlClient;
using System.Drawing;

using System.IO;
using System.Drawing.Imaging;

public partial class logoImage : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

    string url = "https://svn.sdsc.edu/repo/WATER/CUAHSI/OntologyOwl/StarTree_Current/viewtree.stc" + Request.ServerVariables["QUERY_STRING"];

        WebRequest objWebClient = System.Net.HttpWebRequest.Create(url);
        WebResponse objResponse;

        objResponse = objWebClient.GetResponse();

        String strResult;

        using (StreamReader sr =
            new StreamReader(objResponse.GetResponseStream()))
        {
            strResult = sr.ReadToEnd();
        }

        Response.Write(strResult);

    
  }
}

