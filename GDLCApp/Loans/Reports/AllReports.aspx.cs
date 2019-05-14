using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDLCApp.Loans.Reports
{
    public partial class AllReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpStartDate.SelectedDate = DateTime.Now;
                dpEndDate.SelectedDate = DateTime.Now;
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string startdate = dpStartDate.SelectedDate.Value.ToString();
            string enddate = dpEndDate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
            if (dlReportType.SelectedText == "Loan Master")
            {
                if (Cache["rptLoanMaster"] != null)
                    Cache.Remove("rptLoanMaster");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Loans/Reports/vwLoanMaster.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Loan Repayment Master")
            {
                if (Cache["rptLoanRepaymentAll"] != null)
                    Cache.Remove("rptLoanRepaymentAll");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Loans/Reports/vwLoanRepaymentAll.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Loan Repayment Summary")
            {
                if (Cache["rptLoanRepaymentSummary"] != null)
                    Cache.Remove("rptLoanRepaymentSummary");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Loans/Reports/vwLoanRepaymentSummary.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Loan Repayment Master - Daily")
            {
                if (Cache["rptLoanRepaymentDaily"] != null)
                    Cache.Remove("rptLoanRepaymentDaily");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Loans/Reports/vwLoanRepayments_Daily.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Loan Repayment Master - Weekly")
            {
                if (Cache["rptLoanRepaymentWeekly"] != null)
                    Cache.Remove("rptLoanRepaymentWeekly");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Loans/Reports/vwLoanRepayments_Weekly.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
            else if (dlReportType.SelectedText == "Loan Repayment Master - Monthly")
            {
                if (Cache["rptLoanRepaymentMonthly"] != null)
                    Cache.Remove("rptLoanRepaymentMonthly");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Loans/Reports/vwLoanRepayments_Monthly.aspx?st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }
    }
}