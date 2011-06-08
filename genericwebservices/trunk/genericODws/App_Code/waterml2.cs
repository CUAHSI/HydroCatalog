using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using cuahsi.his.service.xslt.v1_0;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "waterml2" in code, svc and config file together.
[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
public class waterml2 : Iwaterml2
{


    public Message GetValues(string location, string variable,
        string startDate, string endDate)
    {
        var context = System.ServiceModel.OperationContext.Current.IncomingMessageHeaders;
        var baseUrl = context.To.GetLeftPart(UriPartial.Path);
        var hostUrl = System.ServiceModel.OperationContext.Current.Host.BaseAddresses[0];

        var svc = new TransformValues("REST/xslt/WaterML1_1_timeSeries_to_WaterML2.xsl", 
            hostUrl, hostUrl);
        var result = svc.GetTimeSeries(location, variable,
                             startDate, endDate
                             );
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(result.ToString());
        var message = Message.CreateMessage(MessageVersion.None, null, xmlDoc.DocumentElement);

        return message;
    }

    public Message GetSites(string location)
    {
        var svc = new TransformSites("REST/xslt/WaterML1_1_siteResponse_to_WaterML2.xsl");
        var result = svc.GetSiteInfo(location
                             );
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(result.ToString());
        var message = Message.CreateMessage(MessageVersion.None, null, xmlDoc.DocumentElement);

        return message;
    }

    public Message GetVariable(string variable)
    {
        var svc = new TransformVariable("REST/xslt/WaterML1_1_variables_to_waterml2.xslt");
        var result = svc.GeVariable(variable);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(result.ToString());
        var message = Message.CreateMessage(MessageVersion.None, null, xmlDoc.DocumentElement);

        return message;
    }

    #region Helper class

    private class TextBodyWriter : BodyWriter
    {
        private byte[] messageBytes;

        public TextBodyWriter(string message)
            : base(true)
        {
            this.messageBytes = Encoding.UTF8.GetBytes(message);
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Binary");
            writer.WriteBase64(this.messageBytes, 0, this.messageBytes.Length);
            writer.WriteEndElement();
        }
    }

    #endregion
}
