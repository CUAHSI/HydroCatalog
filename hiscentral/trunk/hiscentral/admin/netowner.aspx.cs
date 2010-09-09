using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_netwowner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack) {





        System.Web.Security.MembershipUserCollection users = System.Web.Security.Membership.GetAllUsers();
        System.Web.Security.MembershipUser user;
        IEnumerator userenum = users.GetEnumerator();
        userenum.Reset();
        while (userenum.MoveNext())
        {
          user = (System.Web.Security.MembershipUser)userenum.Current;

          ddlUsers.Items.Add(new ListItem(user.UserName));


        }
      
      }


    }
  protected void btnUpdate_Click(object sender, EventArgs e)
  {

  }
}
