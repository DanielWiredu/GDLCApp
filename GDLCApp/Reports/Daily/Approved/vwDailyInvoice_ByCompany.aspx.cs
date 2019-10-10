using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Net;
using System.Net.Mail;

namespace GDLCApp.Reports.Daily.Approved
{
    public partial class vwDailyInvoice_ByCompany : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string cachedReports = "rptDailyInvoice_ByCompany";

            //int rptCacheTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("rptCacheTimeout").ToString());

            if (Session[cachedReports] == null)
            {
                ReportDocument rd = new rptDailyInvoice();
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                string startdate = Request.QueryString["st"].ToString();
                string enddate = Request.QueryString["ed"].ToString();
                string companies = Request.QueryString["comps"].ToString();
                ParameterValues parameters = new ParameterValues();
                ParameterDiscreteValue sdate = new ParameterDiscreteValue();
                ParameterDiscreteValue edate = new ParameterDiscreteValue();
                sdate.Value = startdate;
                edate.Value = enddate;
                adapter = new SqlDataAdapter("spGetDailyInvoiceByCompany", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@companies", SqlDbType.VarChar).Value = companies;
                adapter.SelectCommand.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startdate;
                adapter.SelectCommand.Parameters.Add("@enddate", SqlDbType.DateTime).Value = enddate;
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                adapter.Fill(ds, "vwDailyInvoice");
                //rd.Load(Server.MapPath("rptDailyInvoice.rpt"));
                rd.SetDataSource(ds);
                parameters.Add(sdate);
                rd.DataDefinition.ParameterFields["Startdate"].ApplyCurrentValues(parameters);
                parameters.Add(edate);
                rd.DataDefinition.ParameterFields["Enddate"].ApplyCurrentValues(parameters);
                adapter.Dispose();
                connection.Dispose();
                //Cache.Insert(cachedReports, rd, null, DateTime.MaxValue, TimeSpan.FromMinutes(rptCacheTimeout));
                Session[cachedReports] = rd;
                DailyInvoiceReport_ByCompany.ReportSource = rd;
            }
            else
            {
                DailyInvoiceReport_ByCompany.ReportSource = Session[cachedReports];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            //ExportFormatType formatType = ExportFormatType.NoFormat;
            //string fileName = "Daily Invoice";
            //string fileExt = "";
            //switch (rbFormat.SelectedItem.Value)
            //{
            //    case "PDF":
            //        formatType = ExportFormatType.PortableDocFormat;
            //        fileExt = ".pdf";
            //        break;
            //    case "Excel":
            //        formatType = ExportFormatType.Excel;
            //        fileExt = ".xls";
            //        break;
            //}
            //try
            //{
            //    ReportDocument crystalReport = (ReportDocument) Cache["rptDailyInvoice_ByCompany"];
            //    using (MailMessage mm = new MailMessage())
            //    {
            //        mm.From = new MailAddress("daniel.wiredu@eupacwebs.com", "EUPAC Dan");
            //        mm.To.Add(new MailAddress("danielwiredu@gmail.com", "Daniel Wire10"));
            //        mm.CC.Add(new MailAddress("info@eupacwebs.com", "EUPAC Info"));
            //        mm.Subject = "GDLC Daily Invoice";
            //        mm.Body = string.Format("Hello Employer, Please be reminded that you have <b>0 expiring/expired lead(s)</b>, <b>0 expiring policy(ies)</b> and <b>0 expired policy(ies)</b>.<br />Kindly remind your clients. Thank you.");
            //        mm.IsBodyHtml = true;
            //        if (!String.IsNullOrEmpty(fileExt))
            //        {
            //            mm.Attachments.Add(new Attachment(crystalReport.ExportToStream(formatType), fileName + fileExt));
            //        }
            //        else
            //        {
            //            mm.Attachments.Add(new Attachment(crystalReport.ExportToStream(ExportFormatType.PortableDocFormat), fileName + ".pdf"));
            //            mm.Attachments.Add(new Attachment(crystalReport.ExportToStream(ExportFormatType.Excel), fileName + ".xls"));
            //        }
                    
            //        SmtpClient smtp = new SmtpClient();
            //        smtp.Send(mm);
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Email Sent Successfully');", true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('"+ ex.Message + "');", true);
            //}
        }
    }
}