using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Ruon;

namespace Cuahsi.His.Ruon
{
    internal class AgentFactory
    {
        internal static ServiceAgent Create(IServiceProcess serviceProcess)
        {
            
            Type t = FindType();
            ConstructorInfo ci = t.GetConstructor(new Type[] { typeof(IServiceProcess) });
            if (ci == null)
            {
                throw new Exception("Class " + t + " does not have a valid constructor");
            }
            return (ServiceAgent) ci.Invoke(new object[]{serviceProcess});
        }
        internal static AgentAttributes FindAttributes()
        {
            Type t = FindType();
            return (AgentAttributes) Attribute.GetCustomAttribute(t, typeof(AgentAttributes));
        }
        
        private static Type FindType()
        {
            foreach(Assembly asm in Assemblies())
            {
                foreach (System.Type t in asm.GetExportedTypes())
                {
                    if (t.IsSubclassOf(typeof(ServiceAgent)))
                    {
                        if (Attribute.GetCustomAttribute(t, typeof(AgentAttributes))!=null)
                        {
                            return t;
                        }
                    }
                }
            }
            throw new Exception("Cannot find a subclass of ServiceAgent that has the neccessary AgentAttributes");
        }
        private static List<Assembly> Assemblies()
        {
            List<Assembly> l = new List<Assembly>();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            foreach (string file in Directory.GetFiles(dir, "*.dll"))
            {
                try
                {
                    l.Add(Assembly.LoadFrom(file));
                }
                catch(Exception)
                {
                }
            }
            return l;
        }
    }
}
