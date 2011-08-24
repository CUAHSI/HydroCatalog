using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicesWebSite
{
    public partial class PublicServicesStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void servicesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // taken from example at http://msdn.microsoft.com/en-us/library/aa479342.aspx
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var severity = (string)DataBinder.Eval(e.Row.DataItem, "Severity");
                switch (severity)
                {
                    case "Minor":
                        e.Row.BackColor = Color.LightYellow;
                        break;
                    case "Critical":
                        e.Row.BackColor = Color.LightPink;
                        break;
                    case "Major":
                         e.Row.BackColor = Color.LightSalmon;
                         break;
                    case "Clear":
                         e.Row.BackColor = Color.LightGreen;
                         break;
                }
            }
            return;
        }
    }
}