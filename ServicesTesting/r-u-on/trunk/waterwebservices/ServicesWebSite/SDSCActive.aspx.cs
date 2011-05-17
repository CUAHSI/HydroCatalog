using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicesWebSite
{
    public partial class SDSCActive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load("http://rss.r-u-on.com/rssalarmhistory?id=AAAABIESfWjQAAADDrFZJTSn&criteria=SDSCWaterWebServicesActive&reverse");
            System.Xml.Xsl.XslTransform trans = new
               System.Xml.Xsl.XslTransform();
            trans.Load(Server.MapPath("xsltRss.xsl"));
            Xml1.Document = doc;
            Xml1.Transform = trans;
        }
    }
}