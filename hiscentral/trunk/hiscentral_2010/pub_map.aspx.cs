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
using System.Text;

public partial class pub_map : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

      string sql = "SELECT NetworkID, Xmin, Xmax, Ymin, Ymax FROM hisnetworks WHERE (IsPublic = 'True') AND Xmin is not null";


      DataSet ds = new DataSet();
      SqlConnection con = new SqlConnection(this.SqlDataSource1.ConnectionString);
      
      
      using (con)
      {
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.Fill(ds, "LIST");
      }

      con.Close();
      StringBuilder script = new StringBuilder();
      script.Append("<script type='text/javascript'>\n");
      script.Append(" var box_extents = [");
      DataTable dt = ds.Tables["LIST"];
      DataRow row;
      
      for (int i = 0; i < dt.Rows.Count; i++) {
        row = dt.Rows[i];
        if (i>0) script.Append(',');
        script.Append('[');
        script.Append(row["Xmin"].ToString()).Append(',');
        script.Append(row["Ymin"].ToString()).Append(',');
        script.Append(row["Xmax"].ToString()).Append(',');
        script.Append(row["Ymax"].ToString()).Append(']');
        // xmin, ymin, xmax, ymax
        // [-122.6, 37.6, -122.3, 37.9],
       

      }
      script.Append("];\n");
      script.Append("init();\n");
      script.Append("</script>\n");
 

        
        //ClientScript.RegisterClientScriptBlock(Page.GetType(),"mapscript", script.ToString());
      this.Literal1.Text = script.ToString();
       

    }
}
