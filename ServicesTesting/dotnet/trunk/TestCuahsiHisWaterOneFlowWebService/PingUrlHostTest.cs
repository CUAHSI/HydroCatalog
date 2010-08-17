#define DEBUG

using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using log4net;

namespace TestWebService
{
    class PingUrlHostTest
    {
        private static readonly ILog logger = LogManager.GetLogger("PingUrlHostTest");
        private string webServiceUrl, hostName; 

        public PingUrlHostTest()
        {
            webServiceUrl = null;
            hostName = null;
        }

        public PingUrlHostTest(string url)
        {
            webServiceUrl = url;
            hostName = getHostNameFromUrl();
        }

        public void setNewUrl(string url)
        {
            webServiceUrl = url;
            hostName = getHostNameFromUrl();
        }

        private string getHostNameFromUrl()
        {
            Regex stripHostName = new Regex("^http://(\\w|\\.)+");
            Match hostNameMatch = null; 
            string[] splitter = { "//" }, hostNameParts = null;

            hostNameMatch = stripHostName.Match(webServiceUrl);
            hostNameParts = hostNameMatch.Value.Split(splitter, System.StringSplitOptions.None);
                       
            if (hostNameParts == null) {
                throw new NullReferenceException("Null reference for host name in given url " +
                                        " in getHostNameFromUrl method, PingUrlHostTest class " +
                                        "when trying to perform regex and string operation on " +
                                        webServiceUrl + " string");
            }

            #if DEBUG_WEBSERV_TEST
            Console.WriteLine("DEBUG: host name, getHostNameFromUrl: " + hostNameParts[1]);
            #endif

            return hostNameParts[1];
        }

        private Boolean pingUrlHost()
        {
            PingReply reply = null; 

            try {
                // Create a buffer of 32 bytes of data to be transmitted.
                const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                const int timeout = 10000;
                byte[] buffer = Encoding.ASCII.GetBytes(data);                
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // Use the default Ttl value which is 128, but change the fragmentation behavior.
                // TTL stands for time to live
                // options.Ttl  this option specifies how many hops packet can have
                // DontFragment option is useful if I want to test MTU (maximum transmission unit)
                // of the routers and gateways used to transmit the packet 
                options.DontFragment = true;                                                                             
        
                reply = pingSender.Send(hostName, timeout, buffer, options);                
            }           
            catch (Exception e) {
                logger.Fatal(e.Message);                
            }

            if ( reply != null && reply.Status == IPStatus.Success) {
                return true;
            } else {
                return false;
            }
        }

        public void testPingUrlHost(int numToRepeat)
        {
            for (int i = 0; i < numToRepeat; i++ ) {
                if ( pingUrlHost() ) {
                    logger.Info(hostName + " SUCCESSFULLY pinged at attempt " + (i + 1));                    
                } else {
                    logger.Info(hostName + " FAILED to response ping at attempt " + (i + 1));                    
                }
            }
        }
    }
}
