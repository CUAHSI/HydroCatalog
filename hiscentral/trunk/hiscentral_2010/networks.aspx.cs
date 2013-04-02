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

public partial class networks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Membership.GetUser() == null) Response.Redirect("Login.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string x = GridView1.SelectedRow.DataItem.ToString();

        string id = GridView1.SelectedValue.ToString();
        Session["NetworkID"] = id;
        Response.Redirect("network.aspx");

    }
}
