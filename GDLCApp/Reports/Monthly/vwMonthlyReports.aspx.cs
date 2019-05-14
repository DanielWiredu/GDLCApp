using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace GDLCApp.Reports.Monthly
{
    public partial class vwMonthlyReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpStartDate.SelectedDate = DateTime.Now;
                dpEndDate.SelectedDate = DateTime.Now;

                dpSdate.SelectedDate = DateTime.Now;
                dpEdate.SelectedDate = DateTime.Now;
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            //foreach (System.Collections.DictionaryEntry entry in HttpContext.Current.Cache)
            //{
            //    HttpContext.Current.Cache.Remove((string)entry.Key);
            //}

            //Response.Cache.SetExpires(DateTime.Now);
            //Response.Cache.SetNoServerCaching();
            //Response.Cache.SetNoStore();

            string startdate = dpStartDate.SelectedDate.Value.ToString();
            string enddate = dpEndDate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
            if (dlReportType.SelectedText == "Monthly Cost Sheet")
            {
                string reqno = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/General/vwMonthlyCostSheet.aspx?reqno=" + reqno + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Preview Cost Sheet")
            {
                if (Cache["rptMonthlyPreviewCostSheet"] != null)
                    Cache.Remove("rptMonthlyPreviewCostSheet");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/General/vwMonthlyPreviewCostSheet.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Approved Cost Sheet")
            {
                if (Cache["rptMonthlyApprovedCostSheet"] != null)
                    Cache.Remove("rptMonthlyApprovedCostSheet");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyApprovedCostSheet.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Payroll - Individual")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "newModal();", true);
            }
            else if (dlReportType.SelectedText == "Monthly Bank Payment")
            {
                if (Cache["rptMonthlyBankPayment"] != null)
                    Cache.Remove("rptMonthlyBankPayment");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyBankPayment.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Processed")
            {
                if (Cache["rptMonthlyProcessed"] != null)
                    Cache.Remove("rptMonthlyProcessed");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyProcessed.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Invoice")
            {
                if (Cache["rptMonthlyInvoice"] != null)
                    Cache.Remove("rptMonthlyInvoice");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Invoice Summary")
            {
                if (Cache["rptMonthlyInvoiceSummary"] != null)
                    Cache.Remove("rptMonthlyInvoiceSummary");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyInvoiceSummary.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Report Listing")
            {
                if (Cache["rptMonthlyReportListing"] != null)
                    Cache.Remove("rptMonthlyReportListing");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Report Listing - Preview")
            {
                if (Cache["rptMonthlyReportListingPreview"] != null)
                    Cache.Remove("rptMonthlyReportListingPreview");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/General/vwMonthlyReportListingPreview.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Statistics")
            {
                if (Cache["rptMonthlyStatistics"] != null)
                    Cache.Remove("rptMonthlyStatistics");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly SSF (Approved)")
            {
                if (Cache["rptMonthlySSF_Approved"] != null)
                    Cache.Remove("rptMonthlySSF_Approved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlySSF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            //STORED REPORTS BELOW
            else if (dlReportType.SelectedText == "Monthly Invoice (Stored)")
            {
                if (Cache["rptMonthlyInvoice_Stored"] != null)
                    Cache.Remove("rptMonthlyInvoice_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Invoice Summary (Stored)")
            {
                if (Cache["rptMonthlyInvoiceSummary_Stored"] != null)
                    Cache.Remove("rptMonthlyInvoiceSummary_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyInvoiceSummary.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Report Listing (Stored)")
            {
                if (Cache["rptMonthlyReportListing_Stored"] != null)
                    Cache.Remove("rptMonthlyReportListing_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Statistics (Stored)")
            {
                if (Cache["rptMonthlyStatistics_Stored"] != null)
                    Cache.Remove("rptMonthlyStatistics_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report")
            {
                if (Cache["rptMonthlySSF"] != null)
                    Cache.Remove("rptMonthlySSF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlySSF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Leave and Bonus")
            {
                if (Cache["rptMonthlyLeaveBonus"] != null)
                    Cache.Remove("rptMonthlyLeaveBonus");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyLeaveBonus.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Provident Fund")
            {
                if (Cache["rptMonthlyPF"] != null)
                    Cache.Remove("rptMonthlyPF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyPF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Tax Report")
            {
                if (Cache["rptMonthlyTax"] != null)
                    Cache.Remove("rptMonthlyTax");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyTax.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "DISAPPROVED Monthly Report Listing")
            {
                if (Cache["rptMonthlyReportListing_Disapproved"] != null)
                    Cache.Remove("rptMonthlyReportListing_Disapproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyReportListing_Disapproved.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string companies = "";
            foreach (RadComboBoxItem item in dlCompanies.CheckedItems)
            {
                companies += item.Value + ",";
            }
            companies = companies.TrimEnd(',');

            if (companies == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Please select a Company','Error')", true);
                return;
            }

            string startdate = dpSdate.SelectedDate.Value.ToString();
            string enddate = dpEdate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
            if (dlReportTypeByCompany.SelectedText == "Monthly Bank Payment")
            {
                if (Cache["rptMonthlyBankPayment_ByCompany"] != null)
                    Cache.Remove("rptMonthlyBankPayment_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyBankPayment_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Invoice")
            {
                if (Cache["rptMonthlyInvoice_ByCompany"] != null)
                    Cache.Remove("rptMonthlyInvoice_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Invoice Summary")
            {
                if (Cache["rptMonthlyInvoiceSummary_ByCompany"] != null)
                    Cache.Remove("rptMonthlyInvoiceSummary_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyInvoiceSummary_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Processed")
            {
                if (Cache["rptMonthlyProcessed_ByCompany"] != null)
                    Cache.Remove("rptMonthlyProcessed_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyProcessed_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Approved Cost Sheet")
            {
                if (Cache["rptMonthlyApprovedCostSheet_ByCompany"] != null)
                    Cache.Remove("rptMonthlyApprovedCostSheet_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyApprovedCostSheet_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Report Listing")
            {
                if (Cache["rptMonthlyReportListing_ByCompany"] != null)
                    Cache.Remove("rptMonthlyReportListing_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            //STORED REPORTS BELOW
            else if (dlReportTypeByCompany.SelectedText == "Monthly Invoice (Stored)")
            {
                if (Cache["rptMonthlyInvoice_Stored_ByCompany"] != null)
                    Cache.Remove("rptMonthlyInvoice_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Invoice Summary (Stored)")
            {
                if (Cache["rptMonthlyInvoiceSummary_Stored_ByCompany"] != null)
                    Cache.Remove("rptMonthlyInvoiceSummary_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyInvoiceSummary_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Report Listing (Stored)")
            {
                if (Cache["rptMonthlyReportListing_Stored_ByCompany"] != null)
                    Cache.Remove("rptMonthlyReportListing_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }

        protected void btnReportByWorker_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
            string startdate = dpStartDate.SelectedDate.Value.ToString();
            string enddate = dpEndDate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
            string workerId = txtWorkerID.Text.Trim();
            txtWorkerID.Text = "";

            if (dlReportType.SelectedText == "Monthly Active Worker Record")
            {
                if (Cache["rptMonthlyActiveWorkerRecord"] != null)
                    Cache.Remove("rptMonthlyActiveWorkerRecord");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/General/vwMonthlyActiveWorkerRecord.aspx');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Payroll - Individual")
            {
                if (Cache["rptMonthlyPayroll_Individual"] != null)
                    Cache.Remove("rptMonthlyPayroll_Individual");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyPayroll_Individual.aspx?workerid=" + workerId + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }

        protected void btnLabourRequestReport_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closereqModal();", true);
            string reqno = txtReqNo.Text.Trim();
            txtReqNo.Text = "";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/General/vwLabourRequestList.aspx');", true);
        }
    }
}