using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using CrystalDecisions.Shared;
using System.Drawing.Printing;

namespace GDLCApp.Reports
{
    public partial class vwWorkerList_Tagged : System.Web.UI.Page
    {
        rptWorkerList_Tagged rpt = new rptWorkerList_Tagged();
        protected void Page_Init(object sender, EventArgs e)
        {
            string cachedReports = "rptWorkerList_Tagged";
            if (Session[cachedReports] == null)
            {
                loadReport(cachedReports);
            }
            else
            {
                WorkerListTaggedReport.ReportSource = Session[cachedReports];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GenerateReport();
                getPrinters();
            }
        }

        protected void loadReport(string cachedReports)
        {
            //int rptCacheTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("rptCacheTimeout").ToString());
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter("select * from vwWorkerList_Tagged", connection);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwWorkerList_Tagged");
            rpt.SetDataSource(ds);

            adapter.Dispose();
            connection.Dispose();
            //Cache.Insert(cachedReports, rpt, null, DateTime.MaxValue, TimeSpan.FromMinutes(rptCacheTimeout));
            Session[cachedReports] = rpt;
            WorkerListTaggedReport.ReportSource = rpt;
        }

        //protected void ExportReport()
        //{
        //    MemoryStream oStream = new MemoryStream();
        //    switch (DropDownList1.SelectedItem.Text)
        //    {
        //        case "Rich Text (RTF)":
        //            oStream = rpt.ExportToStream(ExportFormatType.WordForWindows) as MemoryStream;
        //            Response.Clear();
        //            Response.Buffer = true;
        //            Response.ContentType = "application/rtf";
        //            break;
        //        case "Portable Document (PDF)":
        //            oStream = rpt.ExportToStream(ExportFormatType.PortableDocFormat) as MemoryStream;
        //            Response.Clear();
        //            Response.Buffer = true;
        //            Response.ContentType = "application/pdf";
        //            //rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Context.Response, false, String.Empty);
        //            break;
        //        case "MS Word (DOC)":
        //            oStream = rpt.ExportToStream(ExportFormatType.WordForWindows) as MemoryStream;
        //            Response.Clear();
        //            Response.Buffer = true;
        //            Response.ContentType = "application/docx";
        //            break;
        //        case "MS Excel (XLS)":
        //            oStream = rpt.ExportToStream(ExportFormatType.Excel) as MemoryStream;
        //            Response.Clear();
        //            Response.Buffer = true;
        //            Response.ContentType = "application/vnd.ms-excel";
        //            break;
        //    }

        //    try
        //    {
        //        Response.BinaryWrite(oStream.ToArray());
        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<BR>");
        //        Response.Write(ex.Message);
        //    }

        //}
        protected void btnExport_Click(object sender, EventArgs e)
        {
            //ExportReport();
            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Context.Response, false, String.Empty);
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            rpt.PrintToPrinter(1, false, 1, 1);
        }
        protected void getPrinters()
        {
            if (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count > 0)
            {
                foreach (String myPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cboCurrentPrinters.Items.Add(myPrinter);
                }
                cboCurrentPrinters.SelectedIndex = 0;
            }
            else
            {
                //rdoCurrent.Enabled = false;
                //EnableDisableCurrentControls(false);
            }
            //For printers exposed to System account as per MS Kbase 
            ////http://support.microsoft.com/default.aspx?scid=kb;en-us;184291

            ////Look to HKEY_USERS\.Default\Software\Microsoft\Windows NT\CurrentVersion\Devices
            //Microsoft.Win32.RegistryKey mySystemPrinters =
            //    Microsoft.Win32.Registry.Users.OpenSubKey(@".DEFAULT\Software\Microsoft\Windows NT\CurrentVersion\Devices");
            //foreach (String defaultPrinters in mySystemPrinters.GetValueNames())
            //{
            //    cboDefaultPrinters.Items.Add(defaultPrinters);
            //}
            //if (cboDefaultPrinters.Items.Count > 0)
            //{
            //    cboDefaultPrinters.SelectedIndex = 0;
            //}
            //else
            //{
            //    rdoDefault.Enabled = false;
            //}
        }

        protected void btnPrinttoPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                rpt.PrintOptions.PrinterName = cboCurrentPrinters.SelectedItem.Text;
                rpt.PrintToPrinter(1, false, 1, 1);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert","alert('No Printer Selected');", true);
            }
        }
    }
}