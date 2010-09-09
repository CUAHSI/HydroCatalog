using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_calcstats : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["NetworkID"] == null) Response.Redirect("admin.aspx");


  }

  //
  protected void Button1_Click(object sender, EventArgs e)
  {
    
    string networkid = Session["NetworkID"].ToString();
    //    SELECT NetworkID, NetworkName, ymin, ymax, xmax, xmin, ValueCount, SiteCount, VariableCount, earliestRec, LatestRec
    //FROM stats_all
    //WHERE (NetworkID = 4)
    string sql = "SELECT NetworkID, NetworkName, ymin, ymax, xmax, xmin, ValueCount, SiteCount, VariableCount, earliestRec, LatestRec FROM stats_all WHERE (NetworkID = " + networkid + ")";
    String URL = " ";
    // Console.WriteLine(sql);
    String Organization = " ";
    DataSet ds = new DataSet();
    SqlConnection con = new SqlConnection(this.SqlDataSource1.ConnectionString);

    using (con)
    {
      SqlDataAdapter da = new SqlDataAdapter(sql, con);
      da.Fill(ds, "stats");
    }
    con.Close();
    DataRow therow = ds.Tables[0].Rows[0];

    sql = "UPDATE HISNetworks SET LatestRec = @latestRec, EarliestRec = @EarliestRec, SiteCount = @SiteCount, VariableCount = @VariableCount, ValueCount = @ValueCount, Ymax = @Ymax, Ymin = @Ymin, Xmax = @Xmax, Xmin = @Xmin WHERE (NetworkID = @NetworkID)";
    SqlDataSource1.UpdateParameters.Clear();
    SqlDataSource1.UpdateParameters.Add("latestRec", therow["latestRec"].ToString());
    SqlDataSource1.UpdateParameters.Add("EarliestRec", therow["EarliestRec"].ToString());
    SqlDataSource1.UpdateParameters.Add("SiteCount", therow["SiteCount"].ToString());
    SqlDataSource1.UpdateParameters.Add("VariableCount", therow["VariableCount"].ToString());
    SqlDataSource1.UpdateParameters.Add("ValueCount", therow["ValueCount"].ToString());
    SqlDataSource1.UpdateParameters.Add("Ymax", therow["Ymax"].ToString());
    SqlDataSource1.UpdateParameters.Add("Ymin", therow["Ymin"].ToString());
    SqlDataSource1.UpdateParameters.Add("Xmax", therow["Xmax"].ToString());    
    SqlDataSource1.UpdateParameters.Add("Xmin", therow["Xmin"].ToString());
    SqlDataSource1.UpdateParameters.Add("NetworkID", Session["NetworkID"].ToString());
    this.SqlDataSource1.Update();
    Response.Redirect("network.aspx");

  }
}
