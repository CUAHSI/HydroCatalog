using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GetCVs
/// </summary>
public class GetCVs : DataAccess
{
    private SqlConnection conn;

    public GetCVs()
	{
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CUAHSIWebsiteConnectionString"].ConnectionString);
    }

    public DataTable GetCVInfo(string type)
    {
        DataTable CVList = new DataTable();
        if (type != null)
        {
            if (type == "cv10")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM cv10 ORDER BY name", conn);
                    CVList = ExecuteSelectCommand(cmd);                
                }
            else
            if (type == "cv11")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM cv11 ORDER BY name", conn);
                    CVList = ExecuteSelectCommand(cmd);
                }
        }
        return CVList;
    }
}
