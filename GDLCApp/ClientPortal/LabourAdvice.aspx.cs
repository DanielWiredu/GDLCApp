﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace GDLCApp.ClientPortal
{
    public partial class LabourAdvice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void txtSearchStaffReq_TextChanged(object sender, EventArgs e)
        {
            weeklyAdviceGrid.Rebind();
        }
        protected void weeklyAdviceGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                Response.Redirect("/ClientPortal/EditLabourAdvice.aspx?adviceno=" + item["AdviceNo"].Text);
            }
        }
    }
}