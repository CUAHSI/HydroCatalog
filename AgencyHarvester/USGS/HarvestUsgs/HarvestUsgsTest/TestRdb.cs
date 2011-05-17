using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HarvestUsgs;
using NUnit.Framework;

namespace HarvestUsgsTest
{
    [TestFixture()]
    public class TestRdb
    {
        [TestCase("examples/site01646500.txt", 1)]
        [TestCase("examples/series_01646500.txt",120)]
public void TestLineCount(string filename, int fileLineCount)
        {
            StreamReader reader = new StreamReader(filename);

            ParseRdb parseRdb = new ParseRdb(reader);

            parseRdb.init();

            var headers = parseRdb.Headers;

            Assert.Contains("# alt_datum_cd    -- Altitude datum",headers);
         
            int actual = 0;
            foreach (Dictionary<string, string> keyValuePair in parseRdb.GetNextValue())
            {
                actual++;
                Assert.AreEqual(keyValuePair.Keys.Count, parseRdb.Columns.Count);
            }
            Assert.AreEqual(fileLineCount, actual);
        }
    }
}
