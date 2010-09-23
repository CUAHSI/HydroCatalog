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

public partial class admin_Harvest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  protected void Button1_Click(object sender, EventArgs e)
  {
    string sourceid = Session["NetworkID"].ToString();
    //Harvester h = new Harvester(sourceid);
    //h.HarvestNetwork();

    //Response.Redirect("../network.aspx      string datestring = begdate.Year.ToString();
      DateTime begdate = DateTime.Now;
      string datestring = begdate.Year.ToString();
      datestring += (begdate.Month < 10 ? "0" + begdate.Month.ToString() : begdate.Month.ToString());
      datestring += (begdate.Day < 10 ? "0" + begdate.Day.ToString() : begdate.Day.ToString());




      string logfilename = sourceid + "_"+datestring + ".txt";

    //string harvesterPath = "C:/Documents and Settings/whitenac/My Documents/Visual Studio 2005/Projects/HISCentralHarvester/HISCentralHarvester/bin/Debug/HISCentralHarvester.exe";
    string harvesterPath = "C:\\hydroseek\\Harvester\\HISCentralHarvester.exe";
    System.Diagnostics.Process.Start(harvesterPath, sourceid);

    this.HyperLink1.NavigateUrl = "/hydroseekdata/" + logfilename;
    this.HyperLink1.Visible = true;
  }
}
