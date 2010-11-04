using System.IO;
using WaterOneFlowRemoteLogService.Appender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using log4net.Core;
using System.Data;

namespace Unittests
{
    
    
    /// <summary>
    ///This is a test class for CuahsiLoggingDbAppenderTest and is intended
    ///to contain all CuahsiLoggingDbAppenderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CuahsiLoggingDbAppenderTest
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
        ///A test for CuahsiLoggingDbAppender Constructor
        ///</summary>
        [TestMethod()]
        public void CuahsiLoggingDbAppenderConstructorTest()
        {
            CuahsiLoggingDbAppender target = new CuahsiLoggingDbAppender();
           
        }

        /// <summary>
        ///A test for ActivateOptions
        ///</summary>
        [TestMethod()]
        public void ActivateOptionsTest()
        {
            CuahsiLoggingDbAppender target = new CuahsiLoggingDbAppender(); // TODO: Initialize to an appropriate value
            target.ActivateOptions();
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [TestMethod()]
        public void CloseTest()
        {
            CuahsiLoggingDbAppender target = new CuahsiLoggingDbAppender(); // TODO: Initialize to an appropriate value
            target.Close();
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
        /*
        /// <summary>
        ///A test for DoAppend
        ///</summary>
        [TestMethod()]
        public void DoAppendTest()
        {
            CuahsiLoggingDbAppender target = new CuahsiLoggingDbAppender(); // TODO: Initialize to an appropriate value
            LoggingEvent[] loggingEvents = null; // TODO: Initialize to an appropriate value
            target.DoAppend(loggingEvents);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
        */
        /// <summary>
        ///A test for DoAppend
        ///</summary>
        [TestMethod()]
        public void DoAppendOneRecord()
        {
            CuahsiLoggingDbAppender target = new CuahsiLoggingDbAppender(); // TODO: Initialize to an appropriate value
            LoggingEvent loggingEvent = null; // TODO: Initialize to an appropriate value
            String logdata = "2008-09-25 13:45:27,232 |(HIS) | TWDB|GetValues|TWDB:D1|TWDB:TEm001|1900-06-16T00:00:00|1900-06-16T00:00:00|||129.116.248.192";
            LoggingEventData led = new LoggingEventData();
            led.Message = logdata;
            
            loggingEvent = new LoggingEvent(led);
            target.ConnectionString = "Server=disrupter.sdsc.edu;Database=hiscentral_logging;User ID=loggingService;Password=l0gg1ng;Trusted_Connection=False;";
            target.DoAppend(loggingEvent);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void DoAppend1000Records()
        {
            CuahsiLoggingDbAppender target = new CuahsiLoggingDbAppender(); // TODO: Initialize to an appropriate value
            LoggingEvent loggingEvent = null; // TODO: Initialize to an appropriate value
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo pparentDir = dir.Parent.Parent;
            
           
            String queryLogFile = "query-log-unittest.txt";
            String queryFilePath = Path.Combine(pparentDir.FullName, queryLogFile);
            
            StreamReader loggingStream  = new StreamReader(queryFilePath);
            String logdata = null;

            while ((logdata = loggingStream.ReadLine() )!= null)
            {
                LoggingEventData led = new LoggingEventData();
                if (logdata.Split('|').Length == 11)
                {
                    led.Message = logdata;
                    loggingEvent = new LoggingEvent(led);
                    target.ConnectionString =
                        "Server=disrupter.sdsc.edu;Database=hiscentral_logging;User ID=loggingService;Password=l0gg1ng;Trusted_Connection=False;";
                    target.DoAppend(loggingEvent);
                }

            }

            /*
            String logdata = "2008-09-25 13:45:27,232 |(HIS) | TWDB|GetValues|TWDB:D1|TWDB:TEm001|1900-06-16T00:00:00|1900-06-16T00:00:00|||129.116.248.192";
            LoggingEventData led = new LoggingEventData();
            led.Message = logdata;

            loggingEvent = new LoggingEvent(led);
            target.ConnectionString = "Server=disrupter.sdsc.edu;Database=hiscentral_logging;User ID=loggingService;Password=l0gg1ng;Trusted_Connection=False;";
            target.DoAppend(loggingEvent);
            */
        }
        /*
        /// <summary>
        ///A test for GetConnection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WaterOneFlowRemoteLogService.exe")]
        public void GetConnectionTest()
        {
            CuahsiLoggingDbAppender_Accessor target = new CuahsiLoggingDbAppender_Accessor(); // TODO: Initialize to an appropriate value
            IDbConnection expected = null; // TODO: Initialize to an appropriate value
            IDbConnection actual;
            actual = target.GetConnection();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitializeCommand
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WaterOneFlowRemoteLogService.exe")]
        public void InitializeCommandTest()
        {
            CuahsiLoggingDbAppender_Accessor target = new CuahsiLoggingDbAppender_Accessor(); // TODO: Initialize to an appropriate value
            IDbCommand command = null; // TODO: Initialize to an appropriate value
            target.InitializeCommand(command);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetCommandValues
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WaterOneFlowRemoteLogService.exe")]
        public void SetCommandValuesTest()
        {
            CuahsiLoggingDbAppender_Accessor target = new CuahsiLoggingDbAppender_Accessor(); // TODO: Initialize to an appropriate value
            IDbCommand command = null; // TODO: Initialize to an appropriate value
            LoggingEvent loggingEvent = null; // TODO: Initialize to an appropriate value
            target.SetCommandValues(command, loggingEvent);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ConnectionString
        ///</summary>
        [TestMethod()]
        public void ConnectionStringTest()
        {
            CuahsiLoggingDbAppender target = new CuahsiLoggingDbAppender(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ConnectionString = expected;
            actual = target.ConnectionString;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            CuahsiLoggingDbAppender target = new CuahsiLoggingDbAppender(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
         */
    }
}
