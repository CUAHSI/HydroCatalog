using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cuahsi.his.ogc
{
    public class Network
    {
        //string sql = "SELECT NetworkName,NetworkTitle,ServiceWSDL,ServiceAbs,ContactName,ContactEmail," +
        //              "ContactPhone,Organization,website,Citation," +
        //              "Xmin,Xmax,Ymin,Ymax,ValueCount,VariableCount,SiteCount,EarliestRec,LatestRec" +
        //              " FROM HISNetworks where NetworkID = @NetworkID AND (isPublic='true')";

        public string NetworkName { get; set; }
        public string NetworkTitle { get; set; }
        public string ServiceWSDL { get; set; }
        public string ServiceAbs { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Organization { get; set; }
        public string Website { get; set; }
        public Double Xmin { get; set; }
        public Double Xmax { get; set; }
        public Double Ymin { get; set; }
        public Double Ymax { get; set; }
        public Int64 ValueCount { get; set; }
        public int SiteCount { get; set; }
        public int VariableCount { get; set; }
        public string EarliestRec { get; set; }
        public string LatestRec { get; set; }

        public Network()
        {
            
        }
        public Network(DataRow row)
        {
            if (row == null) return;
           NetworkName= item2string(row, "NetworkName");
           NetworkTitle = item2string(row, "NetworkTitle");
           ServiceWSDL = item2string(row, "ServiceWSDL");
           ServiceAbs = item2string(row, "ServiceAbs");
           ContactName = item2string(row, "ContactName");
           ContactEmail = item2string(row, "ContactEmail");
           ContactPhone = item2string(row, "ContactPhone");
           Organization = item2string(row, "Organization");
           Website = item2string(row, "Website");

           Xmin = item2double(row, "Xmin");
           Xmax = item2double(row, "Xmax");
           Ymin = item2double(row, "Ymin");
           Ymax = item2double(row, "Ymax");
            Int64 count;
             Int64.TryParse(row["ValueCount"].ToString(), out count);
            ValueCount = count;
            int siteCount;
            int.TryParse(row["SiteCount"].ToString(),out siteCount);
            SiteCount = siteCount;

           EarliestRec = item2string(row, "EarliestRec");
           LatestRec = item2string(row, "LatestRec");
        }

        private string item2string(DataRow row, string name)
        {
            if (row.Table.Columns.Contains(name)){
            return row[name].ToString();
            }
            else
            {
               
                    return String.Empty;
                
            }

        }
        private Double item2double(DataRow row, string name)
        {
            if (row.Table.Columns.Contains(name))
            {
                return (Double) row[name];
            }

            return Double.NaN;
        }
    
    }
}
