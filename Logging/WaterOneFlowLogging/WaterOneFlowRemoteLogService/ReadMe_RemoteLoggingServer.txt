
This is an application that uses Apache log4net wit
Windows Remoting to log information to a remote server.

log4net  (http://logging.apache.org/log4net/) is highly 
configurable, and support logging changes on the fly.

In order for the service to work, logging must be configured
and the directory being logged to must be writable by NETWORK SERVICE.

By default logging will happen to 
d:\log-data\
To change, open WaterOneFlow.logging.log4net 
in <<appender name="QueryLogFileAppender">
 and <appender name="ErrorLogFileAppender"
edit  <file value="D:\log-data\query-log.txt" />
set permissions so that the  D:\log-data\ exists, 
and is writable by NETWORK SERVICE

Installed at:
Program Files\Cuahsi HIS\Cuahsi Remote Logging Service\

To run as a program:
WaterOneFlowRemoteLogService.exe debugmode

To install service:
Install.bat


-------------------
Insert in you code:
// add a using statement
using log4net;
[...]
// add an attribute to a file in the same assembely. Before the namespace
// Load the configuration from the 'WebApp.dll.log4net' file
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "genericODws.logging.log4net", Watch = true)]
namespace WaterOneFlow.odws
    public class Service : WebService, IService
    {
        
 //add a static loggers
 // log is the logger for the class.
 // traditionally this is the name of the class (typeof(Service))
        private static readonly ILog log = LogManager.GetLogger(typeof(Service));
 // we also use this for query logging
        private static readonly ILog queryLog = LogManager.GetLogger("myQueryLog");

// in one of you methods, add logging statements
// to send a generic message:
        log.Warn("This is a log from the services class); 

// log info to the queryLogger
   queryLog.Info("MyService|MyInfo|");
 

------------------------------------------------
Config:
<?xml version="1.0" encoding="utf-8" ?>
<log4net debug="true">
  <appender name="SDSCQueryLog" type="log4net.Appender.RemotingAppender" >
     <sink value="tcp://localhost:8085/LoggingSink" />
   <!-- <sink value="tcp://river.sdsc.edu:8085/LoggingSink" />-->
    <lossy value="true" />
    <bufferSize value="200" />
    <onlyFixPartialEventData value="true" />
    <evaluator type="log4net.Core.LevelEvaluator">
      <threshold value="INFO"/>
    </evaluator>
  </appender>
	<root>
		<level value="DEBUG" />
    <appender-ref ref="EventLogAppender"  />
    <appender-ref ref="SDSCQueryLog" />	
    <appender-ref ref="LogFileAppender" />
		<appender-ref ref="HttpTraceAppender" />

		<!-- <appender-ref ref="RollingLogFileAppender" /> -->
	</root>
</log4net>	

