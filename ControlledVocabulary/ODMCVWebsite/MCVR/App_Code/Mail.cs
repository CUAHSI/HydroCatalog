using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Mail
/// </summary>
public class Mail
{
	public Mail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void RequestSubmitEmailNotification(string actionFlag, string msgModerators,string tableName,string tableID,string submitterInfo,string changeInfo, string msgTo )
    {
        MailMessage objMailMessage = new MailMessage();
        string time_stamp = DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString();
                       
        string strSignature = "David Tarboton<br>Utah State University<br>" + "<a href='mailto:david.tarboton@usu.edu'>david.tarboton@usu.edu</a>";
        
        objMailMessage.BodyFormat = MailFormat.Html;
       
        objMailMessage.Body = "<div style=\"font-family:Verdana,Arial,sans-serif; font-size:13px; width:600px\">";

                objMailMessage.To = msgModerators;
                objMailMessage.Subject = "ODM Controlled Vocabularies Submission";

                objMailMessage.Body += "<p>" + time_stamp + ": A user has submitted a change to ODM Controlled Vocabulary.</p>";
                objMailMessage.Body += "<p>Table: " + tableName + "<br>Request: " + actionFlag + "<br>ID/Term Affected: " + tableID + "<br>";
                objMailMessage.Body += "<p>Submitter: " + submitterInfo + "<br>";
                objMailMessage.Body += changeInfo;
                objMailMessage.Body += "<p>Please click <a href='http://his.cuahsi.org/mastercvreg/login.aspx'>HERE</a> to view the pending submissions page.</p>";
                                
                objMailMessage.Body += "</div>";

                //SmtpMail.SmtpServer = "cc.usu.edu"
                SmtpMail.SmtpServer = "mail.usu.edu";
                SmtpMail.Send(objMailMessage);

                objMailMessage.To = msgTo;
                objMailMessage.Body = "<div style=\"font-family:Verdana,Arial,sans-serif; font-size:13px; width:600px\">";
                objMailMessage.Body += "<p>Thank you for your submission to ODM Controlled Vocabularies. ";
                objMailMessage.Body += "<p>Table: " + tableName + "<br>Request: " + actionFlag + "<br>ID/Term Affected: " + tableID + "<br>";
                objMailMessage.Body += changeInfo;

                objMailMessage.Body += "<p>This request will be reviewed by a moderator and you will be notified once the status of the submission changes.";

                objMailMessage.Body += "<br><br><p>" + strSignature;
                objMailMessage.Body += "</div>";

                //SmtpMail.SmtpServer = "cc.usu.edu"
                SmtpMail.SmtpServer = "mail.usu.edu";
                SmtpMail.Send(objMailMessage);
                                           
        }
    }


