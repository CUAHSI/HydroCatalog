using System;
using System.Collections.Generic;
using System.Text;

namespace Ruon
{
    /// <summary>
    /// An interface used to get notifications on uninstall and upgrade by the issuing process
    /// </summary>
    public interface IServiceProcess
    {
        /// <summary>
        /// unistall has been reqeusted
        /// </summary>
        void Uninstall();
        /// <summary>
        /// An upgrade has been requested
        /// </summary>
        /// <param name="buff">The image of the new version</param>
        void Upgrade(byte[] buff);
        /// <summary>
        /// Log the message
        /// </summary>
        /// <param name="message">The message</param>
        void Log(string message);
    }

    /// <summary>
    /// Use ServiceAgent to create an Agent that will be launched as a service.
    /// The ServiceLoader will only load descendants of this class.
    /// This class takes care of the Uninstall method.<br/>
    /// <br/>
    /// The constructor of the subclassed Agent should only contain the IServiceProcess paramter
    /// The rest should be populated and not recevied as arguments.<br/>
    /// See ServiceAgentSample for an example on how to create a ServiceLoader compatible Agent
    /// </summary>
    public class ServiceAgent:Agent
    {
        /// <summary>
        /// Class constructor specifying the Agent's details
        /// </summary>
        /// <param name="agentType">The agent's type. This name will be displayed as the agent type in the management screen.</param>
        /// <param name="agentVersion">The agent's version.</param>
        /// <param name="accountId">The secret account id (taken from account settings page)</param>
        /// <param name="monitorIntervalSec">Number of seconds between each call to Monitor() where 
        /// specific monitoring routines should be performed. Monitor is not called immidiatly. Specify -1 if 
        /// you do not want to use the Monitor method at all.</param>
        /// <param name="proxyUser">If there is a proxy and it requries a user name, you would specify it here. Other wise a null is expected</param>
        /// <param name="proxyPassword">If there is a proxy and it requries a password, you would specify it here. Other wise a null is expected</param>
        /// <param name="serviceProcess">Will be passed by the ServiceLoader to the subclassing agent</param>
        public ServiceAgent(string agentType, string agentVersion, string accountId, int monitorIntervalSec, string proxyUser, string proxyPassword, IServiceProcess serviceProcess)
            :base(agentType, agentVersion, accountId, monitorIntervalSec, proxyUser, proxyPassword)
        {
            this.serviceProcess = serviceProcess;
        }

        /// <summary>
        /// internal protected
        /// </summary>
        internal protected IServiceProcess serviceProcess;
        /// <summary>
        /// Uninstall
        /// </summary>
        protected override void Uninstall()
        {
            serviceProcess.Uninstall();
        }
        /// <summary>
        /// Letting the wrapping service log the message
        /// </summary>
        /// <param name="message"></param>
        protected override void Log(string message)
        {
            serviceProcess.Log(message);
        }
    }
}
