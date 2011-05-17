using System;
using System.Collections.Generic;

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
        String errorString { get; set; }
        Double runTime { get; set; }
        Double runTimeGetSitesSeries { get; set; }
        Double runTimeGetValues { get; set; }
    }
    public interface ITestResult2 :ITestResult
    {
        /// <summary>
        /// Adds Storage for parameters, and 
  
        /// </summary>
        

        String location { get; set; }
        String variable { get; set; }
        String startDate { get; set; }
        Double endDate { get; set; }
        Double endpoint { get; set; }
        Dictionary<string, string> errorList { get; set; }
        
    }
    public class TestResult : ITestResult
    {
        /// <summary>
        /// Null if no report
        /// false if there was an error
        /// true if everthing is ok.
        /// </summary>
        public bool? Working { get; set; }
        public String ServiceName { get; set; }
        public String MethodName { get; set; }
        public String errorString { get; set; }
        public Double runTime { get; set; }
        public Double runTimeGetSitesSeries { get; set; }
        public Double runTimeGetValues { get; set; }
        public Dictionary<string, string> errorList { get; set; }
    }

    public class TestResult2 : ITestResult2
    {
        private string _location;

        private string _variable;

        private string _startDate;

        private double _endDate;

        private double _endpoint;

        /// <summary>
        /// Null if no report
        /// false if there was an error
        /// true if everthing is ok.
        /// </summary>
        public bool? Working { get; set; }
        public String ServiceName { get; set; }
        public String MethodName { get; set; }
        public String errorString { get; set; }
        public Double runTime { get; set; }
        public Double runTimeGetSitesSeries { get; set; }
        public Double runTimeGetValues { get; set; }

        public string location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string variable
        {
            get { return _variable; }
            set { _variable = value; }
        }

        public string startDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public double endDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public double endpoint
        {
            get { return _endpoint; }
            set { _endpoint = value; }
        }

        public Dictionary<string, string> errorList
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}