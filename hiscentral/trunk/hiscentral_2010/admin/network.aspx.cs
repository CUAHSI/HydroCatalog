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

public partial class admin_network : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack) {
        System.Web.Security.MembershipUserCollection users = System.Web.Security.Membership.GetAllUsers();
        System.Web.Security.MembershipUser user;
        IEnumerator userenum = users.GetEnumerator();
        userenum.Reset();
        while (userenum.MoveNext())
        {
          user = (System.Web.Security.MembershipUser)userenum.Current;
          ListItem li = new ListItem(user.UserName);
          if (Membership.GetUser().UserName == user.UserName) li.Selected = true;
          ddlUsers.Items.Add(li);
        }
        if (Request.Params.Get("n") != null) {
          string netid = Request.Params.Get("n");
          Session["NetworkID"] = netid;
        }
      }
    }
  

    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
      Response.Redirect("uploadImages.aspx?icon=org");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("uploadImages.aspx?icon=map");
    }
  protected void LinkButton1_Click(object sender, EventArgs e)
  {
    //SqlDataSource1.Select = "Select NetworkName from HISNetworks where NetworkID = 
    string sourceid = Session["NetworkID"].ToString();
    String sql = "SELECT Organization from Sources WHERE sourceID = " + sourceid;
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
    orgname = dataRow["Organization"].ToString();
    Session["OrgName"] = orgname;
    
    Response.Redirect("SitesInfo.aspx");
  }
  protected void Harvest_Click(object sender, EventArgs e) {
    Response.Redirect("Harvest.aspx");
  }

  protected void LinkButton2_Click(object sender, EventArgs e)
  {
    Response.Redirect("variables.aspx");
  }
  protected void ddlUsers_PreRender(object sender, EventArgs e)
  {
    ddlUsers.Attributes.Add("onchange", "setUser(this.selectedIndex)");
  }
  protected void btnHarvest_Click(object sender, EventArgs e)
  {
    Response.Redirect("harvest.aspx");
  }
  protected void btnStats_Click(object sender, EventArgs e)
  {
    Response.Redirect("calcstats.aspx");
  }

}
