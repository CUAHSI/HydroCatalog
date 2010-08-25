using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Cuahsi.His.Ruon
{
    public partial class HisCentralMontiorWindow : Form
    {
        private HISCentralAgent agent = null;

        public HisCentralMontiorWindow()
        {
            InitializeComponent();
            Status.Text = "Ready";
            SetPictures();
        }

       

        private void ToggleAgent()
        {
            try
            {
                if (agent == null)
                {
                    agent = new HISCentralAgent(null); // if i can do this, we have an installed agent
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
