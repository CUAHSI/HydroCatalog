using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ruon;

namespace CoffeeOn
{
    /// <summary>
    /// The dialog that let's the user set the parameter(s) they want to change.
    /// </summary>
    public partial class SetAgentParams : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SetAgentParams()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Show the dialog and return the parameters (or null if canceled)
        /// </summary>
        /// <returns></returns>
        public static AgentParams Get()
        {
            SetAgentParams sap = new SetAgentParams();
            if (sap.ShowDialog() == DialogResult.OK)
            {
                return sap.parameters;
            }
            return null;
        }

        private AgentParams parameters
        {
            get
            {
                AgentParams ap = new AgentParams();


                // The standard parameters
                if (textBox1.Text!="")
                {
                    ap.Alias = textBox1.Text;
                }
                if (textBox2.Text != "")
                {
                    ap.Group = textBox2.Text;
                }
                
                if (comboBox1.SelectedIndex != -1)
                {
                    AlarmSeverity[] sevs = { AlarmSeverity.Clear, AlarmSeverity.Minor, AlarmSeverity.Major, AlarmSeverity.Critical};
                    ap.Notif = sevs[comboBox1.SelectedIndex];
                }
                if (checkBox1.CheckState != CheckState.Indeterminate)
                {
                    ap.SuppressKeepAliveAlarms = checkBox1.Checked;
                }

                // The custom parameters
                String[] cappuccino = { "Cappuccino", "5" };
                String[] espresso = { "Espresso", "5" };

                StringBuilder sb = new StringBuilder();
                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        ap.Resources = new string[][] { cappuccino };
                        break;
                    case 1:
                        ap.Resources = new string[][] { cappuccino, espresso };
                        break;
                    case 2:
                        ap.Resources = new string[][] { espresso };
                        break;
                }

                if (checkBox2.CheckState != CheckState.Indeterminate)
                {
                    ap["Report_Low_Coffee"] = checkBox2.Checked ? "true" : "false";
                }

                return ap;
            }
        }
    }
}