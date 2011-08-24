using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GenericWebservice
{
    public partial class WaterML_1_1 : System.Web.UI.Page
    {
        private static Examples examples;
      
        protected void Page_Load(object sender, EventArgs e)
        {
             examples = new Examples();

            examples.ConnectionString = ConfigurationManager.ConnectionStrings["ODDB"].ConnectionString;
            examples.NetworkCode = ConfigurationManager.AppSettings["network"];
            examples.VocabularyCode = ConfigurationManager.AppSettings["vocabulary"];

            List<String> sites = examples.GetSites();
           

            List<String> siteInfos = examples.GetSiteInfo();
            

            var variableSimple = examples.GetVariableSimple();
            

            var varDetailed    = examples.GetVariableDetailed();
            
        }
        [WebMethod]
        public static string GetNetwork()
        {
            return examples.NetworkCode;
        }
        [WebMethod]
        public static string GetVocabulary()
        {
            return examples.VocabularyCode;
        }

        [WebMethod]
        public static string GetSite()
        {
            return examples.GetSites()[0];
        }
    }
}