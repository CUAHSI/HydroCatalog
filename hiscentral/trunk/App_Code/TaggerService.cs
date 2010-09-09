using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using OntologyTools;
using System.Web.Caching;
using System.Web.Security;
using com.hp.hpl.jena.ontology;
using com.hp.hpl.jena.rdf.model;
using com.hp.hpl.jena.util.iterator;
namespace Tagger
{

    /// <summary>
    /// Summary description for GetVariableName
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class TaggerService : System.Web.Services.WebService
    {

        private DataSet dataSet;
        private SqlConnection con;
        private string connect;
        private HttpContext appContext;
        public TaggerService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public string GetVariableName(string varID)
        {
            string variableName = "error";
            connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
            con = new SqlConnection(connect);
            string sql = "Select AltVariableName from Variables where variableid=" + varID;
            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                dataSet = new DataSet();
                da.Fill(dataSet, "VariableList");
            }

            foreach (DataRow dataRow in dataSet.Tables["VariableList"].Rows)
            {
                variableName = dataRow["AltVariableName"].ToString();
                variableName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(variableName.ToLower());


            }

            return variableName;
        }


        [WebMethod]
        public void FinalizeMapping(string varID, string conceptID,string keyword, string userName)
        {
            //string conceptID = conceptIDstring.Substring(4);
            String sqlupdatestring = "INSERT INTO MappingsApproved (VariableID, ConceptID, conceptKeyword, DateMapped, DateApproved, RegisteringIndividual, ApprovingIndividual, OntologyVersion)" +
                " VALUES ("+varID+","+conceptID+",'"+keyword+"','"+DateTime.Now.ToString() +"','"+DateTime.Now.ToString()+"','"+userName+"','Automatic','2.1')";
            connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
            con = new SqlConnection(connect);
            con.Open();
            SqlCommand updt = new SqlCommand(sqlupdatestring, con);
            updt.ExecuteNonQuery();
            updt.Dispose();
            //drexel.sync.SyncDatabases syncServ = new drexel.sync.SyncDatabases();
            //syncServ.FinalizeMapping(varID, conceptID, userName, "eddy280f");
        }


        [WebMethod]
        public void MapAndSuggest(string activeVarID, string activeConceptID, string suggestion, string userName) {
            String sqlupdatestring = "INSERT INTO MappingsPending VALUES (" + activeVarID + ",'" + activeConceptID + "','" + suggestion + "','"+ DateTime.Now.ToString() + "','"+userName+"')";
            connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
            con = new SqlConnection(connect);
            con.Open();
            SqlCommand updt = new SqlCommand(sqlupdatestring, con);
            updt.ExecuteNonQuery();
            sqlupdatestring = "INSERT INTO MappingsApproved VALUES (" + activeVarID + ",'" + activeConceptID + "','" + DateTime.Now.ToString() + "',NULL,'"+userName+"','Pending','1.0')";
            updt = new SqlCommand(sqlupdatestring, con);
            updt.ExecuteNonQuery();
            updt.Dispose();
            //drexel.sync.SyncDatabases syncServ = new drexel.sync.SyncDatabases();
            //syncServ.MapAndSuggest(activeVarID, activeConceptID,suggestion,userName,"eddy280f");
        
        }


        [WebMethod]
        public void MapAndRemovePendingStatus(string activeVarID, string activeConceptID, string otherConceptID, string userName)
        {
            String sqlupdatestring = "DELETE FROM MappingsPending WHERE VariableID=" + activeVarID + "AND ConceptID='" + otherConceptID + "'";
            connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
            con = new SqlConnection(connect);
            con.Open();
            SqlCommand updt = new SqlCommand(sqlupdatestring, con);
            updt.ExecuteNonQuery();
            sqlupdatestring = "UPDATE MappingsApproved SET ApprovingIndividual='"+userName+"', DateApproved='"+DateTime.Now.ToString()+"', ConceptID='"+activeConceptID+"' where ConceptID='"+otherConceptID+"' AND VariableID="+activeVarID;
            updt = new SqlCommand(sqlupdatestring, con);
            updt.ExecuteNonQuery();
            updt.Dispose();
            //drexel.sync.SyncDatabases syncServ = new drexel.sync.SyncDatabases();
            //syncServ.MapAndRemovePendingStatus(activeVarID, activeConceptID, otherConceptID, userName, "eddy280f");

        }



        [WebMethod]
        public void RefreshTree() {

           inxightTreeCreator myTree = new inxightTreeCreator("http://cbe.cae.drexel.edu/ontology/search.owl", "D:/Tagger/");

        }


        [WebMethod]
        public PendingMappingObject GetPendingMappingInfo(string varID)
        {
            PendingMappingObject myp = new PendingMappingObject();
            string variableName = "error";
            string conceptname = "not applicable";
            string suggestion = "no suggestion provided";
            connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
            con = new SqlConnection(connect);
            string sql = "Select AltVariableName, ConceptID, TextualDescription from MappingsPending as p join Variables as v on v.variableID=p.variableID where p.variableid=" + varID;
            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                dataSet = new DataSet();
                da.Fill(dataSet, "VariableList");
            }

            foreach (DataRow dataRow in dataSet.Tables["VariableList"].Rows)
            {
                variableName = dataRow["AltVariableName"].ToString();
                conceptname = dataRow["ConceptID"].ToString();
                suggestion = dataRow["TextualDescription"].ToString();
                variableName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(variableName.ToLower());
                myp.Suggestion = suggestion;
                myp.VariableName = variableName;
                myp.ConceptID = conceptname;
                


            }


            return myp;

        }

        [WebMethod (CacheDuration=0,BufferResponse=false)]
        public bool CheckIfUnique(string conceptID) {

            bool doesExist = false;
         // //  appContext = HttpContext.Current;
         // //  OntModel m = (OntModel)appContext.Cache["SearchOntology"];


         // //  if (m == null)
         ////   {
         //       OntologyLoader myLoader = new OntologyLoader("http://cbe.cae.drexel.edu/ontology/search.owl");
         //     OntModel m = myLoader.getOntologyModel();
         //  //     appContext.Cache.Insert("SearchOntology", m);

         ////   }

         //   for (ExtendedIterator allClassesItr = m.listClasses(); allClassesItr.hasNext(); )
         //   {

         //       OntClass k = (OntClass)allClassesItr.next();
         //       string classname = k.getLocalName();
         //       if (classname != null && classname.ToLower().Equals(conceptID.ToLower()))
         //       {

         //           doesExist = true;
         //       }

         //   }
         ////--   m.close();

          //  if (!doesExist) {
          //      m = null;
          //      appContext.Cache.Remove("SearchOntology");
          //  }
            return !doesExist;

        }

    }


    public class PendingMappingObject
    {
        public string ConceptID;
        public string VariableName;
        public string Suggestion;


        public PendingMappingObject()
        {

        }

        public PendingMappingObject(string cid, string varName, string sugg)
        {
            ConceptID = cid;
            VariableName = varName;
            Suggestion = sugg;
        }
    }

}