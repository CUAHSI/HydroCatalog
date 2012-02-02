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

public partial class account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUserDetails(User.Identity.Name.ToString());
        }
    }

    protected void BindUserDetails(string UserName)
    {
        string name = Profile.FirstName;
        name += " ";
        name += Profile.LastName;

        if (name != " ")
            NameLabel.Text = name;
        else
            NameLabel.Text = UserName;
        EmailAddress.Text = (Membership.GetUser(User.Identity.Name)).Email;
        Organization.Text = Profile.Organization;
        Department.Text = Profile.Department;
        //Designation.Text = Profile.Designation;
        Phone.Text = Profile.Phone;
    }

    protected void UpdateUserInfoButton_Click(object sender, EventArgs e)
    {
        AccountInfoDisplay.Visible = false;

        EmailAddressText.Text = (Membership.GetUser(User.Identity.Name)).Email;
        OrganizationText.Text = Profile.Organization;
        DepartmentText.Text = Profile.Department;
        //DesignationText.Text = Profile.Designation;
        PhoneText.Text = Profile.Phone;
        FirstNameText.Text = Profile.FirstName;
        LastNameText.Text = Profile.LastName;

        EditUserInfoBox.Visible = true;        
    }


    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        MembershipUser CurrentUser = Membership.GetUser(User.Identity.Name.ToString());
        CurrentUser.Email = EmailAddressText.Text;
        Membership.UpdateUser(CurrentUser);

        //(Membership.GetUser(User.Identity.Name)).Email = EmailAddressText.Text;
        //Membership.UpdateUser(Membership.GetUser(User.Identity.Name));

        Profile.Organization = OrganizationText.Text;
        Profile.Department = DepartmentText.Text;
        //Profile.Designation = DesignationText.Text;
        Profile.Phone = PhoneText.Text;
        Profile.FirstName = FirstNameText.Text;
        Profile.LastName = LastNameText.Text;

        BindUserDetails(User.Identity.Name.ToString());
        
        EditUserInfoBox.Visible = false;
        AccountInfoDisplay.Visible = true;
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        EditUserInfoBox.Visible = false;
        AccountInfoDisplay.Visible = true;
    }
    protected void ChangePasswordButton_Click(object sender, EventArgs e)
    {
        ChangePasswordControl.Visible = true;
        ChangePasswordButton.Visible = false;
    }
    protected void ChangePasswordControl_ChangedPassword(object sender, EventArgs e)
    {
        //Response.Write("<script>alert('Password changed successfully!');</script>");
        ChangePasswordControl.Visible = false;
        ChangePasswordButton.Visible = true;
    }
    protected void ChangePasswordControl_CancelButtonClick(object sender, EventArgs e)
    {
        ChangePasswordControl.Visible = false;
        ChangePasswordButton.Visible = true;
    }
}
