using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDLCApp
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //if (!this.IsPostBack)
            //{
            //    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
            //    SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
            //    int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
            //    ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "SessionExpireAlert(" + timeout + ");", true);
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string mailSubject = "PRH Apomuden";
            //string message = "Testing Message from Premier Health Apomuden";
            //MailMessage myMessage = new MailMessage("daniel.wiredu@eupacwebs.com", "danielwiredu@gmail.com", mailSubject, message);
            //myMessage.IsBodyHtml = true;
            //SmtpClient mySmtpClient = new SmtpClient();
            //mySmtpClient.Host = "mail.eupacwebs.com";
            //mySmtpClient.EnableSsl = false;
            //mySmtpClient.Credentials = new System.Net.NetworkCredential("daniel.wiredu@eupacwebs.com", "P@ssword");
            //mySmtpClient.UseDefaultCredentials = true;
            //mySmtpClient.Port = 25;
            //mySmtpClient.Send(myMessage);

            string mailSubject = "PRH Apomuden";
            string message = "Testing Message from Premier Health Apomuden";
            MailMessage myMessage = new MailMessage("gdlctema@gmail.com", "danielwiredu@gmail.com", mailSubject, message);
            myMessage.IsBodyHtml = false;
            SmtpClient mySmtpClient = new SmtpClient();
            mySmtpClient.Host = "smtp.gmail.com";
            mySmtpClient.EnableSsl = true;
            mySmtpClient.Credentials = new System.Net.NetworkCredential("gdlctema@gmail.com", "123@Matrix20");
            mySmtpClient.UseDefaultCredentials = true;
            mySmtpClient.Port = 587;
            mySmtpClient.Send(myMessage);
        }
    }
}