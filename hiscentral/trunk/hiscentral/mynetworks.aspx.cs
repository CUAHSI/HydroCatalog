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
        //Membership.GetUser() == null) Response.Redirect("login.aspx?url="+Request.Url.AbsolutePath);
    }
    protected void GridView1_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
    {

        int index = int.Parse(e.CommandArgument.ToString());
        GridView1.SelectedIndex = index;
        if (e.CommandName == "Select") {
            Session["NetworkID"] = this.GridView1.SelectedValue;
            Response.Redirect("network.aspx");
        }
        else
        {
            Session["NetworkName"] = this.GridView1.Rows[index].Cells[2].Text;
            Session["NetworkWSDL"] = this.GridView1.Rows[index].Cells[3].Text;
            Response.Redirect("testpage.aspx");
        }

    

    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void SqlDataSource1_Init(object sender, EventArgs e)
    {
        if (Membership.GetUser() == null) Response.Redirect("Login.aspx");
        SqlDataSource1.SelectCommand += "Where username = '" + Membership.GetUser().UserName + "'";

    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridView1.SelectedIndex = index;
        if (e.CommandName == "Select") {
            Session["NetworkID"] = this.GridView1.SelectedValue;
            Response.Redirect("network.aspx");
        }
        else
        {
            Session["NetworkName"] = this.GridView1.Rows[index].Cells[2].Text;
            Session["NetworkWSDL"] = this.GridView1.Rows[index].Cells[3].Text;
            Response.Redirect("testpage.aspx");
        }

    }


    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}
