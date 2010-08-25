// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Xml;


namespace Ruon
{
    /// <summary>
    /// This object is used to get and set Agent parameters such as Alias, Group, etc.<br/>
    /// <br/>
    /// After settings the desired parameters (it is not neccessray to set them all) use
    /// the instance in conjunction with the Agent.SetParameter method.
    /// </summary>
    public class AgentParams
    {
        /// <summary>
        /// The agent alias, as displayed in the agent page.
        /// </summary>
        public string Alias
        {
            set
            {
                Add("alias", value);
            }
        }
        /// <summary>
        /// The agent group. Will create a new group if does not already exist.
        /// </summary>
        public string Group
        {
            set
            {
                Add("group", value);
            }
        }
        /// <summary>
        /// Minimum alarm severity for notification. If Clear is indicated, it means no notifications will be sent (none).
        /// </summary>
        public AlarmSeverity Notif
        {
            set
            {
                Add("notif", value == AlarmSeverity.Clear ? "none" : value.ToString());
            }
        }
        /// <summary>
        /// Settings this to true will suppress Agent Down, Agent Back Up and Agent Reboot Alarms for this agent
        /// </summary>
        public bool SuppressKeepAliveAlarms
        {
            set
            {
                Add("skaa", value ? "true" : "false");
            }
        }

        /// <summary>
        /// This allows the agent to set its own resource list, so it is saved on the R-U-ON server and 
        /// reflected properly in the agent page. This is useful when providing the user with an interface
        /// to edit the resource list localy.
        /// Each row in the array stands for a resource and each coloumn for one of its properies, according
        /// to the meta data supplied to the AgentConfig class.
        /// </summary>
        public string [][] Resources
        {
            set
            {
                StringBuilder sb = new StringBuilder();
                foreach (string[] resource in value)
                {
                    foreach (string attr in resource)
                    {
                        sb.Append(attr);
                        sb.Append(",");
                    }
                    sb.Length = sb.Length - 1;
                    sb.Append("\r\n");
                }
                Add("resources", sb.ToString());
            }
        }

        /// <summary>
        /// This operator allows the agent to set its own configuration parameters so they are saved in the 
        /// R-U-ON server and relected properly in the agent page. 
        /// This is useful when providing the user with an interface to edit the resource list localy.
        /// </summary>
        /// <param name="key">The name of the agent configuration variable, as passed in the Agent.Configuration.MetaConfig method</param>
        public string this[string key] { set { Add("config." + key, value); } }


        #region privateParts
        private StringBuilder sb = new StringBuilder();
        private void Add(String name, String value)
        {
            sb.Append("<").Append(name).Append(">");
            sb.Append("<![CDATA[");
            sb.Append(value);
            sb.Append("]]>");
            sb.Append("</").Append(name).Append(">");
        }
        internal string Xml()
        {
            return sb.ToString();
        }
        #endregion
    }
}
