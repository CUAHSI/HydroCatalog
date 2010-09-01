package webservicesdiagnostic;

import java.io.IOException;
import java.util.*;
import javax.xml.soap.*;
import webservicesdiagnostic.CheckSites;
import webservicesdiagnostic.GetURLS;
import webservicesdiagnostic.SiteStatus;


public class Main {
    
    //SiteResponse SR = new SiteResponse();
    public static void main(String[] args) throws IOException {
        
        GetURLS GU = new GetURLS();
        CheckSites CS = new CheckSites();
        SiteStatus SS = new SiteStatus();
        
        System.out.println("Are You Here?");
        
        HashMap HT1 = GU.GetURLS().SiteName;
        HashMap HT2 = GU.GetURLS().SiteStatus;
        HashMap HT3 = GU.GetURLS().SiteURL;
        
        HT2 = CS.CheckSites(HT1,HT2,HT3).SiteStatus;
        
        SS.SiteStatus(HT2);
        
        
        
        
    }
    
    
}