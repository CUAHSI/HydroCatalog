using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using log4net;
using String = System.String;

/// <summary>
/// Summary description for ServiceStatistics
/// </summary>
public  class ServiceStatistics
{
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private static readonly ILog PerformanceLog = LogManager.GetLogger("PerformanceLog");
    private static  string _machineName = "UNSET";
    private static Stopwatch timer = new Stopwatch();

    private Dictionary<string, Int64> _methodCalls = new Dictionary<string, long>();

     static ServiceStatistics()
    {
       timer.Start();
    }

    private Int64 _hitCount =0;

     public static String Name { get { return "HISCentral"; } }
    public  String MachineName
    {
        get
    {
        
        return _machineName;
    }
        set { _machineName = value; }}
    public  TimeSpan Uptime
    {
        get { return timer.Elapsed; }
    }
    public  Dictionary<string, Int64> MethodCalls
    {
        get { return _methodCalls; }  } 

     public  void AddCount(string methodName)
     {
         _hitCount++;
        if (MethodCalls.ContainsKey(methodName))
        {
            MethodCalls[methodName]++;
        } else
        {
            MethodCalls.Add(methodName,1); 
        }
         if ( _hitCount % 1000 == 0)
         {
             PerformanceLog.Info(this.ToString());
         }
    }
    
    public override String ToString()
    {
        const string format = " [{0}:{1}] ";
       StringBuilder message = new StringBuilder();
        message.Append("[ServerStats: ");
        message.AppendFormat(format, "Uptime", Uptime);
        foreach (var methodCall in MethodCalls)
        {
            message.AppendFormat(format, methodCall.Key, methodCall.Value);
        }
        message.Append(" ]");

        return message.ToString();
    }
}
