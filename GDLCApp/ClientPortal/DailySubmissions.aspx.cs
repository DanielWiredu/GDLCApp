using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDLCApp.ClientPortal
{
    public partial class DailySubmissions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpStartDate.SelectedDate = DateTime.Now;
                dpEndDate.SelectedDate = DateTime.Now;
            }
        }

        protected void txtSearchStaffReq_TextChanged(object sender, EventArgs e)
        {
            //dailyStaffReqGrid.Rebind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dailyStaffReqGrid.Rebind();
        }

        protected void btnExcelExport_Click(object sender, EventArgs e)
        {
            dailyStaffReqGrid.MasterTableView.ExportToExcel();
        }
    }
}