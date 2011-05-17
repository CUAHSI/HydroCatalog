using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace HarvestUsgs
{
    public class ParseRdb
    {
        List<String> headers = new List<String>();
        List<String> columnNames = new List<String>();
        private string colSizes = String.Empty;
        Boolean haveReadHeaders = false;

        public ParseRdb()
        {

        }
        public ParseRdb(TextReader inputStream)
        {
            InputStream = inputStream;
        }

        public TextReader InputStream { get; set; }

        public List<String> Headers { get { return headers; } }

        public List<String> Columns { get { return columnNames; } }

        public void init()
        {
            ReadHeaders();
            haveReadHeaders = true;

        }
        public IEnumerable<Dictionary<String, string>> GetNextValue()
        {
            // ideally this would be an enumerator... but
            // no time to figure out how to do a forwarding only version
            String line;
            while ((line = InputStream.ReadLine()) != null)
            {
                yield return ParseLine(line);
            }

        }

        public void ReadHeaders()
        {
            String line;
            while ((line = InputStream.ReadLine()) != null)
            {
                if (!line.StartsWith("#")) break;
                Headers.Add(line);
                
            }
            ReadColumns(line);
        }

        public void ReadColumns(String line)
        {
            
            if (line.StartsWith("agency_cd"))
            {
                String[] tokens = line.Split(new char[] { '\t' });
                foreach (string token in tokens)
                {
                    Columns.Add(token);
                }
                colSizes = InputStream.ReadLine(); // read and ignore size fields
            }

        }

        public Dictionary<String, string> ParseLine(String line)
        {
            Dictionary<String, string> dataValues = new Dictionary<string, string>(Columns.Count);

            String[] tokens = line.Split(new char[] { '\t' });
            IEnumerator<string> colName = Columns.GetEnumerator();
            foreach (string s in tokens)
            {
                colName.MoveNext();
                dataValues.Add(colName.Current, s);
                
            }

            return dataValues;
        }



    }
}

