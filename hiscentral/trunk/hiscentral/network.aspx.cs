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

public partial class network : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["NetworkID"] == null) Response.Redirect("default.aspx");
      string sourceid = Session["NetworkID"].ToString();
      this.lnkPublic.NavigateUrl = "pub_network.aspx?n=" + sourceid;
        
    }

    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }

  protected void LinkButton1_Click(object sender, EventArgs e)
  {
    //SqlDataSource1.Select = "Select NetworkName from HISNetworks where NetworkID = 
    string sourceid = Session["NetworkID"].ToString();
    String sql = "SELECT networkname from hisnetworks WHERE networkid = " + sourceid;
    String orgname = " ";
    Console.WriteLine(sql);
    DataSet ds = new DataSet();
    SqlConnection con = new SqlConnection(SqlDataSource1.ConnectionString);

    using (con)
    {
      SqlDataAdapter da = new SqlDataAdapter(sql, con);
      da.Fill(ds, "ID");
    }
    con.Close();
    //should be only one
    DataRow dataRow = ds.Tables["ID"].Rows[0];
    orgname = dataRow["networkname"].ToString();
    Session["OrgName"] = orgname;
    
    Response.Redirect("SitesInfo.aspx");
  }
  protected void Harvest_Click(object sender, EventArgs e) {
    Response.Redirect("Harvest.aspx");
  }

  protected void upload_Click(object sender, EventArgs e)
  {
    Response.Redirect("uploadImages.aspx");
  }


  protected void LinkButton2_Click(object sender, EventArgs e)
  {
    Response.Redirect("variables.aspx");
  }
  protected void LinkButton5_Click(object sender, EventArgs e)
  {
    //Session["NetworkWSDL"] = this.
    Response.Redirect("testpage.aspx");
  }
  protected void LinkButton4_Click(object sender, EventArgs e)
  {
    Response.Redirect("tagger.aspx");
  }
  protected void LnkContacts_Click(object sender, EventArgs e)
  {
    Response.Redirect("editcontacts.aspx");
  }
  protected void lnkLinks_Click(object sender, EventArgs e)
  {
    Response.Redirect("editlinks.aspx");
  }
  protected void lnkDesc_Click(object sender, EventArgs e)
  {
    Response.Redirect("editdesc.aspx");
  }
  protected void LinkButton5_Click1(object sender, EventArgs e)
  {
    // Request harvest
    string netid = Session["NetworkID"].ToString();
    string body = "A network has requested to be harvested: ";// +txtNetworkName.Text;
    body += " http://water.sdsc.edu/hiscentral/admin/network.aspx?n=" + netid;
    //  txtServiceWSDL.Text
    //    Page.User.Identity.Name

    Emailer mailer = new Emailer();
    mailer.sendMessageToAdmins("Harvest Request", body);

    Page.RegisterClientScriptBlock("harvest","<script type=\"Javascript\">alert(\"Your request has been sent\")</script>");
    this.lblMessage.Text = "Your request has been sent.";
  }
  protected void LinkButton6_Click(object sender, EventArgs e)
  {
    // Request harvest
    string netid = Session["NetworkID"].ToString(); ;
    string body = "A network has requested Approval: ";// +txtNetworkName.Text;
    body += " http://water.sdsc.edu/hiscentral/admin/network.aspx?n=" + netid;
    //  txtServiceWSDL.Text
    //    Page.User.Identity.Name

    Emailer mailer = new Emailer();
    mailer.sendMessageToAdmins("Approval Request", body);
    this.lblMessage.Text = "Your request has been sent.";
  }
  protected void upload_Click(object sender, ImageClickEventArgs e)
  {

  }
}
