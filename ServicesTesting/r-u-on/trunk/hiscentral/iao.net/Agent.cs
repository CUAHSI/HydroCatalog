// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ruon
{
    /// <summary>
    /// The Agent class is an API to the IAOP protocol, allowing you
    /// to communicate with the R-U-ON platform.<br/>
    /// <br/>
    /// Subclass Agent and add your own logic to create a new and exciting Agent!<br/>
    /// <br/>
    /// When creating an instance the caller should pass the Agent type, version and account id. The Agent object
    /// should be created once for the lifetime of the agent. It must not be constructed each time
    /// a call is made as that will seem to the R-U-ON platform like an agent reboot.<br/>
    /// <br/>
    /// To report alarms, use the ReportAlarms() method. If you need a to use a polling mechanism, Monitor() can save 
    /// you some coding.<br/>
    /// <br/>
    /// The derived class must implement the Uninstall method. This method is called as a response to a user
    /// request to uninstall the agent. The method is expected to cleanup all traces of the agent from the system.
    /// The least that uninstall must ensure it that there are no subsequent calls to the server under the deleted
    /// agent id.
    /// <br/><br/>
    /// For information about the IAOP protcol, goto http://www.r-u-on.com/api/IAOP.pdf
    /// <br/>
    /// Version     1.13
    /// </summary>
    public abstract class Agent:IDisposable
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
        /// <param name="proxyUser">If there is a proxy and it requries a user name, you would specify it here. Other wise a null is expected. The agent
        /// will use the proxy server defined in the Ineternet Explorer connectivity options. </param>
        /// <param name="proxyPassword">If there is a proxy and it requries a password, you would specify it here. Other wise a null is expected</param>
        public Agent(string agentType, string agentVersion, string accountId, int monitorIntervalSec, string proxyUser, string proxyPassword)
        {
            this.iaop = new Iaop(agentType, agentVersion, true);
            config = new AgentConfig(agentType, this);
            if (proxyUser != null)
            {
                iaop.SetProxyCredentials(proxyUser, proxyPassword);
            }
            else
            {
                proxyUser = config["ProxyUser"];
                proxyPassword = config["ProxyPassword"];
                string proxyDomain = config["ProxyDomain"];
                string proxyAuthType = config["ProxyAuthType"];
                string proxyUrl = config["ProxyURL"];

                if (proxyUser!=null || proxyUrl!=null)
                {
                    iaop.SetProxySettings(proxyUrl, proxyUser, proxyPassword, proxyDomain, proxyAuthType);
                }
            }

            string id = config["id"];
            if (id == null)
            {
                id = Register(accountId);
                config["id"] = id;
                iaop.AgentId = id;
            }
            else
            {
                iaop.AgentId = id;
            }

            keepaliveTimer = new Timer(new TimerCallback(Keepalive),null, 30*1000, Timeout.Infinite);
            
            this.monitorIntervalSec = monitorIntervalSec;
            int mis = monitorIntervalSec>0?monitorIntervalSec*1000:monitorIntervalSec;
            sampleTimer = new System.Threading.Timer(new TimerCallback(CheckTime), null, mis, mis);
        }

        /// <summary>
        /// Override this method with the code that monitors whatever the agent is monitoring.
        /// The interval governing the call is specified in the constructor. You do not have to
        /// use this method if you would like to implement a seperate polling mechanism or if 
        /// you are working with a notification/subscription scheme.
        /// Monitor will not ba called again, until a previous call has returned.
        /// </summary>
        virtual protected void Monitor()
        {
        }

        /// <summary>
        /// This method is called after configuration has been successfuly loaded.<br/>
        /// Configuration is loaded when the agent goes up as a result of a call to Configuration.MetaConfig().<br/>
        /// After the initial configuration load, the configuration is updated every time the administrator
        /// makes a change to the configuration via the Agent page.
        /// </summary>
        virtual protected void OnConfigLoaded()
        {
        }

        /// <summary>
        /// Reports alarms to the R-U-ON server.
        /// </summary>
        /// <param name="alarms">An array of alarms, clears and events (Alarm, Clear, Event)</param>
        /// <param name="incremental"> Indicates if the call is the full list of active alarms (snapshot) or a list of
        /// alarms that should be added or deleted. In the case of a snapshot, all active alarms that are not reported
        /// in the array are implicitly supressed. 
        /// If two consecutive, non-incremental, calls to ReportAlarms have the exact same information, the call is ignored.
        /// This saves you the trouble of calculating whether you should report the alarms or not.</param>
        /// <exception cref="Ruon.IAOException">Throws an IAOException in case of failure</exception>
        public void ReportAlarms(List<IAlarm> alarms, bool incremental)
        {
            if (SameAsLast(alarms, incremental))
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<alarms incremental=\"");
            sb.Append(incremental?"true":"false");
            sb.Append("\">");
            foreach (IAlarm alarm in alarms)
            {
                sb.Append(alarm.ToString());
            }
            sb.Append("</alarms>");
            ActOn( iaop.Request(sb.ToString()) );
        }
        
        /// <summary>
        /// Set agent parameters such as Alias, Group, etc.
        /// </summary>
        /// <param name="agentParams">Use the AgentParams to set the parameters
        /// you want to change. It is not neccessary to set all the parameters.
        /// Parameters that you do not specify will retain their current value.</param>
        public void SetParameters(AgentParams agentParams)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<setparam>");
            sb.Append(agentParams.Xml());
            sb.Append("</setparam>");
            ActOn(iaop.Request(sb.ToString()));
        }

        /// <summary>
        /// The agent configuration object. <br/>
        /// It is used to get configuration input from the user and store local variables.
        /// </summary>
        public AgentConfig Configuration
        {
            get { return config; }
        }

        /// <summary>
        /// Get/Set the inerval, in seconds in which the Monitor method is called.
        /// Set to -1 to disable the timer.
        /// This also resets the counter.
        /// </summary>
        public int MonitorIntervalSec
        {
            get { return MonitorIntervalSec; }
            set
            {
                monitorIntervalSec = value;
                int mis = monitorIntervalSec > 0 ? monitorIntervalSec * 1000 : monitorIntervalSec;
                sampleTimer.Change(mis, mis);
            }
        }

        /// <summary>
        /// Checks to see if an agent of this type is already installed on this system. 
        /// If you are prompting for account id, you can use this method to avoid the prompt
        /// when the agent is already installed.
        /// </summary>
        /// <param name="agentType">The type of agent, as passed to the agent constructor</param>
        /// <returns>true if the agent is installed, false if it isn't</returns>
        public static bool IsInstalled(string agentType)
        {
            return AgentConfig.RegGet("id", agentType) != null;
        }


        /// <summary>
        /// When something needs logging Log is called. You can override it to
        /// decide what to do with the message. The default implementation is empty.
        /// </summary>
        /// <param name="message">The message</param>
        virtual protected void Log(string message)
        {
        }

        /// <summary>
        /// This method is being called when the server sends the agent an instruction to uninstall.
        /// The implementing agent should implement this method to assure that the agent is uninstalled 
        /// and that no further API calls are being made on the Agent object.
        /// </summary>
        abstract protected void Uninstall();

        /// <summary>
        /// Dispose of internal timers. Highly desirable to call this method when the object is no longer needed.
        /// </summary>
        public void Dispose() 
        {
            Dispose(true); 
            GC.SuppressFinalize(this); 
        }

        /// <summary>
        /// If a subclass needs the dispose option it should override this method.
        /// </summary>
        /// <param name="includeManagedResources">
        /// Only dispose of managed object if this parameter is true. If you disregard
        /// this you might be trying to dispose of objects that have been collected
        /// by the garbage disposer.
        /// </param>
        virtual protected void Dispose(bool includeManagedResources) 
        { 
            if (includeManagedResources)
            {
                keepaliveTimer.Dispose();
                if (sampleTimer != null)
                {
                    sampleTimer.Dispose();
                }
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~Agent()
        {
            Dispose(false);
        }

        #region privateParts
        internal Iaop iaop;
        private AgentConfig config;
        private System.Threading.Timer keepaliveTimer;
        private System.Threading.Timer sampleTimer = null;
        private int monitorIntervalSec;
        private int emergencyRetry = -1;
        private bool shouldLoadConfig = false;
        private Dictionary <String, bool> lastSnapshot = null;
        private bool insideMonitor = false;

        private string Register(string accountId)
        {
            iaop.AgentId = accountId;
            Iaop.Result r = iaop.Request("<register />");
            if (r.Is("directive"))
            {
                throw new IAOException(new Iaop.Directive(r).x);
            }
            return r.GetValue();
        }
        private void ActOn(Iaop.Result r)
        {
            Iaop.Directive d = new Iaop.Directive(r);
            iaop.iterate();
            ActOn(d);
        }
        virtual internal void ActOn(Iaop.Directive d)
        {
            switch (d.verb)
            {
                case Iaop.Directive.Verb.Die:
                    Dispose();
                    break;
                case Iaop.Directive.Verb.Uninstall:
                    config.Clean();
                    Uninstall();
                    break;
                case Iaop.Directive.Verb.Config:
                case Iaop.Directive.Verb.Sleep:
                    if (d.verb == Iaop.Directive.Verb.Config)
                    {
                        shouldLoadConfig = true;
                    }
                    int timeout = int.Parse(d.x) * 1000;
                    keepaliveTimer.Change(timeout, Timeout.Infinite);
                    break;
                default:
                    throw new IAOException("Can't an unsupported directive: " + d);
            }

            if (shouldLoadConfig)
            {
                LoadConfig();
            }
        }
        private void Keepalive(object stateInfo)
        {
            try
            {
                ActOn(iaop.Request("<keepalive />"));
                emergencyRetry = 10;
            }
            catch (Exception)
            {
                if (emergencyRetry-- < 0)
                {
                    keepaliveTimer.Change(60 * 1000, Timeout.Infinite);
                }
                else
                {
                    keepaliveTimer.Change(3 * 1000, Timeout.Infinite);
                }

            }
        }
        private void CheckTime(object stateInfo)
        {
            if (!insideMonitor)
            {
                try
                {
                    insideMonitor = true;
                    Monitor();
                }
                catch (Exception e)
                {
                    // This shouldn't really happen...
                    Log(e.ToString());
                    Console.Out.WriteLine(e);
                }
                finally
                {
                    insideMonitor = false;
                }
            }
        }
        internal void LoadConfig()
        {
            try
            {
                config.UserConfig(iaop.Request(config.Request()));
                shouldLoadConfig = false;
                OnConfigLoaded();
            }
            catch (Exception e)
            {
                Log(e.ToString());
                Console.Out.Write(e);
            }
        }
        private bool SameAsLast(List<IAlarm> alarms, bool incremental)
        {
            if (incremental)
            {
                lastSnapshot = null;
                return false;
            }
            else
            {
                Dictionary <String,bool> thisSnapshot = new Dictionary<string,bool>();
                bool delta = false;

                foreach (IAlarm ia in alarms)
                {
                    AlarmTop alarm = (AlarmTop) ia;
                    StringBuilder sb = new StringBuilder();
                    foreach (String arg in alarm.args)
                    {
                        sb.Append(arg);
                        sb.Append("|");
                    }
                    String key = sb.ToString();

                    if (lastSnapshot != null && delta==false)
                    {
                        if (lastSnapshot.ContainsKey(key))
                        {
                            lastSnapshot.Remove(key);
                        }
                        else
                        {
                            delta = true;
                        }
                    }
                    thisSnapshot[key]=true;
                }

                if (lastSnapshot == null || lastSnapshot.Count > 0)
                {
                    delta = true;
                }
                lastSnapshot = thisSnapshot;
                return !delta;
            }
        }
        #endregion
    }

    /// <summary>
    /// An exception class used to signal a failure of the IAOP protocol.
    /// </summary>
    public class IAOException : Exception
    {
        internal IAOException(string msg, Exception innerException)
            :base(msg, innerException)
        {
        }
        internal IAOException(string msg)
            :base(msg)
        {
        }
    }
}
