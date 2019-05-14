using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace GDLCApp.CustomizePayroll.Tools
{
    public partial class DLEPayrollSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dleGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                Response.Redirect("/CustomizePayroll/Tools/EditDLEPayrollSetup.aspx?DleCompanyId=" + item["DleCompanyId"].Text);
            }
        }

        protected void dleGrid_ItemDeleted(object sender, GridDeletedEventArgs e)
        {

        }
    }
}