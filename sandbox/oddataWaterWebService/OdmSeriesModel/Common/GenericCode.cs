using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Common
{
    public class GenericCode : BaseEntity
    {
        public virtual string Prefix { get; set; }
        public virtual string Code { get; set; }
        
        private const char Separator = ':';
        private const string Format = "{0}:{1}";

        public GenericCode()
        {
            
        }

        public  GenericCode(string WebServiceCode)
        {
            if (String.IsNullOrEmpty(WebServiceCode))
            {
                throw new ArgumentException("WebServiceCode cannot be null or empty", "WebServiceCode");
            }
            char[] seprators = new char[] { Separator };
            string[] split = WebServiceCode.Split(seprators, 2);

            if (split.Length == 2)
            {
                Prefix = split[0];
                Code = split[1];
            }
            else
            {
                /* Take a bad ID, assume it is the code
                 * Other option is to throw an error
                  
                  throw new ArgumentException( 
                  "WebServiceCode a Prefix is required. GroupCode formats are "
                  + String.Format(Format, "Prefix", "GroupCode")  
                  ,"WebServiceCode");

                 * */
                Code = split[0];
            }

        }
        //public static string GetWebServiceCode(GenericCode genericCode)
        //{
        //    return genericCode.ToString();
        //}

        public override string ToString()
        {
            return String.Format(Format, Prefix, Code);
        }
    }
}