// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace Ruon
{
    internal class Iaop
    {
        private class ProxySettings
        {
            public string url;
            public string username;
            public string password;
            public string domain;
            public string authType;
        }


        private string agentType;
        private string agentVersion;
        private string id = null;
        private int iteration = 0;
        private DateTime born = DateTime.Now;
        private object mutex = new object();
        private ProxySettings proxySettings;
        private string iaopUrl;


        internal Iaop(string agentType, string agentVersion, bool ssl)
        {
            this.agentType = agentType;
            this.agentVersion = agentVersion;
            iaopUrl = (ssl ? "https" : "http") + "://agent.r-u-on.com/iaop1";
        }

        internal string AgentId
        {
            set { id = value; }
            get { return id; }
        }

        internal string AgentType
        {
            get { return agentType; }
        }

        internal void SetProxyCredentials(string username, string password)
        {
            proxySettings = new ProxySettings();
            proxySettings.username = username;
            proxySettings.password = password;
        }

        internal void SetProxySettings(string url, string username, string password, string domain, string authType)
        {
            proxySettings = new ProxySettings();
            proxySettings.url = url;
            proxySettings.username = username;
            proxySettings.password = password;
            proxySettings.domain = domain;
            proxySettings.authType = authType;
        }

        private bool isSet(string s)
        {
            return s != null && s != "";
        }

        private NetworkCredential CreateNetworkCredentials()
        {
            return isSet(proxySettings.domain)
                       ? new NetworkCredential(proxySettings.username, proxySettings.password, proxySettings.domain)
                       : new NetworkCredential(proxySettings.username, proxySettings.password);
        }


        private WebProxy CreateProxy()
        {
            Uri proxyUri = new Uri(proxySettings.url);
            WebProxy proxy = new WebProxy(proxyUri);
            proxy.UseDefaultCredentials = false;
            if (isSet(proxySettings.username))
            {
                CredentialCache credetialCache = new CredentialCache();
                credetialCache.Add(proxyUri, isSet(proxySettings.authType) ? proxySettings.authType : "Basic",
                                   CreateNetworkCredentials());
                proxy.Credentials = credetialCache;
            }
            return proxy;
        }

        internal Result Request(string innerRequest)
        {
            lock (mutex)
            {
                if (id == null)
                {
                    throw new IAOException("Id not specified");
                }

#if RUONDEV
                WebRequest req = WebRequest.Create("http://192.168.0.200/iaop1");
#else
                WebRequest req = WebRequest.Create(iaopUrl);
#endif
                if (proxySettings != null)
                {
                    if (isSet(proxySettings.url))
                    {
                        req.Proxy = CreateProxy();
                    }
                    else
                    {
                        req.Proxy.Credentials = CreateNetworkCredentials();
                    }
                }
                else
                {
                    req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }

                req.Method = "POST";

                string content = BuildRequest(innerRequest);
                req.ContentLength = content.Length;
                Stream s = req.GetRequestStream();
                try
                {
                    byte[] b = Encoding.ASCII.GetBytes(content);
                    s.Write(b, 0, b.Length);
                }
                finally
                {
                    s.Close();
                }

                WebResponse resp = req.GetResponse();
                try
                {
                    //byte[] buff = new byte[1024];
                    //resp.GetResponseStream().Read(buff, 0, 1024);

                    XmlDocument doc = new XmlDocument();
                    doc.Load(resp.GetResponseStream());
                    return new Result(doc);
                }
                finally
                {
                    resp.Close();
                }
            }
        }

        internal void iterate()
        {
            lock (mutex)
            {
                ++iteration;
            }
        }

        private string pair(string name, string value)
        {
            return new StringBuilder().Append(" ").Append(name).Append("=\"").Append(value).Append("\"").ToString();
        }

        private string uptime()
        {
            TimeSpan delta = DateTime.Now - born;
            return Math.Round(delta.TotalSeconds).ToString();
        }

        private string time()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private string BuildRequest(string innerRequest)
        {
            string host = Dns.GetHostName();
            string ip = Dns.GetHostEntry(host).AddressList[0].ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("<iaop");
            sb.Append(pair("pver", "1"));
            sb.Append(pair("atype", agentType));
            sb.Append(pair("aver", agentVersion));
            sb.Append(pair("os", "os.win32"));
            sb.Append(pair("ip", ip));
            sb.Append(pair("host", host));
            sb.Append(pair("id", id));
            sb.Append(pair("time", time()));
            sb.Append(pair("uptime", uptime()));
            sb.Append(pair("iter", iteration.ToString()));
            sb.Append(">");
            sb.Append(innerRequest);
            sb.Append("</iaop>");
            return sb.ToString();
        }

        internal class Result
        {
            private XmlNode basenode;

            private void Error()
            {
                XmlNode n = basenode.ChildNodes[0];
                if (n != null)
                {
                    if (n.Name == "error")
                    {
                        throw new IAOException("Server response: " + n.InnerText);
                    }
                }
            }

            internal Result(XmlDocument doc)
            {
                XmlNode node = doc.ChildNodes[0];
                if ("iaop" == node.Name)
                {
                    basenode = node;
                    Error();
                }
                else
                {
                    throw new IAOException("HTTP result is not IAOP compliant");
                }
            }

            internal bool Is(string t)
            {
                XmlNode n = basenode.ChildNodes[0];
                if (n != null)
                {
                    return n.Name == t;
                }
                else
                {
                    return false;
                }
            }

            internal string GetValue()
            {
                XmlNode n = basenode.ChildNodes[0];
                if (n != null)
                {
                    return n.InnerText;
                }
                else
                {
                    throw new IAOException("Empty IAOP response");
                }
            }

            internal XmlNode BaseNode
            {
                get { return basenode; }
            }

            public override string ToString()
            {
                return basenode.InnerText;
            }
        }

        /// <summary>
        /// A class returned by IAmOn.ReportOn, specifying the expected agent behaviour.
        /// The directive has two parts, action and X. X changes in meaning depending
        /// on the action.
        /// If the agent does not follow the Directive, it might be declared delinquent
        /// and rejected immidiatly on contact.
        /// </summary>
        internal class Directive
        {
            /// <summary>
            /// The directive is returned to the agent code to be executed.
            /// </summary>
            internal enum Verb
            {
                /// <summary>
                /// The agent can SLEEP for X seconds.  If the agent does
                /// not make contact within the specified time, it may be declared
                /// offline. Once contact is made again the agent will be considered
                /// online again.
                /// </summary>
                Sleep,
                /// <summary>
                /// The agent is requested to die, usually because it has been declared
                /// delinquent. The reason is specified in X
                /// </summary>
                Die,
                /// <summary>
                /// The agent needs to upgrade. This will only be sent to public agents
                /// that have the ability to upgrade themselves.
                /// </summary>
                Upgrade,
                /// <summary>
                /// The agent needs to uninstall due to a user request. If the agent
                /// does not support this action it should at least stop making
                /// additional API calls
                /// </summary>
                Uninstall,
                /// <summary>
                /// Need to load configuration
                /// </summary>
                Config,
            } ;

            internal Directive(Iaop.Result result)
            {
                if (result.Is("directive"))
                {
                    string v = result.GetValue();
                    string[] ss = v.Split(new char[] {':'});
                    x = ss[1];
                    string[] nnn = {"sleep", "die", "upgrade", "uninstall", "config"};
                    for (int i = 0; i < nnn.Length; ++i)
                    {
                        if (nnn[i] == ss[0])
                        {
                            verb = (Verb) i;
                            return;
                        }
                    }
                    throw new IAOException("Unknown directive: " + v);
                }
                else
                {
                    throw new IAOException("Result is not a directive");
                }
            }

            public override string ToString()
            {
                return verb + ":" + x;
            }

            internal Verb verb;
            internal string x;
        }
    }
}