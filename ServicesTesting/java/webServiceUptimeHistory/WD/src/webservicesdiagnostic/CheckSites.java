/*
 * CheckSites.java
 *
 * Created on August 6, 2010, 3:37 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package webservicesdiagnostic;

import java.util.HashMap;
import java.util.Iterator;
import javax.xml.ws.BindingProvider;

/**
 *
 * @author mae171b
 */
public class CheckSites {
    
    public CurrentStatus CheckSites(HashMap SiteName, HashMap SiteStatus, HashMap SiteURL){
        
        CurrentStatus CS = new CurrentStatus();
        
        unitvalues.SiteInfoResponseType Sites;
        Iterator iter = SiteURL.keySet().iterator();
        unitvalues.ArrayOfString empty = new unitvalues.ArrayOfString();
        int j = 0;
        while(iter.hasNext()){
            j = j + 1;
            String endpoint = (String)SiteURL.get(iter.next());
            
            endpoint.trim();
            
            if(endpoint.endsWith("?WSDL ")){
                endpoint = endpoint.substring(0,endpoint.length()-6);
                System.out.println(j+": "+endpoint);
            }
            
            if(endpoint == (null)){
                System.out.println("Damnit");
            }else{
                String Info = null;
                String k = null;
                try {
                    unitvalues.WaterOneFlow service = new unitvalues.WaterOneFlow();
                    unitvalues.WaterOneFlowSoap port = service.getWaterOneFlowSoap();
                    BindingProvider bp = (BindingProvider)port;
                    bp.getRequestContext().put(BindingProvider.ENDPOINT_ADDRESS_PROPERTY, endpoint);
                    Sites = port.getSites(empty,"");
                    Info = (String)SiteName.get(endpoint);
                    SiteStatus.put(Info,"Success");
                    k = SiteStatus.get(Info).toString();
                    System.out.println(j+": "+k+": " +Info);
                } catch(Exception ex) {
                    Info = (String)SiteName.get(endpoint);
                    SiteStatus.put(Info,"Failed");
                    k = SiteStatus.get(Info).toString();
                    System.out.println(j+": "+k+": " +Info);
                }
                
                
            }
            
            
        }
      CS.SiteStatus = SiteStatus;
       return CS;
    }
    
    public class CurrentStatus{
        public HashMap SiteStatus = new HashMap();
    }
    

}
