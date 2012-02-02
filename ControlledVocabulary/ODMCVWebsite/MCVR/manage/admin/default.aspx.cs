using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class manage_admin_Default : System.Web.UI.Page
{
    AdminAccess current = new AdminAccess();

    protected void Page_Load(object sender, EventArgs e)
    {
        Managers.DataBind();
        Users.DataBind();
    }

    protected void Managers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
       {
           LinkButton SelectUser = (LinkButton)e.Row.FindControl("SelectUserButton");
           SelectUser.OnClientClick = "window.open('account.aspx?User=" + (string)DataBinder.Eval(e.Row.DataItem, "UserName") + "',null,'height=600, width=600,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no ');";
               
       }
    }


    protected void Users_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton SelectUser = (LinkButton)e.Row.FindControl("SelectUserButton2");
            SelectUser.OnClientClick = "window.open('account.aspx?User=" + (string)DataBinder.Eval(e.Row.DataItem, "UserName") + "',null,'height=600, width=600,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no ');";

        }
    }
}
