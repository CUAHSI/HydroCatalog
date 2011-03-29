using System;
using System.IO;
using System.Net;
using WaterOneFlowWebServiceTests.WaterOneFlowWebService;
using System.Xml;
using System.Web.Services.Description;
using log4net;


// XmlDocument <-- do not use it to read web service.... too much stuff
// Note: 14 August 2008 
// Note: 18 August 2008
// Note: 25 August 2008  this class was test bed for experimenting with various approach to 
//                       testing web methods
[assembly: log4net.Config.XmlConfigurator(ConfigFile = 
                                          "log4netConfig.xml", Watch = true)]
namespace WaterOneFlowWebServiceTests
{
    public class WaterOneFlowWebMethodTests
    {
        // SoapHttpClientProtocol is parent class for WaterOneFlow
        // Object is parent for 
        private WaterOneFlow testObject;
        private SiteInfoResponseType testResult;
        private int sizeOfGetSitesReturnValue;
        private string wsdlLocation, webServiceLocationSoap, webServiceLocationSoap12;        
        private ServiceDescription wsdlObject;
        private static readonly ILog logger = LogManager.GetLogger("TestWaterOneWebService");     

        public WaterOneFlowWebMethodTests() 
        {
            testObject = null;
            testResult = null;
            sizeOfGetSitesReturnValue = 0;
            wsdlLocation = ""; 
            webServiceLocationSoap = ""; 
            webServiceLocationSoap12 = "";
            wsdlObject = null;           
        }

        public WaterOneFlowWebMethodTests( string wsdlUrl, bool getSoap12 )
        {                        
            initialize(wsdlUrl, getSoap12);
        }

        private void initialize(string wsdlUrl, bool getSoap12)                               
        {
            // wonder what I should do about test result ...  
            // I will wait on implementing file options after I'm done making rest of the
            // test to work.          
            testObject = new WaterOneFlow() ;

            HttpWebRequest wsdlRequest = null;
            HttpWebResponse wsdlResponse = null;                      
            Uri wsdlUri = new Uri(wsdlUrl);
            

            if (wsdlUri.Scheme == Uri.UriSchemeHttp) {
                wsdlRequest = (HttpWebRequest)HttpWebRequest.Create(wsdlUri);
                // hmm, why am I chossing Get method ??? Will this code still work with 
                // POST method ?
                wsdlRequest.Method = WebRequestMethods.Http.Get;
                wsdlResponse = (HttpWebResponse)wsdlRequest.GetResponse();
                
                // reading http response body stream, and extracting address binding location 
                // from the port for soap and soap1.2
                try {
                    wsdlObject = ServiceDescription.Read(wsdlResponse.GetResponseStream(), true);
                    
                    // code to remember ... for getting attribute from WSDL 
                    SoapAddressBinding addressBinding = null;

                    // initializing webServiceLocationSoap and webServiceLocationSoap12 
                    addressBinding = (SoapAddressBinding)wsdlObject.Services[0].Ports[0].Extensions.Find(
                                          typeof(SoapAddressBinding));
                    webServiceLocationSoap12 = addressBinding.Location;
                    addressBinding = (SoapAddressBinding)wsdlObject.Services[0].Ports[1].Extensions.Find(
                                          typeof(SoapAddressBinding));
                    webServiceLocationSoap = addressBinding.Location;

                    testObject.Url = getSoap12 ? webServiceLocationSoap12 : webServiceLocationSoap;                                     
                } catch ( Exception e ) {
                    Console.WriteLine(e.Message);
                } finally {
                    if ( wsdlResponse != null ) {
                        wsdlResponse.Close();
                    }                    
                }
            }            
                        
            testResult = null;            
            sizeOfGetSitesReturnValue = 0;            
        }

        public string WsdlLocation
        {
            get {
                return wsdlLocation;
            }

            set {
                wsdlLocation = value;

                initialize(wsdlLocation, true);
            }
        }

        public string WebServiceUrlSoap12
        { 
            get {
                return webServiceLocationSoap12;
            }
        }

        // url retrieved from wsdl for web service
        public string WebServiceUrlSoap
        {
            get {
                return webServiceLocationSoap;
            }
        }              

        // hey, make sure to test this first =P argh... 
        // maybe I need to store network:site pair in file and use it to test randomly.... 
        // hmm, not a bad idea... 
        // 
        // 18 Auguest: How should I determinie... testGetSites is operatinal... 
        //             Should I return true if no exceptions are caught ? 
        public bool testGetSites()
        {            
            try {
                int size = 0;

                string[] argForGetSites = { "" };                
                
                testResult = testObject.GetSites(argForGetSites, "");
                size = testResult.site.Length;

                logger.Info("Returned string array size from GetSiteInfo: " +
                                  size);
                return true;
            } catch ( Exception e ) {
                logger.Fatal(e.Message);
                return false;
            }            
        }

        // why did I comment this out ??
        public void testGetSitesXml()
        {
            /*
            try {
                SiteInfoResponseType getSitesXmlResult = null;
                string[] argForGetSitesXml = { getSiteCode(0) };
                string xmlReturnValue = testObject.GetSitesXml(argForGetSitesXml, "");

                // this is bit inefficient... maybe I'll modify my code a bit 
                if ( getSitesXmlResult != null ) {
                    showSiteXmlElements( xmlReturnValue );
                }

            } catch ( Exception e ) {
                logger.Fatal(e.Message);                
            }
            */
        }

        // question: Should I compare string returned with value of object from 
        //           GetValuesObject ?? Think they return exact same values, just in 
        //           different format.         
        public bool testGetValues( string networkName, string location,
                                   string variable, string startDate,
                                   string endDate, string authToken, ref string result ) {            
            string theLocation = networkName + ":" + location;
            string theVariable = networkName + ":" + variable;

            // wonder what GetValues return if given parameters are bogus... 
            // NOTE: 19 Sep 2008
            // I am assuming that GetValues will return empty string if invalid 
            // parameter is entered... 
            try {            
                result = testObject.GetValues(theLocation, theVariable,
                                              startDate, endDate, authToken);                

                // ok, now I need to refine this test to check ... 
                // attributes/field returned is not empty !!!! 

                return ! String.IsNullOrEmpty(result);
            } catch ( Exception e ) {
                logger.Info(e.Message);
                logger.Info("Parameter used");
                logger.Info("networkName->" + networkName + "<-");
                logger.Info("location->" + location + "<-");
                logger.Info("variable->" + variable + "<-");
                logger.Info("theLocation->" + theLocation + "<-");
                logger.Info("theVariable->" + theVariable + "<-");
                logger.Info("startDate->" + startDate + "<-");
                logger.Info("endDate->" + endDate + "<-");
                logger.Info("authToken->" + authToken + "<-");
                logger.Info("result-> " + result +" <-");
             
                return false;
            }            
        }

        public bool testGetValues2(string location,
                                   string variable, string startDate,
                                   string endDate, string authToken, ref string result)
        {            
            // wonder what GetValues return if given parameters are bogus... 
            // NOTE: 19 Sep 2008
            // I am assuming that GetValues will return empty string if invalid 
            // parameter is entered... 
            try
            {
                result = testObject.GetValues(location, variable,
                                              startDate, endDate, authToken);

                return !String.IsNullOrEmpty(result);
            }
            catch (Exception e)
            {
                logger.Info(e.Message);
                logger.Info("Parameter used");               
                logger.Info("location->" + location + "<-");
                logger.Info("variable->" + variable + "<-");
                logger.Info("theLocation->" + location + "<-");
                logger.Info("theVariable->" + variable + "<-");
                logger.Info("startDate->" + startDate + "<-");
                logger.Info("endDate->" + endDate + "<-");
                logger.Info("authToken->" + authToken + "<-");
                logger.Info("result-> " + result + " <-");

                return false;
            }
        }    

        // by default, only shows value of first element 
        // ok, so I need to keep track of for which site code testGetSiteInfo failed also... 
        // maybe I can modify this to check randomly selected values, with given number for 
        // 
        public bool testGetSiteInfo(Boolean showAllSiteValues, Boolean showElementValues)
        {
            if (showAllSiteValues) { // showing all values -__-; will take a while
                if (testResult != null) {
                    for (int i = 0; i < sizeOfGetSitesReturnValue; i++) {
                        testGetSiteInfo_private(i, showElementValues);
                    }

                    return true;
                } else {
                    // should I just return false or still throw exception ??
                    throw new Exception("Initialize testResult by running testGetSites");                    
                }
            } else { // only showing value of first site 
                testGetSiteInfo_private(10, showElementValues);
                return true;
            }            
        }

        // I'll probably parametize this to display ... random set of results
        //
        // Remember to correctly type cast this... =P all taken cared by private methods... 
        // String site = testResult.site[100].siteInfo.siteCode[0].network + ":" +
        //               testResult.site[100].siteInfo.siteCode[0].Value;
        //
        // Note: siteCode's index is ALWAYS 0 
        private void testGetSiteInfo_private(int index, Boolean showElements) 
        {
            try { // later, when I use file to store result from GetSites, I can be bit mroe flexible...
                if (testResult == null) {
                    logger.Info("Run testGetSiteReturnValues to get network:sitecode values.");                  
                } else {                    
                    // Showing network and site information from GetSiteInfo web method 
                    testGetSiteInfo_privateNetworkSiteName(index);                                                                                               

                    // showing xml elements for each site, if option is choosen
                    if ( showElements ) {
                        string argForGetSitesXml = getSiteCode(index);
                        string xmlReturnValue = testObject.GetSiteInfo(argForGetSitesXml, "");
                        showSiteXmlElements( xmlReturnValue );
                    }
                }
            } catch ( Exception e ) {
                logger.Info(e.Message);               
            }
        }       
   
        private void testGetSiteInfo_privateNetworkSiteName(int index)
        {
            string networkID = "", siteValue = "", siteName = "";

            networkID = testResult.site[index].siteInfo.siteCode[0].network;
            siteValue = testResult.site[index].siteInfo.siteCode[0].Value;
            siteName = testResult.site[index].siteInfo.siteName;

            logger.Info("Network ID for first site: " + networkID);
            logger.Info("Site Value for first site: " + siteValue);
            logger.Info("Name of Site " + siteName);            
        }

        // returns network:sitecode value from the result of GetSites 
        private string getSiteCode(int index)
        {
            string siteCode = "";

            try {
                siteCode = testResult.site[index].siteInfo.siteCode[0].network + ":" +
                           testResult.site[index].siteInfo.siteCode[0].Value;
                logger.Info(siteCode);
            } 
            catch ( IndexOutOfRangeException e ) {
                logger.Fatal(e.Message);                
            }
            catch ( Exception e ) {
                logger.Fatal(e.Message);               
            }

            return siteCode;
        }

        // used by testGetSiteInfo to show elements for each site info returned 
        public void showSiteXmlElements(string xmlReturnValue)
        {                                               
            StringReader xmlArgument = new StringReader(xmlReturnValue);
            XmlReader testWebServiceReader = XmlTextReader.Create(xmlArgument);    
            String nodeNameAndType = "";

            // ok, so GetSiteInfo spits out XML in actuality.. 
            // GetSiteInof returns string, but I should be able to create .NET XML 
            // object with it
            #if DEBUG_WEBSERV_TEST
            Console.WriteLine(xmlReturnValue);
            #endif

            testWebServiceReader.MoveToFirstAttribute();

            // logic below skips elements without any Text body
            while (testWebServiceReader.Read()) {
                if (testWebServiceReader.NodeType == XmlNodeType.Element) {
                    nodeNameAndType = "Qualified Name: " + testWebServiceReader.Name +
                                      " " + testWebServiceReader.NodeType;
                    testWebServiceReader.Read();
                    if (testWebServiceReader.NodeType == XmlNodeType.Text) {
                        logger.Info(nodeNameAndType);
                        logger.Info("Element Content: " + testWebServiceReader.Value);                                      
                    }
                }
            }
        }               
    }
}
