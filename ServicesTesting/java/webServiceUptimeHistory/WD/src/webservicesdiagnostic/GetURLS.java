/*
 * GetURLS.java
 *
 * Created on August 6, 2010, 2:13 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package webservicesdiagnostic;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;
import java.util.StringTokenizer;

/**
 *
 * @author mae171b
 */
public class GetURLS {
   
    /** Creates a new instance of GetURLS */
    public HashTables GetURLS() throws IOException {
        
        String currentdir = System.getProperty("user.dir");
        dirlist(currentdir);
        currentdir = "C:\\Documents and Settings\\mae171b\\Desktop\\WebDiagnostic\\WD";
        currentdir = currentdir+"\\WSDL.txt";
        
        HashTables HT = new HashTables();
        
        String Parameter = null;
        String key = null;
        String value = null;
        
        int Log = 1;
        try {
            BufferedReader br = new BufferedReader(new FileReader(currentdir));
            Parameter = br.readLine();
            int k = 0;
            while(Log == 1){
                k = k + 1;
                Parameter = br.readLine();
                if(Parameter != null){
                    StringTokenizer l = new StringTokenizer(Parameter);
                    key = l.nextToken(";");
                    value = l.nextToken(";");
                    
                    System.out.println(k+": "+key);
                    System.out.println(k+": "+value);
                    HT.toString();
                    HT.SiteName.put(value,key);
                    HT.SiteURL.put(key,value);
                    HT.SiteStatus.put(key,"Unknown");
                
                }else{
                    Log = 0;
                }
            }
        } catch (FileNotFoundException ex) {
            ex.printStackTrace();
        }
        
    
        return HT;
    }
    
    private static void dirlist(String fname){
        File dir = new File(fname);
        System.out.println("Current Working Directory: "+dir.getPath());
    }
    
    public class HashTables{
    
        public HashMap SiteURL = new HashMap();
        public HashMap SiteName = new HashMap();
        public HashMap SiteStatus = new HashMap();
        
    } 
    
}


