using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class temp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/default.aspx");
        }
 
    }
    protected void EnterUserNameButton_Click(object sender, EventArgs e)
    {
        MembershipUser CurrentUser = Membership.GetUser(UserNameText.Text.ToString());
        string GivenUserName = Membership.GetUserNameByEmail(EmailAddressText.Text.ToString());

        if ((CurrentUser != null) && (GivenUserName != null) && (CurrentUser.UserName.ToString() == GivenUserName))
        {
            UserNameError.Visible = false;
            EnterUserNameBox.Visible = false;           
            ValidateUser(CurrentUser);
        }
        else
        {
            UserNameError.Text = "Account retrieval failed. No User account exists with the above user name and email address. Please try again.";
            UserNameError.Visible = true;
        }
    }

    protected void ValidateUser(MembershipUser CurrentUser)
    {
        ValidateUserBox.Visible = true;
        UserNameLabel.Text = CurrentUser.UserName.ToString();
        QuestionLabel.Text = CurrentUser.PasswordQuestion.ToString();
    }

    protected void AnswerButton_Click(object sender, EventArgs e)
    {
        AnswerQuestionError.Visible = false;
        try
        {
            string NewPassword = "";
            NewPassword = Membership.GetUser(UserNameLabel.Text).ResetPassword(AnswerBox.Text.ToString());
            NewPasswordLabel.Text = NewPassword;
            ValidateUserBox.Visible = false;
            ShowPasswordBox.Visible = true;
        }
        catch (MembershipPasswordException)
        {
            AnswerQuestionError.Text = "Answer Incorrect! . Please try again or contact the Website Administrator";
            AnswerQuestionError.Visible = true;
        }        
    }
    protected void ShowPasswordButton_Click(object sender, EventArgs e)
    {
        PasswordContainer.Visible = true;
        ShowPasswordButton.Visible = false;
    }
}
