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
using System.Collections.Generic;

public partial class manage_account : System.Web.UI.Page
{
    private SiteUser currentUser = new SiteUser();
    private AdminPermissionsAccess AdminPermissionsAccessIns = new AdminPermissionsAccess();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["User"].ToString() != null && !IsPostBack)
        {
            currentUser.SetUser(Request.QueryString["User"].ToString());
            PopulateUserInfo();

            if (currentUser.getRole() == "Moderator")
                ManagePermissionLinks.Visible = true;
            else
            {
                ManagePermissionLinks.Visible = false;
                ManagePermissionsBox.Visible = false;
            }
        }
    }

    protected void PopulateUserInfo()
    {
        currentUser.SetUser(Request.QueryString["User"].ToString());
        NameLabel.Text = currentUser.UserName();
        FirstNameLabel.Text = Profile.GetProfile(currentUser.UserName()).FirstName.ToString();
        LastNameLabel.Text = Profile.GetProfile(currentUser.UserName()).LastName.ToString();
        EmailAddressLabel.Text = currentUser.EmailAddress();
        RoleLabel.Text = currentUser.getRole();
        OrganizationLabel.Text = Profile.GetProfile(currentUser.UserName()).Organization.ToString();
        DepartmentLabel.Text = Profile.GetProfile(currentUser.UserName()).Department.ToString();
        DesignationLabel.Text = Profile.GetProfile(currentUser.UserName()).Designation.ToString();
        PhoneLabel.Text = Profile.GetProfile(currentUser.UserName()).Phone.ToString();

        if (currentUser.getRole() == "Moderator")
            ManagePermissionLinks.Visible = true;
        else
        {
            ManagePermissionLinks.Visible = false;
            ManagePermissionsBox.Visible = false;
        }
    }

    protected void EditUserLink_Click(object sender, EventArgs e)
    {
        currentUser.SetUser(Request.QueryString["User"].ToString());

        UserDetailsDisplay.Visible = false;
        UserDetailsEdit.Visible = true;

        EmailAddressText.Text = currentUser.EmailAddress();
        List<string> RoleList = new List<string>();
        foreach (string Role in Roles.GetAllRoles())
        {
            if (Role != "Administrator")
            {
                RoleList.Add(Role);
            }
        }
        RoleRadioList.DataSource = RoleList;
        RoleRadioList.DataBind();
        RoleRadioList.SelectedValue = currentUser.getRole();
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        currentUser.SetUser(Request.QueryString["User"].ToString());

        currentUser.setEmailAddress(EmailAddressText.Text.ToString());

        if (!Roles.IsUserInRole(currentUser.UserName(), RoleRadioList.SelectedValue))
            currentUser.setRole(RoleRadioList.SelectedValue);

        if (currentUser.getRole() == "User")
        {
            AdminPermissionsAccessIns.RemoveAllCV10Permissions(currentUser.UserName());
            AdminPermissionsAccessIns.RemoveAllCV11Permissions(currentUser.UserName());
        }

        PopulateUserInfo();

        UserDetailsEdit.Visible = false;
        UserDetailsDisplay.Visible = true;
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        UserDetailsEdit.Visible = false;
        UserDetailsDisplay.Visible = true;
    }

    protected void cv10PermissionsButton_Click(object sender, EventArgs e)
    {
        currentUser.SetUser(Request.QueryString["User"].ToString());
        if (currentUser.getRole() == "Moderator")
        {
            ManagePermissionLinks.Visible = false;
            CVTypeLabel.Text = "ODM 1.0";

            CurrentPermissionsListLabel.Text = AdminPermissionsAccessIns.GetCurrentCV10Permissions(currentUser.UserName());
            RemainingPermissions.DataSource = AdminPermissionsAccessIns.GetRemainingCV10Permissions(currentUser.UserName());
            RemainingPermissions.DataBind();
            CurrentPermissions.DataSource = AdminPermissionsAccessIns.GetCurrentCV10PermissionsList(currentUser.UserName());
            CurrentPermissions.DataBind();

            ManagePermissionsBox.Visible = true;
           
        }
    }

    protected void cv11PermissionsButton_Click(object sender, EventArgs e)
    {
        currentUser.SetUser(Request.QueryString["User"].ToString());
        if (currentUser.getRole() == "Moderator")
        {
            ManagePermissionLinks.Visible = false;
            CVTypeLabel.Text = "ODM 1.1";

            CurrentPermissionsListLabel.Text = AdminPermissionsAccessIns.GetCurrentCV11Permissions(currentUser.UserName());
            RemainingPermissions.DataSource = AdminPermissionsAccessIns.GetRemainingCV11Permissions(currentUser.UserName());
            RemainingPermissions.DataBind();
            CurrentPermissions.DataSource = AdminPermissionsAccessIns.GetCurrentCV11PermissionsList(currentUser.UserName());
            CurrentPermissions.DataBind();

            ManagePermissionsBox.Visible = true;
        }
    }
    protected void FinishManageButton_Click(object sender, EventArgs e)
    {
        ManagePermissionLinks.Visible = true;
        ManagePermissionsBox.Visible = false;
    }
    protected void AddPermissionButton_Click(object sender, EventArgs e)
    {
        currentUser.SetUser(Request.QueryString["User"].ToString());
        if (CVTypeLabel.Text == "ODM 1.0")
        {
            AdminPermissionsAccessIns.AddCV10Permission(currentUser.UserName(), RemainingPermissions.SelectedValue.ToString());

            CurrentPermissionsListLabel.Text = AdminPermissionsAccessIns.GetCurrentCV10Permissions(currentUser.UserName());
            RemainingPermissions.DataSource = AdminPermissionsAccessIns.GetRemainingCV10Permissions(currentUser.UserName());
            RemainingPermissions.DataBind();
            CurrentPermissions.DataSource = AdminPermissionsAccessIns.GetCurrentCV10PermissionsList(currentUser.UserName());
            CurrentPermissions.DataBind();
        }
        else
        if (CVTypeLabel.Text == "ODM 1.1")
        {
            AdminPermissionsAccessIns.AddCV11Permission(currentUser.UserName(), RemainingPermissions.SelectedValue.ToString());

            CurrentPermissionsListLabel.Text = AdminPermissionsAccessIns.GetCurrentCV11Permissions(currentUser.UserName());
            RemainingPermissions.DataSource = AdminPermissionsAccessIns.GetRemainingCV11Permissions(currentUser.UserName());
            RemainingPermissions.DataBind();
            CurrentPermissions.DataSource = AdminPermissionsAccessIns.GetCurrentCV11PermissionsList(currentUser.UserName());
            CurrentPermissions.DataBind();
        }
    }
    protected void RemovePermissionButton_Click(object sender, EventArgs e)
    {
        currentUser.SetUser(Request.QueryString["User"].ToString());
        if (CVTypeLabel.Text == "ODM 1.0")
        {
            AdminPermissionsAccessIns.RemoveCV10Permission(currentUser.UserName(), CurrentPermissions.SelectedValue.ToString());

            CurrentPermissionsListLabel.Text = AdminPermissionsAccessIns.GetCurrentCV10Permissions(currentUser.UserName());
            RemainingPermissions.DataSource = AdminPermissionsAccessIns.GetRemainingCV10Permissions(currentUser.UserName());
            RemainingPermissions.DataBind();
            CurrentPermissions.DataSource = AdminPermissionsAccessIns.GetCurrentCV10PermissionsList(currentUser.UserName());
            CurrentPermissions.DataBind();
        }
        else
        if (CVTypeLabel.Text == "ODM 1.1")
        {
            AdminPermissionsAccessIns.RemoveCV11Permission(currentUser.UserName(), CurrentPermissions.SelectedValue.ToString());

            CurrentPermissionsListLabel.Text = AdminPermissionsAccessIns.GetCurrentCV11Permissions(currentUser.UserName());
            RemainingPermissions.DataSource = AdminPermissionsAccessIns.GetRemainingCV11Permissions(currentUser.UserName());
            RemainingPermissions.DataBind();
            CurrentPermissions.DataSource = AdminPermissionsAccessIns.GetCurrentCV11PermissionsList(currentUser.UserName());
            CurrentPermissions.DataBind();
        }
    }

    protected void RemoveAllPermissionsButton_Click(object sender, EventArgs e)
    {
        currentUser.SetUser(Request.QueryString["User"].ToString());
        if (CVTypeLabel.Text == "ODM 1.0")
        {
            AdminPermissionsAccessIns.RemoveAllCV10Permissions(currentUser.UserName());

            CurrentPermissionsListLabel.Text = AdminPermissionsAccessIns.GetCurrentCV10Permissions(currentUser.UserName());
            RemainingPermissions.DataSource = AdminPermissionsAccessIns.GetRemainingCV10Permissions(currentUser.UserName());
            RemainingPermissions.DataBind();
            CurrentPermissions.DataSource = AdminPermissionsAccessIns.GetCurrentCV10PermissionsList(currentUser.UserName());
            CurrentPermissions.DataBind();
        }
        else
        if (CVTypeLabel.Text == "ODM 1.1")
        {
            AdminPermissionsAccessIns.RemoveAllCV11Permissions(currentUser.UserName());

            CurrentPermissionsListLabel.Text = AdminPermissionsAccessIns.GetCurrentCV11Permissions(currentUser.UserName());
            RemainingPermissions.DataSource = AdminPermissionsAccessIns.GetRemainingCV11Permissions(currentUser.UserName());
            RemainingPermissions.DataBind();
            CurrentPermissions.DataSource = AdminPermissionsAccessIns.GetCurrentCV11PermissionsList(currentUser.UserName());
            CurrentPermissions.DataBind();
        }
    }
}