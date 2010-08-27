using System;

namespace Cuahsi.His.Ruon.SMan
{
    internal class ServiceManager:IDisposable
    {
        private int handle;

        internal ServiceManager()
        {
            handle = modAPI.OpenSCManagerA(null, null,
                     modAPI.ServiceControlManagerType.SC_MANAGER_ALL_ACCESS);
            if (handle < 1)
            {
                throw new SysException("Unable to open the Services Manager");
            }
        }
        internal Service OpenService(string name)
        {
            int service = modAPI.OpenServiceA(handle, name, modAPI.ACCESS_TYPE.SERVICE_ALL_ACCESS);
            if (service == 0)
            {
                throw new SysException("Can't open service " + name);
            }
            return new Service(service);
        }
        internal Service CreateService(string name, string path, string displayName, string description)
        {
            int service = modAPI.CreateServiceA(handle, name, displayName, modAPI.ACCESS_TYPE.SERVICE_ALL_ACCESS,
                modAPI.ServiceType.SERVICE_WIN32_OWN_PROCESS|modAPI.ServiceType.SERVICE_INTERACTIVE_PROCESS,
                modAPI.ServiceStartType.SERVICE_AUTO_START,
                modAPI.ServiceErrorControl.SERVICE_ERROR_NORMAL, path, null, 0, null, null, null);
            if (service == 0)
            {
                throw new SysException("Can't create service " + name);
            }

            modAPI.SERVICE_DESCRIPTION sd;
            sd.lpDescription = description;
            if (!modAPI.ChangeServiceConfig2A(service, modAPI.InfoLevel.SERVICE_CONFIG_DESCRIPTION, ref sd))
            {
                modAPI.CloseServiceHandle(handle);
                throw new SysException("Can't set service description");
            }

            return new Service(service);
        }
        public void Dispose()
        {
            modAPI.CloseServiceHandle(handle);
        }
    }
}
