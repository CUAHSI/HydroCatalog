using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwaterml2" in both code and config file together.
[ServiceContract(Namespace = "http://company/waterml2")]
public interface Iwaterml2
{
	[OperationContract]
    [WebGet(
       // ResponseFormat = WebMessageFormat.Xml,
        UriTemplate = "values?location={location}&variable={variable}&startDate={startDate}&endDate={endDate}"
        )]
    //[WebGet(ResponseFormat = WebMessageFormat.Xml,
    //   UriTemplate = "/values/location/variable?startDate={startDate}&endDate={endDate}"
    //   )]
    Message GetValues(string location, string variable, 
        string startDate, string endDate);

    [OperationContract]
    [WebGet(
        // ResponseFormat = WebMessageFormat.Xml,
        UriTemplate = "featureOfInterest?location={location}"
        )]
    Message GetSites(string location);

    [OperationContract]
    [WebGet(
        // ResponseFormat = WebMessageFormat.Xml,
        UriTemplate = "observedProperty?variable={variable}"
        )]
    Message GetVariable(string variable
    );
}
