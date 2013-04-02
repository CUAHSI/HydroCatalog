using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Profile;


/// <summary>
/// Summary description for SiteUser
/// </summary>
public class SiteUser
{
    private MembershipUser member;

    public SiteUser()
    {
        member = new MembershipUser("CuashiHisSqlMembershipProvider", null, null, null, null, null, true, true, System.DateTime.Now, System.DateTime.Now, System.DateTime.Now, System.DateTime.Now, System.DateTime.Now);
    }

    public SiteUser(string userName)
    {
        member = Membership.GetUser(userName);
    }

    public void SetUser(string userName)
    {
        member = Membership.GetUser(userName);
    }

    public string UserName()
    {
        return member.UserName;
    }

    public string getRole()
    {
        string role = Roles.GetRolesForUser(member.UserName)[0].ToString();
        return role;
    }

    public string EmailAddress()
    {
        return member.Email;
    }

    public void setEmailAddress(string emailAddress)
    {
        member.Email = emailAddress;
        Membership.UpdateUser(member);        
    }

    public void setRole(string newRole)
    {
        if (Roles.RoleExists(newRole))
        {
            if (!Roles.IsUserInRole(member.UserName, "Administrator"))
            {
                foreach (string Role in Roles.GetAllRoles())
                {
                    if (Roles.IsUserInRole(member.UserName,Role))
                    {
                        Roles.RemoveUserFromRole(member.UserName, Role);
                    }
                }
                Roles.AddUserToRole(member.UserName, newRole);
            }
        }
    }

}