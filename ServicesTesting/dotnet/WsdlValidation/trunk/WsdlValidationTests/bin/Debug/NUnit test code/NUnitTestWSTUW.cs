namespace WsdlValidationTests.NUnit_test_code
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTestWSTUW
    {
        private string filePathForGoodWsdl, filePathForBadWsdl, filePathForNonExistWsdl;
        private string filePathForGoodWsdl_fullpath, filePathForBadWsdl_fullpath;
        private string filePathForNonExistWsdl_fullpath;
        private string knownWebWsdlUri, bogusWebWsdlUri;
        private string fileUri;
      
        [SetUp]
        public void Init()
        {
            filePathForGoodWsdl = "WSDL xml files\\DailyValues.xml";
            filePathForBadWsdl = "WSDL xml files\\BadlyFormedDailyValues.xml";
            filePathForNonExistWsdl = "WSDL xml files\\NoValues.xml";
            
            filePathForGoodWsdl_fullpath = Environment.CurrentDirectory + "\\" + 
                                  filePathForGoodWsdl;
            filePathForBadWsdl_fullpath = Environment.CurrentDirectory + "\\" + 
                                 filePathForBadWsdl;
            filePathForNonExistWsdl_fullpath = Environment.CurrentDirectory + "\\" + 
                                      filePathForNonExistWsdl;
            fileUri = "file:///D:/Visual%20Studio%202005/Projects/TestCuahsiHisWaterOneFlowWebService/" + 
                      "WsdlValidationTests/WSDL%20xml%20files/DailyValues.xml";

            knownWebWsdlUri = "http://river.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx?WSDL";
            bogusWebWsdlUri = "http://river.sdsc.edu/wateroneflow/NWIS/BogusStuff.asmx?WSDL";
            
        }

        [Test]
        public void doesUriResourceExists_strparam_withValidFilePath() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesUriResourceExists(filePathForGoodWsdl_fullpath));
        }

        [Test]
        public void doesUriResourceExists_strparam_withInvalidFilePath() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(filePathForGoodWsdl_fullpath + "/\\"));
        } 

        [Test]
        public void doesUriResourceExists_strparam_withNonExistFilePath() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(filePathForNonExistWsdl_fullpath));
        }

        [Test]
        public void doesUriResourceExists_strparam_withValidWebUri() 
        {            
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesUriResourceExists(knownWebWsdlUri));
        }

        [Test]
        public void doesUriResourceExists_strparam_withInvalidWebUri() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists("bogus//" + knownWebWsdlUri));
        }

        [Test]
        public void doesUriResourceExists_strparam_withNonExistWebUri() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(bogusWebWsdlUri));
        }

        [Test]
        public void doesUriResourceExists_strparam_withValidFileUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesUriResourceExists(
                          "file://" + filePathForGoodWsdl_fullpath));
        }

        [Test]
        public void doesUriResourceExists_strparam_withInvalidFileUri() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(
                          "file://" + ":/" + filePathForGoodWsdl_fullpath));
        }
        
        [Test]
        public void doesUriResourceExists_uriparam_withValidFilePath() 
        {
            Uri uriObj = new Uri(filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesUriResourceExists(uriObj));
        }

        [Test]
        public void doesUriResourceExists_uriparam_withInvalidFilePath() 
        {
            Uri uriObj = new Uri(filePathForGoodWsdl_fullpath + "/\\");

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(uriObj));
        }

        [Test]
        public void doesUriResourceExists_uriparam_withNonExistFilePath() 
        {
            Uri uriObj = new Uri(filePathForNonExistWsdl_fullpath);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(uriObj));
        }

        [Test]
        public void doesUriResourceExists_uriparam_withValidWebUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesUriResourceExists(uriObj));
        }

        [Test]
        public void doesUriResourceExists_uriparam_withInvalidWebUri() 
        {
            Uri uriObj = new Uri("bogus://" + knownWebWsdlUri);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(uriObj));
        }

        [Test]
        public void doesUriResourceExists_uriparam_withNonExistWebUri() 
        {
            Uri uriObj = new Uri(bogusWebWsdlUri);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(uriObj));
        }

        [Test]
        public void doesUriResourceExists_uriparam_withValidFileUri() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesUriResourceExists(uriObj));
        }

        [Test]
        public void doesUriResourceExists_uriparam_withInvalidFileUri() 
        {
            Uri uriObj = new Uri("file://" + "/blah\\" + filePathForGoodWsdl_fullpath);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(uriObj));
        }

        [Test]
        public void doesUriResourceExists_uriparam_withNonExistFileUri() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath + "/noHome.xml");

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesUriResourceExists(uriObj));
        }
       
        [Test]
        public void isWsdlValid_strparam_withValidFullFilepath() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.isWsdlValid(filePathForGoodWsdl_fullpath));
        }

        [Test]
        public void isWsdlValid_strparam_withValidFileUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.isWsdlValid("file://" + filePathForGoodWsdl_fullpath));
        }

        [Test]
        public void isWsdlValid_strparam_withValidWebUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.isWsdlValid(knownWebWsdlUri));
        }

        [Test]
        public void isWsdlValid_strparam_withInvalidWebUri() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.isWsdlValid(this.bogusWebWsdlUri));
        }

        /// <summary>
        /// This test case uses absolute uri... so it will not work if path specified in 
        /// fileUri does not exist... 
        /// </summary>
        [Test]
        public void isWsdlValid_strparam_withValidFileUri2() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.isWsdlValid(fileUri));
        }

        [Test]
        public void doesWsdlUriWellFormed_strparam_withValidUri()
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlUriWellFormed(knownWebWsdlUri, UriKind.Absolute ));            
        }

        [Test]
        public void doesWsdlUriWellFormed_strparam_withInvalidUri() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlUriWellFormed("river.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx?WSDL", UriKind.Absolute));
        }

        [Test]
        public void doesWsdlUriWellFormed_uriparam_withValidUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlUriWellFormed(uriObj));
        }   
      
        //******************************************************************************************

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValues_soap12() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetValues"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValuesObject_soap12() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetValuesObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSitesXml_soap12() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSitesXml"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfo_soap12() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSiteInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfo_soap12() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetVariableInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSites_soap12() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSites"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfoObject_soap12() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSiteInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfoObject_soap12() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetVariableInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistMethod_soap12() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "NonExistMethod"));
        }

        //************************************************************************************

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValues_soap12_webUri() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetValues"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValuesObject_soap12_webUri() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetValuesObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSitesXml_soap12_webUri() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSitesXml"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfo_soap12_webUri() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSiteInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfo_soap12_webUri() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetVariableInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSites_soap12_webUri() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSites"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfoObject_soap12_webUri() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSiteInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfoObject_soap12_webUri() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetVariableInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistMethod_soap12_webUri() {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "NonExistMethod"));
        }

        //*************************************************************************************

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValues_soap_webUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetValues"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValuesObject_soap_webUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetValuesObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSitesXml_soap_webUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSitesXml"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfo_soap_webUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSiteInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfo_soap_webUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetVariableInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSites_soap_webUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSites"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfoObject_soap_webUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSiteInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfoObject_soap_webUri() 
        {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetVariableInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistMethod_soap_webUri() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "WaterOneFlowSoap",
                                                                                  "NonExistMethod"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistBinding_webUri() 
        {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(knownWebWsdlUri,
                                                                                  "POST",
                                                                                  "NonExistMethod"));
        }

        //*************************************************************************************

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValues_soap() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetValues"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValuesObject_soap() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetValuesObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSitesXml_soap() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSitesXml"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfo_soap() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSiteInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfo_soap() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetVariableInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSites_soap() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSites"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfoObject_soap() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSiteInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfoObject_soap() {
            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetVariableInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistMethod_soap() {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "WaterOneFlowSoap",
                                                                                  "NonExistMethod"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistBinding() {
            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(filePathForGoodWsdl_fullpath,
                                                                                  "POST",
                                                                                  "NonExistMethod"));
        }

        //**********************************************************************************
        
        [Test]
        public void doesWsdlSupportMethodInBinding_GetValues_soap_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetValues"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValuesObject_soap_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetValuesObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSitesXml_soap_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSitesXml"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfo_soap_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSiteInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfo_soap_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetVariableInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSites_soap_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSites"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfoObject_soap_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSiteInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfoObject_soap_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetVariableInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistMethod_soap_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "NonExistMethod"));
        }

        
        //**********************************************************************************
        
        [Test]
        public void doesWsdlSupportMethodInBinding_GetValues_soap_UriParam_webUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetValues"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValuesObject_soap_UriParam_webUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetValuesObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSitesXml_soap_UriParam_webUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSitesXml"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfo_soap_UriParam_webUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSiteInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfo_soap_UriParam_webUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetVariableInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSites_soap_UriParam_webUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSites"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfoObject_soap_UriParam_webUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetSiteInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfoObject_soap_UriParam_webUri() 
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap",
                                                                                  "GetVariableInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistMethod_soap_UriParam_webUri()
        {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                   "WaterOneFlowSoap",
                                                                                   "NonExistMethod"));
        }


        //****************************************************************************************

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValues_soap12_UriParam() {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetValues"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValuesObject_soap12_UriParam() {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetValuesObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSitesXml_soap12_UriParam() {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSitesXml"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfo_soap12_UriParam() {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSiteInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfo_soap12_UriParam() {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetVariableInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSites_soap12_UriParam() {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSites"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfoObject_soap12_UriParam() {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSiteInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfoObject_soap12_UriParam() {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetVariableInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistMethod_soap12_UriParam() {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "NonExistMethod"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistBinding_UriParam() 
        {
            Uri uriObj = new Uri("file://" + filePathForGoodWsdl_fullpath);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "POST",
                                                                                  "NonExistMethod"));
        }

        //****************************************************************************************

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValues_soap12_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetValues"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetValuesObject_soap12_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetValuesObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSitesXml_soap12_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSitesXml"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfo_soap12_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSiteInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfo_soap12_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetVariableInfo"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSites_soap12_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSites"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetSiteInfoObject_soap12_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetSiteInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_GetVariableInfoObject_soap12_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsTrue(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "GetVariableInfoObject"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistMethod_soap12_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "WaterOneFlowSoap12",
                                                                                  "NonExistMethod"));
        }

        [Test]
        public void doesWsdlSupportMethodInBinding_NonExistBinding_UriParam_webUri() {
            Uri uriObj = new Uri(knownWebWsdlUri);

            Assert.IsFalse(WebServiceTestsUsingWsdl.doesWsdlSupportMethodInBinding(uriObj,
                                                                                  "POST",
                                                                                  "NonExistMethod"));
        }

        ///**********************************************************************************
        
        [Test]
        public void verifyWebMethodParamNamesAndTypes_existMethodCorrectType()
        {
            Assert.IsTrue(
                   WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(fileUri,
                                                                           "GetValues", "location", "string"));           
            Assert.IsTrue(
                   WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(this.fileUri,
                                                                           "GetValues", "variable", "string"));
            Assert.IsTrue(
                   WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(this.fileUri,
                                                                           "GetValues", "startDate", "string"));
            Assert.IsTrue(
                   WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(this.fileUri,
                                                                           "GetValues", "endDate", "string"));
            Assert.IsTrue(
                   WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(this.fileUri,
                                                                           "GetValues", "authToken", "string"));            
            
        }

        [Test]
        public void verifyWebMethodParamNamesAndTypes_existMethodCorrectType2() {
            Assert.IsTrue(
                   WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(fileUri,
                                                                           "GetSitesXml", "site", "ArrayOfString"));
            Assert.IsTrue(
                   WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(fileUri,
                                                                           "GetSitesXml", "authToken", "string"));            
        }

        [Test]
        public void verifyWebMethodParamNamesAndTypes_existMethodIncorrectType()
        {
            Assert.IsFalse(
                WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(fileUri,
                                                                           "GetSitesXml", "site", "string"));
        }

        [Test]
        public void verifyWebMethodParamNamesAndTypes_nonexistParam() {
            Assert.IsFalse(
                WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(fileUri,
                                                                           "GetSitesXml", "BLAH", "string"));
        }

        [Test]
        public void verifyWebMethodParamNamesAndTypes_nonExistMethod() {
            Assert.IsFalse(
                WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(fileUri,
                                                                           "GetSitesXml123", "site", "ArrayOfString"));
        }
    }
}
