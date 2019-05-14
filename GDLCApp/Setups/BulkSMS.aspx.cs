using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Configuration;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace GDLCApp.Setups
{
    public partial class BulkSMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void contactGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (item["ContactNo"].Text == "" || item["ContactNo"].Text.Length < 10)
                {
                    item.SelectableMode = GridItemSelectableMode.None;
                }
            }
        }
        protected void btnNewSMS_Click(object sender, EventArgs e)
        {

            if (contactGrid.SelectedItems.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.warning('No Contact Selected', 'Info');", true);
                return;
            }
            else
            {
                //txtMessage.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "newSMSModal();", true);
            }
        }
        static bool MyCertHandler(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors error)
        {
            // Ignore errors
            return true;
        }
        protected void btnSendSMS_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("c:\\QuoteAppLog"))
                Directory.CreateDirectory("c:\\QuoteAppLog");

            int sentsms = 0; int failedsms = 0;
            foreach (GridDataItem item in contactGrid.SelectedItems)
            {
                string id = item["Id"].Text;
                string fullname = item["Fullname"].Text;
                string contactno = item["ContactNo"].Text;
                string message = "";
                try
                {
                    if (String.IsNullOrEmpty(contactno) || contactno.Length != 10)
                    {
                        continue;
                    }
                    WriteToFile("Trying to send message to: " + contactno + " {0}");
                    //////
                    if (contactno.Length == 10)
                        contactno = contactno.Substring(1, 9);
                    else
                        continue;
                    contactno = "233" + contactno;
                    message = txtMessage.Text.Trim();
                    System.Net.ServicePointManager.Expect100Continue = false;
                    string url = "https://txtconnect.co/api/send/";
                    WebClient client = new WebClient();
                    System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection();
                    postData.Add("token", "8d77d40c56a7712aae84012d7edde6427928d348");
                    postData.Add("from", txtHeader.Text.Trim());
                    postData.Add("to", contactno);
                    postData.Add("msg", message);
                    ServicePointManager.ServerCertificateValidationCallback = MyCertHandler;
                    byte[] responseBytes = client.UploadValues(url, postData);
                    string response1 = System.Text.Encoding.ASCII.GetString(responseBytes);

                    WriteToFile("Message sent successfully to: " + contactno + " {0}");
                    sentsms++;
                }
                catch (Exception ex)
                {
                    WriteToFile("Message Sending Error on: {0} " + ex.Message + ex.StackTrace + " {0}");
                    failedsms++;
                }
            }

            if (sentsms > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sent", "toastr.success('" + sentsms + " Message(s) Sent Successfully','Success');", true);
            if (failedsms > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "failed", "toastr.error('" + failedsms + " Message(s) could not be sent','Failed');", true);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "log", "toastr.info('Check messaging log','Log');", true);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closeSMSModal();", true);
        }
        private void WriteToFile(string text)
        {
            string path = "C:\\QuoteAppLog\\ClientReminderLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                writer.Close();
            }
        }
    }
}