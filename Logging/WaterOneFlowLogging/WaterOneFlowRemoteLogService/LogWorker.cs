using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Text;

namespace WaterOneFlowRemoteLogService
{
    class LogWorker
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private System.Threading.Thread m_thread;
        private Boolean m_MustStop;
        private Random m_Random = new Random(DateTime.Now.Millisecond);

        public void StopWork()
        {
            m_MustStop = true;
            if (m_thread != null)
            {
                if (!m_thread.Join(100)) m_thread.Abort();
            }

        }

        public void DoWork()
        {

            // Configure remoting. This loads the TCP channel as specified in the .config file.
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            // Publish the remote logging server. This is done using the log4net plugin.
            log4net.LogManager.GetRepository().PluginMap.Add(new log4net.Plugin.RemoteLoggingServerPlugin("LoggingSink"));
            if (log.IsInfoEnabled) log.Info("Application [RemotingServer] Started");

            m_thread = System.Threading.Thread.CurrentThread;
            int i = m_Random.Next();
            while (!m_MustStop)
            {
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
