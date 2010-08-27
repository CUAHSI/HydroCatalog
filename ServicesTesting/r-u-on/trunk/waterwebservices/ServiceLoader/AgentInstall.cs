using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Cuahsi.His.Ruon.SMan;
using Ruon;

namespace Cuahsi.His.Ruon
{
    internal class AgentInstall
    {
        private static string ProgramFiles()
        {
            return System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        }
        private static string ExtractFile(string path)
        {
            return path.Substring(path.LastIndexOf('\\') + 1);
        }
        private static string ExtractDir(string path)
        {
            return path.Substring(0, path.LastIndexOf('\\'));
        }
        private static void DirCopy(string src, string dst)
        {
            Directory.CreateDirectory(dst);

            foreach (string file in Directory.GetFiles(src))
            {
                File.Copy(file, dst + "\\" + ExtractFile(file), true);
            }

            foreach (string dir in Directory.GetDirectories(src))
            {
                DirCopy(dir, dst + "\\" + ExtractFile(dir));
            }
        }

        private string id;
        private string name;
        private string description;

        internal AgentInstall()
        {
            AgentAttributes attr = AgentFactory.FindAttributes();
            this.id = attr.Id;
            this.name = attr.Name;
            this.description = attr.Description;
        }
        internal void Install()
        {
            ServiceManager sman = new ServiceManager();
            try
            {
                Install(sman);
            }
            finally
            {
                sman.Dispose();
            }
        }
        internal void Uninstall()
        {
            SpawnRemover();
            ServiceManager sman = new ServiceManager();
            try
            {
                Service service = sman.OpenService(id);
                try
                {
                    service.Delete();
                    service.TryStop();
                }
                finally
                {
                    service.Dispose();
                }
            }
            finally
            {
                sman.Dispose();
            }
            
        }

        private void SpawnRemover()
        {
            string tmpdir = Path.GetTempPath();
            string batfname = tmpdir + "runinst.bat";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@echo off\n");
            sb.AppendFormat("echo Uninstalling R-U-ON agent {0} ...\n", name);
            sb.AppendFormat("ping -w 1000 -n 10 127.0.0.1 > NUL\n");
            sb.AppendFormat("rmdir /q /s \"{0}\"\n", ExtractDir(Application.ExecutablePath));
            sb.AppendFormat("echo Done.\n");
            sb.AppendFormat("ping -w 1000 -n 2 127.0.0.1 > NUL\n");
            sb.AppendFormat("del \"{0}\"\n", batfname);

            StreamWriter fs = new StreamWriter(batfname, false);
            try
            {
                fs.Write(sb.ToString());
            }
            finally
            {
                fs.Dispose();
            }

            Directory.SetCurrentDirectory(tmpdir);
            Process p = Process.Start(batfname);
            p.Dispose();
        }
        private void Install(ServiceManager sman)
        {
            try
            {
                Service s = sman.OpenService(id);
                try
                {
                    s.TryStop();
                    int i=10;
                    while (i>0)
                    {
                        try
                        {
                            InstallFiles();
                            i = 0;
                        }
                        catch (Exception)
                        {
                            if (i-- > 0)
                            {
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                    
                    s.Start();
                }
                finally
                {
                    s.Dispose();
                }
            }
            catch (Exception)
            {
                // I assume serice is not there
                CreateService(sman, InstallFiles());
            }
        }
        private void CreateService(ServiceManager sman, string exepath)
        {
            Service s = sman.CreateService(id, exepath+" service", name, description);
            try
            {
                s.Start();
            }
            finally
            {
                s.Dispose();
            }
        }
        private string InstallFiles()
        {
            string dstdir = ProgramFiles() + "\\" + id;
            DirCopy(ExtractDir(Application.ExecutablePath), dstdir);

            return dstdir + "\\" + ExtractFile(Application.ExecutablePath);
        }
        internal static void Upgrade(byte[] image)
        {
            string newfile = ExtractDir(Application.ExecutablePath) + "\\upgrade.exe";
            FileStream fs = new FileStream(newfile, FileMode.Create);
            fs.Write(image, 0, image.Length);
            Process p = Process.Start(newfile);
            p.Dispose();
        }
    }
}
