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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login1_LoginError(object sender, EventArgs e)
    {

        //There was a problem logging in the user

        //'See if this user exists in the database
        MembershipUser userInfo = Membership.GetUser(Login1.UserName);

        if (userInfo == null)
        {
            //'The user entered an invalid username...
            LoginErrorDetails.Text = "There is no user in the database with the username " + Login1.UserName;
        }
        else
        {
            //'See if the user is locked out or not approved
            if (!userInfo.IsApproved)
            {
                LoginErrorDetails.Text = "Your account has not yet been approved by the site's administrators. Please try again later...";
            }
            else if (userInfo.IsLockedOut)
            {
                LoginErrorDetails.Text = "Your account has been locked out because of a maximum number of incorrect login attempts. You will NOT be able to login until you contact a site administrator and have your account unlocked.";
            }
            else
            {
                //'The password was incorrect (don't show anything, the Login control already describes the problem)
                LoginErrorDetails.Text = String.Empty;
            }
        }

    }


    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

    }
}

