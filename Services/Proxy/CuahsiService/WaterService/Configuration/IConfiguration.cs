using System;
using System.Collections.Generic;
using System.Text;

namespace cuahsi.his.WaterService.Configuration
{
   public interface IConfiguration
    {
       
    }

    public  abstract  class aConfiguration : IConfiguration
    {
        public String ServiceName;
        public  String VariablesRestUriTemplate;
        public  String SitesRestUriTemplate;
        public  String SiteInfoRestUriTemplate;
        public String TimeSeriesRestUriTemplate;

        public String VariablesRestXslt;
        public String SitesRestXslt;
        public String SiteInfoRestXslt;
        public String TimeSeriesRestXslt;
    }
}
