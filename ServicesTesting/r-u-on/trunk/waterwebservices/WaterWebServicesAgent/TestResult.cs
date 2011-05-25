using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ruon;

namespace cuahsi.wof.ruon
{
    public interface ITestResult
    {
        /// <summary>
        /// Null if no report
        /// false if there was an error
        /// true if everthing is ok.
        /// </summary>
        bool? Working { get; set; }
        String ServiceName { get; set; }
        String MethodName { get; set; }
        String ErrorString { get; set; }
        Double RunTime { get; set; }
        Double RunTimeGetSitesSeries { get; set; }
        Double RunTimeGetValues { get; set; }
    }

   
    public interface ITestResult2 :ITestResult
    {
        /// <summary>
        /// Adds Storage for parameters, and 

        /// </summary>
        Guid Identifier { get; set; }
        AlarmSeverity Serverity { get; set; }
        String Location { get; set; }
        String Variable { get; set; }
        String StartDate { get; set; }
        string EndDate { get; set; }
        String Endpoint { get; set; }
        String ExceptionMessage { get; set; }

        IAlarm ToAlarm();
    }
    //public class TestResult : ITestResult
    //{
    //    /// <summary>
    //    /// Null if no report
    //    /// false if there was an error
    //    /// true if everthing is ok.
    //    /// </summary>
    //    public bool? Working { get; set; }
    //    public String ServiceName { get; set; }
    //    public String MethodName { get; set; }
    //    public String ErrorString { get; set; }
    //    public Double runTime { get; set; }
    //    public Double runTimeGetSitesSeries { get; set; }
    //    public Double runTimeGetValues { get; set; }
    //    public Dictionary<string, string> errorList { get; set; }
    //}

     [DataContract( Namespace = "uri:his.cuahsi.org/Monitoring/1/TestResult/")]
    public class TestResult : ITestResult2
    {
         private String exceptionMessage;

         /// <summary>
         /// Null if no report
         /// false if there was an error
         /// true if everthing is ok.
         /// </summary>
         [DataMember]
         public Guid Identifier { get; set; }
        [DataMember]
        public bool? Working { get; set; }
        [DataMember]
        public String ServiceName { get; set; }
        [DataMember]
        public String MethodName { get; set; }
        [DataMember]
        public String ErrorString { get; set; }
        [DataMember]
        public Double RunTime { get; set; }
       
        public Double RunTimeGetSitesSeries { get; set; }
       
        public Double RunTimeGetValues { get; set; }

        public TestResult()
        {
            //Identifier = Guid.NewGuid();
            init(true);
        }
        public TestResult(bool working)
        {
            init(working);
        }

        public TestResult(bool working, AlarmSeverity alarmSeverity )
        {
            init(working);
            Serverity = alarmSeverity;
        }

        public TestResult(bool working, AlarmSeverity alarmSeverity,
            String serviceName,
            String methodName)
        {
            init(working);
            Serverity = alarmSeverity;
            ServiceName = serviceName;
            MethodName = methodName;

        }
        public TestResult(bool working, AlarmSeverity alarmSeverity,
           String serviceName,
           String methodName,String endpoint)
        {
            init(working);
            Serverity = alarmSeverity;
            ServiceName = serviceName;
            MethodName = methodName;
            Endpoint = endpoint;

        } 
        public TestResult(bool working, AlarmSeverity alarmSeverity,
           String serviceName,
           String methodName,String endpoint,String errorString)
        {
            init(working);
            Serverity = alarmSeverity;
            ServiceName = serviceName;
            MethodName = methodName;
            Endpoint = endpoint;
            ErrorString = errorString;
        }
        private void init(bool working)
        {
            Identifier = Guid.NewGuid();

            ServiceName = "UNSET";
            MethodName = String.Empty;
            Working = working;
            Serverity = AlarmSeverity.Clear;
            if (!working)
            {
                Serverity = AlarmSeverity.Minor;
            }

            ErrorString = String.Empty;
            RunTime = -1;
            Location = String.Empty;
            Variable = String.Empty;
            StartDate = String.Empty;
            EndDate = String.Empty;
            Endpoint = String.Empty;
            ExceptionMessage = String.Empty;

        }
        [DataMember]
        public AlarmSeverity Serverity { get; set; }

         [DataMember]
         public string Location { get; set; }

         [DataMember]
         public string Variable { get; set; }

         [DataMember]
         public string StartDate { get; set; }

         [DataMember]
         public String EndDate { get; set; }

         [DataMember]
         public string Endpoint { get; set; }

         [DataMember]
        public String ExceptionMessage { get; set; }

        public IAlarm ToAlarm()
        {
            if (Working.HasValue)
            {
                if (Working.Value)
                {
                    return new Clear(ServiceName, ServiceName + MethodName);
                }
                else
                {
                    return  new Alarm
                    (ServiceName, ServiceName + MethodName, Serverity, 
                    ErrorString);
                    
                }

            }
            return new Alarm
                    ("CODINGERROR", "CODINGERROR", AlarmSeverity.Minor,
                    "CODINGERROR SHOULD NOT GET HERE");
        }

    }
}