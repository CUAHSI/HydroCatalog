using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HisCentralServicesList;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "cuahsi.log4net.xml", Watch = true)]
namespace HisCentralSeriesCmdLine
{
    class Program
    {
        static void Main(string[] args)
        {
            ObsSeriesServerList seriesList = HisSeriesList.SeriesList(); 

            String OutputFormat = "{0},{1},{2},{3},{4},{5}";

            var output = System.IO.File.CreateText("hisServers");
            foreach (var series in seriesList)
            {
                var line = String.Format(OutputFormat,
                                         series.Name.Trim(),
                                         series.Enabled,
                                         series.Endpoint.Trim(),
                                         series.SiteCode.Trim(), series.VariableCode.Trim(),
                                         series.ISOTimeInterval);
                output.WriteLine(line);
                output.Flush();

            }
            output.Close();
        }

    }
}
