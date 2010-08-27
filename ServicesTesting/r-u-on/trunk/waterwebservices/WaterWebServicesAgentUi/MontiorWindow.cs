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
       

        public MontiorWindow()
        {
            InitializeComponent();
            Status.Text = "Ready";
            agent = new WaterWebServicesAgent(null);

           Dictionary<string,string>[] resorrces = agent.Configuration.ManagedResources;

           ServerListGrid.DataSource = resorrces; 
            SetPictures();
        }

       

        private void ToggleAgent()
        {
            try
            {
                if (agent == null)
                {
                    agent = new WaterWebServicesAgent(null); // if i can do this, we have an installed agent
                }
                else
                {
                    agent.Dispose();
                    agent = null;
                }
                SetPictures();
            }
            catch (Exception ex)
            {
               // ReportError(ex);
            }
        }
        private void SetPictures()
        {
            return;
            //  throw new NotImplementedException();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          // Chk_AgentRun.Checked = !Chk_AgentRun.Checked;
            ToggleAgent();
            Status.Text = "Clicked";
        }
    }
}
