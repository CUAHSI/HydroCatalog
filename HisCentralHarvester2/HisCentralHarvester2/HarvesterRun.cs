using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using System.Web;
using HisCentralHarvester2.Properties;
using HisCentralHarvester2.waterml_10;


namespace HisCentralHarvester2
{
    class HarvesterRun
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string sourceID = args[i];
                    Harvester harvester = new Harvester(sourceID);

                    harvester.HarvestNetwork();


                }
            }

        }
    }
    public class Harvester
    {
        Hashtable varList;
        //System.Collections.ArrayList<String> varcodes;
        String URL;
        String connect;
        String stationName;
        String vocab = "";
        String network = "";
        String NetworkName;
        //String sessionID;
        String SourceID;
        //private static readonly ILog log = LogManager.GetLogger("HarvestLog");
        string logfilename;
        List<String> seriescatalogList;
        //static string SourceID;
        long currentSiteIdentifier;
        long maxVariableIdentifier;
        long valcount, sitecount, varcount;
        double xmin, xmax, ymin, ymax;
        DateTime begdate, enddate;
        public Harvester(String id)
        {

            SourceID = id;
            valcount = 0;
            sitecount = 0;
            varcount = 0;

            xmin = 200.0;
            ymin = 200.0;
            xmax = -200.0;
            ymax = -200.0;
            begdate = DateTime.Now;
            string datestring = begdate.Year.ToString();
            datestring += (begdate.Month < 10 ? "0" + begdate.Month.ToString() : begdate.Month.ToString());
            datestring += (begdate.Day < 10 ? "0" + begdate.Day.ToString() : begdate.Day.ToString());

            varList = new Hashtable();

            string outpath = Settings.Default.outpath;
            connect = Settings.Default.constring;

            if (!outpath.EndsWith("/")) outpath += "/";
            //connect = ConfigurationSettings.AppSettings.Get("constring");

            logfilename = outpath + id + "_" + datestring + ".txt";
            //connect = "Data Source=disrupter.sdsc.edu,1433;Initial Catalog=hydroseek;User id=hiscentralUser;password=im2nopploki";

        }
        public void log(string text)
        {
            System.IO.TextWriter tw = new System.IO.StreamWriter(logfilename, true);
            text = System.DateTime.Now.ToString() + "::" + text;
            tw.WriteLine(text);
            System.Console.WriteLine(text);

            tw.Close();

        }
        public void HarvestNetwork()
        {
            log("Begin Harvest for service ID:" + SourceID);
            log(System.DateTime.Now.ToString());
            String sql = "SELECT ServiceWSDL AS Link, NetworkName AS Organization FROM HISNetworks WHERE networkID = " + SourceID;
            URL = " ";
            Console.WriteLine(sql);
            String Organization = " ";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connect);

            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "URL");
            }
            con.Close();
            //should be only one
            foreach (DataRow dataRow in ds.Tables["URL"].Rows)
            {
                URL = dataRow["Link"].ToString();
                Organization = dataRow["Organization"].ToString();
                NetworkName = Organization;
                try
                {
                    if (URL.Contains("cuahsi_1_1"))
                    {
                        DoSiteList_11(Organization, con, URL);
                    }
                    else
                    {

                        DoSiteList_10(Organization, con, URL);
                    }
                    updateStatistics();
                }
                catch (Exception e)
                {
                    log(e.Message);
                    log(e.StackTrace);
                }
                //once update is complete insert the date of update
                //updateStatistics();
                //con = new SqlConnection(connect);
                //con.Open();
                //String updateSchedule = "UPDATE HISNetworks SET LastHarvested='" + DateTime.Now + "' WHERE NetworkID=" + SourceID;
                //Console.WriteLine(updateSchedule);
                //SqlCommand msco = new SqlCommand(updateSchedule,con);
                //msco.ExecuteNonQuery();
                //msco.Dispose();
                //con.Close();

            }

            log("Harvest completed:" + System.DateTime.Now.ToString());

        }
        private void updateStatistics()
        {
            //if (xmin < 200) // don't update if xmin hasn't been set. 
            //{

            SqlConnection con = new SqlConnection(connect);
            con.Open();
            //    int valcount, sitecount, varcount;
            //double xmin, xmax, ymin, ymax;
            //DateTime begdate, enddate;
            String updatestats = "sp_UpdateStatistics";

            //match the variableID in the web service with its counterpart in the database
            //log("ADDED SERIES: " + siteCode + "|" + varCode);
            SqlCommand mysco = new SqlCommand(updatestats, con);
            mysco.CommandType = CommandType.StoredProcedure;


            mysco.Parameters.Add("@networkid", SqlDbType.Int);
            mysco.Parameters["@networkid"].Value = SourceID;


            mysco.ExecuteNonQuery();
            mysco.Dispose();
            con.Close();
            //}

        }

        public int LookUpUnitID(String unitcode)
        {

            String sql = "Select unitid from units where unitsabreviation = '" + unitcode + "' or unitsname = '" + unitcode + "'";

            URL = " ";
            Console.WriteLine(sql);
            String Organization = " ";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connect);

            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "unit");
            }
            con.Close();
            //should be only one
            int unitid = 0;
            if (ds.Tables["unit"].Rows.Count > 0)
            {

                DataRow row = ds.Tables["unit"].Rows[0];
                unitid = int.Parse(row[0].ToString());

                NetworkName = Organization;



            }
            else
            {
                log("didn't work");
            }
            return unitid;


        }



        public void DoSiteList_10(string org, SqlConnection con, string url)
        {
            waterml_10.WaterOneFlow wof = new waterml_10.WaterOneFlow();
            wof.Url = url;

            String[] blank = new String[0];
            String varcode;
            String sitecode;
            //String network;
            //string vocab;
            site[] sites = GetSites_10(wof, blank);

            for (int i = 0; i < sites.Length; i++)
            {
                //sites[i].seriesCatalog

                network = sites[i].siteInfo.siteCode[0].network;
                if (network == null) network = NetworkName;
                sitecode = network + ":" + sites[i].siteInfo.siteCode[0].Value.Trim();
                waterml_10.SiteInfoResponseType siteinforesp = wof.GetSiteInfoObject(sitecode, "");

                updateInsertSite(siteinforesp.site[0].siteInfo, new SqlConnection(connect));
                waterml_10.seriesCatalogTypeSeries[] seriesCat = siteinforesp.site[0].seriesCatalog[0].series;
                if (seriesCat != null)
                {
                    for (int jj = 0; jj < seriesCat.Length; jj++)
                    {
                        vocab = seriesCat[jj].variable.variableCode[0].vocabulary;
                        if (vocab == null) vocab = NetworkName;

                        varcode = vocab + ":" + seriesCat[jj].variable.variableCode[0].Value;
                        DoVariable_10(varcode);
                        updateInsertSeries(seriesCat[jj], siteinforesp.site[0].siteInfo, new SqlConnection(connect));
                    }
                }


            }

        }

        private site[] GetSites_10(WaterOneFlow wof, string[] blank)
        {
            waterml_10.SiteInfoResponseType sitesResp = wof.GetSites(blank, "");
            //waterml_10.SiteInfoResponseTypeSite[] sites = sitesResp.site;
            return sitesResp.site;
        }

        public void DoSiteList_11(string org, SqlConnection con, string url)
        {
            waterml_11.WaterOneFlow wof = new waterml_11.WaterOneFlow();
            wof.Url = url;

            String[] blank = new String[0];
            String varcode;
            String sitecode;
            //String network;
            //String vocab;
            waterml_11.SiteInfoResponseType sitesResp = wof.GetSitesObject(blank, "");
            waterml_11.SiteInfoResponseTypeSite[] sites = sitesResp.site;
            for (int i = 0; i < sites.Length; i++)
            {
                //sites[i].seriesCatalog
                network = sites[i].siteInfo.siteCode[0].network;
                if (network == null) network = NetworkName;
                sitecode = network + ":" + sites[i].siteInfo.siteCode[0].Value;
                waterml_11.SiteInfoResponseType siteinforesp = wof.GetSiteInfoObject(sitecode, "");
                updateInsertSite(siteinforesp.site[0].siteInfo, new SqlConnection(connect));
                waterml_11.seriesCatalogTypeSeries[] seriesCat = siteinforesp.site[0].seriesCatalog[0].series;
                if (seriesCat != null)
                {
                    for (int jj = 0; jj < seriesCat.Length; jj++)
                    {
                        vocab = seriesCat[jj].variable.variableCode[0].vocabulary;
                        if (vocab == null) vocab = NetworkName;

                        varcode = vocab + ":" + seriesCat[jj].variable.variableCode[0].Value;
                        DoVariable_11(varcode);
                        updateInsertSeries(seriesCat[jj], siteinforesp.site[0].siteInfo, new SqlConnection(connect));
                    }
                }


            }

        }
        public void DoVariable_10(string variableCode)
        {
            if (!varList.Contains(variableCode))
            {
                try
                {
                    waterml_10.WaterOneFlow wof = new waterml_10.WaterOneFlow();
                    wof.Url = URL;
                    //wof.GetVariableInfoObject(
                    waterml_10.VariablesResponseType varResp = wof.GetVariableInfoObject(variableCode, "");
                    updateInsertVariable(varResp.variables[0], new SqlConnection(connect));
                    varList.Add(variableCode, variableCode);
                }
                catch (Exception e)
                {
                    log(e.Message);
                    log(e.StackTrace);

                }

            }
        }
        public void DoVariable_11(string variableCode)
        {
            if (!varList.Contains(variableCode))
            {
                try
                {
                    waterml_11.WaterOneFlow wof = new waterml_11.WaterOneFlow();
                    wof.Url = URL;
                    //wof.GetVariableInfoObject(
                    waterml_11.VariablesResponseType varResp = wof.GetVariableInfoObject(variableCode, "");
                    updateInsertVariable(varResp.variables[0], new SqlConnection(connect));
                    varList.Add(variableCode, variableCode);
                }
                catch (Exception e)
                {
                    log(e.Message);
                    log(e.StackTrace);

                }

            }
        }

        public void updateInsertVariable(waterml_10.VariableInfoType var, SqlConnection con)
        {
            try
            {
                //@Varcode varchar(250), @varname varchar(250), @SampleMedium varchar(50), @ValueType varchar(50), @IsRegular bit, @timeSupport int, @timeUnitID int, 
                //@dataType varchar(50), @unitid int, @units varchar(50), @GenCategory varchar(50), @networkid int
                con.Open();


                SqlCommand msco = new SqlCommand("sp_updateInsertVariable", con);
                msco.CommandType = CommandType.StoredProcedure;

                msco.Parameters.Clear();
                msco.Parameters.Add("@varcode", SqlDbType.VarChar, 250);
                msco.Parameters["@varcode"].Value = vocab + ":" + var.variableCode[0].Value;
                msco.Parameters.Add("@varname", SqlDbType.VarChar, 250);
                msco.Parameters["@varname"].Value = var.variableName;
                msco.Parameters.Add("@SampleMedium", SqlDbType.VarChar, 50);
                msco.Parameters["@SampleMedium"].Value = var.sampleMedium;
                msco.Parameters.Add("@ValueType", SqlDbType.VarChar, 50);
                msco.Parameters["@ValueType"].Value = var.valueType;

                msco.Parameters.Add("@IsRegular", SqlDbType.Bit);
                msco.Parameters["@IsRegular"].Value = var.timeSupport.isRegular;

                msco.Parameters.Add("@TimeSupport", SqlDbType.Int);
                msco.Parameters["@TimeSupport"].Value = var.timeSupport.timeInterval;
                msco.Parameters.Add("@TimeUnitID", SqlDbType.Int);
                if (var.timeSupport.isRegular && var.timeSupport.unit != null && var.timeSupport.unit.UnitID != null)
                {
                    msco.Parameters["@TimeUnitID"].Value = var.timeSupport.unit.UnitID;
                }
                else
                {
                    msco.Parameters["@TimeUnitID"].Value = 104;
                }
                msco.Parameters.Add("@DataType", SqlDbType.VarChar, 50);
                msco.Parameters["@DataType"].Value = var.dataType;
                msco.Parameters.Add("@unitid", SqlDbType.Int);
                if (!string.IsNullOrEmpty(var.units.unitsCode))
                {
                    msco.Parameters["@unitid"].Value = var.units.unitsCode;
                }
                else
                {
                    msco.Parameters["@unitid"].Value = 1;
                }
                msco.Parameters.Add("@units", SqlDbType.VarChar, 50);
                msco.Parameters["@units"].Value = var.units.Value;
                msco.Parameters.Add("@GenCategory", SqlDbType.VarChar, 50);
                msco.Parameters["@GenCategory"].Value = var.generalCategory;
                msco.Parameters.Add("@NetworkID", SqlDbType.Int);
                msco.Parameters["@NetworkID"].Value = SourceID;


                msco.ExecuteNonQuery();
                msco.Dispose();

            }
            catch (Exception e)
            {
                log(e.Message);
                log(e.StackTrace);

            }
            finally
            {
                con.Close();
            }
        }
        public void updateInsertVariable(waterml_11.VariableInfoType var, SqlConnection con)
        {
            try
            {
                //@Varcode varchar(250), @varname varchar(250), @SampleMedium varchar(50), @ValueType varchar(50), @IsRegular bit, @timeSupport int, @timeUnitID int, 
                //@dataType varchar(50), @unitid int, @units varchar(50), @GenCategory varchar(50), @networkid int
                con.Open();


                SqlCommand msco = new SqlCommand("sp_updateInsertVariable", con);
                msco.CommandType = CommandType.StoredProcedure;

                msco.Parameters.Clear();
                msco.Parameters.Add("@varcode", SqlDbType.VarChar, 250);
                msco.Parameters["@varcode"].Value = vocab + ":" + var.variableCode[0].Value;
                msco.Parameters.Add("@varname", SqlDbType.VarChar, 250);
                msco.Parameters["@varname"].Value = var.variableName;
                msco.Parameters.Add("@SampleMedium", SqlDbType.VarChar, 50);
                msco.Parameters["@SampleMedium"].Value = var.sampleMedium;
                msco.Parameters.Add("@ValueType", SqlDbType.VarChar, 50);
                msco.Parameters["@ValueType"].Value = var.valueType;

                msco.Parameters.Add("@IsRegular", SqlDbType.Bit);
                msco.Parameters["@IsRegular"].Value = var.timeScale.isRegular;

                msco.Parameters.Add("@TimeSupport", SqlDbType.Int);
                msco.Parameters["@TimeSupport"].Value = var.timeScale.timeSupport;
                msco.Parameters.Add("@TimeUnitID", SqlDbType.Int);
                if (var.timeScale.isRegular && var.timeScale.unit != null && var.timeScale.unit.unitCode != null)
                {

                    msco.Parameters["@TimeUnitID"].Value = var.timeScale.unit.unitCode;
                }
                else
                {
                    msco.Parameters["@TimeUnitID"].Value = 104;
                }
                msco.Parameters.Add("@DataType", SqlDbType.VarChar, 50);
                msco.Parameters["@DataType"].Value = var.dataType;
                msco.Parameters.Add("@unitid", SqlDbType.Int);
                msco.Parameters["@unitid"].Value = var.unit.unitID;
                msco.Parameters.Add("@units", SqlDbType.VarChar, 50);
                msco.Parameters["@units"].Value = var.unit.unitName;
                msco.Parameters.Add("@GenCategory", SqlDbType.VarChar, 50);
                msco.Parameters["@GenCategory"].Value = var.generalCategory;
                msco.Parameters.Add("@NetworkID", SqlDbType.Int);
                msco.Parameters["@NetworkID"].Value = SourceID;


                msco.ExecuteNonQuery();
                msco.Dispose();
                //con.Close();
            }
            catch (Exception e)
            {
                log(e.Message);
                log(e.StackTrace);

            }
            finally
            {
                con.Close();
            }
        }

        public void updateInsertSite(waterml_10.SiteInfoType site, SqlConnection con)
        {
            try
            {
                //@SiteCode varchar(250), @SiteName varchar(250), @latitude real, @longitude real, @Networkid int, @orgname varchar(250),
                //@HUC int, @hucnumeric varchar(50)

                con.Open();


                SqlCommand msco = new SqlCommand("sp_updateInsertSites", con);
                msco.CommandType = CommandType.StoredProcedure;

                msco.Parameters.Clear();
                msco.Parameters.Add("@SiteCode", SqlDbType.VarChar, 250);
                msco.Parameters["@SiteCode"].Value = network + ":" + site.siteCode[0].Value;
                msco.Parameters.Add("@SiteName", SqlDbType.VarChar, 250);
                msco.Parameters["@SiteName"].Value = site.siteName;
                msco.Parameters.Add("@Latitude", SqlDbType.Real);
                waterml_10.LatLonPointType latlong = site.geoLocation.geogLocation as waterml_10.LatLonPointType;

                msco.Parameters["@Latitude"].Value = latlong.latitude;
                msco.Parameters.Add("@Longitude", SqlDbType.Real);
                msco.Parameters["@Longitude"].Value = latlong.longitude;
                msco.Parameters.Add("@NetworkID", SqlDbType.Int);
                msco.Parameters["@NetworkID"].Value = SourceID;
                msco.Parameters.Add("@orgname", SqlDbType.VarChar, 250);
                msco.Parameters["@orgname"].Value = NetworkName;
                msco.Parameters.Add("@HUC", SqlDbType.VarChar, 50);
                msco.Parameters["@HUC"].Value = 0;
                msco.Parameters.Add("@hucnumeric", SqlDbType.VarChar, 50);
                msco.Parameters["@hucnumeric"].Value = "0";



                msco.ExecuteNonQuery();
                msco.Dispose();

                log("Site" + site.siteName);
            }
            catch (Exception e)
            {
                log(e.Message);
                log(e.StackTrace);

            }
            finally
            {
                con.Close();
            }

        }
        public void updateInsertSite(waterml_11.SiteInfoType site, SqlConnection con)
        {
            try
            {
                //@SiteCode varchar(250), @SiteName varchar(250), @latitude real, @longitude real, @Networkid int, @orgname varchar(250),
                //@HUC int, @hucnumeric varchar(50)

                con.Open();


                SqlCommand msco = new SqlCommand("sp_updateInsertSites", con);
                msco.CommandType = CommandType.StoredProcedure;

                msco.Parameters.Clear();
                msco.Parameters.Add("@SiteCode", SqlDbType.VarChar, 250);
                msco.Parameters["@SiteCode"].Value = network + ":" + site.siteCode[0].Value;
                msco.Parameters.Add("@SiteName", SqlDbType.VarChar, 250);
                msco.Parameters["@SiteName"].Value = site.siteName;
                msco.Parameters.Add("@Latitude", SqlDbType.Real);
                waterml_11.LatLonPointType latlong = site.geoLocation.geogLocation as waterml_11.LatLonPointType;

                msco.Parameters["@Latitude"].Value = latlong.latitude;
                msco.Parameters.Add("@Longitude", SqlDbType.Real);
                msco.Parameters["@Longitude"].Value = latlong.longitude;
                msco.Parameters.Add("@NetworkID", SqlDbType.Int);
                msco.Parameters["@NetworkID"].Value = SourceID;
                msco.Parameters.Add("@orgname", SqlDbType.VarChar, 250);
                msco.Parameters["@orgname"].Value = NetworkName;
                msco.Parameters.Add("@HUC", SqlDbType.VarChar, 50);
                msco.Parameters["@HUC"].Value = 0;
                msco.Parameters.Add("@hucnumeric", SqlDbType.VarChar, 50);
                msco.Parameters["@hucnumeric"].Value = "0";



                msco.ExecuteNonQuery();
                msco.Dispose();
                // con.Close();
                log("Site" + site.siteName);
            }
            catch (Exception e)
            {
                log(e.Message);
                log(e.StackTrace);

            }
            finally
            {
                con.Close();
            }

        }


        public void updateInsertSeries(waterml_10.seriesCatalogTypeSeries series, waterml_10.SiteInfoType site, SqlConnection con)
        {
            /*
@SiteCode varchar(250), @SiteName varchar(250), @VariableCode varchar(100), @VarUnitsId int, @VariableName varchar (250), 
@varunitsName varchar(50), @SampleMedium varchar(100), @ValueType varchar(100), @beginDate date, @endDate date, 
@valuecount int, @GenCat int, @UTCOffset int, @Networkid int */
            try
            {
                con.Open();


                SqlCommand msco = new SqlCommand("sp_updateInsertSeriesCatalog", con);
                msco.CommandType = CommandType.StoredProcedure;

                msco.Parameters.Clear();

                msco.Parameters.Add("@SiteCode", SqlDbType.VarChar, 250);
                msco.Parameters["@SiteCode"].Value = network + ":" + site.siteCode[0].Value;
                msco.Parameters.Add("@SiteName", SqlDbType.VarChar, 250);
                msco.Parameters["@SiteName"].Value = site.siteName;

                msco.Parameters.Add("@VariableCode", SqlDbType.VarChar, 250);
                msco.Parameters["@VariableCode"].Value = vocab + ":" + series.variable.variableCode[0].Value;

                msco.Parameters.Add("@VarUnitsId", SqlDbType.Int);
                msco.Parameters["@VarUnitsId"].IsNullable = true;
                if (series.variable.units.unitsCode == null)
                {
                    msco.Parameters["@VarUnitsId"].Value = DBNull.Value;
                }
                else
                {
                    msco.Parameters["@VarUnitsId"].Value = series.variable.units.unitsCode;
                }

                msco.Parameters.Add("@VariableName", SqlDbType.VarChar, 250);
                msco.Parameters["@VariableName"].Value = series.variable.variableName;

                msco.Parameters.Add("@varunitsName", SqlDbType.VarChar, 50);
                msco.Parameters["@varunitsName"].Value = series.variable.units.Value;
                msco.Parameters.Add("@SampleMedium", SqlDbType.VarChar, 50);
                msco.Parameters["@SampleMedium"].Value = series.variable.sampleMedium;
                msco.Parameters.Add("@ValueType", SqlDbType.VarChar, 50);
                msco.Parameters["@ValueType"].Value = series.valueType;



                msco.Parameters.Add("@beginDate", SqlDbType.DateTime);
                msco.Parameters.Add("@endDate", SqlDbType.DateTime);

                waterml_10.TimeIntervalType thetime = series.variableTimeInterval as waterml_10.TimeIntervalType;

                msco.Parameters["@beginDate"].Value = thetime.beginDateTime;
                msco.Parameters["@endDate"].Value = thetime.endDateTime;

                msco.Parameters.Add("@valuecount", SqlDbType.BigInt);
                msco.Parameters["@valuecount"].Value = series.valueCount.Value;

                //msco.Parameters.Add("@GenCat", SqlDbType.VarChar, 50);
                //msco.Parameters["@GenCat"].Value = series.variable.generalCategory;
                msco.Parameters.Add("@UTCOffset", SqlDbType.Int);
                if (site.timeZoneInfo != null)
                {
                    msco.Parameters["@UTCOffset"].Value = site.timeZoneInfo.defaultTimeZone.ZoneOffset;
                }
                else
                {
                    msco.Parameters["@UTCOffset"].Value = 0;
                }
                msco.Parameters.Add("@NetworkID", SqlDbType.Int);
                msco.Parameters["@NetworkID"].Value = SourceID;

                msco.ExecuteNonQuery();
                msco.Dispose();

                log("Series: site " + site.siteName + "- var" + series.variable.variableName);
            }
            catch (Exception e)
            {
                log(e.Message);
                log(e.StackTrace);

            }
            finally
            {
                con.Close();
            }

        }
        public void updateInsertSeries(waterml_11.seriesCatalogTypeSeries series, waterml_11.SiteInfoType site, SqlConnection con)
        {
            /*
@SiteCode varchar(250), @SiteName varchar(250), @VariableCode varchar(100), @VarUnitsId int, @VariableName varchar (250), 
@varunitsName varchar(50), @SampleMedium varchar(100), @ValueType varchar(100), @beginDate date, @endDate date, 
@valuecount int, @GenCat int, @UTCOffset int, @Networkid int */
            try
            {
                con.Open();


                SqlCommand msco = new SqlCommand("sp_updateInsertSeriesCatalog", con);
                msco.CommandType = CommandType.StoredProcedure;

                msco.Parameters.Clear();

                msco.Parameters.Add("@SiteCode", SqlDbType.VarChar, 250);
                msco.Parameters["@SiteCode"].Value = network + ":" + site.siteCode[0].Value;
                msco.Parameters.Add("@SiteName", SqlDbType.VarChar, 250);
                msco.Parameters["@SiteName"].Value = site.siteName;

                msco.Parameters.Add("@VariableCode", SqlDbType.VarChar, 250);
                msco.Parameters["@VariableCode"].Value = vocab + ":" + series.variable.variableCode[0].Value;

                msco.Parameters.Add("@VarUnitsId", SqlDbType.Int);
                msco.Parameters["@VarUnitsId"].Value = series.variable.unit.unitCode;
                msco.Parameters.Add("@VariableName", SqlDbType.VarChar, 250);
                msco.Parameters["@VariableName"].Value = series.variable.variableName;

                msco.Parameters.Add("@varunitsName", SqlDbType.VarChar, 50);
                msco.Parameters["@varunitsName"].Value = series.variable.unit.unitName;
                msco.Parameters.Add("@SampleMedium", SqlDbType.VarChar, 50);
                msco.Parameters["@SampleMedium"].Value = series.variable.sampleMedium;
                msco.Parameters.Add("@ValueType", SqlDbType.VarChar, 50);
                msco.Parameters["@ValueType"].Value = series.variable.valueType;



                msco.Parameters.Add("@beginDate", SqlDbType.DateTime);
                msco.Parameters.Add("@endDate", SqlDbType.DateTime);

                waterml_11.TimeIntervalType thetime = series.variableTimeInterval as waterml_11.TimeIntervalType;

                msco.Parameters["@beginDate"].Value = thetime.beginDateTime;
                msco.Parameters["@endDate"].Value = thetime.endDateTime;

                msco.Parameters.Add("@valuecount", SqlDbType.BigInt);
                msco.Parameters["@valuecount"].Value = series.valueCount.Value;

                //msco.Parameters.Add("@GenCat", SqlDbType.VarChar, 50);
                //msco.Parameters["@GenCat"].Value = series.variable.generalCategory;
                msco.Parameters.Add("@UTCOffset", SqlDbType.Int);
                if (site.timeZoneInfo != null)
                {
                    msco.Parameters["@UTCOffset"].Value = site.timeZoneInfo.defaultTimeZone.zoneOffset;
                }
                else
                {
                    msco.Parameters["@UTCOffset"].Value = 0;
                }
                msco.Parameters.Add("@NetworkID", SqlDbType.Int);
                msco.Parameters["@NetworkID"].Value = SourceID;

                msco.ExecuteNonQuery();
                msco.Dispose();

                log("Series: site " + site.siteName + "- var" + series.variable.variableName);
            }
            catch (Exception e)
            {
                log(e.Message);
                log(e.StackTrace);

            }
            finally
            {
                con.Close();
            }

        }
    }
}
