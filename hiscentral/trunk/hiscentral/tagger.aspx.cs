using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class tagger : System.Web.UI.Page 
{
    private DataSet dataSet;
    private SqlConnection con;
    private string connect;
    protected void Page_Load(object sender, EventArgs e)
    {
        string email = User.Identity.Name;
        string networkid = "";
        if (Session["NetworkID"] != null)
        {
          networkid = Session["NetworkID"].ToString();
        }
        else
        {
          Response.Redirect("default.aspx");
        }
        this.uem.Value = User.Identity.Name;
        connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        //con = new SqlConnection(connect);
        //string adminchecksql = "Select FullName from Users where Email='" + email + "'";
        //using (con)
        //{
        //    SqlDataAdapter da = new SqlDataAdapter(adminchecksql, con);
        //    dataSet = new DataSet();
        //    da.Fill(dataSet, "NameList");
        //    da.Dispose();
        //}

        //foreach (DataRow myRow in dataSet.Tables["NameList"].Rows)
        //{
        //    uem.Value = myRow["FullName"].ToString();
        //}
        //con.Close();



        //con = new SqlConnection(connect);
        //con.Open();
        //string sourceString = "WHERE ";
        //string sql = "Select SourceID from UserSourceAssociation where Email='" + email + "'";
        //using (con)
        //{
        //    SqlDataAdapter da = new SqlDataAdapter(sql, con);
        //    dataSet = new DataSet();
        //    da.Fill(dataSet, "orgList");
        //    da.Dispose();
        //}
        //int i = 0;
        //foreach (DataRow myRow in dataSet.Tables["orgList"].Rows)
        //{
        //    i++;
        //    sourceString = sourceString + " networkId=" + myRow["SourceID"].ToString();
        //    if (i < dataSet.Tables["orgList"].Rows.Count)
        //    {
        //        sourceString = sourceString + " OR";

        //    }

        //}

        //if (sourceString.Equals("WHERE "))
        //{
        //    sourceString = " ";
        //}
        //con.Close();
        string sourceString = "networkId = " + networkid; 
        SqlDataSource2.SelectCommand="select altvariablename, conceptID, m.conceptKeyword, m.variableID from mappingsapproved as m join variables as v on v.variableid=m.variableID WHERE "+sourceString+" order by datemapped desc";
        //string selectcom = "SELECT [AltVariableName],variableid,SampleMedium FROM [Variables] where (variableID not in (select variableID from MappingsApproved)) " + sourceString.Replace("WHERE ", " AND (");
        //if (selectcom.Contains(" AND ("))
        //{
        //    selectcom = selectcom + ")";
        //}
        string selectcom = "SELECT [AltVariableCode],[AltVariableName],variableid,SampleMedium FROM [Variables] where (variableID not in (select variableID from MappingsApproved)) AND " + sourceString;
                            
        SqlDataSource1.SelectCommand = selectcom;
            //"SELECT [AltVariableName],variableid,SampleMedium FROM [VariablesMapper] where (variableID not in (select variableID from MappingsApproved)) "+sourceString.Replace("WHERE "," AND (");
        GridView1.DataBind();
        GridView2.DataBind();
       // if (GridView1.Rows.Count < 1) {
      //      isEmpty.Text = "<br/><br/><br/><br/>There are no unmapped variables";
       // }
    }

    protected void HandleRowDatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[0].Text.Length > 27)
            {
                e.Row.Cells[0].ToolTip = e.Row.Cells[0].Text;
                e.Row.Cells[0].Text = e.Row.Cells[0].Text.Substring(0, 24) + "...";
            }
            else {
                e.Row.Cells[0].ToolTip = e.Row.Cells[0].Text;
            
            }
        }

    }

    protected void LoadItemsBtn_Click(object sender, EventArgs e)
    {
        GridView1.DataBind();
        GridView2.DataBind();

    }




    protected void HandleRowsDatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Cells[1].Width = new Unit("220px");
            if (e.Row.Cells[1].Text.Length > 22)
            {
                e.Row.Cells[1].ToolTip = e.Row.Cells[1].Text;
                e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 19) + "...";
            }
            else
            {
                e.Row.Cells[1].ToolTip = e.Row.Cells[1].Text;

            }

            if (e.Row.Cells[2].Text.Length > 22)
            {
                e.Row.Cells[2].ToolTip = e.Row.Cells[2].Text;
                e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 19) + "...";
            }
            else
            {
                e.Row.Cells[2].ToolTip = e.Row.Cells[2].Text;

            }
        }

    }


}