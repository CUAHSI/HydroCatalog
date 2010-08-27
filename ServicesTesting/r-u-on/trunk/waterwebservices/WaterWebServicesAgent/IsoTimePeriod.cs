using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace cuahsi.wof.ruon
{
    public class IsoTimePeriod
    {
        private TimeSpan? _span = null;
        private DateTimeOffset? _startDate = null;
        private DateTimeOffset? _endDate = null;

        public IsoTimePeriod()
        {

        }

        public DateTimeOffset StartDate
        {
            get
            {
                if (_startDate.HasValue) return _startDate.Value;

                if (_endDate.HasValue && _span.HasValue)
                {
                    return _endDate.Value.Subtract(_span.Value);
                }
                else if (_span.HasValue)
                {
                    return DateTimeOffset.Now.Subtract(_span.Value);
                }
                throw new ArgumentException("TimeSpan and (StartDate|EndDate) must be set");
            }
            set
            {
                if (_span.HasValue && _endDate.HasValue)
                {
                    throw new ArgumentException("Cannot Set StartDate because  TimeSpan and EndDate set. TimeSpan and  (StartDate or EndDate) must be set. NOT BOTH. Create new object");
                }
                _startDate = value;
            }
        }
        public DateTimeOffset EndDate
        {
            get
            {
                if (_endDate.HasValue) return _endDate.Value;

                if (_startDate.HasValue && _span.HasValue)
                {
                    return _startDate.Value.Subtract(_span.Value);
                }
                else if (_span.HasValue)
                {
                    return DateTimeOffset.Now;
                }
                throw new ArgumentException("TimeSpan and (StartDate|EndDate) must be set");
            }
            set
            {
                if (_span.HasValue && _startDate.HasValue)
                {
                    throw new ArgumentException("Cannot Set EndDate because  TimeSpan and StartDate set. TimeSpan and  (StartDate or EndDate) must be set. NOT BOTH. Create new object");
                }
                _endDate = value;
            }
        }

        public TimeSpan TimeSpan
        {
            get
            {
                if (_startDate.HasValue && _endDate.HasValue)
                {
                    TimeSpan span = StartDate.Subtract(EndDate);
                    return span;
                }

                else if (_span.HasValue)
                {
                    return _span.Value;
                }
                throw new ArgumentException("TimeSpan or (StartDate&&EndDate) must be set");
            }
            set
            {

                if (_startDate.HasValue && _endDate.HasValue)
                {
                    throw new ArgumentException("Cannot Set TimeSpan because StartDate and EndDate set. TimeSpan and  (StartDate or EndDate) must be set. NOT BOTH. Create new object");
                }

                _span = value;
            }
        }

        public IsoTimePeriod Parse(String period)
        {
            throw new NotImplementedException();
        }

        public static TimeSpan ParseTimeSpan(string s)
        {
            const string Quantity = "quantity";
            const string Unit = "unit";

            const string Days = @"(d(ays?)?)";
            const string Hours = @"(h((ours?)|(rs?))?)";
            const string Minutes = @"(m((inutes?)|(ins?))?)";
            const string Seconds = @"(s((econds?)|(ecs?))?)";

            Regex timeSpanRegex = new Regex(
                string.Format(@"\s*(?<{0}>\d+)\s*(?<{1}>({2}|{3}|{4}|{5}|\Z))",
                              Quantity, Unit, Days, Hours, Minutes, Seconds),
                              RegexOptions.IgnoreCase);
            MatchCollection matches = timeSpanRegex.Matches(s);

            TimeSpan ts = new TimeSpan();
            foreach (Match match in matches)
            {
                if (Regex.IsMatch(match.Groups[Unit].Value, @"\A" + Days))
                {
                    ts = ts.Add(TimeSpan.FromDays(double.Parse(match.Groups[Quantity].Value)));
                }
                else if (Regex.IsMatch(match.Groups[Unit].Value, Hours))
                {
                    ts = ts.Add(TimeSpan.FromHours(double.Parse(match.Groups[Quantity].Value)));
                }
                else if (Regex.IsMatch(match.Groups[Unit].Value, Minutes))
                {
                    ts = ts.Add(TimeSpan.FromMinutes(double.Parse(match.Groups[Quantity].Value)));
                }
                else if (Regex.IsMatch(match.Groups[Unit].Value, Seconds))
                {
                    ts = ts.Add(TimeSpan.FromSeconds(double.Parse(match.Groups[Quantity].Value)));
                }
                else
                {
                    // Quantity given but no unit, default to Hours
                    ts = ts.Add(TimeSpan.FromHours(double.Parse(match.Groups[Quantity].Value)));
                }
            }
            return ts;
        }
    }
}
