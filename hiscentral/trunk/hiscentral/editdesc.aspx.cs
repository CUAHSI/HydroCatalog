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

public partial class editdesc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
      this.SqlDataSource1.InsertParameters.Clear();
      this.SqlDataSource1.InsertParameters.Add("NetworkID", Session["NetworkID"].ToString());
      this.SqlDataSource1.InsertParameters.Add("title", this.txtTitle.Text);
      this.SqlDataSource1.InsertParameters.Add("text", this.txtDesc.Text);      
      this.SqlDataSource1.Insert();        
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String cname = e.CommandName;
        if (cname == "Update" || cname == "Delete")
        {
          int index = Convert.ToInt32(e.CommandArgument);
          string descid = GridView1.DataKeys[index].Value.ToString();
          String iID = Convert.ToString(this.GridView1.DataKeys[index].Value);
          GridViewRow row = GridView1.Rows[index];
          if (cname == "Update")
          {
            //((System.Web.UI.WebControls.TextBox)(GridView1.Rows[4].Cells[2].Controls[0]))

            string title = ((TextBox)row.Cells[1].Controls[0]).Text;
            string text = ((TextBox)row.Cells[2].Controls[0]).Text;

            this.SqlDataSource1.UpdateParameters.Clear();
            this.SqlDataSource1.UpdateParameters.Add("text", text);
            this.SqlDataSource1.UpdateParameters.Add("title", title);
            this.SqlDataSource1.UpdateParameters.Add("NetworkID", Session["NetworkID"].ToString());
            this.SqlDataSource1.UpdateParameters.Add("descid", descid);
            this.SqlDataSource1.Update();
          }
          else if (cname == "Delete")
          {

            this.SqlDataSource1.DeleteParameters.Clear();
            this.SqlDataSource1.DeleteParameters.Add("descID", descid);
            this.SqlDataSource1.Delete();
          }
        }
        
        //string sDemoLevel = ((DropDownList)e.Item.Cells[2].Controls[0]).SelectedValue;
        //string sValidated = ((DropDownList)e.Item.Cells[3].Controls[0]).SelectedValue;

        //OleDbConnection pOleDBConnection = null;
        //string ConnectionStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionStr"];
        //pOleDBConnection = new OleDbConnection(ConnectionStr);
        //pOleDBConnection.Open();

        ////string sSQL = @"UPDATE [Users] SET Validated = '" + sValidated + "',DemoLevel = '" + sDemoLevel + "' WHERE ValidationCode = '" + sValidationCode + "'";
        //string sSQL = @"UPDATE [Users] SET Validated = '" + sValidated + "',DemoLevel = '" + sDemoLevel + "' WHERE ID2 = " + iID;
        //OleDbCommand pOLEDbCommand = new OleDbCommand(sSQL, pOleDBConnection);
        //pOLEDbCommand.ExecuteNonQuery();

        //pOleDBConnection.Close();
        //this.DataGrid1.EditItemIndex = -1;

        //FillDataGrid("Users");
    }




}
