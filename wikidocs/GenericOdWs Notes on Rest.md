[REST for Original Services (cuahsi.asmx)](REST-for-Original-Services-(cuahsi.asmx)) 

For the services that have a REST endpoint, these are the calls.
Improvements:
* naming consistency.
* methods removed, since all methods return the XML objects.

GetSites (all sites)
* [http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/sites?authToken=](http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/sites?authToken=)
* [http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/sites?authToken=](http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/sites?authToken=)
GetSites (some sites)
* [http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/sites?location=LBRSDSC:USU-LBR-SFLower,USU-LBR-ExpFarm&authToken=](http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/sites?location=LBRSDSC:USU-LBR-SFLower,USU-LBR-ExpFarm&authToken=)
* [http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/sites?location=LBRSDSC:USU-LBR-SFLower,USU-LBR-ExpFarm&authToken=](http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/sites?location=LBRSDSC:USU-LBR-SFLower,USU-LBR-ExpFarm&authToken=)

GetSiteInfo (1 site)
* [ http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/siteinfo?location=LBRSDSC:USU-LBR-SFLower&authToken=]( http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/siteinfo?location=LBRSDSC:USU-LBR-SFLower&authToken=)
* [ http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/siteinfo?location=LBRSDSC:USU-LBR-SFLower&authToken=]( http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/siteinfo?location=LBRSDSC:USU-LBR-SFLower&authToken=)

GetVariable (all)
* [ http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/variables?authToken=]( http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/variables?authToken=)
* [ http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/variables?authToken=]( http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/variables?authToken=)
GetVariable (one)
* [ http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/variables?variable=LRBSDSC:USU4&authToken=]( http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/variables?variable=LRBSDSC:USU4&authToken=)
* [ http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/variables?variable=LRBSDSC:USU4&authToken=]( http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_0.svc/variables?variable=LRBSDSC:USU4&authToken=)

GetValues:
* [ http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/datavalues?variable=LRBSDSC:USU4&location=LRBSDSC:USU-LBR-SFLower&startDate=&endDate=&authToken=]( http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/datavalues?variable=LRBSDSC:USU4&location=LRBSDSC:USU-LBR-SFLower&startDate=&endDate=&authToken=)
* [ http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/datavalue?variable=LRBSDSC:USU4&location=LRBSDSC:USU-LBR-SFLower&startDate=&endDate=&authToken=]( http://hydro10.sdsc.edu/lbrsdsc/REST/waterml_1_1.svc/datavalue?variable=LRBSDSC:USU4&location=LRBSDSC:USU-LBR-SFLower&startDate=&endDate=&authToken=)


GetValuesForASite: Not yet implemented.
~~[ http://water.sdsc.edu/lbrsdsc/cuahsi_1_1.asmx/GetValuesForASiteObject?site=LRBSDSC:USU-LBR-SFLower&startDate=2008-01-01&endDate=2008-02-01&authToken=]( http://water.sdsc.edu/lbrsdsc/cuahsi_1_1.asmx/GetValuesForASiteObject?site=LRBSDSC:USU-LBR-SFLower&startDate=2008-01-01&endDate=2008-02-01&authToken=)~~

GetSiteInfoMulitple (not implemented)
* ~~[ http://water.sdsc.edu/lbrsdsc/cuahsi_1_1.asmx/GetSiteInfoMultpleObject?Site=LBRSDSC:USU-LBR-SFLower&site=LBRSDSC:USU-LBR-ExpFarm&authToken=]( http://water.sdsc.edu/lbrsdsc/cuahsi_1_1.asmx/GetSiteInfoMultpleObject?Site=LBRSDSC:USU-LBR-SFLower&site=LBRSDSC:USU-LBR-ExpFarm&authToken=)~~


