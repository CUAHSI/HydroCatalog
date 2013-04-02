using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using log4net;


namespace cuahsi.his.WaterService.Rest
{
    using cuahsi.his.schema;
    public class GetXmlFromRest
    {
        private static ILog log = LogManager.GetLogger(typeof(GetXmlFromRest));


        
        private XmlReaderSettings settings = null;

        public GetXmlFromRest()
        {

        }
        public GetXmlFromRest(Utilities.CompiledXslt compiledXslt)
        {
            Xslt = compiledXslt;
        }
        public GetXmlFromRest(Utilities.CompiledXslt compiledXslt, XmlReaderSettings Settings)
        {
            settings = Settings;
            Xslt = compiledXslt;
        }
        public Utilities.CompiledXslt Xslt { get; set; }

        public XmlReader GetXmlReader(string url)
        {
            //string urlFormat = "{0}?sites={1}&parameterCd={2}&startDT={3}&endDT={4}";
            //        string url = string.Format(urlFormat, USGSUVBaseUrl,
            //                                   siteNum,
            //                                   parameterCode,
            //                                   startDateTime.ToString("yyyy-MM-dd"),
            //                                   endDateTime.ToString("yyyy-MM-dd")); 

            try
            {
                Uri uri = new Uri(url);
                using (WebClient web = new WebClient())
                {

                    XmlReader reader = XmlReader.Create(web.OpenRead(url));
                    MemoryStream memoryStream = new MemoryStream();
                    XmlWriter writer = XmlWriter.Create(memoryStream);
                    Xslt.Transform(reader, writer);
                    memoryStream.Position = 0;
                    reader = XmlReader.Create(memoryStream,settings);

                    // TimeSeriesResponseType response
                    //= (TimeSeriesResponseType)serializer.Deserialize(reader);
                    /* old
                         * TimeSeriesResponseType response
                        //    = new Passthrough(web.OpenRead(url));
                         * */
                    return reader;
                }
            }



            catch (Exception ex)
            {
                log.InfoFormat("Rest  Error: url:<{0}> xslt({1}) error:{2}", url, Xslt.ToString(), ex.Message);
            }
            throw new WaterOneFlowSourceException("Error connecting to REST Service at URL '" + url + "'");
        }
    }
}

