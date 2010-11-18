using System;
using System.Collections.Generic;
using System.Text;


namespace WaterOneFlowRemoteLogService
{
    /* Matt says that some unformatted messages have made it into the log
     * We will need to be smarter about the parsing.
     * Creating a base object with all the informaiton, and
     * a second v1 object that should contain the logic
     * 
     * A third class should hold a list before sending to the db in bulk?
     * */
    /* WaterOneFlowImpl.Logging
     * queryLog.InfoFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                 Network, // network
                 Method, // method
                 Location, //locaiton
                 Variable, //variable
                 start, // startdate
                 end, //enddate
                ProcessingTime, // processing time
                 Count, // count 
                 userHost);
     * */

     public abstract class QueryMessage
    {
         protected QueryMessage()
        {

        }
       public DateTime CallDateTime { get; set; } // time from log
       public string HisServer { get; set; } 

        public string Network { get; set; }
        public string Method { get; set; } // method
        public string Location { get; set; } //locaiton
        public string Variable { get; set; } //variable
        public DateTimeOffset StartDateTime { get; set; } // startdate
        public DateTimeOffset EndDateTime { get; set; } //enddate
        public TimeSpan ProcessingTime { get; set; } // processing time
        public Int64 Count { get; set; } // count 
        public string UserHostIp { get; set; }
        public string UserDomain { get; set; }

    }

    
    public class QueryMessageV1 : QueryMessage
    {
        public QueryMessageV1(string message)
        {

        }

    }
}
