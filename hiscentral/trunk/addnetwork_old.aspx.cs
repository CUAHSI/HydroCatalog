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

public partial class addnetwork : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated) Response.Redirect("login.aspx");
        this.SubmitButton.Attributes.Add("disabled", "true");

    }


    protected void InsertCancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("mynetworks.aspx");
    }


    //INSERT INTO HISNetworks(username, NetworkName, ServiceAbs, ServiceWSDL, ContactEmail, ContactName, ContactPhone, Organization, website) 
    //VALUES (,,,,,,,,)">
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        ParameterCollection parms = SqlDataSource1.InsertParameters;
        parms.Clear();
        parms.Add("username", Page.User.Identity.Name);
        parms.Add("NetworkName", txtNetworkName.Text);
        parms.Add("NetworkTitle", txtNetworkTitle.Text);
        parms.Add("ServiceWSDL", txtServiceWSDL.Text);
        parms.Add("ContactName", txtContactName.Text);
        parms.Add("ContactEmail", txtContactEmail.Text);
        parms.Add("ContactPhone", txtContactPhone.Text);
        parms.Add("Organization", txtOrganization.Text);
        parms.Add("website", txtwebsite.Text);
        parms.Add("Citation", CitationTextBox.Text);
        parms.Add("IsPublic", "False");
        parms.Add("IsApproved", "False");
        parms.Add("CreatedDate", DateTime.Now.ToString());

        SqlDataSource1.Insert();
       
        //mailAdmins();
        getNetworkID();
        //Response.Redirect("mynetworks.aspx");
       
    }
  private void getNetworkID() { 
    String sql = "Select max(networkID) as newnetwork from HISNetworks where username = '" + Page.User.Identity.Name + "'";  
    DataSet ds = new DataSet();
    SqlConnection con = new SqlConnection(SqlDataSource1.ConnectionString);
    int netid =0;
    using (con)
    {
      SqlDataAdapter da = new SqlDataAdapter(sql, con);
      da.Fill(ds, "network");
    }
    con.Close();
    //should be only one
    foreach (DataRow dataRow in ds.Tables["network"].Rows)
    {
      netid = (int)dataRow[0];
    }
    if (netid != 0)
    {
      mailAdmins(netid);
      Session["NetworkID"] = netid;
      Response.Redirect("network.aspx");
    }
    else {
      Response.Redirect("mynetworks.aspx");
    }



  }
  private void mailAdmins(int netid)
  {
    string body = "A new network has been added and needs to be harvested: " + txtNetworkName.Text;
    body += " http://water.sdsc.edu/hiscentral/admin/network.aspx?n=" + netid;
    //  txtServiceWSDL.Text
    //    Page.User.Identity.Name

    Emailer mailer = new Emailer();
    mailer.sendMessageToAdmins("Data Service Addeded:", body);
  }
}
