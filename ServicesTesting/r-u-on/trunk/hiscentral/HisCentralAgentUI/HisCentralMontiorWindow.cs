using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ruon;


namespace Cuahsi.His.Ruon
{
    [System.Diagnostics.DebuggerDisplay("HISCentral")]
    public partial class HisCentralMontiorWindow : Form
    {
        private HISCentralAgent agent = null;
        private AgentParams _agentParams;
        private int originalMontiorInterval = 600;

        private HisCentralServerList servers;

        public HisCentralMontiorWindow()
        {
            InitializeComponent();
            Status.Text = "Ready";
            RuonResourceChanged += new EventHandler(this.OnResourceUpdateEvent); 
            
            agent = new HISCentralAgent(null);
            agent.MonitorIntervalSec = -1;
            RuonResourceChanged(this, null);
        }

       

       

       

        public event EventHandler RuonResourceChanged;

        private void OnResourceUpdateEvent(object sender, EventArgs e)
        {
            servers = new HisCentralServerList(agent.Configuration.ManagedResources);

            hisCentralServerListBindingSource.DataSource = servers;
            dataGridView1.Refresh();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Status.Text = "run completed";
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            agent.Monitor(servers.AsResource());

        }

        private void executeMonitor_Click(object sender, EventArgs e)
        {
       
             Status.Text = "Running Monitors"; 
            backgroundWorker1.RunWorkerAsync();
            
        
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            AgentParams ap = new AgentParams();
            ap.Resources = servers.AsAgentResource();
            agent.SetParameters(ap);
        }
    }
}
