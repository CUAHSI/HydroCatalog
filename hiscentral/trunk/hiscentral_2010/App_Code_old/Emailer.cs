using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using  System.Net.Mail;
/// <summary>
/// Summary description for Emailer
/// </summary>
public class Emailer
{
  public Emailer()
  {
    //
    // TODO: Add constructor logic here
    //
  }
  private SmtpClient getSMTP()
  {
    try
    {
      Configuration conf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/CentralHIS2");
      string eserver = conf.AppSettings.Settings["EmailServer"].Value;
      string fromadd = conf.AppSettings.Settings["EmailFromAddress"].Value;
      string fromname = conf.AppSettings.Settings["EmailFromName"].Value;
      string emailauthuser = conf.AppSettings.Settings["EmailServerAuthUserName"].Value;
      string emailauthpass = conf.AppSettings.Settings["EmailServerAuthPassword"].Value;
      string emailserverport = conf.AppSettings.Settings["EmailServerPort"].Value;
      string emailserverSSL = conf.AppSettings.Settings["EmailServerUseSSL"].Value;
      string emailReqAuth = conf.AppSettings.Settings["EmailServerRequireAuth"].Value;




      SmtpClient smtp = new SmtpClient(eserver);


      if (emailReqAuth.ToLower() == "true")
      {
        smtp.Credentials = new System.Net.NetworkCredential(emailauthuser, emailauthpass);


      }
      if (emailserverSSL.ToLower() == "true")
      {
        smtp.EnableSsl = true;
        if (emailserverport != "465")
        {
          smtp.Port = int.Parse(emailserverport);
        }

      }
      else
      {
        if (emailserverport != "25")
        {
          smtp.Port = int.Parse(emailserverport);
        }
      }
      return smtp;


    }
    catch (Exception ex)
    {
      //this.lblexception.Text = ex.Message + "<br>" + ex.StackTrace;
      return null;
    }
  }

  protected void sendBulkMail(string[] bccList, string subject, string body)
  {
    MailMessage message = new System.Net.Mail.MailMessage();
    message.IsBodyHtml = false;
    for (int i = 0; i < bccList.Length; i++)
    {
      MailAddress address = new MailAddress(bccList[i]);
      message.Bcc.Add(address);
    }
    message.Subject = subject;
    message.Body = body;

    SmtpClient smtp = getSMTP();
    smtp.Send(message);
  }
  public void sendMessageToAdmins(string subject, string body)
  {
    MailMessage message = new System.Net.Mail.MailMessage();
    message.IsBodyHtml = false;
    string[] admins = System.Web.Security.Roles.GetUsersInRole("Administrator");
    //for (int i = 0; i < admins.Length; i++) {
    //    System.Web.Security.MembershipUserCollection admins2 = System.Web.Security.Membership.FindUsersByName(admins[i]);
    //    System.Web.Security.MembershipUser user;
    //    System.Collections.IEnumerator userenum = admins2.GetEnumerator();
    //    userenum.Reset();
    //    while (userenum.MoveNext())
    //    {
    //      user = (System.Web.Security.MembershipUser)userenum.Current;
    //      MailAddress address = new MailAddress(user.Email);
    //      message.To.Add(address);
    //    }

    //  }
      message.To.Add("twhitenack@sdsc.edu");
      message.Subject = subject;
      message.Body = body;
      SmtpClient smtp = getSMTP();
      smtp.Send(message);
    
  }
}
