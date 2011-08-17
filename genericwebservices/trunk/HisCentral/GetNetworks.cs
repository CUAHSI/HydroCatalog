using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cuahsi.hiscentral.cuahsi.hiscentral;

namespace HisCentral
{
   public static class GetNetworks
    {
        private static cuahsi.hiscentral.cuahsi.hiscentral.hiscentral svc;
        private static Boolean _loaded = false;
        private static Dictionary<string, ServiceInfo> _serviceList = new  Dictionary<string, ServiceInfo>() ;

       static GetNetworks()
       {
            lock (_serviceList)
               {
                 if (Loaded == false)
           {
                svc = new cuahsi.hiscentral.cuahsi.hiscentral.hiscentral();
                   var services = svc.GetWaterOneFlowServiceInfo();
                   foreach (var service in services)
                   {
                       _serviceList.Add(service.NetworkName, service);
                   }

                   _loaded = true;
               }
           }
       }

       public static Boolean Loaded
       {
           get { return _loaded; }
       }


       public static ServiceInfo GetNetworkByCode(String netowrkCode)
       {
           if (_serviceList.ContainsKey(netowrkCode))
           {
               return _serviceList[netowrkCode];
           }
           else return null;
       }
    }
}
