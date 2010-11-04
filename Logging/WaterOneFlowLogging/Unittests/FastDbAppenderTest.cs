using WaterOneFlowRemoteLogService.Appender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using log4net.Core;
using System.Data;

namespace Unittests
{
    
    
    /// <summary>
    ///This is a test class for FastDbAppenderTest and is intended
    ///to contain all FastDbAppenderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FastDbAppenderTest
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
        ///A test for FastDbAppender Constructor
        ///</summary>
        [TestMethod()]
        public void FastDbAppenderConstructorTest()
        {
            FastDbAppender target = new FastDbAppender();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ActivateOptions
        ///</summary>
        [TestMethod()]
        public void ActivateOptionsTest()
        {
            FastDbAppender target = new FastDbAppender(); // TODO: Initialize to an appropriate value
            target.ActivateOptions();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [TestMethod()]
        public void CloseTest()
        {
            FastDbAppender target = new FastDbAppender(); // TODO: Initialize to an appropriate value
            target.Close();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoAppend
        ///</summary>
        [TestMethod()]
        public void DoAppendTest()
        {
            FastDbAppender target = new FastDbAppender(); // TODO: Initialize to an appropriate value
            LoggingEvent[] loggingEvents = null; // TODO: Initialize to an appropriate value
            target.DoAppend(loggingEvents);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoAppend
        ///</summary>
        [TestMethod()]
        public void DoAppendTest1()
        {
            FastDbAppender target = new FastDbAppender(); // TODO: Initialize to an appropriate value
            LoggingEvent loggingEvent = null; // TODO: Initialize to an appropriate value
            target.DoAppend(loggingEvent);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetConnection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WaterOneFlowRemoteLogService.exe")]
        public void GetConnectionTest()
        {
            FastDbAppender_Accessor target = new FastDbAppender_Accessor(); // TODO: Initialize to an appropriate value
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
            FastDbAppender_Accessor target = new FastDbAppender_Accessor(); // TODO: Initialize to an appropriate value
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
            FastDbAppender_Accessor target = new FastDbAppender_Accessor(); // TODO: Initialize to an appropriate value
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
            FastDbAppender target = new FastDbAppender(); // TODO: Initialize to an appropriate value
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
            FastDbAppender target = new FastDbAppender(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
