**Project Description**
This project is the web services and the central catalog for the CUAHSI Hydrologic Information System (HIS) is an internet-based system for sharing hydrologic data.  See [http://his.cuahsi.org/](http://his.cuahsi.org/) for details. 

![](Home_http://his.cuahsi.org/images/histriangle.jpg)
The component of HIS are:
* HIS Central (THIS PROJECT) — contains copies of metadata which facilitates searches; works like a search engine, in that it harvests metadata from the data servers and allows it to be efficiently searched by the clients.
* [HydroServer](url_http___HydroServer.codeplex.com_) — stores, organizes and publishes data; allows metadata to be harvested by HIS Central and data to be shared with clients.
* Clients (such as [HydroDesktop](url_http___HydroDesktop.codeplex.com_)) — gives users a convenient interface to access data; retrieves metadata from HIS Central and retrieves data from HydroServers.

In addition, this project will contains the base code for the Web Services. We will be requesting the code examples/donations from the existing community of developers for more examples.

SubProjects:
* [HIS Central](-HisCentral) The code the harvests HIS web services, stores then and enables cross domain seraching
* [Generic Web Services](GenericWebServices)
* [HIS Services Monitoring](ServicesMonitoring)
* Ontology
* [Water Markup Language v 1.X](WaterML_1)
* [Web Services Testing](WebServicesTesting)
* [Projects in the Sandbox](SandBox)

