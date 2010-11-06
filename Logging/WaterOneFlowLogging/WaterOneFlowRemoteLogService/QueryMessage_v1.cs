using System;
using System.Collections.Generic;
using System.Text;
using log4net.Core;


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
        public DateTimeOffset? StartDateTime { get; set; } // startdate
        public DateTimeOffset? EndDateTime { get; set; } //enddate
        public TimeSpan? ProcessingTime { get; set; } // processing time
        public Int64? Count { get; set; } // count 
        public string UserHostIp { get; set; }
        public string UserDomain { get; set; }

    }


    public class QueryMessageV1 : QueryMessage
    {
        public QueryMessageV1(LoggingEvent logEvent)
        {

            this.CallDateTime = logEvent.TimeStamp;
            if (logEvent.Properties.Contains("log4net:HostName"))
            {
                this.HisServer = logEvent.Properties["log4net:HostName"].ToString();
            } else
            {
                this.HisServer = "MISSING";
            }
            ParseMessage(logEvent.RenderedMessage);

        }
        private void ParseMessage(string message)
        {
            String[] tokens = message.Split('|');
            if (tokens.Length == 9)
            {
                //this.CallDateTime = DateTime.Parse(tokens[0]);
                // this.HisServer = tokens[0];
                this.Network = tokens[0];
                this.Method = tokens[1];
                this.Location = tokens[2];

                if (!String.IsNullOrEmpty(tokens[3]))
                {
                    this.Variable = tokens[3];
                }

                DateTimeOffset start;
                if (DateTimeOffset.TryParse(tokens[4], out start))
                {
                    this.StartDateTime = start;
                }
                DateTimeOffset end;
                if (DateTimeOffset.TryParse(tokens[5], out end))
                {
                    this.EndDateTime = end;
                }

                TimeSpan span;
                if (TimeSpan.TryParse(tokens[6], out span))
                { this.ProcessingTime = span; }
                Int64 count;
                if (Int64.TryParse(tokens[7], out count))
                {
                    this.Count = count;
                }

                this.UserHostIp = tokens[8];

            }
        }

    }
}
