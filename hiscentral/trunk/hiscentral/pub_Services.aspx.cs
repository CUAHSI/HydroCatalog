using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {        

    }


    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("default.aspx");
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
      
    }

    protected void LoginView1_ViewChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        if (e.CommandName == "Select") {
            index   = int.Parse(e.CommandArgument.ToString());
            GridView1.SelectedIndex = index;
            Session["NetworkID"] = this.GridView1.SelectedValue;
            Response.Redirect("pub_network.aspx");
        }
        else if (e.CommandName=="Test")        {
          index = int.Parse(e.CommandArgument.ToString());
          GridView1.SelectedIndex = index;
            Session["NetworkName"] = this.GridView1.Rows[index].Cells[2].Text;
            Session["NetworkWSDL"] = this.GridView1.Rows[index].Cells[3].Text;
            Response.Redirect("testpage.aspx");
        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
