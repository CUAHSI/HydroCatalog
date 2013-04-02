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
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class admin : System.Web.UI.Page
{
    private DataSet dataSet;
    private SqlConnection con;
    private string connect;
    protected void Page_Load(object sender, EventArgs e)
    {
        string email = User.Identity.Name;
        GridView2.RowDeleting += new GridViewDeleteEventHandler(this.DeleteSynch);

        connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        con = new SqlConnection(connect);
        string adminchecksql = "Select Role, FullName from Users where Email='" + email + "'";
        using (con)
        {
            SqlDataAdapter da = new SqlDataAdapter(adminchecksql, con);
            dataSet = new DataSet();
            da.Fill(dataSet, "RoleList");
            da.Dispose();
        }

        foreach (DataRow myRow in dataSet.Tables["RoleList"].Rows)
        {
            if (!myRow["Role"].ToString().Equals("admin"))
            {
                Response.Redirect("login.aspx", true);

            }
            uem.Value = myRow["FullName"].ToString();
        }
        con.Close();
        con = new SqlConnection(connect);
        con.Open();
        string sourceString = "WHERE ";
        string sql = "Select SourceID from UserSourceAssociation where Email='" + email + "'";
        using (con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            dataSet = new DataSet();
            da.Fill(dataSet, "orgList");
            da.Dispose();
        }
        int i = 0;
        foreach (DataRow myRow in dataSet.Tables["orgList"].Rows)
        {
            i++;
            sourceString = sourceString + " networkId=" + myRow["SourceID"].ToString();
            if (i < dataSet.Tables["orgList"].Rows.Count)
            {
                sourceString = sourceString + " OR";

            }

        }

        if (i>0){
            SqlDataSource2.SelectCommand = "select altvariablename, p.conceptID, m.variableID,TextualDescription from mappingsapproved as m join variables as v on v.variableid=m.variableID join mappingspending as p on p.variableID=m.variableid "+sourceString+" order by m.datemapped desc";
        GridView2.DataBind();
        }
        con.Close();

               

      /*  if (GridView2.Rows.Count == 0 && GridView2.DataSource != null) {
            Response.Write("blank blank");
            DataTable dt = new DataTable();

            // need to clone sources otherwise it will be indirectly adding to 
            // the original source

            if (GridView2.DataSource is DataSet)
            {
                dt = ((DataSet)GridView2.DataSource).Tables[0].Clone();
            }
            else if (GridView2.DataSource is DataTable)
            {
                dt = ((DataTable)GridView2.DataSource).Clone();
            }

 
                dt.Rows.Add(dt.NewRow()); // add empty row
                GridView2.DataSource = dt;
                GridView2.DataBind();

                // hide row
                GridView2.Rows[0].Visible = false;
               GridView2.Rows[0].Controls.Clear();
          
        
        }*/
        
        
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
            else
            {
                e.Row.Cells[0].ToolTip = e.Row.Cells[0].Text;

            }
        }

    }

    protected void LoadItemsBtn_Click(object sender, EventArgs e)
    {

        GridView2.DataBind();
        

    }

    protected void DeleteSynch(object sender, GridViewDeleteEventArgs e)
    {

        //drexel.sync.SyncDatabases mydelcom = new drexel.sync.SyncDatabases();
        //mydelcom.DeleteMapping(GridView2.DataKeys[e.RowIndex].Values[0].ToString(), GridView2.DataKeys[e.RowIndex].Values[1].ToString(), "eddy280f");

        GridView2.DataBind();
    
    }


    protected void CreateConcept(object sender, EventArgs e)
    {
    /* with ontology update
        drexel.ontology.updateOntology newUpdateAction = new drexel.ontology.updateOntology();
        String parentName = newUpdateAction.insertNewConcept(parentID.Value, conceptID.Value, conceptLabel.Value, "drexelcuahsitagger280");

        String fileLoc = "D:/Tagger/tree.stc";
        FileStream file = new FileStream(fileLoc, FileMode.Open, FileAccess.ReadWrite);
        StreamReader sr = new StreamReader(file);
        String ontBody = sr.ReadToEnd();
        ontBody = ontBody.Replace("hydrology,Water Resources,,,,,,,,,,,", "hydrology,Water Resources,,,,,,,,,,,\r\n" + conceptID.Value + "," + conceptLabel.Value.Replace(",", "\\c") + ",,,,,,,,,,,");
        ontBody = ontBody.Replace("[links]", "[links]\r\n" + parentName + "," + conceptID.Value + ",,,,,");
        sr.Close();
        file.Close();
        StreamWriter sw = new StreamWriter(fileLoc,false);
        sw.Write(ontBody);
        sw.Close();
        */
        //drexel.ontology.updateOntology newUpdateAction = new drexel.ontology.updateOntology();
        //String parentName = newUpdateAction.insertNewConcept(parentID.Value, conceptID.Value, conceptLabel.Value, "drexelcuahsitagger280");
        //sdsc.ontology.updateOntology localUpdateAction = new sdsc.ontology.updateOntology();
        //parentName = localUpdateAction.insertNewConcept(parentID.Value, conceptID.Value, conceptLabel.Value, "drexelcuahsitagger280");
        string input = null;
        string parentConceptID=null;

        String fileLoc = "D:/Tagger/tree.stc";
        FileStream file = new FileStream(fileLoc, FileMode.Open, FileAccess.ReadWrite);
        StreamReader sr = new StreamReader(file);
        string parentConceptName = parentID.Value;

        while ((input = sr.ReadLine()) != null)
        {
            int parentConceptIndex = input.IndexOf("," + parentConceptName + ",,,,,");
            if (parentConceptIndex > -1)
            {
                parentConceptID = input.Substring(0, parentConceptIndex);
            
            }
        }
        sr.Close();
        file.Close();

        //if (parentConceptID != null && parentName != null && parentConceptID.Equals(parentName))
        //{
        //    FileStream filek = new FileStream(fileLoc, FileMode.Open, FileAccess.ReadWrite);
        //    StreamReader sk = new StreamReader(filek);
        //    String ontBody = sk.ReadToEnd();
        //    ontBody = ontBody.Replace("hydrology,Water Resources,,,,,,,,,,,", "hydrology,Water Resources,,,,,,,,,,,\r\n" + conceptID.Value + "," + conceptLabel.Value.Replace(",", "\\c") + ",," + conceptID.Value + ",,,,,,,,,");
        //    ontBody = ontBody.Replace("[links]", "[links]\r\n" + parentConceptID + "," + conceptID.Value + ",,,,,");
        //    sk.Close();
        //    filek.Close();
        //    StreamWriter sw = new StreamWriter(fileLoc, false);
        //    sw.Write(ontBody);
        //    sw.Close();
        //    message.Value = "New concept successfully added. Refresh page to see the updates";

        //}
        //else {
        //    message.Value = "An unforeseen error occurred. Addition of the new concept failed.";
        //}

    }



    protected void HandleRowsDatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

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

            if (e.Row.Cells[3].Text.Length > 22)
            {
                e.Row.Cells[3].ToolTip = e.Row.Cells[3].Text;
                e.Row.Cells[3].Text = e.Row.Cells[3].Text.Substring(0, 19) + "...";
            }
            else
            {
                e.Row.Cells[3].ToolTip = e.Row.Cells[3].Text;

            }
        }

    }


    
}
