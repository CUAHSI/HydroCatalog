using System;
using System.Collections;
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

public partial class manage_admin_manageCV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void NewEntry_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName.ToLower() == "insert" || e.CommandName.ToLower() == "cancel")
        {
            EditContainer.Visible = true;
            AddContainer.Visible = false;            
        }
    }
    protected void AddButton_Click(object sender, EventArgs e)
    {
        EditContainer.Visible = false;
        AddContainer.Visible = true;
    }
    protected void NewEntry_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        GridView1.DataBind();
    }
}
