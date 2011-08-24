using System;
using cuahsi.his.WaterService.Configuration;

namespace cuahsi.CuahsiService
{
    public  class GLDAS_NasaConfiguration10 : IConfiguration
    {
        private static String BaseUrl
        {
            get { return "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?product=GLDAS_NOAH025_3H.001"; }
        }
        public static String ServiceName
        {
            get
            {
                return
                    "GLDAS_NOAH025_3H.001";
            }
        }
        public static String VariablesRestUriTemplate
        {
            get
            {
                return
                 BaseUrl +   "&function=GetVariableInfo&variable={0}";
            }
        }

        public static String SitesRestUriTemplate
        {
            get
            {
                return
   BaseUrl + "&function=GetSites";
            }
        }

        public static String SiteInfoRestUriTemplate
        {
            get
            {
                return
   BaseUrl + "&function=GetSiteInfo&location={0}";
            }
        }

        public static String TimeSeriesRestUriTemplate
        {
            get
            {
                return
                 BaseUrl + "&function=GetVaules&variable={1}&location={0}&startDate={2}&endDate={3}";
            }
        }


        public static string xsltPath
        {
            get { return System.IO.Path.Combine( "v1_0","xslt"); }
        }
        public static String VariablesRestXslt
            {
            get
            {
                return
                 System.IO.Path.Combine(xsltPath,"passthrough_variablesResponse.xslt");
            }
        }
        public static String SitesRestXslt
            {
            get
            {
                return
                 System.IO.Path.Combine(xsltPath, "passthrough_sitesResponse.xslt");
            }
        }
        public static String SiteInfoRestXslt
            {
            get
            {
                return
                System.IO.Path.Combine(xsltPath,"passthrough_sitesResponse.xslt");
            }
        }
        public static String TimeSeriesRestXslt
            {
            get
            {
                return
                 System.IO.Path.Combine(xsltPath, "passthrough_timeSeriesResponse.xslt");
            }
        }
    }
}