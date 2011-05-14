using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Description;
using System.Net;

namespace HisServiceTypes
{

    public enum ServiceTypeEnum
    {
        WOF_1_0,
        WOF_1_1,
        WOF_1_1_badNamespace,
        WOF_1_0_Old,
        SOS_1_1,
        SOS_2_0,
        UNKNOWN
    }

    public class WsdlUtilities
    {
        const string WOF11Namespace = "http://www.cuahsi.org/his/1.1/ws/";
        const string WOF10Namespace = "http://www.cuahsi.org/his/1.0/ws/";

        const string WaterML11Namespace = "http://www.cuahsi.org/waterML/1.1/";
        const string WaterML10Namespace = "http://www.cuahsi.org/waterML/1.0/";

        public static ServiceTypeEnum ServiceTypeFromWsdlUrl(string WSDLUrl)
        {
            Uri url = new Uri(WSDLUrl);
            ServiceDescription myServiceDescription;
            using (WebClient client = new WebClient())
            {
                var stream = client.OpenRead(url);
                myServiceDescription = ServiceDescription.Read(stream);
            }


            return ServiceTypeFromWsdl(myServiceDescription);

        }

        public static ServiceTypeEnum ServiceTypeFromWsdlFile(string file)
        {
            var myServiceDescription =
            ServiceDescription.Read(file);

            return ServiceTypeFromWsdl(myServiceDescription);

        }

        public static ServiceTypeEnum ServiceTypeFromWsdl(ServiceDescription myServiceDescription)
        {
            ServiceTypeEnum svcType;
            switch (myServiceDescription.TargetNamespace)
            {
                case WOF11Namespace:
                    svcType = ServiceTypeEnum.WOF_1_1;
                    break;
                case WOF10Namespace:
                    svcType = CheckForWrongNamespaceWof1_1(myServiceDescription);
                    break;
                default:
                    svcType = ServiceTypeEnum.UNKNOWN;
                    break;
            }
            return svcType;

        }


        public static ServiceTypeEnum CheckForWrongNamespaceWof1_1(ServiceDescription myServiceDescription)
        {
            if (myServiceDescription.TargetNamespace.Equals(WOF11Namespace))
            {
                throw new ArgumentException("Should Be use the 1.0 namespace: " + WOF11Namespace);
            }
            var schemas = myServiceDescription.Types.Schemas;
            if ((from s in schemas
                 where s.TargetNamespace.Equals(WaterML11Namespace)
                 select s).FirstOrDefault() != null)
            {
                return ServiceTypeEnum.WOF_1_1_badNamespace;
            }
            else if ((from s in schemas
                      where s.TargetNamespace.Equals(WaterML10Namespace)
                      select s).FirstOrDefault() != null)
            {
                return ServiceTypeEnum.WOF_1_0;
            }
            else
            {return ServiceTypeEnum.UNKNOWN;
            }

            
        }
    }
}
