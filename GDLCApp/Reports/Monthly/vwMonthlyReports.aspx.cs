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
                if (Session["rptMonthlyPreviewCostSheet"] != null)
                    Session.Remove("rptMonthlyPreviewCostSheet");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/General/vwMonthlyPreviewCostSheet.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Approved Cost Sheet")
            {
                if (Session["rptMonthlyApprovedCostSheet"] != null)
                    Session.Remove("rptMonthlyApprovedCostSheet");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyApprovedCostSheet.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Payroll - Individual")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "newModal();", true);
            }
            else if (dlReportType.SelectedText == "Monthly Bank Payment")
            {
                if (Session["rptMonthlyBankPayment"] != null)
                    Session.Remove("rptMonthlyBankPayment");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyBankPayment.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Processed")
            {
                if (Session["rptMonthlyProcessed"] != null)
                    Session.Remove("rptMonthlyProcessed");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyProcessed.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Invoice")
            {
                if (Session["rptMonthlyInvoice"] != null)
                    Session.Remove("rptMonthlyInvoice");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Invoice Summary")
            {
                if (Session["rptMonthlyInvoiceSummary"] != null)
                    Session.Remove("rptMonthlyInvoiceSummary");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyInvoiceSummary.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Report Listing")
            {
                if (Session["rptMonthlyReportListing"] != null)
                    Session.Remove("rptMonthlyReportListing");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Report Listing - Preview")
            {
                if (Session["rptMonthlyReportListingPreview"] != null)
                    Session.Remove("rptMonthlyReportListingPreview");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/General/vwMonthlyReportListingPreview.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Statistics")
            {
                if (Session["rptMonthlyStatistics"] != null)
                    Session.Remove("rptMonthlyStatistics");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly SSF (Approved)")
            {
                if (Session["rptMonthlySSF_Approved"] != null)
                    Session.Remove("rptMonthlySSF_Approved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlySSF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            //STORED REPORTS BELOW
            else if (dlReportType.SelectedText == "Monthly Invoice (Stored)")
            {
                if (Session["rptMonthlyInvoice_Stored"] != null)
                    Session.Remove("rptMonthlyInvoice_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Invoice Summary (Stored)")
            {
                if (Session["rptMonthlyInvoiceSummary_Stored"] != null)
                    Session.Remove("rptMonthlyInvoiceSummary_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyInvoiceSummary.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Report Listing (Stored)")
            {
                if (Session["rptMonthlyReportListing_Stored"] != null)
                    Session.Remove("rptMonthlyReportListing_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Statistics (Stored)")
            {
                if (Session["rptMonthlyStatistics_Stored"] != null)
                    Session.Remove("rptMonthlyStatistics_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report")
            {
                if (Session["rptMonthlySSF"] != null)
                    Session.Remove("rptMonthlySSF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlySSF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Leave and Bonus")
            {
                if (Session["rptMonthlyLeaveBonus"] != null)
                    Session.Remove("rptMonthlyLeaveBonus");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyLeaveBonus.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Provident Fund")
            {
                if (Session["rptMonthlyPF"] != null)
                    Session.Remove("rptMonthlyPF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyPF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Tax Report")
            {
                if (Session["rptMonthlyTax"] != null)
                    Session.Remove("rptMonthlyTax");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyTax.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "DISAPPROVED Monthly Report Listing")
            {
                if (Session["rptMonthlyReportListing_Disapproved"] != null)
                    Session.Remove("rptMonthlyReportListing_Disapproved");
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
                if (Session["rptMonthlyBankPayment_ByCompany"] != null)
                    Session.Remove("rptMonthlyBankPayment_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyBankPayment_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Invoice")
            {
                if (Session["rptMonthlyInvoice_ByCompany"] != null)
                    Session.Remove("rptMonthlyInvoice_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Invoice Summary")
            {
                if (Session["rptMonthlyInvoiceSummary_ByCompany"] != null)
                    Session.Remove("rptMonthlyInvoiceSummary_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyInvoiceSummary_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Processed")
            {
                if (Session["rptMonthlyProcessed_ByCompany"] != null)
                    Session.Remove("rptMonthlyProcessed_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyProcessed_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Approved Cost Sheet")
            {
                if (Session["rptMonthlyApprovedCostSheet_ByCompany"] != null)
                    Session.Remove("rptMonthlyApprovedCostSheet_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyApprovedCostSheet_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Report Listing")
            {
                if (Session["rptMonthlyReportListing_ByCompany"] != null)
                    Session.Remove("rptMonthlyReportListing_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Approved/vwMonthlyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            //STORED REPORTS BELOW
            else if (dlReportTypeByCompany.SelectedText == "Monthly Invoice (Stored)")
            {
                if (Session["rptMonthlyInvoice_Stored_ByCompany"] != null)
                    Session.Remove("rptMonthlyInvoice_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Invoice Summary (Stored)")
            {
                if (Session["rptMonthlyInvoiceSummary_Stored_ByCompany"] != null)
                    Session.Remove("rptMonthlyInvoiceSummary_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyInvoiceSummary_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Monthly Report Listing (Stored)")
            {
                if (Session["rptMonthlyReportListing_Stored_ByCompany"] != null)
                    Session.Remove("rptMonthlyReportListing_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Leave and Bonus Payslip")
            {
                if (Session["rptMonthlyLeaveBonusPaySlip"] != null)
                    Session.Remove("rptMonthlyLeaveBonusPaySlip");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyLeaveBonusPaySlip.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Leave and Bonus")
            {
                if (Session["rptMonthlyLeaveBonus_ByCompany"] != null)
                    Session.Remove("rptMonthlyLeaveBonus_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyLeaveBonus_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Provident Fund")
            {
                if (Session["rptMonthlyPF_ByCompany"] != null)
                    Session.Remove("rptMonthlyPF_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/Stored/vwMonthlyPF_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
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
                if (Session["rptMonthlyActiveWorkerRecord"] != null)
                    Session.Remove("rptMonthlyActiveWorkerRecord");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Monthly/General/vwMonthlyActiveWorkerRecord.aspx');", true);
            }
            else if (dlReportType.SelectedText == "Monthly Payroll - Individual")
            {
                if (Session["rptMonthlyPayroll_Individual"] != null)
                    Session.Remove("rptMonthlyPayroll_Individual");
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