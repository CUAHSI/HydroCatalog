using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using WaterOneFlowWebServiceTests;
using WsdlValidationTests;

// ok, now playing with actual web service to test for 
// basic 
namespace TestWebService
{
    class TestWsdl
    {        
        static void Main(string[] args)
        {               
            // ok, gotta figure out how to check my web reference is up and running... 
            // ok, first step was checking if server running web service is up...
            // now, how do I check if web service itself is running ?
            try {               
                Arguments commandLineArgs = new Arguments(args);
                
                if ( commandLineArgs["cmd"] != null ) {
                    switch ( commandLineArgs["cmd"] ) {
                        case "resrcExist":
                            checkUriResourceExist(commandLineArgs);
                            break;
                        case "uriWellFormed":
                            checkWsdlWellFormed(commandLineArgs);
                            break;
                        case "wsdlValid":
                            isWsdlValid(commandLineArgs);
                            break;
                        case "webMethodExist":
                            doesWsdlSupportMethodInBinding(commandLineArgs);
                            break;
                        case "chkParamNameType":
                            verifyWebMethodParamNameAndType(commandLineArgs);
                            break;
                        case "testGetValues":
                            testGetValuesMethod(commandLineArgs);
                            break;
                        case "testGetValuesFromFile":
                            testGetValuesUsingTestDataFile(commandLineArgs);
                            break;
                        case "all":
                            if ((commandLineArgs["verbose"] != null &&
                                !commandLineArgs["verbose"].Equals("off")) ||
                                commandLineArgs["verbose"] == null) {
                                testAll(true);
                            } else {
                                testAll(false);
                            }
                            break;
                        default:
                            printHelpMessage();
                            break;
                    }
                } else {
                    printHelpMessage();
                }
            }
            catch ( NullReferenceException e ) {
                Console.WriteLine("Null Reference Exception occured with following message.");
                Console.WriteLine(e.ToString() );
            }
            catch ( Exception e ) {
                Console.WriteLine("General Exception occured with following message.");
                Console.WriteLine(e.ToString() );
            }            
        }

        // this is the method that'll let users test all WSDL specified in uri, and run all tests
        // available sequentially
        static private void testAll(bool verboseDisplay)
        {
            try {
                ArrayList listOfWsdlUris = RetriveInfoFromFile.getLineEntriesFromFile(
                                               "./TestWsdl config files/wsdl_uri.txt");
                Hashtable mapOfMethodNameAndParams = 
                          RetriveInfoFromFile.extractMethodNameParamNameAndType(
                                                  "./TestWsdl config files/" +
                                                  "web_method_and_param.txt");                               

                for ( int i = 0; i < listOfWsdlUris.Count; i++  ) {
                    string[] arg1 = { "-cmd", "uriWellFormed", "-uri=" + listOfWsdlUris[i] };
                    string[] arg2 = { "-cmd", "resrcExist", "-uri=" + listOfWsdlUris[i] };
                    string[] arg3 = { "-cmd", "wsdlValid", "-uri=" + listOfWsdlUris[i] };
                   
                    if ( !verboseDisplay ) {
                        arg1 = new string[]{ "-cmd", "uriWellFormed", 
                                             "-uri=" + listOfWsdlUris[i],"-verbose","off" };
                        arg2 = new string[]{ "-cmd", "resrcExist", "-uri=" + listOfWsdlUris[i],
                                             "-verbose", "off"};
                        arg3 = new string[]{ "-cmd", "wsdlValid", "-uri=" + listOfWsdlUris[i],
                                             "-verbose", "off"};
                    }

                    checkWsdlWellFormed(new Arguments(arg1));
                    checkUriResourceExist(new Arguments(arg2));
                    isWsdlValid(new Arguments(arg3));                                                             

                    // checking WSDL supports web method specified, and also checks if web method
                    // has specified parameter name/type signature 
                    foreach (string methodName in mapOfMethodNameAndParams.Keys) {
                        Hashtable paramNameType = (Hashtable)mapOfMethodNameAndParams[methodName];
                        
                        foreach (string paramName in paramNameType.Keys) {
                            string [] arg6 = { "-cmd", "chkParamNameType", "-uri=" + listOfWsdlUris[i], 
                                               "-mn",methodName, "-pn", paramName, 
                                               "-pt", (string)paramNameType[paramName] };

                            if (!verboseDisplay) {
                                arg6 = new string[] { "-cmd", "chkParamNameType", 
                                                      "-uri=" + listOfWsdlUris[i], 
                                                      "-mn",methodName, "-pn", paramName, 
                                                      "-pt", (string)paramNameType[paramName],
                                                      "-verbose","off"};                              
                            }

                            verifyWebMethodParamNameAndType(new Arguments(arg6));
                        }
                    }
                                       
                }
            } catch ( Exception e ) {
                Console.WriteLine(e.Message);
            }
        }

        static private void testGetValuesMethod( Arguments commandLineArgs ) 
        {
            if (commandLineArgs["uri"] != null) {
                WaterOneFlowWebMethodTests testWebMethod =
                                       new WaterOneFlowWebMethodTests(commandLineArgs["uri"], true);
                string result = "";
                string authToken = "";                
                
                if ( ! string.IsNullOrEmpty(commandLineArgs["authToken"]) ||
                     commandLineArgs["authToken"].Equals("true") ) {
                    authToken = commandLineArgs["authToken"];
                }
                    
                if ( testWebMethod.testGetValues(commandLineArgs["networkName"], 
                                                 commandLineArgs["location"],
                                                 commandLineArgs["variable"],
                                                 commandLineArgs["startDate"],
                                                 commandLineArgs["endDate"],
                                                 authToken,
                                                 ref result) ) {
                    if ((commandLineArgs["verbose"] != null &&
                         !commandLineArgs["verbose"].Equals("off")) ||
                         commandLineArgs["verbose"] == null) {
                       testWebMethod.showSiteXmlElements(result);
                    }
                } 
            } else {
                printHelpMessage();
            }    
        }

        // I'll use this method to test all values specified in TestData1 excel file 
        // use the Arguments to turn on and off the verbose message only; all other 
        // parameters should be provided by Excel data file
        static private void testGetValuesUsingTestDataFile( Arguments commandLineArgs ) {
            // once I figure out how to access Excel data, I can loop the testGetValuesMethod
            // for all values specified in TestData1 excel file. 
            const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; 
                                          Data Source=./TestWsdl config files/TestData1.xls;Extended Properties=    
                                          ""Excel 8.0;HDR=YES;""";

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            DbDataAdapter adapter = factory.CreateDataAdapter();
            DbCommand selectSeriesCommand = factory.CreateCommand();
            DbCommand selectNetworkCommand = factory.CreateCommand();
            DataSet seriesDataSet = null, networkDataSet = null;                    

            // initializing queries for accessing series and network worksheet 
            // from TestData1 excel file            
            selectSeriesCommand.CommandText = "SELECT * " +
                                              "FROM [Series$]"; // wonder why I need $ sign =/ 
            selectNetworkCommand.CommandText = "SELECT * " +
                                               "FROM [Network$]";

            DbConnection connection = factory.CreateConnection();

            connection.ConnectionString = connectionString;
            selectSeriesCommand.Connection = connection;
            selectNetworkCommand.Connection = connection; 

            // hmm, I guess I can reuse adapter by choosing different SelectCommand
            // hopefully, this properly initialized everything I need correctly... 
            adapter.SelectCommand = selectSeriesCommand;
            seriesDataSet = new DataSet();
            adapter.Fill(seriesDataSet);

            adapter.SelectCommand = selectNetworkCommand;
            networkDataSet = new DataSet();
            adapter.Fill(networkDataSet); 
            
            // hmm, think I'll put networkCode and ServiceWSDL in hastMap first
            Hashtable netCodeAndWSDLuri = new Hashtable();

            foreach ( DataRow theRow in networkDataSet.Tables[0].Rows ) {
                netCodeAndWSDLuri.Add(theRow.ItemArray[0], theRow.ItemArray[1]);
            }

            string[] seperator1 = { " " };

            // ok, compiler is not complaining for now...             
            foreach ( DataRow theRow in seriesDataSet.Tables[0].Rows ) {
                string serviceWSDL = "", sitecode = "", variable ="";
                string beginDate = "", endDate = "";
                int i = 0; 

                foreach ( object stuff in theRow.ItemArray ) {
                    // from first entry, I need to find out                     
                    switch ( i ) {
                        case 0:
                            serviceWSDL = (string)netCodeAndWSDLuri[stuff.ToString()];                            
                            break;
                        case 1:
                            sitecode = stuff.ToString();
                            break;
                        case 2:
                            variable = stuff.ToString();
                            break;
                        case 3:                            
                            beginDate = ((DateTime) stuff).ToString("u");
                            beginDate = beginDate.Split(seperator1, StringSplitOptions.RemoveEmptyEntries)[0];
                            // beginDate = stuff.ToString();
                            break;
                        case 4:                            
                            endDate = ((DateTime)stuff).ToString("u");
                            endDate = endDate.Split(seperator1, StringSplitOptions.RemoveEmptyEntries)[0];                
                            //endDate = stuff.ToString();
                            break;
                        default:
                            break;
                    }
                                        
                    Console.WriteLine(stuff + " ");
                    i++;
                }

                if ( ! String.IsNullOrEmpty(serviceWSDL) ) {
                    WaterOneFlowWebMethodTests testWebMethod =
                        new WaterOneFlowWebMethodTests(serviceWSDL, true);
                    string result = "";

                    bool testResult = testWebMethod.testGetValues2(sitecode, variable, 
                                                                   beginDate, endDate, "",
                                                                   ref result);

                    Console.WriteLine(serviceWSDL);

                    if ( testResult ) {
                        Console.WriteLine("Test Passed.");
                    } else {
                        Console.WriteLine("Test Failed.");    
                    }
                    
                    Console.WriteLine(result);
                }
                
                Console.WriteLine();
            } 
        }

        static private void checkUriResourceExist( Arguments commandLineArgs )
        {
            if ( commandLineArgs["uri"] != null ) {
                if (WebServiceTestsUsingWsdl.doesUriResourceExists(commandLineArgs["uri"])) {
                    if ( (commandLineArgs["verbose"] != null && 
                         !commandLineArgs["verbose"].Equals("off")) || 
                         commandLineArgs["verbose"] == null ) {
                        Console.WriteLine(commandLineArgs["uri"] + " EXISTS.");
                        Console.WriteLine();
                    }
                } else {
                    Console.WriteLine(commandLineArgs["uri"] + " DOES NOT EXIST.");
                    Console.WriteLine();
                }
            } else {
                printHelpMessage();
            }    
        }

        static private void checkWsdlWellFormed( Arguments commandLineArgs )
        {
            if (commandLineArgs["uri"] != null) {
                if (WebServiceTestsUsingWsdl.doesWsdlUriWellFormed(commandLineArgs["uri"], UriKind.RelativeOrAbsolute)) {
                    if ((commandLineArgs["verbose"] != null &&
                         !commandLineArgs["verbose"].Equals("off")) ||
                         commandLineArgs["verbose"] == null) {
                        Console.WriteLine(commandLineArgs["uri"] + " is WELL FORMED URI.");
                        Console.WriteLine();
                    }
                } else {
                    Console.WriteLine(commandLineArgs["uri"] + " is NOT WELL FORMED URI.");
                    Console.WriteLine();
                }
            } else {
                printHelpMessage();
            }            
        }

        static private void isWsdlValid( Arguments commandLineArgs )
        {
            if (commandLineArgs["uri"] != null) {
                if (WebServiceTestsUsingWsdl.isWsdlValid(commandLineArgs["uri"])) {
                    if ((commandLineArgs["verbose"] != null &&
                         !commandLineArgs["verbose"].Equals("off")) ||
                         commandLineArgs["verbose"] == null) {
                        Console.WriteLine(commandLineArgs["uri"] + " is VALID WSDL.");
                        Console.WriteLine();
                    }
                } else {
                    Console.WriteLine(commandLineArgs["uri"] + " is NOT VALID WSDL.");
                    Console.WriteLine();
                }
            } else {
                printHelpMessage();
            }            
        }

        static private void doesWsdlSupportMethodInBinding( Arguments commandLineArgs )
        {
            if (commandLineArgs["uri"] != null && commandLineArgs["bn"] != null &&
                                commandLineArgs["mn"] != null ) {
                if (WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(
                                commandLineArgs["uri"], commandLineArgs["bn"],
                                commandLineArgs["mn"]) ) {
                    if ((commandLineArgs["verbose"] != null &&
                         !commandLineArgs["verbose"].Equals("off")) ||
                         commandLineArgs["verbose"] == null) {
                        Console.WriteLine(commandLineArgs["mn"] + " IS SPECIFIED by WSDL ");
                        Console.WriteLine(commandLineArgs["uri"]);
                        Console.WriteLine(" in binding " + commandLineArgs["bn"]);
                        Console.WriteLine();
                    }
                } else {
                    Console.WriteLine(commandLineArgs["mn"] + " IS NOT SPECIFIED by WSDL ");
                    Console.WriteLine(commandLineArgs["uri"]);
                    Console.WriteLine(" in binding " + commandLineArgs["bn"]);
                    Console.WriteLine();
                }
            } else {
                printHelpMessage();
            }
        }

        static private void verifyWebMethodParamNameAndType( Arguments commandLineArgs )
        {
            if (commandLineArgs["uri"] != null && commandLineArgs["mn"] != null &&
                                commandLineArgs["pn"] != null && commandLineArgs["pt"] != null ) {
                if (WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(
                           commandLineArgs["uri"], commandLineArgs["mn"],
                           commandLineArgs["pn"], commandLineArgs["pt"]) ) {
                    if ((commandLineArgs["verbose"] != null &&
                         !commandLineArgs["verbose"].Equals("off")) ||
                         commandLineArgs["verbose"] == null) {
                        Console.WriteLine("WSDL in " + commandLineArgs["uri"]);
                        Console.WriteLine(" specifies method name " +
                                          commandLineArgs["mn"] + ", and it has parameter named " +
                                          commandLineArgs["pn"] + " with parameter type " +
                                          commandLineArgs["pt"]);
                        Console.WriteLine();
                    }
                } else {
                    Console.WriteLine("WSDL in " + commandLineArgs["uri"]);
                    Console.WriteLine(" DOES NOT SPECIFY method with name " +
                                      commandLineArgs["mn"] + " that has parameter named " +
                                      commandLineArgs["pn"] + " with parameter type " +
                                      commandLineArgs["pt"]);
                    Console.WriteLine();
                }
            } else {
                printHelpMessage();
            }
        }        

        static private void printHelpMessage()
        {
            Console.WriteLine("General argument format: -cmd commandName -uri uriName ...");
            Console.WriteLine();
            Console.WriteLine("NOTE: -verbose option will turn off detailed message.");
            Console.WriteLine("      If detailed message is turned off, test will only display message ");
            Console.WriteLine("      when one of the test failed. So, no news is good news with -verbose off !!!");
            Console.WriteLine("example) TestWebService -cmd resrcExist -uri=uriArg -verbose off");
            Console.WriteLine("Checking if resource specified by uri exists");
            Console.WriteLine("example) TestWebService -cmd resrcExist -uri=uriArg ");
            Console.WriteLine();
            Console.WriteLine("Checking if specified uri is well formed.");
            Console.WriteLine("example) TestWebService -cmd uriWellFormed -uri=uriArg ");
            Console.WriteLine();
            Console.WriteLine("Checking if WSDL specified by uri is valid.");
            Console.WriteLine("example) TestWebService -cmd wsdlValid -uri=uriArg");
            Console.WriteLine();
            Console.WriteLine("Checking web method for specified binding is " + 
                              "specified in WSDL specified by uri.");
            Console.WriteLine("example) TestWebService -cmd webMethodExist -uri=uriArg " +
                              "-bn bindingArg -mn methodNameArg");
            Console.WriteLine();
            Console.WriteLine("Checking web method specified by WSDL contains method with " +
                              "specified parameter name and parameter type");
            Console.WriteLine("example) TestWebService -cmd chkParamNameType -uri=uriArg -mn methodNameArg " + 
                              "-pn paramArg -pt paramTypeArg");
            Console.WriteLine();
            Console.WriteLine("Testing GetValues web method");
            Console.WriteLine("example) TestWebService -cmd testGetValues -uri=uriArg");
            Console.WriteLine("                        -networkName NetworkName -location=SiteCode");
            Console.WriteLine("                        -variable=Variable");
            Console.WriteLine("                        -startDate=date");
            Console.WriteLine("                        -endDate=date");
            Console.WriteLine("                        -authToken=token");                                                
            Console.WriteLine();
            Console.WriteLine("Testing GetValues web method using inputs from excel file");
            Console.WriteLine("example) TestWebService -cmd testGetValuesFromFiles");
            Console.WriteLine();
            Console.WriteLine("Running all tests for uri's specified in file.");
            Console.WriteLine("step 1) Check if uri listed in file for WSDL well formed.");
            Console.WriteLine("step 2) Check if uri listed in file for WSDL exists.");
            Console.WriteLine("step 3) Check if uri listed in file is in VALID WSDL format.");
            Console.WriteLine("step 4) Check if WSDL supports method and parameter signature specified in file.");
            Console.WriteLine("        For run all tests, it'll check for binding WaterOneFlowSoap and WaterOneFlowSoap12.");
            Console.WriteLine();

            
        }
    }
}