using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cuahsi.wof.ruon;
using Ruon;


namespace cuahsi.wof.ruon
{
    public partial class MontiorWindow : Form
    {
        private WaterWebServicesAgent agent = null;
        private AgentParams _agentParams ;
        private int originalMontiorInterval = 600;

        private ServerList servers;

        public MontiorWindow()
        {
            InitializeComponent();
            RuonResourceChanged += new EventHandler(this.OnResourceUpdateEvent);
            
            agent = new WaterWebServicesAgent(null);
            agent.UpdatedStatus += OnAgentStatusUpdate;
            originalMontiorInterval = agent.MonitorIntervalSec;
            agent.MonitorIntervalSec = -1;
      
           //resorrces = agent.Configuration.ManagedResources;
           //ServerListGrid.DataSource = resorrces; 
            RuonResourceChanged(this, null); // trigger a resource load

            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            Status.Text = "Ready";
            SetPictures();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Status.Text = "run completed";
        }

        protected override void OnClosed(EventArgs e)
        {
            agent.MonitorIntervalSec = originalMontiorInterval;
            base.OnClosed(e);
        }

      
        private void SetPictures()
        {
            return;
            //  throw new NotImplementedException();
        }
      

        public event EventHandler RuonResourceChanged;

        private void OnResourceUpdateEvent(object sender, EventArgs e)
        {
            servers =new ServerList(agent.Configuration.ManagedResources);

            serverListBindingSource.DataSource = servers;
            ServerListGrid.Refresh();
        }

        private void OnAgentStatusUpdate(object sender, EventArgs e)
        {
            Status.Text = ((WaterWebServicesAgent) sender).AgentStatus;

        }
        private void hisCentralServerListBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            AgentParams ap = new AgentParams();
            ap.Resources = servers.AsAgentResource();
            agent.SetParameters(ap);
        }

        private void btn_executeMonitor_Click(object sender, EventArgs e)
        {
             Status.Text = "Running Monitors"; 
            backgroundWorker1.RunWorkerAsync();
            
        }

        private event EventHandler MontiorDone;
        private void runMonitorDone (object sender, EventArgs e)
        {
          
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
 
            agent.Monitor(servers.AsResource());

        }
    }
  
}
