using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using HisCentralServicesList.Properties;
using cuahsi.wof.ruon;
using log4net;

namespace HisCentralServicesList
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /*
         * Thoughts
         * We want this to be low CPU, 
         * * get networks
         * * get one series for each network
         * rather than a fancy disctint query that has to run over the entire obervation series view
         * 
        */
        static void Main(string[] args)
        {
            var seriesList = new ObsSeriesServerList();

            var networks = GetNetworks();

            foreach (DataRow network in networks)
            {
                var series = new ObsSeriesServer();
                Boolean enabled;
                int netId = (int)network["NetworkID"];
                var aSeries = GetOneSeries(netId);
                if (aSeries == null) continue;
                foreach (DataRow dataRow in aSeries)
                {


                         try
                        {
                            series.Enabled = true;
                            //series.Endpoint = getEndpointFromWSDL (dataRow["WaterMLURI"].ToString());
                            series.Endpoint = dataRow["WaterMLURI"].ToString();
                            series.Name = dataRow["ServCode"].ToString();
                            series.SiteCode = dataRow["Location"].ToString();
                            series.VariableCode = dataRow["Variable"].ToString();
                            DateTime endate = DateTime.Parse(dataRow["EndDate"].ToString());
                            DateTime startDate = endate.AddDays(-2);
                            string isoRangeFormat = "{0:0000}-{1:00}-{2:00}/{3:0000}-{4:00}-{5:00}";


                            var isoRange = String.Format(isoRangeFormat, startDate.Year, startDate.Month, startDate.Day,
                                                         endate.Year, endate.Month, endate.Day);

                            series.ISOTimeInterval = isoRange;

                            seriesList.Add(series);
                        }
                        catch (Exception e)
                        {
                            log.Error("error on series : " + series.ToAgentStringArray().ToString());
                        }
                   
                }

            }
            //NCDCISD_realtime, false, http://river.sdsc.edu/wateroneflow/NCDC/ISD_1_0.asmx, NCDCISD:72584523225, NCDCISD:CIG, P10D

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
        public static String ServiceTypeGuess(DataRow aRow)
        {
            string version = "1.0";
            if (aRow["WofVersion"].ToString().Equals("1.0"))
            {
                if (aRow["WaterMLURI"].ToString().Contains("_1_1"))
                {
                    return "1.1";
                }
                else
                {
                    return "1.0";
                }
            }
            else
            {
                return "1.1";
            }

            return "0.0";
        }

        //public static String getEndpointFromWSDL(string WsdlUrl)
        //{
        //    // for now
        //    string endpoint = WsdlUrl.Replace("?WSDL", String.Empty);
        //    endpoint = endpoint.Replace("?wsdl", String.Empty);
        //    return endpoint;
        //} 

        public static DataRowCollection GetNetworks()
        {

            String connect = Settings.Default.CentralHISConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connect);
            SqlCommand mysco = new SqlCommand(Settings.Default.SqlGetNetworks, con);
            SqlParameterCollection parms = mysco.Parameters;
            parms.Clear();

            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter(mysco);
                da.Fill(ds, "networkInfo");
            }
            con.Close();
            //Calculate bounding box
            System.Data.DataRowCollection rows = ds.Tables["networkInfo"].Rows;

            if (rows.Count > 0)
            {

                return rows;
            }
            else
            {
                return null;
            }
        }

        public static DataRowCollection GetOneSeries(int networkid)
        {

            String connect = Settings.Default.CentralHISConnectionString; DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connect);
            SqlCommand mysco = new SqlCommand(Settings.Default.SqlGetSource, con);
            SqlParameterCollection parms = mysco.Parameters;
            bool hits = false;
            parms.Clear();
            parms.AddWithValue("@Sourceid", networkid);

            mysco.CommandText = Settings.Default.SqlGetSource;

            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter(mysco);
                da.Fill(ds, "ObsSeries");
            }
            con.Close();
            //Calculate bounding box

            System.Data.DataRowCollection rows = ds.Tables["ObsSeries"].Rows;

            if (rows.Count > 0)
            {

                return rows;
            }
            else
            {
                return null;
            }

        }
    }
}
