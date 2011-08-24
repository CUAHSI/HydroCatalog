using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GenericWebservice
{
    public partial class TestRestUrl : System.Web.UI.UserControl
    {
        public string BaseUrl { get; set; }
        public string SoapPage { get; set; }
        public string variableMethod { get; set; }
        public string siteMethod { get; set; }
        public string valuesMethod { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void Page_PreLoad(object sender, EventArgs e)
        //{
        //    serviceLocation.NavigateUrl =SoapPage;
        //}


    }
}