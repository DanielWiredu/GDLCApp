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
                if (Session["rptWorkerList"] != null)
                    Session.Remove("rptWorkerList");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwWorkerList.aspx');", true);
            }
            else if (dlReportType.SelectedText == "Daily Active Worker List")
            {
                if (Session["rptDailyActiveWorkers"] != null)
                    Session.Remove("rptDailyActiveWorkers");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyActiveWorkerList.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Active Vessel List")
            {
                if (Session["rptDailyActiveVessel"] != null)
                    Session.Remove("rptDailyActiveVessel");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyActiveVessel.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Cost Sheet")
            {
                //string reqno = "";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyCostSheet.aspx?reqno=" + reqno + "&st=" + startdate + "&ed=" + enddate + "');", true);

                if (Session["rptDailyCostSheet_All"] != null)
                    Session.Remove("rptDailyCostSheet_All");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyCostSheet_All.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Cost Sheet - Unapproved")
            {
                if (Session["rptDailyCostSheet_Unapproved"] != null)
                    Session.Remove("rptDailyCostSheet_Unapproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyCostSheet_Unapproved.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Approved Cost Sheet")
            {
                if (Session["rptDailyApprovedCostSheet"] != null)
                    Session.Remove("rptDailyApprovedCostSheet");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyApprovedCostSheet.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Processed")
            {
                if (Session["rptDailyProcessed"] != null)
                    Session.Remove("rptDailyProcessed");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyProcessed.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Processed - New")
            {
                if (Session["rptDailyProcessedNew"] != null)
                    Session.Remove("rptDailyProcessedNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyProcessedNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Temporal Approved Cost Sheet")
            {
                if (Session["rptDailyApproved"] != null)
                    Session.Remove("rptDailyApproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyApproved.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Invoice")
            {
                if (Session["rptDailyInvoice"] != null)
                    Session.Remove("rptDailyInvoice");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Invoice - New")
            {
                if (Session["rptDailyInvoiceNew"] != null)
                    Session.Remove("rptDailyInvoiceNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyInvoiceNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Payroll")
            {
                if (Session["rptDailyPayroll"] != null)
                    Session.Remove("rptDailyPayroll");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyPayroll.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Payroll - Individual")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "newModal();", true);
            }
            else if (dlReportType.SelectedText == "Daily Report Listing")
            {
                if (Session["rptDailyReportListing"] != null)
                    Session.Remove("rptDailyReportListing");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Statistics")
            {
                if (Session["rptDailyStatistics"] != null)
                    Session.Remove("rptDailyStatistics");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Statistics - New")
            {
                if (Session["rptDailyStatisticsNew"] != null)
                    Session.Remove("rptDailyStatisticsNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyStatisticsNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Invoice (Stored)")
            {
                if (Session["rptDailyInvoice_Stored"] != null)
                    Session.Remove("rptDailyInvoice_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyInvoice.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Invoice (Stored) - New")
            {
                if (Session["rptDailyInvoice_StoredNew"] != null)
                    Session.Remove("rptDailyInvoice_StoredNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyInvoiceNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Report Listing (Stored)")
            {
                if (Session["rptDailyReportListing_Stored"] != null)
                    Session.Remove("rptDailyReportListing_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyReportListing.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Statistics (Stored)")
            {
                if (Session["rptDailyStatistics_Stored"] != null)
                    Session.Remove("rptDailyStatistics_Stored");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyStatistics.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Statistics (Stored) - New")
            {
                if (Session["rptDailyStatistics_StoredNew"] != null)
                    Session.Remove("rptDailyStatistics_StoredNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyStatisticsNew.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report")
            {
                if (Session["rptDailySSF"] != null)
                    Session.Remove("rptDailySSF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailySSF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report - Contributors")
            {
                if (Session["rptDailySSF_Contributors"] != null)
                    Session.Remove("rptDailySSF_Contributors");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailySSF_Contributors.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "SSF Report - NonContributors")
            {
                if (Session["rptDailySSF_NonContributors"] != null)
                    Session.Remove("rptDailySSF_NonContributors");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailySSF_NonContributors.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Leave and Bonus")
            {
                if (Session["rptDailyLeaveBonus"] != null)
                    Session.Remove("rptDailyLeaveBonus");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyLeaveBonus.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Provident Fund")
            {
                if (Session["rptDailyPF"] != null)
                    Session.Remove("rptDailyPF");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyPF.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Tax Report")
            {
                if (Session["rptDailyTax"] != null)
                    Session.Remove("rptDailyTax");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyTax.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Stored Date Range")
            {
                if (Session["rptDailyStoredDateRange"] != null)
                    Session.Remove("rptDailyStoredDateRange");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyStoredDateRange.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "DISAPPROVED Daily Report Listing")
            {
                if (Session["rptDailyReportListing_Disapproved"] != null)
                    Session.Remove("rptDailyReportListing_Disapproved");
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
            if (dlReportTypeByCompany.SelectedText == "Daily Cost Sheet")
            {
                if (Session["rptDailyCostSheet_ByCompany"] != null)
                    Session.Remove("rptDailyCostSheet_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyCostSheet_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Invoice")
            {
                if (Session["rptDailyInvoice_ByCompany"] != null)
                    Session.Remove("rptDailyInvoice_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Invoice - New")
            {
                if (Session["rptDailyInvoice_ByCompanyNew"] != null)
                    Session.Remove("rptDailyInvoice_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyInvoice_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Report Listing")
            {
                if (Session["rptDailyReportListing_ByCompany"] != null)
                    Session.Remove("rptDailyReportListing_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyReportListing_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Processed")
            {
                if (Session["rptDailyProcessed_ByCompany"] != null)
                    Session.Remove("rptDailyProcessed_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyProcessed_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Processed - New")
            {
                if (Session["rptDailyProcessed_ByCompanyNew"] != null)
                    Session.Remove("rptDailyProcessed_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyProcessed_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Approved Cost Sheet")
            {
                if (Session["rptDailyApprovedCostSheet_ByCompany"] != null)
                    Session.Remove("rptDailyApprovedCostSheet_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyApprovedCostSheet_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Statictics")
            {
                if (Session["rptDailyStatistics_ByCompany"] != null)
                    Session.Remove("rptDailyStatistics_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyStatistics_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Statictics - New")
            {
                if (Session["rptDailyStatistics_ByCompanyNew"] != null)
                    Session.Remove("rptDailyStatistics_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Approved/vwDailyStatistics_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Invoice (Stored)")
            {
                if (Session["rptDailyInvoice_Stored_ByCompany"] != null)
                    Session.Remove("rptDailyInvoice_Stored_ByCompany");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyInvoice_ByCompany.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Invoice (Stored) - New")
            {
                if (Session["rptDailyInvoice_Stored_ByCompanyNew"] != null)
                    Session.Remove("rptDailyInvoice_Stored_ByCompanyNew");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/Stored/vwDailyInvoice_ByCompanyNew.aspx?comps=" + companies + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportTypeByCompany.SelectedText == "Daily Report Listing (Stored)")
            {
                if (Session["rptDailyReportListing_Stored_ByCompany"] != null)
                    Session.Remove("rptDailyReportListing_Stored_ByCompany");
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
                if (Session["rptDailyActiveWorkerRecord"] != null)
                    Session.Remove("rptDailyActiveWorkerRecord");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyActiveWorkerRecord.aspx?workerid=" + workerId + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Daily Payroll - Individual")
            {
                if (Session["rptDailyPayroll_Individual"] != null)
                    Session.Remove("rptDailyPayroll_Individual");
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