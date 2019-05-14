using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Telerik.Web.UI;

namespace GDLCApp.Loans
{
    public partial class LoanManager : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
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
            if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                Response.Redirect("/Loans/EditLoan.aspx?loanno=" + item["LoanNo"].Text);
            }
        }

        protected void loanGrid_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            string loanno = item["LoanNo"].Text;
            CheckBox chk = item["Approved"].Controls[0] as CheckBox;
            bool approved = chk.Checked;
            if (approved)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Loan Approved...Cannot Delete', 'Error');", true);
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Delete from tblLoans where LoanNo = @LoanNo", connection))
                {
                    //command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@LoanNo", SqlDbType.VarChar).Value = loanno;
                    //command.Parameters.Add("@DeleteBy", SqlDbType.VarChar).Value = Context.User.Identity.Name;
                    //command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        int retVal = command.ExecuteNonQuery();
                        //int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        if (retVal == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Deleted Successfully', 'Success');", true);
                        }
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }
    }
}