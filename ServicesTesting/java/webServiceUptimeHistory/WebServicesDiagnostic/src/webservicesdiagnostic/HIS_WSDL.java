/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package webservicesdiagnostic;
import java.io.*;

public class HIS_WSDL{
 public static void main(String[] args) {
    try { // This code block invokes the HiscentralSoap:getWaterOneFlowServiceInfo operation on web service
                String Location = null;
                String currentdir = System.getProperty("user.dir");

                dirlist(currentdir);

                RequestRetrieve.Hiscentral hiscentral = new RequestRetrieve.Hiscentral_Impl();
                RequestRetrieve.ArrayOfServiceInfo SiteInfo = new RequestRetrieve.ArrayOfServiceInfo();
                RequestRetrieve.HiscentralSoap _hiscentralSoap = hiscentral.getHiscentralSoap();
                SiteInfo = _hiscentralSoap.getWaterOneFlowServiceInfo();
                try{
                currentdir = "C:\\Documents and Settings\\mae171b\\Desktop\\WebDiagnostic\\WD";
                currentdir = currentdir+"\\WSDL.txt";
                FileWriter fstream = new FileWriter(currentdir);
                BufferedWriter out = new BufferedWriter(fstream);
                    for(int i = 0; i < SiteInfo.getServiceInfo().length; i = i + 1){

                        if(SiteInfo.getServiceInfo()[i].getOrganization().isEmpty()){
                        System.out.println("Check CUAHSI for Error in Organization Listing");
                        }else{
                        System.out.println(SiteInfo.getServiceInfo()[i].getServURL());


                            // Create file

                            out.write(SiteInfo.getServiceInfo()[i].getOrganization()+i+"; "+SiteInfo.getServiceInfo()[i].getServURL()+"\r\n");

                        }
            }
                out.close();
            }catch (Exception e){//Catch exception if any

                            }
            } catch(javax.xml.rpc.ServiceException ex) {
                java.util.logging.Logger.getLogger(RequestRetrieve.Hiscentral.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
            } catch(java.rmi.RemoteException ex) {
                java.util.logging.Logger.getLogger(RequestRetrieve.Hiscentral.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
            } catch(Exception ex) {
                java.util.logging.Logger.getLogger(RequestRetrieve.Hiscentral.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
            }
    }

    private static void dirlist(String fname){

        File dir = new File(fname);
        System.out.println("Current Working Directory : "+ dir.getPath());
        
    }

}

