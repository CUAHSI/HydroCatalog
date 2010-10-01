using System;
using System.Net;
using System.Text.RegularExpressions;
using log4net;

namespace TestWebService
{
    class CheckIndivSiteUP
    {
        // ok, basic idea is to test if site is up or down... 
        private HttpWebRequest checkSiteUpOrDown;
        private HttpStatusCode returnedStatusCode;
        private string uriForTest;
        private static readonly ILog logger = LogManager.GetLogger("CheckIndivSiteUP");

        public CheckIndivSiteUP()
        {
            throw new Exception("Use constructor with string argument for uri !!!");
        }

        // hmm, should I check if uri starts with... https or http ?
        public CheckIndivSiteUP(string uri)
        {
            initialize(uri);
        }

        public void setNewUri(string uri)
        {
            initialize(uri);
        }

        private void initialize(string uri)
        {
            // trying to check if uri argument starts with http:// or https://
            Regex checkHttpString = new Regex("^(http://)|(https://).*");
            Match matchingHttpOrHttps = null;

            uriForTest = uri;
            returnedStatusCode = HttpStatusCode.Forbidden;
            matchingHttpOrHttps = checkHttpString.Match(uriForTest);

            if ( matchingHttpOrHttps.Success ) {
                checkSiteUpOrDown = (HttpWebRequest)WebRequest.Create(uriForTest);
            } else {
                throw new Exception("Use full url starting with http:// or https://");
            }
        }

        private Boolean checkSiteLive()
        {
            Boolean siteLiveOrDead = false;

            try {
                WebResponse responseFromWebSite = checkSiteUpOrDown.GetResponse();
                
                returnedStatusCode = ((HttpWebResponse)responseFromWebSite).StatusCode;

                switch ( returnedStatusCode ) {
                    case HttpStatusCode.Accepted:
                    case HttpStatusCode.Continue:
                    case HttpStatusCode.Created:
                    case HttpStatusCode.Found:
                    case HttpStatusCode.OK:
                    case HttpStatusCode.PartialContent:                
                        siteLiveOrDead = true;
                        break;
                }

                responseFromWebSite.Close();
            } catch ( WebException e) {
                logger.Fatal(e.Message);                
            } catch ( Exception e ) {
                logger.Fatal(e.Message);                
            }

            return siteLiveOrDead;
        }

        public void testSiteLiveOrDead(int numToRepeat)
        {
            for (int i = 0; i < numToRepeat; i++) {
                if (checkSiteLive() == true) {
                    logger.Info(uriForTest + " is UP at attempt " + (i + 1));                                 
                } else {
                    logger.Info(uriForTest + " is DOWN attempt " + (i + 1));                                    
                }

                logger.Info("Returned HTTP response status code is " + returnedStatusCode.ToString());                
            }
        }
    }
}
