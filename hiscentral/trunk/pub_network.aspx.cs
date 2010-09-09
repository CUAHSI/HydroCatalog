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
      string networkid = Request.Params.Get("n");
      if (networkid == null)
      {
        if (Session["NetworkID"] == null)
        {
          Response.Redirect("default.aspx");
        }
        else { 
          networkid = Session["NetworkID"].ToString();
        }
        
      }
      Session["NetworkID"] = networkid;
      string NETWORK = " ";
      string sql = "SELECT username, ServiceWSDL, ServiceAbs, NetworkName, ContactName, ContactEmail, ContactPhone, Organization, website, IsPublic, SupportsAllMethods, Citation, MapIconPath, OrgIconPath, LastHarvested, Xmin, Xmax, Ymin, Ymax, ValueCount, VariableCount, SiteCount, EarliestRec, LatestRec, ServiceStatus, ProjectStatus, NetworkTitle, NetworkID, CreatedDate FROM HISNetworks WHERE (NetworkID = "+networkid+")";


      DataSet ds = new DataSet();
      SqlConnection con = new SqlConnection(this.SqlDataSource1.ConnectionString);
      

      using (con)
      {
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.Fill(ds, "NETWORK");
      }

      con.Close();
      if (ds.Tables["NETWORK"].Rows.Count > 0) {
        DataRow row = ds.Tables["NETWORK"].Rows[0];
        //NetworkTitle
        string citation = row["Citation"].ToString();
        if (citation != null && citation != "") {
          this.litCit_Pubs.Text = "<H3>Citation</H3><BR>";
          this.litCit_Pubs.Text += citation;
          this.litCit_Pubs.Text += "<BR><BR>";
        }
        this.lblContactEmailLabel.Text = row["ContactEmail"].ToString();
        this.lblContactNameLabel.Text = row["ContactName"].ToString();
        this.lblContactPhoneLabel.Text = row["ContactPhone"].ToString();
        string networkName = row["NetworkName"].ToString();
        this.lblNetworkNameLabel.Text = networkName;
        this.imgIcon.ImageUrl = "getIcon.aspx?name=" + networkName;
        this.imgLogo.ImageUrl = "getLogo.aspx?name=" + networkName;
        this.lblNetworkTitle.Text = row["NetworkTitle"].ToString();
        this.lblOrganizationLabel.Text = row["Organization"].ToString();
        this.lblServiceWSDLLabel.Text = row["ServiceWSDL"].ToString();
        
        this.litDesc.Text += "<H3>Abstract</H3><BR>";
        this.litDesc.Text += row["ServiceAbs"].ToString();
        this.litDesc.Text += "<BR><BR>";
        string lastHarvested = row["LastHarvested"].ToString();
        if (lastHarvested != null && lastHarvested != "") {
            this.lblLastHarvested.Text = "Last Harvested on " + lastHarvested;
        }
        //this.ServiceAbsLabel.Text = row["ServiceAbs"].ToString(); 
        this.lblSiteCount.Text = row["SiteCount"].ToString();
        this.lblVariableCount.Text = row["VariableCount"].ToString();
        this.lblValueCount.Text = row["ValueCount"].ToString();

        this.lblNorth.Text = row["Ymax"].ToString(); 
        this.lblSouth.Text = row["Ymin"].ToString(); 
        this.lblEast.Text = row["Xmax"].ToString(); 
        this.lblWest.Text = row["Xmin"].ToString(); 

        string mapscript = "<script type='text/javascript'>xmin = " + (row["Xmin"].ToString()) + ";" +
          "xmax = " + (row["Xmax"].ToString()) + ";" +
          "ymin = " + (row["Ymin"].ToString()) + ";" +
          "ymax = " + (row["Ymax"].ToString()) + ";" +
          "</script>";
        RegisterClientScriptBlock("mapscript", mapscript);
        if (Page.User.IsInRole("Administrator") || Page.User.Identity.Name == row["username"].ToString()) {
          this.lnkEdit.Visible = true;
        }
        
      
      }
      AddLinks(networkid);
      AddDescriptions(networkid);

    }

    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
  private void AddDescriptions(string networkid){
          Session["NetworkID"] = networkid;
      string NETWORK = " ";
      string sql = "SELECT descTitle, descText FROM NetworkDesc WHERE (NetworkID = "+networkid+")";


      DataSet ds = new DataSet();
      SqlConnection con = new SqlConnection(this.SqlDataSource1.ConnectionString);
      

      using (con)
      {
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.Fill(ds, "NETWORK");
      }
      //Literal lit;
      //Label lbl;
      con.Close();
    string title, text;
    for (int i=0;i<ds.Tables["NETWORK"].Rows.Count;i++){
           DataRow row = ds.Tables["NETWORK"].Rows[i];
           title = row["DescTitle"].ToString();
           text = row["DescText"].ToString();
           this.litDesc.Text += "<H3>" + title + "</H3><BR>";
           this.litDesc.Text += text;
           this.litDesc.Text += "<BR><BR>";
            
        
     }
  }
    private void AddLinks(string networkid){
          Session["NetworkID"] = networkid;
      string NETWORK = " ";
      string sql = "SELECT linkText, linkURL FROM links WHERE (NetworkID = "+networkid+")";
      

      DataSet ds = new DataSet();
      SqlConnection con = new SqlConnection(this.SqlDataSource1.ConnectionString);
      

      using (con)
      {
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.Fill(ds, "NETWORK");
      }

      con.Close();
    string  text, url;
    string link;
    int count = ds.Tables["NETWORK"].Rows.Count;
    if (count > 0) {
      this.litCit_Pubs.Text += "<H3>Documents and Publications</H3><BR>";
      for (int i = 0; i < ds.Tables["NETWORK"].Rows.Count; i++)
      {
        DataRow row = ds.Tables["NETWORK"].Rows[i];
        text = row["linkText"].ToString();
        url = row["linkURL"].ToString();
        link = "<a href=" + url + " target=_new>" + text + "</a><br>";
        litCit_Pubs.Text += link;

      }
    }
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

  }

}
