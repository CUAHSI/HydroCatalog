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
using System.Data.OleDb;

public partial class editlinks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
      this.SqlDataSource1.InsertParameters.Clear();
      this.SqlDataSource1.InsertParameters.Add("NetworkID", Session["NetworkID"].ToString());
      this.SqlDataSource1.InsertParameters.Add("text", this.txtDesc.Text);
      this.SqlDataSource1.InsertParameters.Add("url", this.txtURL.Text);      
      this.SqlDataSource1.Insert();        
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String cname = e.CommandName;
        int index = Convert.ToInt32(e.CommandArgument);
        string linkid = GridView1.DataKeys[index].Value.ToString();
        String iID = Convert.ToString(this.GridView1.DataKeys[index].Value);
        GridViewRow row = GridView1.Rows[index];
        if (cname == "Update")
        {
            //((System.Web.UI.WebControls.TextBox)(GridView1.Rows[4].Cells[2].Controls[0]))

            string text = ((TextBox)row.Cells[1].Controls[0]).Text;
            string url = ((TextBox)row.Cells[2].Controls[0]).Text;
      
            this.SqlDataSource1.UpdateParameters.Clear();
            this.SqlDataSource1.UpdateParameters.Add("text",  text);
            this.SqlDataSource1.UpdateParameters.Add("url", url);            
            //this.SqlDataSource1.UpdateParameters.Add("NetworkID",  Session["NetworkID"].ToString());
            this.SqlDataSource1.UpdateParameters.Add("linkid", linkid);
            this.SqlDataSource1.Update();
        }
        else if (cname == "Delete") {
            
            this.SqlDataSource1.DeleteParameters.Clear();
            this.SqlDataSource1.DeleteParameters.Add("LinkID", linkid);
            this.SqlDataSource1.Delete();        
        }
        

    }


}
