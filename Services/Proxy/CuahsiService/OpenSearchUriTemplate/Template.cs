using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace cuahsi.his.OpenSearchUri
{
    public class Template
    {
        public Template()
        {
            
        }
        public Template(string baseUrl, string url)
        {
            UrlTemplate = new UriTemplate(url);
            BaseUrl = new Uri(baseUrl);
        }
        public Template(Uri baseUrl, UriTemplate urlTemplate)
        {
            UrlTemplate = urlTemplate;
            BaseUrl = baseUrl;
        }

        public Uri BaseUrl { get; set; }

        public UriTemplate UrlTemplate { get; set; }

        public string GetUrl(IDictionary<string, string> properties)
        {
            // in here we will need to test
          
            return UrlTemplate.BindByName(BaseUrl, properties, true).ToString();
        }

        public ReadOnlyCollection<string> ListVariables()
        {
            return UrlTemplate.QueryValueVariableNames;
        }

        //public ReadOnlyCollection<string> ListRequiredVariables()
        //{
        //    return UrlTemplate.QueryValueVariableNames;
        //}
        //public ReadOnlyCollection<string> ListOptionalVariables()
        //{
        //    return UrlTemplate.QueryValueVariableNames;
        //}
    }
}
