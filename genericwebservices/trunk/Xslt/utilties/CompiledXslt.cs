using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

using log4net;

namespace cuahsi.his.service.xslt.utilties
{
    public class CompiledXslt
    {
        private static ILog log = LogManager.GetLogger(typeof(CompiledXslt));

        private string _filename;
        private DateTime lastUpdate;
        XslCompiledTransform  myXslTransform;
        

        public CompiledXslt(string filename)
        {
            _filename = filename;

                   log.InfoFormat("Creating CompiledXslt filename{0}", _filename); 
            loadXslt();
  
        }

        public string Filename { get { return _filename; }}
        public override string ToString()
        {
            return Filename;
        }

        private void loadXslt()
        {
            myXslTransform  = new XslCompiledTransform();
            myXslTransform.Load(_filename);
            lastUpdate = File.GetLastWriteTimeUtc(_filename);
            log.InfoFormat("Reloaded Xslt lastUpdate{0} filename{1}", lastUpdate, _filename);
        }

        /// <summary>
        /// see http://msdn.microsoft.com/en-us/library/ms163433(v=VS.80).aspx
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public void Transform(XmlReader input, XmlWriter output)
        {
            if (File.GetLastWriteTimeUtc(_filename) > lastUpdate) loadXslt();

            if (log.IsDebugEnabled) log.InfoFormat("tranforming Xslt filename{0}",_filename);

            myXslTransform.Transform(input, output);
        }

        /// <summary>
        /// see http://msdn.microsoft.com/en-us/library/ms163433(v=VS.80).aspx
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public void Transform(XmlReader input, XsltArgumentList args,XmlWriter output )
        {
            if (File.GetLastWriteTimeUtc(_filename) > lastUpdate) loadXslt();

            if (log.IsDebugEnabled) log.InfoFormat("tranforming Xslt filename{0}", _filename);

            myXslTransform.Transform(input,args, output);
        }
    }
}
