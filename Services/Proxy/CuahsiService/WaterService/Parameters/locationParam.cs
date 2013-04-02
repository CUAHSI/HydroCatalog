using System;
using System.Collections.Generic;

/*
 * 
 *  methods
 *   locationParam(inputParamString)
 *   locationParam(NetworkString,SiteCodeSting)
 *   locationParam(Lat,Long)  // geom by default
 *   locationParam(N,W,S,E)   // GEOM BOX
 *   locationParam(coords[]) // GEOM Polygon
 * 
 */
namespace cuahsi.his.WaterService.Parameters
{
    public class locationParam
    {
        private static String locationParamFormat = "Acceptable locationParam formats: \n VOCABULARY:code/option=value/optionN=valueN \n Netowrk:siteCode \n \n GEOM:Point(X Y)\n GEOM:BOX(N W,S E) GEOM:POLYGON(X1 Y1,X2 Y2,X3 Y3,X1 Y1) \n";
        static String optionBlockSep = "/"; // separates key=value blocks
        static String optionSep = "="; // separates key value pairs
        private static String networkSeparator = ":";
        private static String siteIDNetwork = "BYID"; // SITEID means code is a siteID
        private String networkField;
        private Boolean isGeometryField; // is this a location that is a geometry
        private Boolean isIdField = false;

        private String SiteCodeField;
        private basicGeometry GeometryField;
        private String location;

        /// <summary>
        /// list of options.
        /// </summary>
        private Dictionary<String, String> optionsList = new Dictionary<String, String>();



        /// <summary>
        /// Leading and trailing spaces are trimmed.
        /// </summary>
        public String Network
        {
            get
            {
                return networkField;
            }
            set
            {
                
                this.networkField = value.Trim();
                if (string.IsNullOrEmpty(this.networkField))
                    throw new WaterOneFlowException("Network Portion of location cannot be null or empty. Should be 'NETOWRK:SiteCode'");
            }
        }

        public Boolean IsId
        {
            get { return isIdField; }
            set { isIdField = value; }
        }

        /// <summary>
        /// Leading and trailing spaces are trimmed.
        /// </summary>
        public String SiteCode
        {
            get
            {
                return SiteCodeField;
            }
            set
            {
                this.SiteCodeField = value.Trim();
                if (string.IsNullOrEmpty(this.SiteCodeField))
                    throw new WaterOneFlowException("SiteCode Portion of location cannot be null or empty. Should be 'NETOWRK:SiteCode'");
            }
        }

        public Dictionary<String, String> options
        {
            get
            {
                return this.optionsList;

            }
            set
            {
                this.optionsList = value;
            }
        }

        public Boolean isGeometry
        {
            get
            {
                return isGeometryField;
            }
            set
            {
                isGeometryField = value;
            }
        }
        public basicGeometry Geometry
        {
            get { return GeometryField; }
            set { GeometryField = value; }
        }

        public locationParam(String inputParam)
        {
            location = inputParam;
            // cannot be a split using a colon... EPA ID's use a damn colon
            //. needs to be a parse first separator
            /* new logic
             * get Options, if present
             * Then do the code parsing
             * */
            // get options
            String[] s = inputParam.Split(optionBlockSep.ToCharArray());
            if (s.Length > 1)
            {
                for (int i = 1; i < s.Length; i++)
                {
                    String[] l = s[i].Split(optionSep.ToCharArray());
                    if (l.Length < 2)
                    {
                        throw new WaterOneFlowException("Location options should be key=value pairs " + inputParam);

                    }
                    else
                    {
                        addOption(l[0], l[1]);
                    }
                }
            }


             String networkSiteCode = s[0];  
            String[] lp = new String[2];

            if (networkSiteCode.Contains(networkSeparator))
            {
                int sepPosition = networkSiteCode.IndexOf(networkSeparator);

                lp[0] = networkSiteCode.Substring(0, sepPosition).Trim();
                lp[1] = networkSiteCode.Substring(sepPosition + 1).Trim();
                
                Network = lp[0];
                SiteCode = lp[1].Trim();
                if (Network.Equals(siteIDNetwork, StringComparison.InvariantCultureIgnoreCase))
                {
                    IsId = true;
                    try
                    {
                        int.Parse(SiteCode);
                    }
                    catch (Exception e)
                    {
                        throw new WaterOneFlowException("SITEID must be an integer. '" + location + "'");
                    }
                }
                if (Network.Equals(basicGeometry.geomNetworkID))
                    {
                        isGeometry = true;
                        if (lp[1].StartsWith(box.geomType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Geometry = new box(lp[1]);
                        }
                        else if (lp[1].StartsWith(point.geomType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Geometry = new point(lp[1]);
                        }
                        else
                        {
                            // unsupported geometry
                            throw new WaterOneFlowException("Unsupported Geometry :'" + SiteCode + "' " +
                                                            "Must be BOX or POINT");
                        }

                    }
                    else
                    {
                        isGeometry = false;
                    }
                
                
            }
        }

        public static string getSiteCode(string location)
        {
            if (location.Contains(networkSeparator))
            {
                int sepPosition = location.IndexOf(networkSeparator);
                return location.Substring(sepPosition + 1).Trim();
            }
            else
            {
                return null;
            }
        }

        public void addOption(String key, String opt)
        {
            // lowercase
            string lcKey = key.ToLowerInvariant();
            optionsList.Add(lcKey, opt);
        }


        /* public box getBox()
            
         {
         }

         public Double[] getBoxCoords()
         {
         }

         public point getPoint()
         {
         }

         public Double[] getPointCoords()
         {
         }
         */

        public override String ToString()
        {
            return location;
        }


    }
}
