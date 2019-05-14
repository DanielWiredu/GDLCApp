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
                if (Cache["rptWorkerList"] != null)
                    Cache.Remove("rptWorkerList");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWorkerList.aspx');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Active Worker List")
            {
                if (Cache["rptWeeklyActiveWorkers"] != null)
                    Cache.Remove("rptWeeklyActiveWorkers");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyActiveWorkerList.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Active Vessel List")
            {
                if (Cache["rptWeeklyActiveVessel"] != null)
                    Cache.Remove("rptWeeklyActiveVessel");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyActiveVessel.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Cost Sheet")
            {
                //string reqno = "";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyCostSheet.aspx?reqno=" + reqno + "&st=" + startdate + "&ed=" + enddate + "');", true);

                if (Cache["rptWeeklyCostSheet_All"] != null)
                    Cache.Remove("rptWeeklyCostSheet_All");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyCostSheet_All.aspx?&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Cost Sheet - Unapproved")
            {
                if (Cache["rptWeeklyCostSheet_Unapproved"] != null)
                    Cache.Remove("rptWeeklyCostSheet_Unapproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyCostSheet_Unapproved.aspx?&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Approved Cost Sheet")
            {
                if (Cache["rptWeeklyApprovedCostSheet"] != null)
                    Cache.Remove("rptWeeklyApprovedCostSheet");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyApprovedCostSheet.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Processed")
            {
                if (Cache["rptWeeklyProcessed"] != null)
                    Cache.Remove("rptWeeklyProcessed");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyProcessed.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Processed - New")
            {
                if (Cache["rptWeeklyProcessedNew"] != null)
                    Cache.Remove("rptWeeklyProcessedNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyProcessedNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Temporal Approved Cost Sheet")
            {
                if (Cache["rptWeeklyApproved"] != null)
                    Cache.Remove("rptWeeklyApproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyApproved.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Invoice")
            {
                if (Cache["rptWeeklyInvoice"] != null)
                    Cache.Remove("rptWeeklyInvoice");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Invoice - New")
            {
                if (Cache["rptWeeklyInvoiceNew"] != null)
                    Cache.Remove("rptWeeklyInvoiceNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyInvoiceNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Payroll")
            {
                if (Cache["rptWeeklyPayroll"] != null)
                    Cache.Remove("rptWeeklyPayroll");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyPayroll.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Payroll - Individual")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "newModal();", true);
            }
            else if (dlReportType.SelectedText == "Weekly Report Listing")
            {
                if (Cache["rptWeeklyReportListing"] != null)
                    Cache.Remove("rptWeeklyReportListing");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Statistics")
            {
                if (Cache["rptWeeklyStatistics"] != null)
                    Cache.Remove("rptWeeklyStatistics");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Statistics - New")
            {
                if (Cache["rptWeeklyStatisticsNew"] != null)
                    Cache.Remove("rptWeeklyStatisticsNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyStatisticsNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Invoice (Stored)")
            {
                if (Cache["rptWeeklyInvoice_Stored"] != null)
                    Cache.Remove("rptWeeklyInvoice_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Invoice (Stored) - New")
            {
                if (Cache["rptWeeklyInvoice_StoredNew"] != null)
                    Cache.Remove("rptWeeklyInvoice_StoredNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyInvoiceNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Report Listing (Stored)")
            {
                if (Cache["rptWeeklyReportListing_Stored"] != null)
                    Cache.Remove("rptWeeklyReportListing_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Statistics (Stored)")
            {
                if (Cache["rptWeeklyStatistics_Stored"] != null)
                    Cache.Remove("rptWeeklyStatistics_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Statistics (Stored) - New")
            {
                if (Cache["rptWeeklyStatistics_StoredNew"] != null)
                    Cache.Remove("rptWeeklyStatistics_StoredNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyStatisticsNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report")
            {
                if (Cache["rptWeeklySSF"] != null)
                    Cache.Remove("rptWeeklySSF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklySSF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report - Contributors")
            {
                if (Cache["rptWeeklySSF_Contributors"] != null)
                    Cache.Remove("rptWeeklySSF_Contributors");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklySSF_Contributors.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report - NonContributors")
            {
                if (Cache["rptWeeklySSF_NonContributors"] != null)
                    Cache.Remove("rptWeeklySSF_NonContributors");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklySSF_NonContributors.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Leave and Bonus")
            {
                if (Cache["rptWeeklyLeaveBonus"] != null)
                    Cache.Remove("rptWeeklyLeaveBonus");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyLeaveBonus.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Provident Fund")
            {
                if (Cache["rptWeeklyPF"] != null)
                    Cache.Remove("rptWeeklyPF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyPF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Tax Report")
            {
                if (Cache["rptWeeklyTax"] != null)
                    Cache.Remove("rptWeeklyTax");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyTax.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Stored Date Range")
            {
                if (Cache["rptWeeklyStoredDateRange"] != null)
                    Cache.Remove("rptWeeklyStoredDateRange");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyStoredDateRange.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "DISAPPROVED Weekly Report Listing")
            {
                if (Cache["rptWeeklyReportListing_Disapproved"] != null)
                    Cache.Remove("rptWeeklyReportListing_Disapproved");
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
                if (Cache["rptWeeklyInvoice_ByCompany"] != null)
                    Cache.Remove("rptWeeklyInvoice_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Invoice - New")
            {
                if (Cache["rptWeeklyInvoice_ByCompanyNew"] != null)
                    Cache.Remove("rptWeeklyInvoice_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyInvoice_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Report Listing")
            {
                if (Cache["rptWeeklyReportListing_ByCompany"] != null)
                    Cache.Remove("rptWeeklyReportListing_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Processed")
            {
                if (Cache["rptWeeklyProcessed_ByCompany"] != null)
                    Cache.Remove("rptWeeklyProcessed_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyProcessed_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Processed - New")
            {
                if (Cache["rptWeeklyProcessed_ByCompanyNew"] != null)
                    Cache.Remove("rptWeeklyProcessed_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyProcessed_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Approved Cost Sheet")
            {
                if (Cache["rptWeeklyApprovedCostSheet_ByCompany"] != null)
                    Cache.Remove("rptWeeklyApprovedCostSheet_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyApprovedCostSheet_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Statistics")
            {
                if (Cache["rptWeeklyStatistics_ByCompany"] != null)
                    Cache.Remove("rptWeeklyStatistics_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyStatistics_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Statistics - New")
            {
                if (Cache["rptWeeklyStatistics_ByCompanyNew"] != null)
                    Cache.Remove("rptWeeklyStatistics_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyStatistics_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Invoice (Stored)")
            {
                if (Cache["rptWeeklyInvoice_Stored_ByCompany"] != null)
                    Cache.Remove("rptWeeklyInvoice_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Invoice (Stored) - New")
            {
                if (Cache["rptWeeklyInvoice_Stored_ByCompanyNew"] != null)
                    Cache.Remove("rptWeeklyInvoice_Stored_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Stored/vwWeeklyInvoice_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Weekly Report Listing (Stored)")
            {
                if (Cache["rptWeeklyReportListing_Stored_ByCompany"] != null)
                    Cache.Remove("rptWeeklyReportListing_Stored_ByCompany");
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
                if (Cache["rptWeeklyActiveWorkerRecord"] != null)
                    Cache.Remove("rptWeeklyActiveWorkerRecord");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/General/vwWeeklyActiveWorkerRecord.aspx?workerid=" + workerId + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Weekly Payroll - Individual")
            {
                if (Cache["rptWeeklyPayroll_Individual"] != null)
                    Cache.Remove("rptWeeklyPayroll_Individual");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Weekly/Approved/vwWeeklyPayroll_Individual.aspx?workerid=" + workerId + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }
    }
}