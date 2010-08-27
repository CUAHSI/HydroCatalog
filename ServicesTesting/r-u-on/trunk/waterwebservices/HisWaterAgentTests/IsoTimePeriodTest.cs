using cuahsi.wof.ruon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HisAgentTests
{
    
    
    /// <summary>
    ///This is a test class for IsoTimePeriodTest and is intended
    ///to contain all IsoTimePeriodTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IsoTimePeriodTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for TimeSpan
        ///</summary>
        [TestMethod()]
        public void TimeSpanTest()
        {
            IsoTimePeriod target = new IsoTimePeriod(); 
            TimeSpan expected = new TimeSpan(1,0,0,0);
            TimeSpan actual;
            target.TimeSpan = expected;
            actual = target.TimeSpan;
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(target.StartDate == DateTimeOffset.Now.Subtract(expected));
          // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TimeSpan
        ///</summary>
        [TestMethod()]
        public void TimeSpanTest2()
        {
            IsoTimePeriod target = new IsoTimePeriod();
            TimeSpan expected =  TimeSpan.Parse("P1D","PdD");
            TimeSpan p1d = new TimeSpan(1, 0, 0, 0);
            TimeSpan actual;
            target.TimeSpan = expected;
            actual = target.TimeSpan;
            Assert.AreEqual(p1d, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StartDate
        ///</summary>
        [TestMethod()]
        public void StartDateTest()
        {
            IsoTimePeriod target = new IsoTimePeriod(); // TODO: Initialize to an appropriate value
            DateTimeOffset expected = new DateTimeOffset(); // TODO: Initialize to an appropriate value
            DateTimeOffset actual;
            target.StartDate = expected;
            actual = target.StartDate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EndDate
        ///</summary>
        [TestMethod()]
        public void EndDateTest()
        {
            IsoTimePeriod target = new IsoTimePeriod(); // TODO: Initialize to an appropriate value
            DateTimeOffset expected = new DateTimeOffset(); // TODO: Initialize to an appropriate value
            DateTimeOffset actual;
            target.EndDate = expected;
            actual = target.EndDate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Parse
        ///</summary>
        [TestMethod()]
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
