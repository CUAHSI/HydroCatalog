using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_deletenetwork : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }
  protected void btnNo_Click(object sender, EventArgs e)
  {
    Response.Redirect("admin.aspx");
  }
  protected void btnYes_Click(object sender, EventArgs e)
  {
    string networkid = "";
    if (Session["NetworkID"] != null)
    {
      networkid = Session["NetworkID"].ToString();
    }
    else
    {
      Response.Redirect("admin.aspx");
    }
    deleteHarvestedData(networkid,true);
    Response.Redirect("admin.aspx");
  }
  protected void Button1_Click(object sender, EventArgs e)
  {
    string networkid = "";
    if (Session["NetworkID"] != null)
    {
      networkid = Session["NetworkID"].ToString();
    }
    else
    {
      Response.Redirect("admin.aspx");
    }
    deleteHarvestedData(networkid, false);
    Response.Redirect("admin.aspx");
  }
  
  //private string getSiteIDs(string networkid, SqlConnection con ){
  //    //string sql = "SELECT distinct siteid FROM seriescatalog where sourceid = " + networkid;
  //    //string sites = "";
  //    //DataSet siteids = new DataSet();
   
  //    //{
  //    //  SqlDataAdapter mxAd = new SqlDataAdapter(sql, con);
  //    //  mxAd.Fill(siteids, "sites");
  //    //  mxAd.Dispose();
  //    //}
  //    //bool first = true;
  //    //foreach (DataRow dRow in siteids.Tables["sites"].Rows)
  //    //{
  //    //  if (first){
  //    //    sites  = dRow[0].ToString();
  //    //  }else{
  //    //    sites += "," + dRow[0].ToString();
  //    //  }
  //    //  first = false;

  //    //}
  //    //return sites;
  //}


  private void deleteHarvestedData(string networkid, bool allofit){


    string connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection(connect);
    con.Open();
    String delsql = "delete mappingsapproved from mappingsapproved  join variables on variables.variableid=mappingsapproved.variableID WHERE variables.networkid = " + networkid;
    SqlCommand command = new SqlCommand(delsql, con);
    command.ExecuteNonQuery();

    //delsql = "delete from seriescatalog where sourceid = " + networkid;
    //command.CommandText = delsql;
    //command.ExecuteNonQuery();

    delsql = "delete from seriescatalog where sourceid = " + networkid;
    command.CommandText = delsql;
    command.ExecuteNonQuery();

    delsql = "delete from variables where networkid = " + networkid;
    command.CommandText = delsql;
    command.ExecuteNonQuery();

    //string sites = getSiteIDs(networkid, con);



    delsql = "delete from sites where networkid =" + networkid;
    command.CommandText = delsql;
    command.ExecuteNonQuery();

    if (allofit)
    {
        delsql = "delete from hisnetworks where networkid = " + networkid;
        command.CommandText = delsql;
        command.ExecuteNonQuery();
    }
    else {
        delsql = "update hisnetworks set Xmin=null, Xmax=null, Ymin=null, Ymax=null, LastHarvested=null, ValueCount=null, VariableCount=null, SiteCount=null" +
        " where networkid = " + networkid;
        command.CommandText = delsql;
        command.ExecuteNonQuery();    
    }

    command.Dispose();
    con.Close();
    
  }

}
