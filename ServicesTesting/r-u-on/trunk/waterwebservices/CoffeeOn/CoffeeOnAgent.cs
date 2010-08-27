// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Ruon;

namespace CoffeeOn
{
    /// <summary>
    /// The agent code (slightly mixed with the coffee machine code becasue they share
    /// the same window).
    /// </summary>
    public class CoffeeAgent:Agent
    {
        private bool reportedElectricityProblem = false;
        private CoffeeMachine machine;

        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountId">The account id</param>
        /// <param name="machine">Has the machine status interface but is also used for user
        /// feedback</param>
        public CoffeeAgent(String accountId, CoffeeMachine machine)
            :base("CoffeeOn", "1.0", accountId, 1, null, null)
        {
            this.machine = machine;

            Configuration.MetaConfig(
                new AgentConfig.MetaVar[]
                {
                    new AgentConfig.MetaVar("Report_Low_Coffee", AgentConfig.Type.Boolean, "true")
                }, 
                new AgentConfig.MetaVar[]
                {
                    new AgentConfig.MetaVar("Coffee_Type", AgentConfig.Type.String, "Espresso"),
                    new AgentConfig.MetaVar("MAX", AgentConfig.Type.Integer, "5")
                }
            );
            OnConfigLoaded();
        }

        /// <summary>
        /// Overriding Uninstall and doing some visual cleanup
        /// In real life this should actually remove the binary, directory and support files
        /// </summary>
        override protected void Uninstall()
        {
            // Emulating an uninstall
            machine.UninstallAgent();
        }

        /// <summary>
        /// The reaction to configuration change should be some kind of 
        /// a state re-evaluation.
        /// </summary>
        protected override void OnConfigLoaded()
        {
            // This is just to show the Resources API - it doesn't affect any actual monitoring
            StringBuilder sb = new StringBuilder();
            foreach (Dictionary<String,String> resource in Configuration.ManagedResources)
            {
                sb.Append(resource["Coffee_Type"]);
                sb.Append("=");
                sb.Append(resource["MAX"]);
                sb.Append(" ");
            }
            machine.ResourceLine = sb.ToString();
        }

        private struct AlarmConsts
        {
            internal string resource;
            internal string id;
            internal string description;
            internal AlarmSeverity severity;

            internal AlarmConsts(string resource, string id, string description, AlarmSeverity severity)
            {
                this.resource = resource;
                this.id = id;
                this.description = description;
                this.severity = severity;
            }
        }

        private AlarmConsts AlarmConstants(int state)
        {
            AlarmConsts []consts = new AlarmConsts[]{ 
                // resource, id, description, severity
                new AlarmConsts("Power",  "COFFEE_POWER", "Power is OFF",      AlarmSeverity.Critical),
                new AlarmConsts("Coffee", "COFFEE_LOW",    "Coffee is Empty",  AlarmSeverity.Major),
                new AlarmConsts("Coffee", "COFFEE_LOW",    "Coffee is at 1/3", AlarmSeverity.Minor),
                new AlarmConsts("Coffee", "COFFEE_LOW",    "Coffee is at 2/3", AlarmSeverity.Clear),
                new AlarmConsts("Coffee", "COFFEE_LOW",    "Coffee is Full",   AlarmSeverity.Clear)
            };

            AlarmConsts ret = consts[state + 1];

            if ("true" != Configuration["Report_Low_Coffee"] && ret.severity==AlarmSeverity.Minor)
            {
                ret.severity = AlarmSeverity.Clear;
            }

            return ret;
        }

        /// <summary>
        /// This code is slightly complex in order to show how alarms should be reported incrementally when
        /// there is more than one alarm possible (for instance no coffee + no electricity) or as a snapshot (!incremental), 
        /// when you know you have the full picture.
        /// For most purposes, snapshot mode is the simplest to use.
        /// </summary>
        override protected void Monitor()
        {
            try
            {
                List<IAlarm> alarms = new List<IAlarm>();
                
                // Get the state
                int state = machine.GetState();

                if (state >= 0)
                {
                    AlarmConsts alarmConsts = AlarmConstants(state);
                    if (alarmConsts.severity == AlarmSeverity.Clear) // i.e. not an alarm: clear is needed
                    {
                        alarms.Add(new Clear(alarmConsts.resource, alarmConsts.id, alarmConsts.description));
                    }
                    else
                    {
                        alarms.Add(new Alarm(alarmConsts.resource, alarmConsts.id, alarmConsts.severity, alarmConsts.description));
                    }

                    // incremental=false will make sure ELECTRICITY alarm will go down (if exists)
                    // It is okay to report every time, since ReportAlarms 
                    // will ignore if it is identical to last time (non-incremental mode only!!!)
                    ReportAlarms(alarms, false);
                    reportedElectricityProblem = false;
                }
                else
                {
                    if (!reportedElectricityProblem)
                    {
                        AlarmConsts alarmConsts = AlarmConstants(state);
                        alarms.Add(new Alarm(alarmConsts.resource, alarmConsts.id, alarmConsts.severity, alarmConsts.description));
                        ReportAlarms(alarms, true); // Incremental so we don't loose the cofee level alarms.
                        reportedElectricityProblem = true;
                    }
                }
            }
            catch (Exception ex)
            {
                machine.ReportError(ex);
            }
        }
    }
}
