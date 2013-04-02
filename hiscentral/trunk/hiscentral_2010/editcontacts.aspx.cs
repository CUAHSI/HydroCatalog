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

public partial class editcontacts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
      this.SqlDataSource1.InsertParameters.Clear();
      this.SqlDataSource1.InsertParameters.Add("NetworkID", Session["NetworkID"].ToString());
      this.SqlDataSource1.InsertParameters.Add("name", this.txtName.Text);
      this.SqlDataSource1.InsertParameters.Add("title", this.txtTitle.Text);
      this.SqlDataSource1.InsertParameters.Add("email", this.txtEmail.Text);
      this.SqlDataSource1.InsertParameters.Add("phone", this.txtPhone.Text);
      this.SqlDataSource1.InsertParameters.Add("address", this.txtAddress.Text);      
      this.SqlDataSource1.Insert();        
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String cname = e.CommandName;
        int index = Convert.ToInt32(e.CommandArgument);
        string contactid = GridView1.DataKeys[index].Value.ToString();
        String iID = Convert.ToString(this.GridView1.DataKeys[index].Value);
        GridViewRow row = GridView1.Rows[index];
        if (cname == "Update")
        {
            //((System.Web.UI.WebControls.TextBox)(GridView1.Rows[4].Cells[2].Controls[0]))

            string name = ((TextBox)row.Cells[1].Controls[0]).Text;
            string title = ((TextBox)row.Cells[2].Controls[0]).Text;
            string phone = ((TextBox)row.Cells[3].Controls[0]).Text;
            string email = ((TextBox)row.Cells[4].Controls[0]).Text;
            string address = ((TextBox)row.Cells[5].Controls[0]).Text;
      
            this.SqlDataSource1.UpdateParameters.Clear();
            this.SqlDataSource1.UpdateParameters.Add("name",  name);
            this.SqlDataSource1.UpdateParameters.Add("title", title);
            this.SqlDataSource1.UpdateParameters.Add("phone", phone);
            this.SqlDataSource1.UpdateParameters.Add("email", email);
            this.SqlDataSource1.UpdateParameters.Add("address", address);  

            //this.SqlDataSource1.UpdateParameters.Add("NetworkID",  Session["NetworkID"].ToString());
            this.SqlDataSource1.UpdateParameters.Add("contactid", contactid);
            this.SqlDataSource1.Update();
        }
        else if (cname == "Delete") {
            
            this.SqlDataSource1.DeleteParameters.Clear();
            this.SqlDataSource1.DeleteParameters.Add("contactid", contactid);
            this.SqlDataSource1.Delete();        
        }
        

    }


  protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
  {

  }
}
