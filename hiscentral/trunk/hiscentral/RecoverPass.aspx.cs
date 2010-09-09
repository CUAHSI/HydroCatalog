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

public partial class RecoverPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
  {

  }
  protected void PasswordRecovery1_VerifyingAnswer(object sender, LoginCancelEventArgs e)
  {
     
  }
  protected void Button1_Click(object sender, EventArgs e)
  {
    MembershipUser user = Membership.Provider.GetUser(txtUserName.Text, false);
    lblQuestion.Text = user.PasswordQuestion;
  }
  protected void Button2_Click(object sender, EventArgs e)
  {
    MembershipUser user = Membership.Provider.GetUser(txtUserName.Text, false);
    lblPassword.Text = user.GetPassword(txtAnswer.Text);
  }
}
