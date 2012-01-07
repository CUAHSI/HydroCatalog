using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace WCFServiceWebRole1
{
    public class HisDataService : DataService< hisEntities >
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
             config.UseVerboseErrors = true; // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
             config.SetEntitySetAccessRule("SeriesCatalogs", EntitySetRights.AllRead);
             config.SetEntitySetAccessRule("Sites", EntitySetRights.AllRead);
             config.SetEntitySetAccessRule("Variables", EntitySetRights.AllRead);
          
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
}
