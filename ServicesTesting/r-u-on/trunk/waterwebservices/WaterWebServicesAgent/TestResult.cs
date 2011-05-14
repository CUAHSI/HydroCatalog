using System;

namespace cuahsi.wof.ruon
{
    public class TestResult
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
    }
}