using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WaterOneFlow.odws.v1_1.wcf.REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRest" in both code and config file together.
    [ServiceContract]
    public interface IRest
    {
        [OperationContract()]
        [WebGet(UriTemplate = "/")]
        void ListNetworks();

        [OperationContract]
        [WebGet(UriTemplate = "/{network}/capabilities")]
        void NetworkCapabilites(string network);

        [OperationContract]
        [WebGet(UriTemplate = "/{network}/sites")]
        void NetworkSites(string network);

        [OperationContract]
        [WebGet(UriTemplate = "/{network}/series")]
        void NetworkSeries(string network);

        [OperationContract]
        [WebGet(UriTemplate = "/{network}/results")]
        void NetworkData(string network);
    }

}
