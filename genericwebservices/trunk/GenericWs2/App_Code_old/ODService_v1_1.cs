using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using WaterOneFlow.Schema.v1_1;
using WaterOneFlowImpl;

//using Microsoft.Web.Services3;
//using Microsoft.Web.Services3.Addressing;
//using Microsoft.Web.Services3.Messaging;

using log4net;
using WaterOneFlowImpl.geom;

namespace WaterOneFlow.odws
{
    using WaterOneFlow.odm.v1_1;
    namespace v1_1
    {
        public class ODService : IDisposable
        {
            private Cache appCache;

            private HttpContext appContext;

            private VariablesDataset vds;
            /* This is now done in the global.asax file
            // this got cached, which cause the name to be localhost        
           */
            private string serviceUrl;
            private string serviceName;


            private static readonly ILog log = LogManager.GetLogger(typeof(ODService));
            private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
            private static readonly Logging queryLog2 = new Logging();

            public ODService(HttpContext aContext)
            {

                log.Debug("Starting " + System.Configuration.ConfigurationManager.AppSettings["network"]);
                appContext = aContext;
                // This is now done in the global.asax file
                // this got cached, which cause the name to be localhost
                serviceName = ConfigurationManager.AppSettings["GetValuesName"];
                //Boolean odValues = Boolean.Parse(ConfigurationManager.AppSettings["UseODForValues"]);
                //if (odValues)
                //{
                //    string Port = aContext.Request.ServerVariables["SERVER_PORT"];

                //    if (Port == null || Port == "80" || Port == "443")

                //        Port = "";

                //    else

                //        Port = ":" + Port;



                //    string Protocol = aContext.Request.ServerVariables["SERVER_PORT_SECURE"];

                //    if (Protocol == null || Protocol == "0")

                //        Protocol = "http://";

                //    else

                //        Protocol = "https://";





                //    // *** Figure out the base Url which points at the application's root

                //    serviceUrl = Protocol + aContext.Request.ServerVariables["SERVER_NAME"] +

                //                                Port +
                //                                aContext.Request.ApplicationPath
                //                                + "/" + ConfigurationManager.AppSettings["asmxPage_1_1"] + "?WSDL";

                //}
                //else
                //{
                    serviceUrl = ConfigurationManager.AppSettings["externalGetValuesService"];
                //}

            }

            #region Site Information
            public SiteInfoResponseType GetSiteInfo(string locationParameter)
            {
                return GetSiteInfo(new string[] { locationParameter }, true)
                ;
            }

            public SiteInfoResponseType GetSiteInfo(string[] locationParameter, Boolean IncludeSeries)
            {
              
                List<locationParam> lpList = new List<locationParam>();
                try
                {
                    foreach (string s in locationParameter)
                    {
                        locationParam l = new locationParam(s);

                        if (l.isGeometry)
                        {
                            String error = "Location by Geometry not accepted: " + locationParameter;
                            log.Debug(error);
                            throw new WaterOneFlowException(error);
                        }
                        else
                        {
                            lpList.Add(l);
                        }
                    }
                }
                catch (WaterOneFlowException we)
                {
                    log.Error(we.Message);
                    throw;
                }
                catch (Exception e)
                {
                    String error =
                        "Sorry. Your submitted site ID for this getSiteInfo request caused an problem that we failed to catch programmatically: " +
                        e.Message;
                    log.Error(error);
                    throw new WaterOneFlowException(error);
                }
                GetSiteInfoOD getSiteInfo = new GetSiteInfoOD();
                SiteInfoResponseType resp = null;
                resp = getSiteInfo.GetSiteInfoResponse(lpList.ToArray(), true);
                foreach (SiteInfoResponseTypeSite site in resp.site)
                {
                    foreach (seriesCatalogType catalog in site.seriesCatalog)
                    {
                        catalog.menuGroupName = serviceName;
                        catalog.serviceWsdl = serviceUrl;
                    }
                }

               
 
                return resp;
            }


            public SiteInfoResponseType GetSites(string[] locationIDs)
            {
                 GetSiteInfoOD obj = new GetSiteInfoOD();

             

                SiteInfoResponseType resp = obj.GetSites(locationIDs, false);

             

                return resp;
            }

            public SiteInfoResponseType GetSitesInBox(
                float west, float south, float east, float north,
                Boolean IncludeSeries
                )
            {
                
                GetSiteInfoOD obj = new GetSiteInfoOD();

                box queryBox = new box(west, south, east, north);


                SiteInfoResponseType resp = obj.GetSitesByBox(queryBox, IncludeSeries);

               
                return resp;
            }
            #endregion


            #region variable


            public VariablesResponseType GetVariableInfo(String VariableParameter)
            {
               
                GetVariablesOD obj = new GetVariablesOD();


                VariablesResponseType resp = obj.GetVariableInfo(VariableParameter);

               

 
                return resp;
            }

            #endregion

            #region values
            public TimeSeriesResponseType GetValues(string SiteNumber,
                                                    string Variable,
                                                    string StartDate,
                                                    string EndDate)
            {
                 GetValuesOD obj = new GetValuesOD();
            

                TimeSeriesResponseType resp = obj.getValues(SiteNumber, Variable, StartDate, EndDate);

               

                return resp;

            }

            public TimeSeriesResponseType GetValuesForASite(string site, string startDate, string endDate)
            {
                {
                    GetValuesOD obj = new GetValuesOD();

                    //String network,method,location, variable, start, end, , processing time,count
   
                    TimeSeriesResponseType resp = obj.GetValuesForSiteVariable(site, startDate, endDate);

 
                 

                    return resp;

                }
            }

            #endregion


            #region IDisposable Members

            public void Dispose()
            {
                Dispose(true);
            }

            protected virtual void Dispose(bool disposeOf)
            {
                // waterLog.Dispose();
            }

            #endregion
        }
    }
}
