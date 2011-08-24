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

public partial class _Default : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

    string sql = "SELECT count(*) as count from Sources";


    DataSet ds = new DataSet();
    SqlConnection con = new SqlConnection(this.SqlDataSource1.ConnectionString);


    using (con)
    {
      SqlDataAdapter da = new SqlDataAdapter(sql, con);
      da.Fill(ds, "count");
    }

    con.Close();
    if (ds.Tables["count"].Rows.Count > 0)
    {
      DataRow row = ds.Tables["count"].Rows[0];
      //NetworkTitle
      string count = row[0].ToString();
      this.lblCount.Text = count + " registered services";

    }
  }
}
