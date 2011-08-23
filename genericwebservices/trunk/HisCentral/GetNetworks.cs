using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using cuahsi.hiscentral.cuahsi.hiscentral;

namespace HisCentral
{
   public static class GetNetworks
    {
        private static cuahsi.hiscentral.cuahsi.hiscentral.hiscentral svc;
        private static Boolean _loaded = false;
       private static Boolean _loading = false;
        private static Dictionary<string, ServiceInfo> _serviceList = new  Dictionary<string, ServiceInfo>() ;

       static GetNetworks()
       {
            
       }

       private static void LoadServiceListing()
       {
           int i = 0;
           while (_loading)
           {
               i++;
               if (i > 60) throw new TimeoutException("HIS central did not return in a reasonable time");
               Thread.Sleep(500);

           }
           lock (_serviceList)
           {
               if (Loaded == false)
               {
                   _loading = true;
                   svc = new cuahsi.hiscentral.cuahsi.hiscentral.hiscentral();
                   var services = svc.GetWaterOneFlowServiceInfo();
                   foreach (var service in services)
                   {
                       _serviceList.Add(service.NetworkName, service);
                   }

                   _loaded = true;
                   _loading = false;
               }
           }
       }
       public static Boolean Loaded
       {
           get { return _loaded; }
       }


       public static ServiceInfo GetNetworkByCode(String netowrkCode)
       {
           if (!Loaded) LoadServiceListing();
           if (_serviceList.ContainsKey(netowrkCode))
           {
               return _serviceList[netowrkCode];
           }
           else return null;
       }
    }
}
