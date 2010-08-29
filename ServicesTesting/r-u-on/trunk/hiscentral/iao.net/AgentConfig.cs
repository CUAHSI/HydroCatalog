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
    /// This object is used to get and set Agent configuration.<br/>
    /// <br/>
    /// Call Get() and Set() to get and set values from the local registry or from
    /// user input in the Agent Page.<br/>
    /// Call MetaConfig to tell the server what parameters are expected from the user.<br/>
    /// In case the value is available both from the user and as a result of a Set()
    /// call, the user input will take precedence.
    /// </summary>
    public class AgentConfig
    {
        /// <summary>
        /// The possible types of a variable
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// String
            /// </summary>
            String,
            /// <summary>
            /// Integer
            /// </summary>
            Integer,
            /// <summary>
            /// Boolean
            /// </summary>
            Boolean
        } ;

        /// <summary>
        /// Class used to indicate the meta data of a variable.
        /// </summary>
        public class MetaVar
        {
            /// <summary>
            /// Constructor 
            /// </summary>
            /// <param name="name">The name of the variable. Should be a valid XML tag name.
            /// Underscores ("_") will be displayed to the user as spaces.</param>
            /// <param name="type">The type of the variable</param>
            /// <param name="defaultValue">The default value of the variable</param>
            public MetaVar(string name, AgentConfig.Type type, string defaultValue)
                : this(name, type, defaultValue, false)
            {
            }

            /// <summary>
            /// Constructor 
            /// </summary>
            /// <param name="name">The name of the variable</param>
            /// <param name="type">The type of the variable</param>
            /// <param name="defaultValue">The default value of the variable</param>
            /// <param name="secret">Should the entry be hidden on the screen</param>
            public MetaVar(string name, AgentConfig.Type type, string defaultValue, bool secret)
            {
                this.name = name;
                this.type = type;
                this.defaultValue = defaultValue;
                this.secret = secret;
            }

            #region privateParts

            private string name;
            private AgentConfig.Type type;
            private string defaultValue;
            private bool secret;

            internal string Tag()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<param name=\"{0}\" type=\"{1}\" default=\"{2}\" secret=\"secret\"/>",
                                name, type, defaultValue, secret);
                return sb.ToString();
            }

            #endregion
        }

        /// <summary>
        /// Access the Agent's configuration. 
        /// When getting a value, the method looks for the value first in the user config than in the local
        /// registry.
        /// When setting a value, it is stored in the local registry.
        /// </summary>
        /// <param name="key">Name of the variable</param>
        /// <returns>The value of the variable or null if not found</returns>
        public string this[string key]
        {
            get
            {
                if (userConfig != null)
                {
                    if (userConfig.ContainsKey(key))
                    {
                        return userConfig[key];
                    }
                }
                return RegGet(key, agentType);
            }
            set { RegSet(key, value); }
        }

        /// <summary>
        /// Indicate that the agent expects user configuration and specifies its structure
        /// </summary>
        /// <param name="agent">Configuration values for the agent level. Specify null if there is no
        /// agent level configuration.</param>
        /// <param name="resource">Managed resoruce configuration values. Managed resoruces is a list
        /// of entities the agent manages (such as Hosts, Processes, Profiles, etc.). Each resource
        /// has its own values.
        /// </param>
        public void MetaConfig(MetaVar[] agent, MetaVar[] resource)
        {
            this.agentMetaConfig = agent;
            this.resourceMetaConfig = resource;
            if (agent != null || resource != null)
            {
                this.agent.LoadConfig();
            }
        }

        /// <summary>
        /// Get the list of user configured managed resources. Each entry is a map
        /// containing the variables the user entered.
        /// </summary>
        public Dictionary<string, string>[] ManagedResources
        {
            get
            {
                if (managedResources == null)
                {
                    return null;
                }
                return managedResources.ToArray();
            }
        }

        #region private_parts

        private static RegistryKey regBase = Registry.LocalMachine;
        private static string regSoftware = "SOFTWARE";
        private static string regRuon = regSoftware + "\\R-U-ON";
        private static string regAgent = regRuon + "\\Agents";

        private Agent agent;
        private string agentType;
        private MetaVar[] agentMetaConfig;
        private MetaVar[] resourceMetaConfig;
        private List<Dictionary<string, string>> managedResources = null;
        private Dictionary<string, string> userConfig = null;

        internal AgentConfig(string agentType, Agent agent)
        {
            this.agentType = agentType;
            this.agent = agent;
        }

        private static string RegGetAtPath(string path, string key)
        {
            RegistryKey reg = regBase.OpenSubKey(path);
            if (reg == null)
            {
                return null;
            }
            try
            {
                return (string) reg.GetValue(key);
            }
            finally
            {
                reg.Close();
            }
        }

        internal static string RegGet(string key, string agentType)
        {
            string value = RegGetAtPath(regAgent + "\\" + agentType, key);
            if (value == null)
            {
                value = RegGetAtPath(regAgent, key);
            }
            return value;
        }


        private void RegSet(string key, string value)
        {
            RegistryKey reg = regBase.CreateSubKey(regAgent + "\\" + agentType);
            try
            {
                reg.SetValue(key, value);
            }
            finally
            {
                reg.Close();
            }
        }

        internal void Clean()
        {
            regBase.DeleteSubKeyTree(regAgent + "\\" + agentType);
            if (Clean(regAgent))
            {
                Clean(regRuon);
            }
        }

        private bool Clean(string subKey)
        {
            RegistryKey reg = regBase.OpenSubKey(subKey);
            try
            {
                if (reg.ValueCount + reg.SubKeyCount == 0)
                {
                    regBase.DeleteSubKeyTree(subKey);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                reg.Close();
            }
        }

        internal string Request()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<fetchconfig>");
            sb.Append(Request("agent", agentMetaConfig));
            sb.Append(Request("resources", resourceMetaConfig));
            sb.Append("</fetchconfig>");
            return sb.ToString();
        }

        private string Request(string p, MetaVar[] meta)
        {
            if (meta != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<{0}>", p);
                foreach (MetaVar m in meta)
                {
                    sb.Append(m.Tag());
                }
                sb.AppendFormat("</{0}>", p);
                return sb.ToString();
            }
            else
            {
                return "";
            }
        }

        internal void UserConfig(Iaop.Result result)
        {
            if (result.Is("config"))
            {
                Dictionary<string, string> newConfig = new Dictionary<string, string>();
                foreach (XmlNode node in result.BaseNode.ChildNodes[0].ChildNodes)
                {
                    if (node.Name == "resources")
                    {
                        LoadResources(node);
                    }
                    else
                    {
                        newConfig.Add(node.Name, node.InnerText);
                    }
                }
                userConfig = newConfig;
            }
            else
            {
                throw new IAOException("UserConfig: illigal result" + result);
            }
        }

        private void LoadResources(XmlNode node)
        {
            List<Dictionary<string, string>> newResources = new List<Dictionary<string, string>>();
            foreach (XmlNode n in node.ChildNodes)
            {
                Dictionary<string, string> resource = new Dictionary<string, string>();
                foreach (XmlNode nn in n.ChildNodes)
                {
                    resource.Add(nn.Name, nn.InnerText);
                }
                newResources.Add(resource);
            }

            managedResources = newResources;
        }

        #endregion
    }
}