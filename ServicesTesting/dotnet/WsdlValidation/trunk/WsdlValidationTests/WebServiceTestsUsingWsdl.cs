[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4netConfig.xml", Watch = true)]
namespace WsdlValidationTests
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Web.Services.Description;    
    using System.Xml.Schema;
    using log4net;

    public class WebServiceTestsUsingWsdl
    {
        private static readonly ILog logger = LogManager.GetLogger("TestWsdlAndWebService");        

        /// <summary>
        /// Check existance of specified URI resource.   
        /// For our purpose, this checks if WSDL exists either in local file or online.      
        /// </summary>        
        /// <param name="uriString">
        /// Representing URI for file or web resource; must be either http or file.
        /// It also accepts windows style file path. 
        /// </param>
        /// <returns>Returns true if URI resource exists, false if not</returns>
        /// <remarks>
        /// -This method uses Uri and WebClient class to get the job done. 
        /// -File URI example: file://c:/path/file_name
        /// -This method also implicitly checks if passed uriString is in correct URI format.   
        ///  Therefore, if badly formed uriString is passed, this method returns false. 
        /// </remarks>
        static public bool doesUriResourceExists( string uriString ) {            
            try {
                // abusing using statement to just to check if I can find and 
                // open the file; using statement should take care of closing File 
                // resource               
                Uri wsdlUri = new Uri(uriString);
                WebClient testUriExist = new WebClient();
                
                testUriExist.BaseAddress = uriString;

                return checkUriResourceExist(wsdlUri, testUriExist);                
            } catch (FileNotFoundException e) {           
                logger.Warn(e.Message);
                return false;
            } catch (Exception e) {
                logger.Fatal(e.Message);
                return false;               
            }            
        }
       
        /// <summary>
        /// Check existance of specified URI resource.    
        /// For our purpose, this checks if WSDL exists either in local file or online.     
        /// </summary>        
        /// <param name="uriObj">
        /// Representing URI for file or web resource; must be either http or file.
        /// It also accepts windows style file path. 
        /// </param>
        /// <returns>Returns true if URI resource exists, false if not</returns>
        /// <remarks>
        /// -This method uses Uri and WebClient class to get the job done.        
        /// -This method also implicitly checks if passed uriString is in correct URI format.   
        ///  Therefore, if badly formed uriString is passed, this method returns false. 
        /// </remarks>
        static public bool doesUriResourceExists( Uri uriObj ) {
            try {               
                WebClient testUriExist = new WebClient();
                
                testUriExist.BaseAddress = uriObj.AbsoluteUri;

                return checkUriResourceExist(uriObj, testUriExist);                             
            } catch (FileNotFoundException e) {
                logger.Warn(e.Message);
                return false;
            } catch (Exception e) {
                logger.Fatal(e.Message);
                return false;
            }           
        }
               
        static private bool checkUriResourceExist(Uri wsdlUri, WebClient testUriExist)
        {
            if (wsdlUri.Scheme == Uri.UriSchemeFile ||
                wsdlUri.Scheme == Uri.UriSchemeHttp) {
                using (testUriExist.OpenRead(wsdlUri)) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if WSDL uri is well formed. Use Uri.IsWellFormedUriString method        
        /// </summary>
        /// <param name="wsdlUri">
        /// WSDL's uri, passed as string. 
        /// </param>
        /// <param name="uriKind">
        /// Defines uri type: absolute, relative, or absolute/relative 
        /// </param>
        /// <returns>
        /// Returns true if WSDL's uri is well formed. Returns false if not.
        /// </returns>
        static public bool doesWsdlUriWellFormed(string wsdlUri, UriKind uriKind) {                       
            try {
                return Uri.IsWellFormedUriString(wsdlUri, uriKind);           
            } catch ( Exception e ) {
                logger.Fatal(e.Message);
                return false;
            }          
        }

        /// <summary>
        /// Check if WSDL uri is well formed. Use Uri.IsWellFormedUriString method        
        /// </summary>
        /// <param name="uriObj">
        /// WSDL's uri, passed as System.Uri object.
        /// </param>        
        /// <returns>
        /// Returns true if WSDL's uri is well formed. Returns false if not.
        /// </returns>
        static public bool doesWsdlUriWellFormed( Uri uriObj ) {          
            try {
                return Uri.IsWellFormedUriString(uriObj.AbsoluteUri, UriKind.RelativeOrAbsolute);
            } catch (Exception e) {
                logger.Fatal(e.Message);
                return false;
            }            
        }

        /// <summary>
        /// Validates if given WSDL is within valid form.
        /// </summary>
        /// <param name="wsdlUri">
        /// URI string for web service WSDL. 
        /// </param>
        /// <returns>
        /// Returns true if given WSDL is valid. Returns false with any number of
        /// XML validation warning
        /// </returns>  
        /// <remarks>
        /// Using WebClient class to transparently take care of getting WSDL from either
        /// local file or from web. 
        /// </remarks>      
        static public bool isWsdlValid(string wsdlUri) {          
            try {
                Uri wsdlUriObj = new Uri(wsdlUri);
                WebClient testWsdlValid = new WebClient();

                testWsdlValid.BaseAddress = wsdlUri;  

                using (Stream sr = testWsdlValid.OpenRead(wsdlUri) ) {
                    return isWsdlValidLogic(sr);                 
                }               
            } catch ( FileNotFoundException e ) {
                logger.Warn(e.Message);
                return false;
            } catch ( Exception e ) {
                logger.Fatal(e.Message);
                return false;
            }          
        }

        /// <summary>
        /// Validates if given WSDL is within valid form.
        /// </summary>
        /// <param name="wsdlUriObj">
        /// System.Uri object representing URI.
        /// </param>
        /// <returns>
        /// Returns true if given WSDL is valid. Returns false with any number of
        /// XML validation warning
        /// </returns>  
        /// <remarks>
        /// Using WebClient class to transparently take care of getting WSDL from either
        /// local file or from web. 
        /// </remarks>      
        static public bool isWsdlValid( Uri wsdlUriObj ) {
            try {                
                WebClient testWsdlValid = new WebClient();
                
                testWsdlValid.BaseAddress = wsdlUriObj.AbsoluteUri;

                using (Stream sr = testWsdlValid.OpenRead(wsdlUriObj)) {
                    return isWsdlValidLogic(sr);
                }               
            } catch (FileNotFoundException e) {
                logger.Warn(e.Message);
                return false;
            } catch (Exception e) {
                logger.Fatal(e.Message);
                return false;
            }
        }

        static private bool isWsdlValidLogic(Stream sr)
        {            
            ServiceDescription wsdlDescription = ServiceDescription.Read(sr, true);

            return (wsdlDescription.ValidationWarnings.Count == 0);
        }

        /// <summary>
        /// Verifies if WSDL specifies web service method in port for soap or soap1.2
        /// </summary>        
        /// <param name="wsdlUri">
        /// URI string for web service WSDL. 
        /// </param>
        /// <param name="bindingName">
        /// Name of binding in WSDL. 
        /// </param>
        /// <param name="methodName">
        /// Name of operation to be searched in either Soap or Soap 1.2 bind element's operations
        /// </param>        
        /// <returns>
        /// Returns true if given methodName exists in bind element's operation. 
        /// Returns false if method specified by methodName does not exist.     
        /// </returns>                  
        static public bool doesWsdlSupportMethodInBinding(string wsdlUri, string bindingName,
                                                          string methodName)
        {
            try {
                Uri wsdlUriObj = new Uri(wsdlUri);
                WebClient testWsdlValid = new WebClient();
                testWsdlValid.BaseAddress = wsdlUri;

                using (Stream sr = testWsdlValid.OpenRead(wsdlUri)) {
                    return doesWsdlSupportMethodInBindingLogic(sr, bindingName, methodName);                                                                                                                  
                }                
            } catch (FileNotFoundException e) {
                logger.Warn(e.Message);
                return false;
            } catch (Exception e) {
                logger.Fatal(e.Message);
                return false;
            }              
        }

        /// <summary>
        /// Verifies if WSDL specifies web service method in port for soap or soap1.2
        /// </summary>        
        /// <param name="wsdlObj">
        /// System.Uri object for web service WSDL. 
        /// </param>
        /// <param name="bindingName">
        /// Name of binding in WSDL. 
        /// </param>
        /// <param name="methodName">
        /// Name of operation to be searched in either Soap or Soap 1.2 bind element's operations
        /// </param>        
        /// <returns>
        /// Returns true if given methodName exists in bind element's operation. 
        /// Returns false if method specified by methodName does not exist.     
        /// </returns>                 
        static public bool doesWsdlSupportMethodInBinding( Uri wsdlObj, string bindingName,
                                                          string methodName ) {
            try {               
                WebClient testWsdlValid = new WebClient();
                testWsdlValid.BaseAddress = wsdlObj.AbsoluteUri;

                using (Stream sr = testWsdlValid.OpenRead(wsdlObj)) {
                    return doesWsdlSupportMethodInBindingLogic(sr, bindingName, methodName);
                }
            } catch (FileNotFoundException e) {
                logger.Warn(e.Message);
                return false;
            } catch (Exception e) {
                logger.Fatal(e.Message);
                return false;
            }
        }
      
        static private bool doesWsdlSupportMethodInBindingLogic(Stream sr, string bindingName, string methodName)
        {
            ServiceDescription wsdlDescription = ServiceDescription.Read(sr, true);
            int bindingCount = wsdlDescription.Bindings.Count;
       
            if (bindingCount > 0) {
                for (int i = 0; i < bindingCount; i++) {
                    // checking to see if specified bindingName exists 
                    if (!(wsdlDescription.Bindings[i].Name).Equals(bindingName)) continue;
                
                    int opCount = wsdlDescription.Bindings[i].Operations.Count;

                    // checking to see if specified method/operation exists in 
                    // bindingName
                    if (opCount <= 0) continue;

                    for (int j = 0; j < opCount; j++) {
                        // checking if specified methodName exists within binding's 
                        // operation
                        if ((wsdlDescription.Bindings[i].Operations[j].Name).Equals(methodName)) {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Verifies if method specified contains specified parameter name and type
        /// </summary>
        /// <returns></returns> 
        static public bool verifyWebMethodParamNamesAndTypes(string wsdlUri, string methodName,
                                                             string paramName, string paramType)
        {
            try {
                Uri wsdlUriObj = new Uri(wsdlUri);
                WebClient testWsdlValid = new WebClient();
                testWsdlValid.BaseAddress = wsdlUri;

                using (Stream sr = testWsdlValid.OpenRead(wsdlUri)) {
                    return verifyWebMethodParamNamesAndTypesLogic(sr, methodName, paramName, paramType);
                }
            } catch (FileNotFoundException e) {
                logger.Warn(e.Message);
                return false;
            } catch (Exception e) {
                logger.Fatal(e.Message);
                return false;
            }              
        }

        static private bool verifyWebMethodParamNamesAndTypesLogic(Stream sr, string methodName, 
                                                                   string paramName, string paramType)
        {
            ServiceDescription wsdlDescription = ServiceDescription.Read(sr, true);
            int numOfSchemas = wsdlDescription.Types.Schemas.Count;
            
            // so, basically  targetNameSpace:name  
            // iterating through all schemas and checking too see if method with given parameter name 
            // and type exists. 
            // OK, THIS IS HOW I CAN GET SCHEMA'S METHOD !!!! 
            // Elements represents types under WSDL TYPE
            for (int i = 0; i < numOfSchemas; i++ ) {
                foreach (DictionaryEntry elementName in wsdlDescription.Types.Schemas[i].Elements) {
                    // assuming all types under element will be complexType                
                    XmlSchemaElement element = (XmlSchemaElement)elementName.Value;

                    //Console.WriteLine("Method Name: " + element.Name);
                    if (!element.Name.Equals(methodName)) {
                        continue;
                    }

                    XmlSchemaComplexType complexType = (XmlSchemaComplexType)element.SchemaType;
                    XmlSchemaSequence sequenceType = (XmlSchemaSequence)complexType.Particle;

                    // iterating through parameters
                    foreach (XmlSchemaElement sequenceElement in sequenceType.Items) {
                        //Console.WriteLine("name of param: " + sequenceElement.Name);
                        //Console.WriteLine("type of param: " + sequenceElement.SchemaTypeName.Name);   
                        if (!sequenceElement.Name.Equals(paramName)) {
                            continue;
                        }

                        if (sequenceElement.SchemaTypeName.Name.Equals(paramType)) {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
      
        static public bool verifyWebMethodExistsInType( string wsdlUri, string methodName ) {
            try {
                Uri wsdlUriObj = new Uri(wsdlUri);
                WebClient testWsdlValid = new WebClient();
                testWsdlValid.BaseAddress = wsdlUri;
           
                using (Stream sr = testWsdlValid.OpenRead(wsdlUri)) {
                    return verifyWebMethodExistsInType_private(sr, methodName);
                }
            } catch (FileNotFoundException e) {
                logger.Warn(e.Message);
                return false;
            } catch (Exception e) {
                logger.Fatal(e.Message);
                return false;
            }
        }

        static private bool verifyWebMethodExistsInType_private( Stream sr, string methodName ) {
            ServiceDescription wsdlDescription = ServiceDescription.Read(sr, true);
            int numOfSchemas = wsdlDescription.Types.Schemas.Count;

            // so, basically  targetNameSpace:name  
            // iterating through all schemas and checking too see if method with given parameter name 
            // and type exists. 
            // OK, THIS IS HOW I CAN GET SCHEMA'S METHOD !!!! 
            // Elements represents types under WSDL TYPE
            for (int i = 0; i < numOfSchemas; i++) {
                foreach (DictionaryEntry elementName in wsdlDescription.Types.Schemas[i].Elements) {
                    // assuming all types under element will be complexType                
                    XmlSchemaElement element = (XmlSchemaElement)elementName.Value;

                    //Console.WriteLine("Method Name: " + element.Name);
                    if ( element.Name.Equals(methodName)) {
                        return true;
                    }                    
                }
            }

            return false;
        }
    }
}
