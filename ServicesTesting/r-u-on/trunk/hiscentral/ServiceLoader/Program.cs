 using System.ServiceProcess;
using System;
using System.IO;
using System.Windows.Forms;

namespace Cuahsi.His.Ruon
{
    static class Program
    {
        static void Main(string [] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Install();
                }
                else
                {
                    if (args[0] == "service")
                    {
                        Service();
                    }
                    else if (args[0] == "install")
                    {
                        Install();
                        MessageBox.Show("Agent Installed successfully\r\nSee EventLog for trouble-shooting", "R-U-ON Agent", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (args[0] == "uninstall")
                    {
                        Uninstall();
                    }
                    else
                    {
                        Help();
                    }
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
                SeriousHelp();
                MessageBox.Show(e.Message, "R-U-ON Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void SeriousHelp()
        {
            Console.Out.WriteLine();
            Console.Out.WriteLine("For this process to work it has to have a .dll in the same directory");
            Console.Out.WriteLine("that contains the actual agent code.");
            Console.Out.WriteLine("To create a compatible agent you shoud subclass ServiceAgent and use");
            Console.Out.WriteLine("AgentAttributes to identify it as your Agent class");
            Console.Out.WriteLine("See the ServiceAgentSample project for an example on how to create");
            Console.Out.WriteLine("a compatible agent");
        }
        private static void Help()
        {
            string agentname = AgentFactory.FindAttributes().Name;
            string agentexe = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            //AgentAttributes att = 
            //att.

            Console.Out.WriteLine(agentname);
            Console.Out.WriteLine("Usage: "+agentexe+" [install|uninstall|service]");
            Console.Out.WriteLine("   no arguments/install: Install the agent and run it");
            Console.Out.WriteLine("   uninstall: Uninstall the agent");
            Console.Out.WriteLine("   service: Runs the process in service mode. Do not run directly");
        }
        private static void Uninstall()
        {
            AgentInstall install = new AgentInstall();
            install.Uninstall();
            Console.Out.WriteLine("Agent uninstalled");
        }
        private static void Install()
        {
            AgentInstall install = new AgentInstall();
            install.Install();
            Console.Out.WriteLine("Installation completed");
        }
        private static void Service()
        {
            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[] { new TheService() };
            ServiceBase.Run(ServicesToRun);
        }
    }
}