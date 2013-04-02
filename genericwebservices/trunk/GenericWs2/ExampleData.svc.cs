using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using genericws.example;

namespace GenericWebservice
{
    [ServiceContract(Namespace = "cuahsi.his.genericservices.exampledata")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ExampleData
    {


        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

        public ExampleData()
        {

           


        }
        #region properties
        public String NetworkCode ()
        {
            return ConfigurationManager.AppSettings["network"];
        }
        public String VocabularyCode()
        {
            return ConfigurationManager.AppSettings["vocabulary"];
        }
        public String ServiceLevel()
        {
            return ConfigurationManager.AppSettings["serviceLevel"];
        }
#endregion

        #region datacontext
        [OperationContract]
        [WebGet]
        public IEnumerable<Site> ListSites()
        {
            using (SitesSeriesDataContext OdmLiteDataContext = new SitesSeriesDataContext(ConfigurationManager.ConnectionStrings["ODDB"].ConnectionString))
            {
                var s = OdmLiteDataContext.GetTable<Site>();

                return s.Take(100).ToList();
            }
        }
        [OperationContract]
        [WebGet]
        public IEnumerable<SeriesCatalog> ListSeries()
        {
            using (SitesSeriesDataContext OdmLiteDataContext = new SitesSeriesDataContext(ConfigurationManager.ConnectionStrings["ODDB"].ConnectionString))
            {
                var s = OdmLiteDataContext.GetTable<SeriesCatalog>();

                return s.Take(100).ToList();
            }

        }
        [OperationContract]
        [WebGet]
        public IEnumerable<Variable> ListVariables()
        {
            using (SitesSeriesDataContext OdmLiteDataContext = new SitesSeriesDataContext(ConfigurationManager.ConnectionStrings["ODDB"].ConnectionString))
            {
                var s = OdmLiteDataContext.GetTable<Variable>();
                return s.Take(100).ToList();
            }
        }
        #endregion
        // Add more operations here and mark them with [OperationContract]
    }
}
