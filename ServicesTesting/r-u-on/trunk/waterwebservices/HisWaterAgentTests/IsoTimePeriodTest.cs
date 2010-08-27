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
          [Test()]
        [Ignore()]
        public void ParseTest()
        {
            IsoTimePeriod target = new IsoTimePeriod(); // TODO: Initialize to an appropriate value
            string period = string.Empty; // TODO: Initialize to an appropriate value
            IsoTimePeriod expected = null; // TODO: Initialize to an appropriate value
            IsoTimePeriod actual;
            actual = target.Parse(period);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
