using System.ServiceProcess;
using Ruon;

namespace Cuahsi.His.Ruon
{
    internal partial class TheService : ServiceBase, IServiceProcess
    {
        private Agent agent;

        public TheService()
        {
            InitializeComponent();
            ServiceName = AgentFactory.FindAttributes().Name;
        }
        protected override void OnStart(string[] args)
        {
            agent = AgentFactory.Create(this);
        }
        protected override void OnStop()
        {
            agent.Dispose();
        }
        /// <summary>
        /// Log the message in the Event Log
        /// </summary>
        /// <param name="message">The message</param>
        public void Log(string message)
        {
            EventLog.WriteEntry(message);
        }

        /// <summary>
        /// </summary>
        public void Uninstall()
        {
            new AgentInstall().Uninstall();
        }
        /// <summary>
        /// </summary>
        /// <param name="image">binary</param>
        public void Upgrade(byte[] image)
        {
            AgentInstall.Upgrade(image);
        }
    }
}
