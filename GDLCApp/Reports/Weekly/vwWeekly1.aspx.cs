using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace GDLCApp.Reports.Weekly
{
    public partial class vwWeekly1 : System.Web.UI.Page
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
            string startdate = dpStartDate.SelectedDate.Value.ToString();
            string enddate = dpEndDate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
            if (dlReportType.SelectedText == "Weekly Active Worker Record")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "newModal();", true);
            }
            else if (dlReportType.SelectedText == "Weekly Worker List")
            {
                if (Session["rptWorkerList"] != null)
                    Session.Remove("rptWorkerList");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWorkerList.aspx');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Active Worker List")
            {
                if (Session["rptWeeklyActiveWorkers"] != null)
                    Session.Remove("rptWeeklyActiveWorkers");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyActiveWorkerList.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Active Vessel List")
            {
                if (Session["rptWeeklyActiveVessel"] != null)
                    Session.Remove("rptWeeklyActiveVessel");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyActiveVessel.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Cost Sheet")
            {
                //string reqno = "";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyCostSheet.aspx?reqno=" + reqno + "&st=" + startdate + "&ed=" + enddate + "');", true);

                if (Session["rptWeeklyCostSheet_All"] != null)
                    Session.Remove("rptWeeklyCostSheet_All");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyCostSheet_All.aspx?&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Advice")
            {
                if (Session["rptWeeklyAdviceSheet"] != null)
                    Session.Remove("rptWeeklyAdviceSheet");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyAdviceSheet.aspx?&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Cost Sheet - Unapproved")
            {
                if (Session["rptWeeklyCostSheet_Unapproved"] != null)
                    Session.Remove("rptWeeklyCostSheet_Unapproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyCostSheet_Unapproved.aspx?&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Approved Cost Sheet")
            {
                if (Session["rptWeeklyApprovedCostSheet"] != null)
                    Session.Remove("rptWeeklyApprovedCostSheet");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyApprovedCostSheet.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Processed")
            {
                if (Session["rptWeeklyProcessed"] != null)
                    Session.Remove("rptWeeklyProcessed");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyProcessed.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Processed - New")
            {
                if (Session["rptWeeklyProcessedNew"] != null)
                    Session.Remove("rptWeeklyProcessedNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyProcessedNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Temporal Approved Cost Sheet")
            {
                if (Session["rptWeeklyApproved"] != null)
                    Session.Remove("rptWeeklyApproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyApproved.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Invoice")
            {
                if (Session["rptWeeklyInvoice"] != null)
                    Session.Remove("rptWeeklyInvoice");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Invoice - New")
            {
                if (Session["rptWeeklyInvoiceNew"] != null)
                    Session.Remove("rptWeeklyInvoiceNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyInvoiceNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Payroll")
            {
                if (Session["rptWeeklyPayroll"] != null)
                    Session.Remove("rptWeeklyPayroll");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyPayroll.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Payroll - Individual")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "newModal();", true);
            }
            else if (dlReportType.SelectedText == "Weekly Report Listing")
            {
                if (Session["rptWeeklyReportListing"] != null)
                    Session.Remove("rptWeeklyReportListing");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Statistics")
            {
                if (Session["rptWeeklyStatistics"] != null)
                    Session.Remove("rptWeeklyStatistics");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Statistics - New")
            {
                if (Session["rptWeeklyStatisticsNew"] != null)
                    Session.Remove("rptWeeklyStatisticsNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyStatisticsNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Invoice (Stored)")
            {
                if (Session["rptWeeklyInvoice_Stored"] != null)
                    Session.Remove("rptWeeklyInvoice_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Invoice (Stored) - New")
            {
                if (Session["rptWeeklyInvoice_StoredNew"] != null)
                    Session.Remove("rptWeeklyInvoice_StoredNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyInvoiceNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Report Listing (Stored)")
            {
                if (Session["rptWeeklyReportListing_Stored"] != null)
                    Session.Remove("rptWeeklyReportListing_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Statistics (Stored)")
            {
                if (Session["rptWeeklyStatistics_Stored"] != null)
                    Session.Remove("rptWeeklyStatistics_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Statistics (Stored) - New")
            {
                if (Session["rptWeeklyStatistics_StoredNew"] != null)
                    Session.Remove("rptWeeklyStatistics_StoredNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyStatisticsNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report")
            {
                if (Session["rptWeeklySSF"] != null)
                    Session.Remove("rptWeeklySSF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklySSF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report - Contributors")
            {
                if (Session["rptWeeklySSF_Contributors"] != null)
                    Session.Remove("rptWeeklySSF_Contributors");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklySSF_Contributors.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report - NonContributors")
            {
                if (Session["rptWeeklySSF_NonContributors"] != null)
                    Session.Remove("rptWeeklySSF_NonContributors");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklySSF_NonContributors.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Leave and Bonus")
            {
                if (Session["rptWeeklyLeaveBonus"] != null)
                    Session.Remove("rptWeeklyLeaveBonus");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyLeaveBonus.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Provident Fund")
            {
                if (Session["rptWeeklyPF"] != null)
                    Session.Remove("rptWeeklyPF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyPF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Tax Report")
            {
                if (Session["rptWeeklyTax"] != null)
                    Session.Remove("rptWeeklyTax");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyTax.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Stored Date Range")
            {
                if (Session["rptWeeklyStoredDateRange"] != null)
                    Session.Remove("rptWeeklyStoredDateRange");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyStoredDateRange.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "DISAPPROVED Weekly Report Listing")
            {
                if (Session["rptWeeklyReportListing_Disapproved"] != null)
                    Session.Remove("rptWeeklyReportListing_Disapproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyReportListing_Disapproved.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }
        protected void dlCompany_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = ((DataRowView)e.Item.DataItem)["DLEcodeCompanyName"].ToString();
            e.Item.Value = ((DataRowView)e.Item.DataItem)["DLEcodeCompanyID"].ToString();
        }

        protected void dlCompany_DataBound(object sender, EventArgs e)
        {
            //set the initial footer label
            //((Literal)dlCompany.Footer.FindControl("companyCount")).Text = Convert.ToString(dlCompany.Items.Count);
        }

        protected void dlCompany_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            //String sql = "SELECT top(30) DLEcodeCompanyID,DLEcodeCompanyName FROM [tblDLECompany] WHERE DLEcodeCompanyName LIKE '%" + e.Text.ToUpper() + "%'";
            //dleSource.SelectCommand = sql;
            //dlCompany.DataBind();
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
            if (dlReportTypeByCompany.SelectedText == "Weekly Invoice")
            {
                if (Session["rptWeeklyInvoice_ByCompany"] != null)
                    Session.Remove("rptWeeklyInvoice_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Invoice - New")
            {
                if (Session["rptWeeklyInvoice_ByCompanyNew"] != null)
                    Session.Remove("rptWeeklyInvoice_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyInvoice_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Report Listing")
            {
                if (Session["rptWeeklyReportListing_ByCompany"] != null)
                    Session.Remove("rptWeeklyReportListing_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Processed")
            {
                if (Session["rptWeeklyProcessed_ByCompany"] != null)
                    Session.Remove("rptWeeklyProcessed_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyProcessed_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Processed - New")
            {
                if (Session["rptWeeklyProcessed_ByCompanyNew"] != null)
                    Session.Remove("rptWeeklyProcessed_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyProcessed_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Approved Cost Sheet")
            {
                if (Session["rptWeeklyApprovedCostSheet_ByCompany"] != null)
                    Session.Remove("rptWeeklyApprovedCostSheet_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyApprovedCostSheet_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Statistics")
            {
                if (Session["rptWeeklyStatistics_ByCompany"] != null)
                    Session.Remove("rptWeeklyStatistics_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyStatistics_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Statistics - New")
            {
                if (Session["rptWeeklyStatistics_ByCompanyNew"] != null)
                    Session.Remove("rptWeeklyStatistics_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyStatistics_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Invoice (Stored)")
            {
                if (Session["rptWeeklyInvoice_Stored_ByCompany"] != null)
                    Session.Remove("rptWeeklyInvoice_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Invoice (Stored) - New")
            {
                if (Session["rptWeeklyInvoice_Stored_ByCompanyNew"] != null)
                    Session.Remove("rptWeeklyInvoice_Stored_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyInvoice_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Report Listing (Stored)")
            {
                if (Session["rptWeeklyReportListing_Stored_ByCompany"] != null)
                    Session.Remove("rptWeeklyReportListing_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }
        protected void btnReportByWorker_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
            string startdate = dpStartDate.SelectedDate.Value.ToString();
            string enddate = dpEndDate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
            string workerId = txtWorkerID.Text.Trim();
            txtWorkerID.Text = "";

            if (dlReportType.SelectedText == "Weekly Active Worker Record")
            {
                if (Session["rptWeeklyActiveWorkerRecord"] != null)
                    Session.Remove("rptWeeklyActiveWorkerRecord");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyActiveWorkerRecord.aspx?workerid=" + workerId + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Payroll - Individual")
            {
                if (Session["rptWeeklyPayroll_Individual"] != null)
                    Session.Remove("rptWeeklyPayroll_Individual");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyPayroll_Individual.aspx?workerid=" + workerId + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }
    }
}