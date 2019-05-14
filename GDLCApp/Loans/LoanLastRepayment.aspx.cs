using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDLCApp.Loans
{
    public partial class LoanLastRepayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loanGrid.Rebind();
        }

        protected void btnExcelExport_Click(object sender, EventArgs e)
        {
            loanGrid.MasterTableView.ExportToExcel();
        }
    }
}