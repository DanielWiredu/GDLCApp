using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace GDLCApp.Reports.Daily
{
    public partial class DailyCostSheet1 : System.Web.UI.Page
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
            if (dlReportType.SelectedText == "Daily Active Worker Record")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "newModal();", true);
            }
            else if (dlReportType.SelectedText == "Labour Request List")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "reqModal();", true);
            }
            else if (dlReportType.SelectedText == "Daily Worker List")
            {
                if (Cache["rptWorkerList"] != null)
                    Cache.Remove("rptWorkerList");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwWorkerList.aspx');", true);
            }
            else if (dlReportType.SelectedText == "Daily Active Worker List")
            {
                if (Cache["rptDailyActiveWorkers"] != null)
                    Cache.Remove("rptDailyActiveWorkers");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyActiveWorkerList.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Active Vessel List")
            {
                if (Cache["rptDailyActiveVessel"] != null)
                    Cache.Remove("rptDailyActiveVessel");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyActiveVessel.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Cost Sheet")
            {
                //string reqno = "";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyCostSheet.aspx?reqno=" + reqno + "&st=" + startdate + "&ed=" + enddate + "');", true);

                if (Cache["rptDailyCostSheet_All"] != null)
                    Cache.Remove("rptDailyCostSheet_All");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyCostSheet_All.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Cost Sheet - Unapproved")
            {
                if (Cache["rptDailyCostSheet_Unapproved"] != null)
                    Cache.Remove("rptDailyCostSheet_Unapproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyCostSheet_Unapproved.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Approved Cost Sheet")
            {
                if (Cache["rptDailyApprovedCostSheet"] != null)
                    Cache.Remove("rptDailyApprovedCostSheet");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyApprovedCostSheet.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Processed")
            {
                if (Cache["rptDailyProcessed"] != null)
                    Cache.Remove("rptDailyProcessed");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyProcessed.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Processed - New")
            {
                if (Cache["rptDailyProcessedNew"] != null)
                    Cache.Remove("rptDailyProcessedNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyProcessedNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Temporal Approved Cost Sheet")
            {
                if (Cache["rptDailyApproved"] != null)
                    Cache.Remove("rptDailyApproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyApproved.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Invoice")
            {
                if (Cache["rptDailyInvoice"] != null)
                    Cache.Remove("rptDailyInvoice");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Invoice - New")
            {
                if (Cache["rptDailyInvoiceNew"] != null)
                    Cache.Remove("rptDailyInvoiceNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyInvoiceNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Payroll")
            {
                if (Cache["rptDailyPayroll"] != null)
                    Cache.Remove("rptDailyPayroll");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyPayroll.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Payroll - Individual")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "newModal();", true);
            }
            else if (dlReportType.SelectedText == "Daily Report Listing")
            {
                if (Cache["rptDailyReportListing"] != null)
                    Cache.Remove("rptDailyReportListing");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Statistics")
            {
                if (Cache["rptDailyStatistics"] != null)
                    Cache.Remove("rptDailyStatistics");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Statistics - New")
            {
                if (Cache["rptDailyStatisticsNew"] != null)
                    Cache.Remove("rptDailyStatisticsNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyStatisticsNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Invoice (Stored)")
            {
                if (Cache["rptDailyInvoice_Stored"] != null)
                    Cache.Remove("rptDailyInvoice_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Invoice (Stored) - New")
            {
                if (Cache["rptDailyInvoice_StoredNew"] != null)
                    Cache.Remove("rptDailyInvoice_StoredNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyInvoiceNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Report Listing (Stored)")
            {
                if (Cache["rptDailyReportListing_Stored"] != null)
                    Cache.Remove("rptDailyReportListing_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Statistics (Stored)")
            {
                if (Cache["rptDailyStatistics_Stored"] != null)
                    Cache.Remove("rptDailyStatistics_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Statistics (Stored) - New")
            {
                if (Cache["rptDailyStatistics_StoredNew"] != null)
                    Cache.Remove("rptDailyStatistics_StoredNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyStatisticsNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report")
            {
                if (Cache["rptDailySSF"] != null)
                    Cache.Remove("rptDailySSF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailySSF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report - Contributors")
            {
                if (Cache["rptDailySSF_Contributors"] != null)
                    Cache.Remove("rptDailySSF_Contributors");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailySSF_Contributors.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report - NonContributors")
            {
                if (Cache["rptDailySSF_NonContributors"] != null)
                    Cache.Remove("rptDailySSF_NonContributors");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailySSF_NonContributors.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Leave and Bonus")
            {
                if (Cache["rptDailyLeaveBonus"] != null)
                    Cache.Remove("rptDailyLeaveBonus");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyLeaveBonus.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Provident Fund")
            {
                if (Cache["rptDailyPF"] != null)
                    Cache.Remove("rptDailyPF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyPF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Tax Report")
            {
                if (Cache["rptDailyTax"] != null)
                    Cache.Remove("rptDailyTax");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyTax.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Stored Date Range")
            {
                if (Cache["rptDailyStoredDateRange"] != null)
                    Cache.Remove("rptDailyStoredDateRange");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyStoredDateRange.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "DISAPPROVED Daily Report Listing")
            {
                if (Cache["rptDailyReportListing_Disapproved"] != null)
                    Cache.Remove("rptDailyReportListing_Disapproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyReportListing_Disapproved.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
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
            if (dlReportTypeByCompany.SelectedText == "Daily Invoice")
            {
                if (Cache["rptDailyInvoice_ByCompany"] != null)
                    Cache.Remove("rptDailyInvoice_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Invoice - New")
            {
                if (Cache["rptDailyInvoice_ByCompanyNew"] != null)
                    Cache.Remove("rptDailyInvoice_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyInvoice_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Report Listing")
            {
                if (Cache["rptDailyReportListing_ByCompany"] != null)
                    Cache.Remove("rptDailyReportListing_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Processed")
            {
                if (Cache["rptDailyProcessed_ByCompany"] != null)
                    Cache.Remove("rptDailyProcessed_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyProcessed_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Processed - New")
            {
                if (Cache["rptDailyProcessed_ByCompanyNew"] != null)
                    Cache.Remove("rptDailyProcessed_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyProcessed_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Approved Cost Sheet")
            {
                if (Cache["rptDailyApprovedCostSheet_ByCompany"] != null)
                    Cache.Remove("rptDailyApprovedCostSheet_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyApprovedCostSheet_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Statictics")
            {
                if (Cache["rptDailyStatistics_ByCompany"] != null)
                    Cache.Remove("rptDailyStatistics_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyStatistics_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Statictics - New")
            {
                if (Cache["rptDailyStatistics_ByCompanyNew"] != null)
                    Cache.Remove("rptDailyStatistics_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyStatistics_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Invoice (Stored)")
            {
                if (Cache["rptDailyInvoice_Stored_ByCompany"] != null)
                    Cache.Remove("rptDailyInvoice_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Invoice (Stored) - New")
            {
                if (Cache["rptDailyInvoice_Stored_ByCompanyNew"] != null)
                    Cache.Remove("rptDailyInvoice_Stored_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyInvoice_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Report Listing (Stored)")
            {
                if (Cache["rptDailyReportListing_Stored_ByCompany"] != null)
                    Cache.Remove("rptDailyReportListing_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }

        protected void btnReportByWorker_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
            string startdate = dpStartDate.SelectedDate.Value.ToString();
            string enddate = dpEndDate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
            string workerId = txtWorkerID.Text.Trim();
            txtWorkerID.Text = "";

            if (dlReportType.SelectedText == "Daily Active Worker Record")
            {
                if (Cache["rptDailyActiveWorkerRecord"] != null)
                    Cache.Remove("rptDailyActiveWorkerRecord");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyActiveWorkerRecord.aspx?workerid=" + workerId + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Payroll - Individual")
            {
                if (Cache["rptDailyPayroll_Individual"] != null)
                    Cache.Remove("rptDailyPayroll_Individual");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyPayroll_Individual.aspx?workerid=" + workerId + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }            
        }

        protected void btnLabourRequestReport_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closereqModal();", true);
            string reqno = txtReqNo.Text.Trim();
            txtReqNo.Text = "";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwLabourRequestList.aspx?reqno=" + reqno + "');", true);
        }
    }
}