using System;
using System.Collections;
using System.IO;
using System.Text;

namespace TestWebService
{
    // utility class used by TestWsdl main method to retrieve uri and method signature from files
    class RetriveInfoFromFile
    {
        static public Hashtable extractMethodNameParamNameAndType( string filePath ) 
        {
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
