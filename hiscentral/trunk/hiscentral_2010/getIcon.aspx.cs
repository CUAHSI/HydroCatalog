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

using System.Data.SqlClient;
using System.Drawing;

using System.IO;
using System.Drawing.Imaging;

public partial class iconImage : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    String networkname=Request.Params.Get("name");
    string networkid;
    string sql = "";
     
    if (networkname != null){
      networkname = 
      sql = "select icon from HISNetworks where NetworkName='" + networkname + "'";
    } else if (Session["NetworkID"]!=null){
      networkid = Session["NetworkID"].ToString();
      sql = "select icon from HISNetworks where networkid='" + networkid + "'";
    }
    if (sql != "")
    {

      MemoryStream stream = new MemoryStream();
      SqlConnection connection = new
        SqlConnection(SqlDataSource1.ConnectionString);
      try
      {
        connection.Open();
        SqlCommand command = new
        SqlCommand(sql, connection);
        byte[] image = (byte[])command.ExecuteScalar();
        stream.Write(image, 0, image.Length);
        Bitmap bitmap = new Bitmap(stream);
        Response.ContentType = "image/gif";
        bitmap.Save(Response.OutputStream, ImageFormat.Gif);
      }
      catch (Exception)
      {
        Response.Redirect("images/defaulticon.gif");
      }
      finally
      {
        connection.Close();
        stream.Close();
      }
    }
    else {
      Response.Redirect("images/defaulticon.gif");
    }
  }
}
