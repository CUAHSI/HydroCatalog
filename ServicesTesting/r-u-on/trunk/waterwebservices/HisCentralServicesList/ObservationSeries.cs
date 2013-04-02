using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HisCentralServicesList
{
    public class constants
    {
        public const string GETSITES = "Use_GetSites";
        public const string GETVALUES = "Use_GetValues";
        public const string READFROMCENTRAL = "Use_HISCENTRAL_forSeries";
        public const string SERVERNAME = "Server_Name";
        public const string SERVERENABLED = "Server_Enabled";
        public const string ENDPOINT = "Endpoint_Url";
        public const string SITECODE = "ws_SiteCode";
        public const string VARIABLECODE = "ws_VariableCode";
        public const string ISOTIMEPERIOD = "ISO_TimeInterval";

        public const string MONITORSERVICE_SERVICENAME = "WaterWebService";

        public const string MONITORSERVICE_METHOD = "WWS_STATUS";

        public const string URLDISABLED_METHODNAME = "URL_STATUS";
        public const string DISABLED_MESSAGE = " DISABLED";
        public const string ENABLED_MESSAGE = " ENABLED";

    }
    public class ObsSeriesServer
    {
        public String Name { get; set; }
        public Boolean Enabled { get; set; }
        public String Endpoint { get; set; }
        public String SiteCode { get; set; }
        public String VariableCode { get; set; }
        public String ISOTimeInterval { get; set; }
        public ObsSeriesServer()
        {

        }
        public Dictionary<String, String> ToDictionary()
        {
            Dictionary<String, String> asDict = new Dictionary<string, string>(6);
            asDict.Add(constants.SERVERNAME, Name);
            asDict.Add(constants.SERVERENABLED, Enabled.ToString().ToLowerInvariant());
            asDict.Add(constants.ENDPOINT, Endpoint);
            asDict.Add(constants.SITECODE, SiteCode);
            asDict.Add(constants.VARIABLECODE, VariableCode);
            asDict.Add(constants.ISOTIMEPERIOD, ISOTimeInterval);
            return asDict;
        }

        public string[] ToAgentStringArray()
        {
            return this.ToDictionary().Values.ToArray();
        }

    }
    public class ObsSeriesServerList : List<ObsSeriesServer>
    {
        private Boolean _editied = false;
        public ObsSeriesServerList()
        {

        }
        public ObsSeriesServerList(Dictionary<string, string>[] agentMangagedResources)
        {
            foreach (Dictionary<string, string> r in agentMangagedResources)
            {
                ObsSeriesServer server = new ObsSeriesServer();
                Boolean enabled;
                Boolean.TryParse(r[constants.SERVERENABLED], out enabled);
                server.Enabled = enabled;
                server.Endpoint = r[constants.ENDPOINT];
                server.Name = r[constants.SERVERNAME];
                server.SiteCode = r[constants.SITECODE];
                server.VariableCode = r[constants.VARIABLECODE];
                server.ISOTimeInterval = r[constants.ISOTIMEPERIOD];
                this.Add(server);
            }
        }
        public Boolean Edited
        {
            get { return _editied; }
            set { _editied = value; }
        }
        public Dictionary<string, string>[] AsResource()
        {
            List<Dictionary<String, String>> s = new List<Dictionary<String, String>>(this.Count);
            foreach (var hisCentralServer in this)
            {
                s.Add(hisCentralServer.ToDictionary());
            }
            return s.ToArray();
        }

        public string[][] AsAgentResource()
        {
            List<string[]> s = new List<string[]>(this.Count);
            foreach (var hisCentralServer in this)
            {
                s.Add(hisCentralServer.ToAgentStringArray());
            }
            return s.ToArray();
        }
    }
}
