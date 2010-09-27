using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HisCentralWSMethodTests.hiscentral.webreference;
using NUnit.Framework;
using HisCentralWSMethodTests.hiscentral.webreference;

namespace HisCentralWSMethodTests
{

    [TestFixture]
    public class WebServiceTests
    {

        HisCentralWSMethodTests.hiscentral.webreference.hiscentral svc;

        private Box testBox;

        [SetUp]
        public void Setup()
        {
            svc = new HisCentralWSMethodTests.hiscentral.webreference.hiscentral();

             double xMin = -112.147;
            double xMax = -111.388;
            double yMin = 41.370;
            double yMax = 42.002;
            DateTime beginDate = new DateTime(1950, 1, 1);
            DateTime endDate = new DateTime(2011, 1, 1);
            int networkID = 52; //service ID of the LittleBearRiver

           testBox = new Box{xmin = xMin,xmax = xMax, ymin = yMin, ymax = yMax};

        }

        //   public SeriesRecord[] GetSeriesCatalogForBox2(double xmin, double xmax, double ymin, double ymax, string conceptKeyword, String networkIDs, string beginDate, string endDate)
        [TestCase(-112.147, -111.388, 41.370, 42.002, null, null,"1950-01-01" , "2011-12-31")]
        [TestCase(-112.147, -111.388, 41.370, 42.002, "", null, "1950-01-01", "2011-12-31")]
        [TestCase(-112.147, -111.388, 41.370, 42.002, null, "", "1950-01-01", "2011-12-31")]
        [TestCase(-112.147, -111.388, 41.370, 42.002, "nitrogen", null, "1950-01-01", "2011-12-31")]
        [TestCase(-112.147, -111.388, 41.370, 42.002, null, "1", "1950-01-01", "2011-12-31")]
       // [TestCase(-112.147, -111.388, 41.370, 42.002, null, "1", "1950-01-01", null)]
      //  [TestCase(-112.147, -111.388, 41.370, 42.002, null, "1", null, "2011-12-31")]
        public void GetSeriesCatalogForBox2Test(double xmin, double xmax, double ymin, double ymax,
            string conceptKeyword, 
            String networkIDs, 
            string beginDateString, string endDateString)
        {
            string format = "Failed {0} {1} {2} {3} {4} {5} {6} {7}";
            string note = String.Format(
                format,
                xmin, xmax, ymin, ymax,
                conceptKeyword ?? String.Empty,
                networkIDs ?? String.Empty,
                beginDateString ?? String.Empty,
                endDateString ?? String.Empty
                );
            SeriesRecord[] result = null;
           Assert.DoesNotThrow(
            delegate
                {
                    result = svc.GetSeriesCatalogForBox2(
                        xmin, xmax, ymin, ymax,
                        conceptKeyword,
                        networkIDs,
                        beginDateString,
                        endDateString);
                }, "Error thrown in " +note
               );

           Assert.That(result.Count() > 0, note
               );

        }

        //   public SeriesRecord[] GetSeriesCatalogForBox2(double xmin, double xmax, double ymin, double ymax, string conceptKeyword, String networkIDs, string beginDate, string endDate)
        [TestCase(-112.147, -111.388, 41.370, 42.002, "NitrateNitrogen", null, "1950-01-01", "2011-12-31")] 
        public void GetSeriesCatalogForBox2ZeroTest(double xmin, double xmax, double ymin, double ymax,
            string conceptKeyword,
            String networkIDs,
            string beginDateString, string endDateString)
        {
            string format = "Failed {0} {1} {2} {3} {4} {5} {6} {7}";

             SeriesRecord[] result = null;
           Assert.DoesNotThrow(
            delegate
                {
                    result = svc.GetSeriesCatalogForBox2(
                        xmin, xmax, ymin, ymax,
                        conceptKeyword,
                        networkIDs,
                        beginDateString,
                        endDateString);
                }, "Error thrown in "
                );
            Assert.That(result.Count() ==0,
                String.Format(
                format,
                xmin, xmax, ymin, ymax,
                conceptKeyword ?? String.Empty,
                networkIDs ?? String.Empty,
                beginDateString ?? String.Empty,
                endDateString ?? String.Empty
                ));

        }


        //   public SeriesRecord[] GetSeriesCatalogForBox2(double xmin, double xmax, double ymin, double ymax, string conceptKeyword, String networkIDs, string beginDate, string endDate)
        [TestCase(-112.147, -111.388, 41.370, 42.002, null, null, "1950-01-01", "2011-12-31")]
        [TestCase(-112.147, -111.388, 41.370, 42.002, "", null, "1950-01-01", "2011-12-31")]
        [TestCase(-112.147, -111.388, 41.370, 42.002, null, new int[] { }, "1950-01-01", "2011-12-31")]
        [TestCase(-112.147, -111.388, 41.370, 42.002, "nitrogen", null, "1950-01-01", "2011-12-31")]
        [TestCase(-112.147, -111.388, 41.370, 42.002, null, new int[] { 1 }, null, "2011-12-31")]
        [TestCase(-112.147, -111.388, 41.370, 42.002, null, new int[] { 1 }, "1950-01-01", null)]
        public void GetSeriesCatalogForBoxTest(double xmin, double xmax, double ymin, double ymax,
            string conceptKeyword,
            int[] networkIDs,
            string beginDateString, string endDateString)
        {
            string format = "Failed {0} {1} {2} {3} {4} {5} {6} {7}";

            SeriesRecord[] result = null;
            Assert.DoesNotThrow(
                delegate
                    {
                        result = svc.GetSeriesCatalogForBox(
                            testBox,
                            conceptKeyword,
                            networkIDs,
                            beginDateString,
                            endDateString);
                    }, "Error thrown in "
                    );
            Assert.That(result.Count() > 0,
                String.Format(
                format,
                xmin, xmax, ymin, ymax,
                conceptKeyword ?? String.Empty,
                "", //networkIDs ?? ""
                beginDateString ?? String.Empty,
                endDateString ?? String.Empty
                ));

        }
    }
}
