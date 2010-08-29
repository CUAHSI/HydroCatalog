// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Ruon
{
    /// <summary>
    /// This is a simple agent implementation intented
    /// to use as COM object for easy access to scripting languages
    /// and entry level agents. It gives the developer significantly less
    /// control but is useful for reporting alarms from within a script, application, etc).
    /// <br/><br/>
    /// To make this class available as a COM object run "regasm iao.net.dll".<br></br>
    /// See simplesample.htm for an example of how to use the object.
    /// </summary>
    //[ClassInterface(ClassInterfaceType.None)]
    //[Guid("8D24FB64-5E39-41d4-B0DB-B8A28A92E85B")]
    public class SimpleAgent : ISimpleAgent
    {
        private string agentType = null;
        private string accountId = null;
        private Agent agent = null;
        private string lastError;

        private List<IAlarm> toList(IAlarm a)
        {
            List<IAlarm> list = new List<IAlarm>(1);
            if (a != null)
            {
                list.Add(a);
            }
            return list;
        }

        private bool Report(IAlarm alarm)
        {
            try
            {
                if (agent == null)
                {
                    throw new Exception("Agent not initialized");
                }
                agent.ReportAlarms(toList(alarm), alarm != null);
                return true;
            }
            catch (Exception e)
            {
                SetError(e);
                return false;
            }
        }

        private string proxyUser = null;
        private string proxyPassword = null;

        /// <summary>
        /// Starts the agent
        /// </summary>
        /// <param name="agentType">The name of the agent type</param>
        /// <param name="accountId">The account secret id (taken from the settings page)</param>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        public bool Start(string agentType, string accountId)
        {
            try
            {
                this.agentType = agentType;
                this.accountId = accountId;
                agent = new SimpleAgentImp(agentType, this, accountId, proxyUser, proxyPassword);
                return true;
            }
            catch (Exception e)
            {
                agent = null;
                SetError(e);
                return false;
            }
        }

        /// <summary>
        /// Report an Alarm
        /// </summary>
        /// <param name="resource">The resource that is failing</param>
        /// <param name="id">The unique "alarm type" identifier </param>
        /// <param name="description">The alarm description</param>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        public bool Alarm(string resource, string id, string description)
        {
            return Report(new Alarm(resource, id, AlarmSeverity.Major, description));
        }


        /// <summary>
        /// Clear an Alarm (identified by the combination of resource and id)
        /// </summary>
        /// <param name="resource">The resource that is failing</param>
        /// <param name="id">The unique "alarm type" identifier </param>
        /// <param name="description">The alarm description</param>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        public bool Clear(string resource, string id, string description)
        {
            return Report(new Clear(resource, id, description));
        }

        /// <summary>
        /// Clear all alarms for this agent
        /// </summary>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        public bool ClearAll()
        {
            return Report(null);
        }

        /// <summary>
        /// Report an Event 
        /// </summary>
        /// <param name="resource">The resource that is failing</param>
        /// <param name="id">The unique "alarm type" identifier </param>
        /// <param name="description">The alarm description</param>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        public bool Event(string resource, string id, string description)
        {
            return Report(new Event(resource, id, AlarmSeverity.Major, description));
        }

        internal void Uninstall()
        {
            agent.Dispose();
            agent = null;
        }

        /// <summary>
        /// Return the description of the last error.
        /// </summary>
        public string LastError
        {
            get { return lastError; }
        }

        /// <summary>
        /// User name to use for proxy server
        /// </summary>
        public string ProxyUser
        {
            get { return proxyUser; }
            set { proxyUser = value; }
        }

        /// <summary>
        /// Password to use for proxy server
        /// </summary>
        public string ProxyPassword
        {
            get { return proxyPassword; }
            set { proxyPassword = value; }
        }

        private void SetError(Exception e)
        {
            lastError = e.Message;
        }


        /// <summary>
        /// Dispose of internal timers. Highly desirable to call this method when the object is no longer needed.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="includeManagedResources"></param>
        protected virtual void Dispose(bool includeManagedResources)
        {
            if (includeManagedResources)
            {
                agent.Dispose();
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~SimpleAgent()
        {
            Dispose(false);
        }
    }
}