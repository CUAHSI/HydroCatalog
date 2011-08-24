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
using System.Net.Mail;

public partial class mailform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        System.Web.Security.MembershipUserCollection users = System.Web.Security.Membership.GetAllUsers();
        System.Web.Security.MembershipUser user;


        IEnumerator userenum = users.GetEnumerator();
        userenum.Reset();
        while (userenum.MoveNext()) {
          user = (System.Web.Security.MembershipUser)userenum.Current;
         
          lbxUsers.Items.Add(new ListItem(user.UserName + " <" + user.Email + ">", user.Email));

        
        }


        
      }
    }
    protected void btnSend_Click(object sender, EventArgs e)
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

      MailMessage message = new System.Net.Mail.MailMessage();
      message.IsBodyHtml = false;
      message.From = new System.Net.Mail.MailAddress(fromadd, fromname);
      message.Body = this.txtMessage.Text;
      message.Subject = this.txtSubject.Text;

      for (int i = 0; i < this.lbxUsers.Items.Count; i++) {
        if (lbxUsers.Items[i].Selected) {
          message.To.Add(lbxUsers.Items[i].Value);        
        }
      }

      SmtpClient smtp = new SmtpClient(eserver);
      

      if (emailReqAuth.ToLower()=="true")
      {
        smtp.Credentials = new System.Net.NetworkCredential(emailauthuser, emailauthpass);


      }
      if (emailserverSSL.ToLower()=="true")
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


      smtp.Send(message);
    }
    catch (Exception ex) {
      this.lblexception.Text = ex.Message+"<br>"+ex.StackTrace;

    }
  }
}
