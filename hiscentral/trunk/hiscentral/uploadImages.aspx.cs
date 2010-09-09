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
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Drawing.Imaging;

public partial class uploadIcon : System.Web.UI.Page
{
    Object networkid;

    protected void Page_Load(object sender, EventArgs e)
    {
         networkid = Session["NetworkID"];
        if (networkid == null) Response.Redirect("default.aspx");

        
        
    }
    protected void uploadOrgIconButton_Click(object sender, EventArgs e)
    {        // Check to see if a file was actually selected
        if (this.uploadOrgFile.PostedFile != null && uploadOrgFile.PostedFile.ContentLength > 0)
        {
            // Get the filename and folder to write to
          int len = uploadOrgFile.PostedFile.ContentLength;
          byte[] pic = new byte[len];
          uploadOrgFile.PostedFile.InputStream.Read(pic, 0, len);
          // Insert the image and comment into the database
          //Image.FromStream

          SqlConnection connection = new SqlConnection(SqlDataSource1.ConnectionString);
          try
          {
            connection.Open();
            SqlCommand cmd = new SqlCommand("update HISNetworks "
              + "set logo=@pic WHERE networkID=@netowrkid", connection);
            cmd.Parameters.AddWithValue("@pic", pic);
            cmd.Parameters.AddWithValue("@netowrkid", networkid);
            cmd.ExecuteNonQuery();
            this.imgOrgIcon.Visible = true;
          }
          catch (SqlException sqEx) {
            string s = sqEx.Message;
          }
          finally
          {
            connection.Close();
          }

        }
    }

    protected void uploadMapIconButton_Click(object sender, EventArgs e)
    {        // Check to see if a file was actually selected

        if (this.uploadMapFile.PostedFile != null && uploadMapFile.PostedFile.ContentLength > 0)
        {
            // Get the filename and folder to write to
          int len = uploadMapFile.PostedFile.ContentLength;
          byte[] pic = new byte[len];
          uploadMapFile.PostedFile.InputStream.Read(pic, 0, len);
          // Insert the image and comment into the database

          SqlConnection connection = new SqlConnection(SqlDataSource1.ConnectionString);
          try
          {
            connection.Open();
            SqlCommand cmd = new SqlCommand("update HISNetworks "
              + "set Icon=@pic WHERE networkID=@netowrkid", connection);
            cmd.Parameters.AddWithValue("@pic", pic);
            cmd.Parameters.AddWithValue("@netowrkid", networkid);
            cmd.ExecuteNonQuery();
            this.imgMapIcon.Visible=true;
          }
          finally
          {
            connection.Close();
          }

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("network.aspx");
    }
}
