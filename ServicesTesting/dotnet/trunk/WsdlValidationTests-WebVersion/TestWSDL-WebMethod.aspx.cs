using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WsdlValidationTests;

namespace WsdlValidationTests_WebVersion
{
    public partial class _Default : System.Web.UI.Page
    {
        protected ArrayList listOfWsdlUris;
        protected Hashtable mapOfMethodNameAndParams;

        protected void Page_Load( object sender, EventArgs e ) {
            // Note: 15 Sep 2008
            //       Using Application object to save data, like below, is
            //       old ASP practice. New Cache object is better choice
            // listOfWsdlUris = Context.Server.MapPath("wsdl_uri.txt");           
            listOfWsdlUris = RetriveInfoFromFile.getLineEntriesFromFile(
                                                 Context.Server.MapPath(
                                                 ConfigurationManager.AppSettings["WSDL"]));
             
            mapOfMethodNameAndParams = 
                         RetriveInfoFromFile.extractMethodNameParamNameAndType(
                         Context.Server.MapPath(
                         ConfigurationManager.AppSettings["methodNames"]));                                         
        }
    }

    class RetriveInfoFromFile
    {
        static public Hashtable extractMethodNameParamNameAndType( string filePath ) {
            Hashtable returnValue = null;
            Hashtable methodParamNameAndTypes = null;
            ArrayList lines = null;

            try {
                returnValue = new Hashtable();
                lines = getLineEntriesFromFile(filePath);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }

            string[] seperator1 = { "," }, seperator2 = { "::" };

            if (lines == null) {
                return null;
            }

            foreach (string uri in lines) {
                methodParamNameAndTypes = null;

                if (uri == null) {
                    continue;
                }

                string[] methodNameAndParams = uri.Split(seperator1, StringSplitOptions.RemoveEmptyEntries);

                // skipping empty lines, if there's any
                if (methodNameAndParams.Length <= 0) {
                    continue;
                }

                string methodName = methodNameAndParams[0];

                try {
                    methodParamNameAndTypes = new Hashtable();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }

                for (int i = 1; i < methodNameAndParams.Length; i++) {
                    string[] paramNameAndType =
                             methodNameAndParams[i].Split(seperator2, StringSplitOptions.RemoveEmptyEntries);
                    // making sure parameter name/type pair is collectly retrieved from file
                    if (paramNameAndType.Length != 2) {
                        continue;
                    }

                    try {
                        // adding parameter name (hashtable key) and type   
                        if (methodParamNameAndTypes != null) {
                            methodParamNameAndTypes.Add(paramNameAndType[0], paramNameAndType[1]);
                        }
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                }

                // adding map of param name/param type to 
                // map of method name/map of param name,type
                try {
                    if (methodParamNameAndTypes != null) {
                        returnValue.Add(methodName, methodParamNameAndTypes);
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            return returnValue;
        }

        static public ArrayList getLineEntriesFromFile( string filePath ) {
            if (!File.Exists(filePath)) {
                return null;
            }

            // Open the file to read from.
            ArrayList uriEntries = new ArrayList();

            using (StreamReader sr = File.OpenText(filePath)) {
                string s = null;
                while ((s = sr.ReadLine()) != null) {
                    uriEntries.Add(s);
                }
            }

            return uriEntries;
        }
    }
}
