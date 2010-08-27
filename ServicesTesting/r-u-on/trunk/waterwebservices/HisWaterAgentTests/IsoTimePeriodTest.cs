using cuahsi.wof.ruon;

using System;
using NUnit.Framework;

namespace HisAgentTests
{
    
    
    /// <summary>
    ///This is a test class for IsoTimePeriodTest and is intended
    ///to contain all IsoTimePeriodTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class IsoTimePeriodTest
    {


     

        /// <summary>
        ///A test for TimeSpan
        ///</summary>
          [Test()]
        public void TimeSpanTest()
        {
            IsoTimePeriod target = new IsoTimePeriod(); 
            TimeSpan expected = new TimeSpan(1,0,0,0);
            TimeSpan actual;
            target.TimeSpan = expected;
            actual = target.TimeSpan;
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(target.StartDate.Date == DateTimeOffset.Now.Subtract(expected).Date);
          // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TimeSpan
        ///</summary>
        // [Test()]
        //public void TimeSpanTest2()
        //{
        //    IsoTimePeriod target = new IsoTimePeriod();
            
        //    TimeSpan expected =  TimeSpan.Parse("P1D","PdD");
        //    TimeSpan p1d = new TimeSpan(1, 0, 0, 0);
        //    TimeSpan actual;
        //    target.TimeSpan = expected;
        //    actual = target.TimeSpan;
        //    Assert.AreEqual(p1d, actual);
        //    //Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        /// <summary>
        ///A test for StartDate
        ///</summary>
        [Test()]
        public void StartDateTest()
        {
            IsoTimePeriod target = new IsoTimePeriod(); // TODO: Initialize to an appropriate value
            DateTimeOffset expected = new DateTimeOffset(); // TODO: Initialize to an appropriate value
            DateTimeOffset actual;
            target.StartDate = expected;
            actual = target.StartDate;
            Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EndDate
        ///</summary>
         [Test()]
        public void EndDateTest()
        {
            IsoTimePeriod target = new IsoTimePeriod(); // TODO: Initialize to an appropriate value
            DateTimeOffset expected = new DateTimeOffset(); // TODO: Initialize to an appropriate value
            DateTimeOffset actual;
            target.EndDate = expected;
            actual = target.EndDate;
            Assert.AreEqual(expected, actual);
         //   Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Parse
        ///</summary>
        [TestCase("P1D", 1)]
        [TestCase("P10D", 10)]
        public void ParseTestPeriod(string input, int resultInDays)
        {
            IsoTimePeriod target =  IsoTimePeriod.Parse(input); 

            TimeSpan period = new TimeSpan(resultInDays,0,0);

              
            Assert.AreEqual(period, target.TimeSpan);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }
        /// <summary>
        ///A test for Parse
        ///</summary>
        [TestCase("2010-01-01/2010-01-01", "2010-01-01", "2010 - 01 - 01", 0)]
        [TestCase("2010-01-01/2010-01-20", "2010-01-01", "2010 - 01 - 20", 19)]
        [TestCase("2008-12-01/2008-12-31", "2008-12-01", "2008 - 12 - 31", 30)]
        public void ParseTestStartEnd(string input, string start, string end, int resultInDays)
        {
            IsoTimePeriod target = IsoTimePeriod.Parse(input);

            TimeSpan period = new TimeSpan(resultInDays, 0, 0,0);
            DateTimeOffset sdate =  DateTimeOffset.Parse(start);
            Assert.AreEqual(sdate, target.StartDate);
            DateTimeOffset edate = DateTimeOffset.Parse(end);
            Assert.AreEqual(edate, target.EndDate);
            Assert.AreEqual(period, target.TimeSpan);

            // Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
