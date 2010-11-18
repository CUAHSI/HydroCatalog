namespace WaterOneFlowWebServiceTests.NUnit_test_code
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTestWOFWMT
    {
        private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; 
                                          Data Source=./TestConfigFiles/TestData1.xls;Extended Properties=    
                                          ""Excel 8.0;HDR=YES;""";
        private DbProviderFactory factory;
        private DbDataAdapter adapter;
        private DbCommand selectSeriesCommand, selectNetworkCommand;
        private DataSet seriesDataSet, networkDataSet;
        private Hashtable netCodeAndWSDLuri;        

        [SetUp]
        public void Init()
        {
            factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            adapter = factory.CreateDataAdapter();
            selectSeriesCommand = factory.CreateCommand();
            selectNetworkCommand = factory.CreateCommand();
            seriesDataSet = null;
            networkDataSet = null;

            // initializing queries for accessing series and network worksheet 
            // from TestData1 excel file            
            selectSeriesCommand.CommandText = "SELECT * " +
                                              "FROM [Series$]"; 
            selectNetworkCommand.CommandText = "SELECT * " +
                                               "FROM [Network$]";

            DbConnection connection = factory.CreateConnection();

            connection.ConnectionString = connectionString;
            selectSeriesCommand.Connection = connection;
            selectNetworkCommand.Connection = connection;

            // hmm, I guess I can reuse adapter by choosing different SelectCommand
            // hopefully, this properly initialized everything I need correctly... 
            adapter.SelectCommand = selectSeriesCommand;
            seriesDataSet = new DataSet();
            adapter.Fill(seriesDataSet);

            adapter.SelectCommand = selectNetworkCommand;
            networkDataSet = new DataSet();
            adapter.Fill(networkDataSet);

            netCodeAndWSDLuri = new Hashtable();

            foreach (DataRow theRow in networkDataSet.Tables[0].Rows) {
                netCodeAndWSDLuri.Add(theRow.ItemArray[0], theRow.ItemArray[1]);
            }            
        }       

        /// <summary>
        /// This test uses excel files that yields some result for GetValues method.
        /// All entries tested from file should result in true return value. 
        /// </summary>
        [Test]
        public void testGetValuesUsingTestFiles()
        {            
            string[] seperator1 = { " " };

            // ok, compiler is not complaining for now...             
            foreach (DataRow theRow in seriesDataSet.Tables[0].Rows) {
                string serviceWSDL = "", sitecode = "", variable = "";
                string beginDate = "", endDate = "";
                int i = 0;

                foreach (object stuff in theRow.ItemArray) {
                    // from first entry, I need to find out                     
                    switch (i) {
                        case 0:
                            serviceWSDL = (string)netCodeAndWSDLuri[stuff.ToString()];
                            break;
                        case 1:
                            sitecode = stuff.ToString();
                            break;
                        case 2:
                            variable = stuff.ToString();
                            break;
                        case 3:
                            beginDate = ((DateTime)stuff).ToString("u");
                            beginDate = beginDate.Split(seperator1, StringSplitOptions.RemoveEmptyEntries)[0];                            
                            break;
                        case 4:
                            endDate = ((DateTime)stuff).ToString("u");
                            endDate = endDate.Split(seperator1, StringSplitOptions.RemoveEmptyEntries)[0];                           
                            break;
                        default:
                            break;
                    }
                    
                    i++;
                }

                if (!String.IsNullOrEmpty(serviceWSDL)) {
                    WaterOneFlowWebMethodTests testWebMethod =
                        new WaterOneFlowWebMethodTests(serviceWSDL, true);
                    string result = "";

                    Assert.IsTrue(testWebMethod.testGetValues2(sitecode, variable,
                                                               beginDate, endDate, "",
                                                               ref result));
                }               
            }            
        }
    }
}
