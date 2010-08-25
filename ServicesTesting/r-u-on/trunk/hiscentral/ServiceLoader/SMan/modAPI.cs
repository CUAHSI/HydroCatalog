using System;
using System.Runtime.InteropServices;

namespace Cuahsi.His.Ruon.SMan
{
    internal class modAPI
    {
        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern int LockServiceDatabase(int hSCManager);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern bool UnlockServiceDatabase(int hSCManager);

        [DllImport("kernel32.dll")]
        internal static extern void CopyMemory(IntPtr pDst, SC_ACTION[] pSrc, int ByteLen);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern bool ChangeServiceConfigA(
            int hService, ServiceType dwServiceType, int dwStartType,
            int dwErrorControl, string lpBinaryPathName, string lpLoadOrderGroup,
            int lpdwTagId, string lpDependencies, string lpServiceStartName,
            string lpPassword, string lpDisplayName);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern bool ChangeServiceConfig2A(
            int hService, InfoLevel dwInfoLevel,
            [MarshalAs(UnmanagedType.Struct)] ref SERVICE_DESCRIPTION lpInfo);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern bool ChangeServiceConfig2A(
            int hService, InfoLevel dwInfoLevel,
            [MarshalAs(UnmanagedType.Struct)] ref SERVICE_FAILURE_ACTIONS lpInfo);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern int OpenServiceA(
            int hSCManager, string lpServiceName, ACCESS_TYPE dwDesiredAccess);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern int CreateServiceA(
            int hSCManager, string lpServiceName, string lpDisplayName,
            ACCESS_TYPE dwDesiredAccess, ServiceType dwServiceType,
            ServiceStartType dwStartType, ServiceErrorControl dwErrorControl, string lpBinaryPathName,
            string lpLoadOrderGroup, int lpdwTagId, string lpDependencies,
            string lpServiceStartName, string lpPassword );

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern bool DeleteService(int hService);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern int OpenSCManagerA(
            string lpMachineName, string lpDatabaseName, ServiceControlManagerType dwDesiredAccess);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern bool CloseServiceHandle(
            int hSCObject);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern bool QueryServiceConfigA(
            int hService, [MarshalAs(UnmanagedType.Struct)] ref QUERY_SERVICE_CONFIG lpServiceConfig, int cbBufSize,
            int pcbBytesNeeded);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern bool ControlService(int hSCObject, ServiceControlType control,
            [MarshalAs(UnmanagedType.Struct)] ref SERVICE_STATUS status);

        [DllImportAttribute("advapi32.dll", SetLastError=true)]
        internal static extern bool StartService(int hSCObject, int args, string [] lpServiceArgVectors);



        internal const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        internal const int GENERIC_READ = -2147483648;
        internal const int ERROR_INSUFFICIENT_BUFFER = 122;
        internal const int SERVICE_NO_CHANGE = -1;
        //internal const int SERVICE_NO_CHANGE = 0xFFFF;

        internal enum ServiceType
        {
            SERVICE_KERNEL_DRIVER = 0x1,
            SERVICE_FILE_SYSTEM_DRIVER = 0x2,
            SERVICE_WIN32_OWN_PROCESS = 0x10,
            SERVICE_WIN32_SHARE_PROCESS = 0x20,
            SERVICE_INTERACTIVE_PROCESS = 0x100,
            SERVICETYPE_NO_CHANGE = SERVICE_NO_CHANGE   
        }

        internal enum ServiceStartType : int
        {
            SERVICE_BOOT_START = 0x0,
            SERVICE_SYSTEM_START = 0x1,
            SERVICE_AUTO_START = 0x2,
            SERVICE_DEMAND_START = 0x3,
            SERVICE_DISABLED = 0x4,
            SERVICESTARTTYPE_NO_CHANGE = SERVICE_NO_CHANGE
        }

        internal enum ServiceErrorControl : int
        {
            SERVICE_ERROR_IGNORE = 0x0,
            SERVICE_ERROR_NORMAL = 0x1,
            SERVICE_ERROR_SEVERE = 0x2,
            SERVICE_ERROR_CRITICAL = 0x3,
            msidbServiceInstallErrorControlVital = 0x8000,
            SERVICEERRORCONTROL_NO_CHANGE = SERVICE_NO_CHANGE
        }

        internal enum ServiceStateRequest : int
        {
            SERVICE_ACTIVE = 0x1,
            SERVICE_INACTIVE = 0x2,
            SERVICE_STATE_ALL = (SERVICE_ACTIVE + SERVICE_INACTIVE)
        }

        internal enum ServiceControlType : int
        {
            SERVICE_CONTROL_STOP = 0x1,
            SERVICE_CONTROL_PAUSE = 0x2,
            SERVICE_CONTROL_CONTINUE = 0x3,
            SERVICE_CONTROL_INTERROGATE = 0x4,
            SERVICE_CONTROL_SHUTDOWN = 0x5,
            SERVICE_CONTROL_PARAMCHANGE = 0x6,
            SERVICE_CONTROL_NETBINDADD = 0x7,
            SERVICE_CONTROL_NETBINDREMOVE = 0x8,
            SERVICE_CONTROL_NETBINDENABLE = 0x9,
            SERVICE_CONTROL_NETBINDDISABLE = 0xA,
            SERVICE_CONTROL_DEVICEEVENT = 0xB,
            SERVICE_CONTROL_HARDWAREPROFILECHANGE = 0xC,
            SERVICE_CONTROL_POWEREVENT = 0xD,
            SERVICE_CONTROL_SESSIONCHANGE = 0xE,
        }

        internal enum ServiceState : int
        {
            SERVICE_STOPPED = 0x1,
            SERVICE_START_PENDING = 0x2,
            SERVICE_STOP_PENDING = 0x3,
            SERVICE_RUNNING = 0x4,
            SERVICE_CONTINUE_PENDING = 0x5,
            SERVICE_PAUSE_PENDING = 0x6,
            SERVICE_PAUSED = 0x7,
        }

        internal enum ServiceControlAccepted : int
        {
            SERVICE_ACCEPT_STOP = 0x1,
            SERVICE_ACCEPT_PAUSE_CONTINUE = 0x2,
            SERVICE_ACCEPT_SHUTDOWN = 0x4,
            SERVICE_ACCEPT_PARAMCHANGE = 0x8,
            SERVICE_ACCEPT_NETBINDCHANGE = 0x10,
            SERVICE_ACCEPT_HARDWAREPROFILECHANGE = 0x20,
            SERVICE_ACCEPT_POWEREVENT = 0x40,
            SERVICE_ACCEPT_SESSIONCHANGE = 0x80
        }

        internal enum ServiceControlManagerType : int
        {
            SC_MANAGER_CONNECT = 0x1,
            SC_MANAGER_CREATE_SERVICE = 0x2,
            SC_MANAGER_ENUMERATE_SERVICE = 0x4,
            SC_MANAGER_LOCK = 0x8,
            SC_MANAGER_QUERY_LOCK_STATUS = 0x10,
            SC_MANAGER_MODIFY_BOOT_CONFIG = 0x20,
            SC_MANAGER_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED + SC_MANAGER_CONNECT + SC_MANAGER_CREATE_SERVICE + SC_MANAGER_ENUMERATE_SERVICE + SC_MANAGER_LOCK + SC_MANAGER_QUERY_LOCK_STATUS + SC_MANAGER_MODIFY_BOOT_CONFIG
        }

        internal enum ACCESS_TYPE : int
        {
            SERVICE_QUERY_CONFIG = 0x1,
            SERVICE_CHANGE_CONFIG = 0x2,
            SERVICE_QUERY_STATUS = 0x4,
            SERVICE_ENUMERATE_DEPENDENTS = 0x8,
            SERVICE_START = 0x10,
            SERVICE_STOP = 0x20,
            SERVICE_PAUSE_CONTINUE = 0x40,
            SERVICE_INTERROGATE = 0x80,
            SERVICE_USER_DEFINED_CONTROL = 0x100,
            SERVICE_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED + SERVICE_QUERY_CONFIG + SERVICE_CHANGE_CONFIG + SERVICE_QUERY_STATUS + SERVICE_ENUMERATE_DEPENDENTS + SERVICE_START + SERVICE_STOP + SERVICE_PAUSE_CONTINUE + SERVICE_INTERROGATE + SERVICE_USER_DEFINED_CONTROL
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SERVICE_STATUS
        {
            internal int dwServiceType;
            internal int dwCurrentState;
            internal int dwControlsAccepted;
            internal int dwWin32ExitCode;
            internal int dwServiceSpecificExitCode;
            internal int dwCheckPoint;
            internal int dwWaitHint;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct QUERY_SERVICE_CONFIG
        {
            internal int dwServiceType;
            internal int dwStartType;
            internal int dwErrorControl;
            internal string lpBinaryPathName;
            internal string lpLoadOrderGroup;
            internal int dwTagId;
            internal string lpDependencies;
            internal string lpServiceStartName;
            internal string lpDisplayName;
        }

        internal enum SC_ACTION_TYPE : int
        {
            SC_ACTION_NONE = 0,
            SC_ACTION_RESTART = 1,
            SC_ACTION_REBOOT = 2,
            SC_ACTION_RUN_COMMAND = 3,
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SC_ACTION
        {
            internal SC_ACTION_TYPE SCActionType;
            internal int Delay;
        }

        internal enum InfoLevel : int
        {
            SERVICE_CONFIG_DESCRIPTION = 1,
            SERVICE_CONFIG_FAILURE_ACTIONS = 2
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SERVICE_DESCRIPTION
        {
            internal string lpDescription;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SERVICE_FAILURE_ACTIONS
        {
            internal int dwResetPeriod;
            internal string lpRebootMsg;
            internal string lpCommand;
            internal int cActions;
            internal int lpsaActions;
        }

        [DllImportAttribute("shell32.dll", SetLastError=true)]
        internal static extern int SHGetFolderPathA(int hwndOwner, int nFolder, int hToken, int dwFlags, ref char [] pszPath);


    }

    internal class SysException : Exception
    {
        internal SysException(string s)
            :base(s+" ["+Marshal.GetLastWin32Error()+"]")
        {
        }
    }
}