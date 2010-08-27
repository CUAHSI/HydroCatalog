// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Collections.Generic;
using System.Text;

namespace Ruon
{

    /// <summary>
    /// Severity of the alarm
    /// </summary>
    public enum AlarmSeverity
    {
        /// <summary>
        /// Critical
        /// </summary>
        Critical=0,
        /// <summary>
        /// Major
        /// </summary>
        Major=1,
        /// <summary>
        /// Minor
        /// </summary>
        Minor=2,
        /// <summary>
        /// This is not a valid alarm state but is useful when coding 
        /// generic state code.
        /// </summary>
        Clear=-1
    };

    /// <summary>
    /// Objects with this interface are used to communicate agent state to the 
    /// R-U-ON server (Alarm Up, Alarm Down, Event).
    /// </summary>
    public interface IAlarm
    {
    }

    /// <summary>
    /// This class implements some common methods needed by Alarm, Clear and Event
    /// There is no direct use for this class.
    /// </summary>
    abstract public class AlarmTop:IAlarm
    {
        internal object[] args;
        internal AlarmTop(object [] args) 
        {
            this.args = args;
        }
        abstract internal String TagFormat();

        /// <summary>
        /// The XML node representing the alarm
        /// </summary>
        /// <returns>
        /// XML Node
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(TagFormat(), args);
            return sb.ToString();
        }

        static internal string Sev(AlarmSeverity s)
        {
            if (s == AlarmSeverity.Clear)
            {
                throw new IAOException("Alarm cannot have a Clear state");
            }
            return (new string[] { "C", "M", "m" })[(int)s];
        }
    }


    /// <summary>
    /// An Alarm object passed to the ReportAlarms() method to indicate an alarm
    /// </summary>
    public class Alarm : AlarmTop
    {
        /// <summary>
        /// Create an Alarm object.
        /// <param name="resource">Resource that is failing (alarmed). Combined with id, this is the unique identifier of the alarm (Up to 256 bytes).</param>
        /// <param name="id">An id that is unique for the alarmed resource (Up to 256 bytes).</param>
        /// <param name="severity">The severity of the alarm (Critical, Major or Minor)/</param>
        /// <param name="description">The verbal description of the alarm (Up to 1024 bytes).</param>
        /// </summary>
        public Alarm(String resource, String id, AlarmSeverity severity, String description)
            :base(new Object[]{resource, id, Sev(severity),description})
        {
        }

        override internal String TagFormat() 
        {
            return "<alarm resource=\"{0}\" id=\"{1}\" severity=\"{2}\"><![CDATA[{3}]]></alarm>";
        }
    }

    /// <summary>
    /// A Clear Alarm instruction passed to the ReportAlarms() method.
    /// The combination of resource and id uniquly identifies the alarm to be cleared.
    /// </summary>
    public class Clear : AlarmTop 
    {
        /// <summary>
        /// Create a Clear object using the default description
        /// <param name="resource">The alarmed resource</param>
        /// <param name="id">The id of the alarm</param>
        /// </summary>
        public Clear(String resource, String id) 
            :base(new Object[]{resource, id})
        {
        }
        /// <summary>
        /// Create a Clear object with a specified description
        /// <param name="resource">The alarmed resource</param>
        /// <param name="id">The id of the alarm</param>
        /// <param name="description">The description to be used in notification for the clear event. If this
        /// is not specified, the system will use a generic statement to inform the user of the alarm
        /// being cleared.</param>
        /// </summary>
        public Clear(String resource, String id, String description)
            :base(new Object[]{resource, id, description})
        {
        }
        override internal String TagFormat() 
        {
            if (args.Length==3)
            {
                return "<clear resource=\"{0}\" id=\"{1}\" ><![CDATA[{2}]]></clear>";
            }
            else 
            {
                return "<clear resource=\"{0}\" id=\"{1}\" />";
            }
        }
    }


    /// <summary>
    /// An Event object, passed to the ReportAlarms() method.
    /// An Event is reported to the user just like an alarm but is not maintained in the
    /// active alarm table and is not expected to have a corresponding Clear event.
    /// </summary>
    public class Event : AlarmTop
    {
        /// <summary>
        /// Create an Event object
        /// <param name="resource">Resource that is failing (Combined with id, this is the unique identifier of the alarm, Up to 256 bytes).</param>  
        /// <param name="id">An id that is unique for the alarmed resource (Up to 256 bytes).</param>  
        /// <param name="severity">The severity of the alarm (Critical, Major or Minor).</param>  
        /// <param name="description"> The verbal description of the alarm (Up to 1024 bytes).</param>  
        /// </summary>
        public Event(String resource, String id, AlarmSeverity severity, String description)
            : base(new Object[]{resource, id, Sev(severity),description})
        {
        }
        override internal String TagFormat() 
        {
            return "<event resource=\"{0}\" id=\"{1}\" severity=\"{2}\"><![CDATA[{3}]]></event>";
        }
    }

}
