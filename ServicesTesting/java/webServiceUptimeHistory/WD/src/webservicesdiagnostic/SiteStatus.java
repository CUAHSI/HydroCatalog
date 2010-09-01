/*
 * SiteStatus.java
 *
 * Created on August 6, 2010, 2:15 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package webservicesdiagnostic;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.util.HashMap;
import java.util.Iterator;

/**
 *
 * @author mae171b
 */
public class SiteStatus {
    
    /** Creates a new instance of SiteStatus */
    public void SiteStatus (HashMap SiteStatus){
        String Master = "";
        String currentdir = System.getProperty("user.dir");
        dirlist(currentdir);
        Iterator i = SiteStatus.keySet().iterator();
            
           try{
                currentdir = currentdir+"\\STATUS.txt";
                FileWriter fstream = new FileWriter(currentdir);
                BufferedWriter out = new BufferedWriter(fstream);
                int k = 0;    
                    while(i.hasNext()){
                        k = k + 1;
                        try{
                        String Name = i.next().toString();
                        String INFO = SiteStatus.get(Name).toString();
                        System.out.println(Name+": "+INFO+"\r\n");
                        Master = Name+": "+INFO+"\r\n" + Master;
                        }catch(Exception Ex){
                        System.out.println(k+": "+"Problem");    
                        }
                    }
                   out.write(Master);
                   out.close();
            } catch(Exception ex) {
                System.out.println("Something Is Wrong With File Output");
            }
    
    }
 
    private static void dirlist(String fname){
        File dir = new File(fname);
        System.out.println("Current Working Directory: "+dir.getPath());
    }
    
}
