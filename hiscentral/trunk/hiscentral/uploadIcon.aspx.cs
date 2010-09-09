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

            string postedfilename = uploadOrgFile.PostedFile.FileName;
            string fileext = postedfilename.Substring(postedfilename.IndexOf('.'));

            //string fileName = Path.GetFileName(uploadFile.PostedFile.FileName);
            
            string folder = Server.MapPath("~/Icons/");
            
           
            networkid = Session["NetworkID"].ToString();
            string fileName = networkid + "orgicon" + fileext;
            // Ensure the folder exists
            //Directory.CreateDirectory(folder);
            string imageurl = ("http://water.sdsc.edu/centralhis2/icons/" + fileName);
            //imageurl.Trim();
            // Save the file to the folder
            uploadOrgFile.PostedFile.SaveAs(Path.Combine(folder, fileName));


            this.SqlDataSource1.UpdateCommand = "UPDATE [HISNetworks] SET [OrgIconPath] = '" + imageurl + "' WHERE [NetworkID] = " + networkid.ToString();
            this.SqlDataSource1.Update();

            this.imgOrgIcon.ImageUrl = imageurl;
            this.imgOrgIcon.Visible = true;

        }
    }

    protected void uploadMapIconButton_Click(object sender, EventArgs e)
    {        // Check to see if a file was actually selected
        if (this.uploadMapFile.PostedFile != null && uploadMapFile.PostedFile.ContentLength > 0)
        {
            // Get the filename and folder to write to

            string postedfilename = uploadMapFile.PostedFile.FileName;
            string fileext = postedfilename.Substring(postedfilename.IndexOf('.'));

            //string fileName = Path.GetFileName(uploadFile.PostedFile.FileName);

            string folder = Server.MapPath("~/Icons/");


            networkid = Session["NetworkID"].ToString();
            string fileName = networkid + "mapicon" + fileext;
            // Ensure the folder exists
            //Directory.CreateDirectory(folder);
            string imageurl = ("http://water.sdsc.edu/centralhis2/icons/" + fileName);
            //imageurl.Trim();
            // Save the file to the folder
            uploadMapFile.PostedFile.SaveAs(Path.Combine(folder, fileName));


            this.SqlDataSource1.UpdateCommand = "UPDATE [HISNetworks] SET [MapIconPath] = '" + imageurl + "' WHERE [NetworkID] = " + networkid.ToString();
            this.SqlDataSource1.Update();

            this.imgMapIcon.ImageUrl = imageurl;
            this.imgMapIcon.Visible = true;

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("network.aspx");
    }
}
