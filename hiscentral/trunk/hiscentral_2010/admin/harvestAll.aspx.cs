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

public partial class HarvestAll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  protected void Button1_Click(object sender, EventArgs e)
  { //log("Begin Harvest for service ID:" + SourceID);
      //log(System.DateTime.Now.ToString());
    String sql = "SELECT NetworkID, NetworkName, FrequentUpdates FROM HISNetworks WHERE (FrequentUpdates = 1) AND (IsPublic = 1)";
      String URL = " ";
     // Console.WriteLine(sql);
      String Organization = " ";
      DataSet ds = new DataSet();
      SqlConnection con = new SqlConnection(this.SqlDataSource1.ConnectionString);

      using (con)
      {
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.Fill(ds, "URL");
      }
      con.Close();
      //should be only one
      String args = "";
      String name, networkid;
      foreach (DataRow dataRow in ds.Tables["URL"].Rows)
      {
        //URL = dataRow["Link"].ToString();
        networkid = dataRow[0].ToString();
        name = dataRow[1].ToString();
        args += networkid + " ";
        
        
      }

      //string logfilename = sourceid + "_"+datestring + ".txt";

    //string harvesterPath = "C:/Documents and Settings/whitenac/My Documents/Visual Studio 2005/Projects/HISCentralHarvester/HISCentralHarvester/bin/Debug/HISCentralHarvester.exe";
    string harvesterPath = "c:\\hydroseek\\Harvester\\HISCentralHarvester.exe";
    System.Diagnostics.Process.Start(harvesterPath, args);

  }
}
