using System;

namespace Cuahsi.His.Ruon.SMan
{
    internal class Service:IDisposable
    {
        private int handle;
        internal Service(int handle)
        {
            this.handle = handle;
        }
        internal void Start()
        {
            if (!modAPI.StartService(handle, 0, null))
            {
                throw new SysException("Can't start service");
            }
        }
        internal void Stop()
        {
            modAPI.SERVICE_STATUS status = new modAPI.SERVICE_STATUS();
            if (!modAPI.ControlService(handle, modAPI.ServiceControlType.SERVICE_CONTROL_STOP, ref status))
            {
                throw new SysException("Can't stop service");
            }
        }
        internal bool TryStop()
        {
            try
            {
                Stop();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal void Delete()
        {
            if (!modAPI.DeleteService(handle))
            {
                throw new SysException("Service cannot be deleted");
            }
        }
        public void Dispose()
        {
            modAPI.CloseServiceHandle(handle);
        }

    }
}
