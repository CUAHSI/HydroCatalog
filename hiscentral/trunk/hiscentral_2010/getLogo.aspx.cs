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

public partial class logoImage : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    //MemoryStream stream = new MemoryStream();
    //SqlConnection connection = new
    //SqlConnection(SqlDataSource1.ConnectionString);
    //try{
    //   String networkname = Request.Params.Get("name").ToString();
    //   if (networkname != null){

   
    //    connection.Open();
    //    SqlCommand command = new
    //    SqlCommand("select logo from HISNetworks where NetworkName='" + networkname + "'", connection);
    //    byte[] image = (byte[])command.ExecuteScalar();
    //    stream.Write(image, 0, image.Length);
    //    Bitmap bitmap = new Bitmap(stream);
    //    Response.ContentType = "image/gif";
    //    bitmap.Save(Response.OutputStream, ImageFormat.Gif);
    //    }
    //  }
    //  catch(Exception ex){
    //    Response.Redirect ("images/defaultlogo.jpg");
    //  }
    //  finally
    //  {
    //    connection.Close();
    //    stream.Close();
    //  }

    String networkname = Request.Params.Get("name");
    string networkid;
    string sql = "";

    if (networkname != null)
    {
      networkname =
      sql = "select logo from HISNetworks where NetworkName='" + networkname + "'";
    }
    else if (Session["NetworkID"] != null)
    {
      networkid = Session["NetworkID"].ToString();
      sql = "select logo from HISNetworks where networkid='" + networkid + "'";
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
        Response.Redirect("images/defaultlogo.jpg");
      }
      finally
      {
        connection.Close();
        stream.Close();
      }
    }
    else
    {
      Response.Redirect("images/defaultlogo.jpg");
    }

    }
  }

