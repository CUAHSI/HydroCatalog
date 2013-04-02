using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using cuahsi.his.WaterService.Service.v1_0.Passthrough;
using cuahsi.his.WaterService.Utilities;
using log4net;


namespace cuahsi.his.WaterService.Rest
{
    using cuahsi.his.schema;
    public class GetXmlFromRest<T>
    {
        private static ILog log = LogManager.GetLogger(typeof(GetXmlFromRest<T>));

        private XmlSerializer serializer;
        
        private XmlReaderSettings settings = null;

        public GetXmlFromRest(string XsltPath)
        {

            Xslt = new CompiledXslt(XsltPath);
            // serializer = WOFXmlSerializerFactory.GetSerializer(typeof(VariablesResponseType)); // just get it into the xml serializer factory
            serializer = WOFXmlSerializerFactory.GetSerializer(typeof(T));
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


            try
            {
                Uri uri = new Uri(url);
                using (WebClient web = new WebClient())
                {
                    Stream s = web.OpenRead(url);

                    return ReadXmlData(s);
                }
            }



            catch (Exception ex)
            {
                log.InfoFormat("Rest  Error: url:<{0}> xslt({1}) error:{2}", url, Xslt.ToString(), ex.Message);
            }
            throw new WaterOneFlowSourceException("Error connecting to REST Service at URL '" + url + "'");
        }

        private XmlReader ReadXmlData(Stream s)
        {
            XmlReader reader = XmlReader.Create(s);
            MemoryStream memoryStream = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(memoryStream);
            Xslt.Transform(reader, writer);
            memoryStream.Position = 0;
            reader = XmlReader.Create(memoryStream,settings);

               
            return reader;
        }
    }
}

