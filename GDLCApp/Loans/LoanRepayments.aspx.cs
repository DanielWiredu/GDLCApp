using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace GDLCApp.Loans
{
    public partial class LoanRepayments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dailyStaffReqGrid.DataSource = GetDataTable();
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //loanSource.SelectCommand = "SELECT TOP (30) AutoNo, ReqNo, date_, Approved, DLEcodeCompanyName, VesselName, ReportingPoint FROM vwDailyReq WHERE (ReqNo LIKE '%' + @ReqNo + '%') ORDER BY AutoNo";
            loanGrid.Rebind();
        }

        protected void loanGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridDataItem item = e.Item as GridDataItem;
                Response.Redirect("/Loans/IndLoanRepayment.aspx?loanno=" + item["LoanNo"].Text);
            }
        }
    }
}