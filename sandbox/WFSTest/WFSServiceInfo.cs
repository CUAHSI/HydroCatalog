using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.IO;
using System.Xml.XPath;
using System.Xml;
using System.Data;

namespace WFSTest
{
    class WFSServiceInfo
    {
        public string WFSEndpoint { get; set; }
        public string Namespace { get; set; }
        public string TypeName { get; set; }
        public DataTable Data { get; set; }

        public WFSServiceInfo(string wfsendpoint, string ns, string typename)
        {
            WFSEndpoint = wfsendpoint;
            Namespace = ns;
            TypeName = typename;
        }

        public WFSServiceInfo(string wfsendpoint)
        {
            WFSEndpoint = wfsendpoint;
            FillInfoWithGetCapabilities();
        }

        public void FillInfoWithGetCapabilities()
        {
            HttpGetRequest wfsGetCapabilitiesRequest = new HttpGetRequest(WFSEndpoint);
            wfsGetCapabilitiesRequest.paramTable = new Hashtable();

            wfsGetCapabilitiesRequest.paramTable.Add("Request", "GetCapabilities");
            wfsGetCapabilitiesRequest.paramTable.Add("Service", "WFS");

            using (HttpWebResponse response = wfsGetCapabilitiesRequest.IssueRequest())
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                XPathDocument docNav = new XPathDocument(reader);
                XPathNavigator nav = docNav.CreateNavigator();
                XmlNamespaceManager manager = new XmlNamespaceManager(nav.NameTable);
                manager.AddNamespace("wfs", "http://www.opengis.net/wfs");
                manager.AddNamespace("ows", "http://www.opengis.net/ows");

                Namespace = nav.Evaluate("string(//ows:ServiceIdentification/ows:Title)", manager).ToString();
                TypeName = nav.Evaluate("string(//wfs:FeatureType/wfs:Title)", manager).ToString();
            }
        }

    }
}
