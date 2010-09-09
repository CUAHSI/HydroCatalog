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

public partial class admin_Ontology : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        TreeNode rootNode = new TreeNode("Hyrdosphere", "hydrosphere");
        PopulateChildNodes( rootNode,"1");
        this.TreeView1.Nodes.Add(rootNode);
        
      }
    }
    private void PopulateChildNodes(TreeNode parentNode, String parentConceptid){
        String sql = "SELECT conceptid, conceptCode, conceptKeyword, parentConcept from concepttree where parentid = " + parentConceptid + ";";

        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(SqlDataSource1.ConnectionString);

        using (con)
        {

          SqlDataAdapter da2 = new SqlDataAdapter(sql, con);
          da2.Fill(ds, "concepts");
        }
        con.Close();


        //should be only one
        String conceptid, conceptcode,conceptKeyword, parentConcept;

        foreach (DataRow dataRow in ds.Tables["concepts"].Rows)
        {
          conceptid = dataRow["conceptid"].ToString();
          conceptcode = dataRow["conceptCode"].ToString();
          conceptKeyword = dataRow["conceptKeyword"].ToString();
          TreeNode childNode = new TreeNode(conceptKeyword,conceptcode);
          parentNode.ChildNodes.Add(childNode);
          PopulateChildNodes(childNode,conceptid);
          //nextIDs.Add(conceptid);
          //conceptcode = dataRow["conceptCode"].ToString();
          
        }
      }


    }
  
  
  

