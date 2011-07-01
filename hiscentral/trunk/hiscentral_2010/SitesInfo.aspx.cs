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

public partial class SitesInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {

      }

        //String select = "Select siteCode, siteName, Latitude, Longitude, from Sites where Organization = '" + orgname + "';";
         

    }

  protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    if (e.CommandName == "siteinfo")
    {
      int index = int.Parse(e.CommandArgument.ToString());
      GridView1.SelectedIndex = index;
      Session["SiteID"] = this.GridView1.SelectedValue;
      Response.Redirect("seriesinfo.aspx");
    }
  }
  
}
