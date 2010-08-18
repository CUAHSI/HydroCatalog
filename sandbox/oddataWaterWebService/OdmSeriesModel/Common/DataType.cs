using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Shared
{
    public class DataType :BaseEntity 
    {
        public DataType()
        {

        }
        public virtual bool Instantaneous
        {
            get
            {
                if (TimeSupport == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public virtual DataTypeCv Name { get; set; }

        public virtual int TimeSupport { get; set; }
        public virtual Unit TimeSupportUnit { get; set; }

        public static DataType InstananteousDataType()
        {
            return new DataType
                       {
                           TimeSupport = 0
                       };
        }

        #region helpers to make creation easier
        public static DataType DailyAverage()
        {
            return new DataType
                       {
                           Name = new DataTypeCv{ Name = "Average"},
                           TimeSupport =1,
                           TimeSupportUnit = new Unit
                               {
                                   Abbreviation = "d",
                                   Name = "Day",
                                   Type =  UnitTypeCv.Time()
                               }
               
            };
        }
        public static DataType MinuteAverage()
        {
            return new DataType
            {
                Name = new DataTypeCv { Name = "Average" },
                TimeSupport = 1,
                TimeSupportUnit = new Unit
                               
                    {
                        Abbreviation = "m",
                        Name = "minute",
                        Type =  UnitTypeCv.Time()
                    }
               
            };
        }

        public static DataType MonthAverage()
        {
            return new DataType
            {
                Name = new DataTypeCv { Name = "Average" },
                TimeSupport = 1,
                TimeSupportUnit = new Unit
                               
                    {
                        Abbreviation = "M",
                        Name = "Month",
                        Type = UnitTypeCv.Time()
                    }
                
            };
        }
        public static DataType YearAverage()
        {
            return new DataType
            {
                 Name = new DataTypeCv{ Name = "Average"},
                           TimeSupport =1,
                           TimeSupportUnit = new Unit
                               {
                        Abbreviation = "yr",
                        Name = "Year",
                        Type = UnitTypeCv.Time()
                    }
               
            };
        }
        #endregion 
    }
}
