using System;
using System.Web.Routing;
using System.Collections.Generic;
using Microsoft.ApplicationServer.Http.Activation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(GenericWebservice.App_Start.WebApi), "Start")]

namespace GenericWebservice.App_Start {
    public static class WebApi {
        public static void Start() {
            // TODO: change "MyModel" to desired route segment
            RouteTable.Routes.MapServiceRoute<GenericWebservice.Resources.MyModelResource>("MyModel");
        }
    }
}