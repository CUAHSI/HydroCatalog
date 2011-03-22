using System;
using System.IO;
using System.Net;
using TestWebService.WaterOneFlowWebService;
using System.Xml;
using System.Web.Services.Description; // use this to properly process xml wsdl and its port 
using log4net;

// XmlDocument <-- do not use it to read web service.... too much stuff
// Note: 14 August 2008 
// Note: 18 August 2008
// Note: 25 August 2008  this class was test bed for experimenting with various approach to 
//                       testing web methods
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "D:\\Visual Studio 2005\\" +
                                          "Projects\\TestCuahsiHisWaterOneFlowWebService" +
                                          "\\TestCuahsiHisWaterOneFlowWebService\\" + 
                                          "log4netConfig.xml", Watch = true)]
namespace TestWebService
{   // also use uri class for properly generating uri's     
    class TestWaterOneWebService
    {           
        // SoapHttpClientProtocol is parent class for WaterOneFlow
        // Object is parent for 
        private WaterOneFlow testObject;
        private SiteInfoResponseType testResult;
        private int sizeOfGetSitesReturnValue;
        private string wsdlLocation, webServiceLocationSoap, webServiceLocationSoap12;        
        private ServiceDescription wsdlObject;
        private static readonly ILog logger = LogManager.GetLogger("TestWaterOneWebService");

        public TestWaterOneWebService() 
        {
            testObject = null;
            testResult = null;
            sizeOfGetSitesReturnValue = 0;
            wsdlLocation = ""; 
            webServiceLocationSoap = ""; 
            webServiceLocationSoap12 = "";
            wsdlObject = null;           
        }            

        public TestWaterOneWebService(string wsdlUrl, bool getSoap12)
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
     
        public void validateWsdl()
        {
            try { // reading wsdl and storing it in testReader               
                if (wsdlObject.ValidationWarnings.Count == 0) {
                    logger.Info(wsdlLocation + " is VALID WSDL.");
                    //Console.WriteLine(wsdlLocation + " is VALID WSDL.");
                } else {
                    logger.Info(wsdlLocation + " is INVALID WSDL and has " +
                                      wsdlObject.ValidationWarnings.Count +
                                      " validation warnings.");                 
                }
            } catch (Exception e) {
                logger.Fatal(e.Message);               
            }
        }

        // hey, make sure to test this first =P argh... 
        // maybe I need to store network:site pair in file and use it to test randomly.... 
        // hmm, not a bad idea... 
        // 
        // 18 Auguest: How should I determinie... testGetSites is operatinal... 
        //             Should I return true if no exceptions are caught ? 
        public void testGetSites()
        {            
            try {
                int size = 0;

                string[] argForGetSites = { "" };                
                
                testResult = testObject.GetSites(argForGetSites, "");
                size = testResult.site.Length;

                logger.Info("Returned string array size from GetSiteInfo: " +
                                  size);                              
            } catch ( Exception e ) {
                logger.Fatal(e.Message);               
            }
        }

        // testing GetValues stuff... 
        // hmm, maybe I should have a parameter that ...
        public bool testGetValues( string networkName, string location,
                                  string variable, string startDate,
                                  string endDate, string authToken, ref string result ) {            
            string theLocation = networkName + ":" + location;
            string theVariable = networkName + ":" + variable;

            // wonder what GetValues return if given parameters are bogus... 
            // NOTE: 19 Sep 2008
            // I am assuming that GetValues will return empty string if invalid 
            // parameter is entered... 
            result = testObject.GetValues(theLocation, theVariable,
                                          startDate, endDate, authToken);           
            
            return ! String.Equals(result, "");
        }        

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

        // by default, only shows value of first element 
        // ok, so I need to keep track of for which site code testGetSiteInfo failed also... 
        // maybe I can modify this to check randomly selected values, with given number for 
        // 
        public void testGetSiteInfo(Boolean showAllSiteValues, Boolean showElementValues)
        {
            if (showAllSiteValues) { // showing all values -__-; will take a while
                if (testResult != null) {
                    for (int i = 0; i < sizeOfGetSitesReturnValue; i++) {
                        testGetSiteInfo_private(i, showElementValues);
                    }
                } else {
                    throw new Exception("Initialize testResult by running testGetSites");
                }
            } else { // only showing value of first site 
                testGetSiteInfo_private(10, showElementValues);
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
                    //Console.WriteLine("Run testGetSiteReturnValues to get network:sitecode values.");
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
        private void showSiteXmlElements(string xmlReturnValue)
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