// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Collections.Generic;
using System.Text;

namespace Ruon
{
    /// <summary>
    /// This class should be used when you want to transition your agent to be downloaded from the R-U-ON server.<br/>
    /// During the development and testing phase, you should use the Agent or ServiceAgent class. After it is ready and it has
    /// been decided to upload the agent to the R-U-ON site all that is needed is changing the parent class
    /// from Agent to SharedAgent.
    /// <br/><br/>
    /// A shared agent is downloaded from the R-U-ON site and is tightly integrated with the R-U-ON web application.
    /// It can be automatically upgraded and can be configured by the R-U-ON system for proxy settings and account id 
    /// (embedded configuration variables are added to the agent during the download process).
    /// Look at our agent publishing program to see how you can make your agent an integral part
    /// of the R-U-ON system.
    /// <br/><br/>
    /// This class is not yet implemented.
    /// </summary>
    public abstract class SharedAgent : ServiceAgent
    {
        /// <summary>
        /// Class Constructor 
        /// </summary>
        /// <param name="agentType">Agent type</param>
        /// <param name="agentVersion">Agent version</param>
        /// <param name="monitorIntervalMili">Number of miliseconds between each call to Monitor() where 
        /// specific monitoring routines should be performed. Monitor is not called immidiatly. Specify -1 if 
        /// you do not want to use the Monitor method at all.</param>
        /// <param name="proxyUser">If there is a proxy and it requries a user name, you would specify it here. Other wise a null is expected</param>
        /// <param name="proxyPassword">If there is a proxy and it requries a password, you would specify it here. Other wise a null is expected</param>
        /// <param name="serviceProcess">The IServiceParam is passed to the subclassing agent by the ServiceLoader</param>
        public SharedAgent(string agentType, string agentVersion, int monitorIntervalMili, string proxyUser,
                           string proxyPassword, IServiceProcess serviceProcess)
            : base(
                agentType, agentVersion, GetEmbeddedVariable("CUSTOMER_ID"), monitorIntervalMili, proxyUser,
                proxyPassword, serviceProcess)
        {
        }

        /// <summary>
        /// This method returns variables that were embedded in the agent during the dowload process.
        ///  The method will return null if the variable name is not found.
        /// </summary>
        /// <param name="name">Name of the varible</param>
        /// <returns>Value of the variable</returns>
        public static String GetEmbeddedVariable(String name)
        {
            string lookfor = "<NAME/>" + name + "<VALUE/>";
            int start = embeddedvariables.IndexOf(lookfor);
            if (start < 0)
            {
                return null;
            }
            start += lookfor.Length;

            int end = embeddedvariables.IndexOf("<END/>", start);
            if (end < 0)
            {
                return null;
            }
            return embeddedvariables.Substring(start, end - start);
        }

        private static string embeddedvariables =
            "!!!EMBEDDED_VARIABLE_NOT_CONFIGURED!!!@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ENDOFBUFF";

        internal override void ActOn(Iaop.Directive d)
        {
            if (d.verb == Iaop.Directive.Verb.Upgrade)
            {
                GetBinary();
            }
            else
            {
                base.ActOn(d);
            }
        }

        private void GetBinary()
        {
            Iaop.Result result = iaop.Request("<getbinary />");
            if (!result.Is("binary"))
            {
                throw new IAOException("GetBinary: Illegal result");
            }

            string auth = GetEmbeddedVariable("AUTHENTIC_TAG");
            if (auth == null)
            {
                throw new IAOException("AUTHENTIC_TAG not embedded");
            }

            if (result.BaseNode.Attributes["authentic"].InnerText != auth)
            {
                throw new IAOException("CRITICAL: Binary not authentic. Might be an external attack.");
            }

            Base64Binary(result.BaseNode.InnerText);
        }

        private void Base64Binary(string bin64)
        {
            byte[] buff = System.Convert.FromBase64String(bin64);
            serviceProcess.Upgrade(buff);
        }
    }
}