// All rights reserved R-U-ON 2006
// www.r-u-on.com


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

using Ruon;

namespace CoffeeOn
{
    /// <summary>
    /// What is the fascination programmers have with coffee machines?
    /// Probably being the most accessible piece of hardware they don't understand
    /// combined with a debt of gratitude.
    /// 
    /// Anyway, this small sample program emulates a coffee machine and let's you deploy 
    /// an agent to monitor it. It demonstrates the basic steps needed to write an agent
    /// in the .net framework.
    /// 
    /// Careful: The content of the code you are about to enjoy may be hot!
    /// 
    /// www.r-u-on.com
    /// </summary>
    public partial class CoffeeMachine : Form
    {

        private int coffeestate = 0;
        private int cupstate = 0;
        private bool electricity = true;
        private CoffeeAgent agent = null;
        private bool shouldUninstall = false;
        private string resourceLine = "";

        /// <summary>
        /// The constructor
        /// </summary>
        public CoffeeMachine()
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
                    agent = new CoffeeAgent("", this); // if i can do this, we have an installed agent
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
                ReportError(ex);
            }
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            ToggleAgent();
        }
        internal void SetStatus(string s)
        {
            Status.Text = s;
        }
        internal void UninstallAgent()
        {
            // Beacuse this is not the window's thread calling
            // I have to resort to timers. Must be an easier way to do this...
            shouldUninstall = true;

        }
        internal string ResourceLine
        {
            set { resourceLine = value; }
        }
        internal void ReportError(Exception e)
        {
            MessageBox.Show(e.ToString());
            Status.Text = e.Message;
        }

        // Coffee Machine Code
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            electricity = !electricity;
            SetPictures();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (!electricity || coffeestate >= 3)
            {
                return;
            }
            coffeestate++;
            SetPictures();

            cupstate = 3;
            DrawCup();
            animationtimer.Enabled = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!electricity)
            {
                return;
            }
            coffeestate = 0;
            SetPictures();
        }
        private void animation_Tick(object sender, EventArgs e)
        {
            cupstate--;
            DrawCup();
            if (cupstate <= 0)
            {
                animationtimer.Enabled = false;
            }
        }
        private void SetPictures()
        {
            if (electricity)
            {
                pictureBox3.Image = global::CoffeeOn.Properties.Resources.plug;
            }
            else
            {
                pictureBox3.Image = global::CoffeeOn.Properties.Resources.plug_off;
            }

            switch (coffeestate)
            {
                case 0:
                    pictureBox1.Image = CoffeeOn.Properties.Resources.coffeemaker0;
                    break;
                case 1:
                    pictureBox1.Image = global::CoffeeOn.Properties.Resources.coffeemaker1;
                    break;
                case 2:
                    pictureBox1.Image = global::CoffeeOn.Properties.Resources.coffeemaker2;
                    break;
                case 3:
                    pictureBox1.Image = global::CoffeeOn.Properties.Resources.coffeemaker3;
                    break;
            }

            pictureBox2.Image = agent!=null?global::CoffeeOn.Properties.Resources.agent:global::CoffeeOn.Properties.Resources.agent_off;
            createAgentLink.Visible = !Agent.IsInstalled("CoffeeOn");
            paramLink.Visible = agent != null;
            pictureBox2.Visible = agent != null || Agent.IsInstalled("CoffeeOn");
            pictureBox9.Visible = agent != null || Agent.IsInstalled("CoffeeOn");
        }

        private void DrawCup()
        {
            switch (cupstate)
            {
                case 0:
                    pictureBox5.Image = CoffeeOn.Properties.Resources.cup0;
                    break;
                case 1:
                    pictureBox5.Image = CoffeeOn.Properties.Resources.cup1;
                    break;
                case 2:
                    pictureBox5.Image = CoffeeOn.Properties.Resources.cup2;
                    break;
                case 3:
                    pictureBox5.Image = CoffeeOn.Properties.Resources.cup3;
                    break;
            }
        }

        /// <summary>
        /// Get the coffee machine's state
        /// </summary>
        /// <returns>
        /// -1 no elictiricity (can't tell status)
        /// 3 - Full
        /// 2 - 2/3
        /// 1 - 1/3
        /// 0 - Empty
        /// </returns>
        internal int GetState()
        {
            if (!electricity)
            {
                return -1;
            }
            else
            {
                return 3 - coffeestate;
            }
        }

        private void uninstallTimer_Tick(object sender, EventArgs e)
        {
            if (label3.Text != resourceLine)
            {
                label3.Text = resourceLine;
            }
            if (shouldUninstall)
            {
                uninstallTimer.Enabled = false;
                shouldUninstall = false;
                SetStatus("Got a request to uninstall");
                createAgentLink.Visible = true;
                if (agent != null)
                {
                    agent.Dispose();
                }
                agent = null;
                SetPictures();
            }
        }

        private void paramLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs ev)
        {
            AgentParams agentParams = SetAgentParams.Get();
            if (agentParams != null)
            {
                try
                {
                    agent.SetParameters(agentParams);
                }
                catch (Exception e)
                {
                    ReportError(e);
                }
            }
        }

        private void createAgentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs ev)
        {
            try
            {
                string accountId = AccountId.Get();
                if (accountId!=null)
                {
                    agent = new CoffeeAgent(accountId, this);
                    Status.Text = "Agent installed";
                }
            }
            catch (Exception e)
            {
                ReportError(e);
            }
            SetPictures();
        }

        private void CoffeeMachine_Shown(object sender, EventArgs e)
        {
            try
            {
                if (Agent.IsInstalled("CoffeeOn"))
                {
                    agent = new CoffeeAgent("", this);
                    SetPictures();
                }
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }
    }


    // To have transparency
    class MyPictureBox : PictureBox
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorKey(Color.FromArgb(255, 255, 255), Color.FromArgb(255, 0, 255));
            e.Graphics.DrawImage(this.Image, this.ClientRectangle, 0, 0,
            this.Image.Width, this.Image.Height, GraphicsUnit.Pixel, attr);
        }
    }

}