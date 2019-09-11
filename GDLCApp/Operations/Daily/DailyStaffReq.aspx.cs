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

namespace GDLCApp.Operations.Daily
{
    public partial class DailyStaffReq : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dailyStaffReqGrid.DataSource = GetDataTable();
            }
        }

        protected void txtSearchStaffReq_TextChanged(object sender, EventArgs e)
        {
            //dailyStaffReqGrid.DataSource = GetDataTable();
            //dailyStaffReqGrid.DataBind();
            //dailyStaffReqSource.SelectCommand = "SELECT TOP (30) AutoNo, ReqNo, date_, Approved, DLEcodeCompanyName, VesselName, ReportingPoint FROM vwDailyReq WHERE (ReqNo LIKE '%' + @ReqNo + '%') ORDER BY AutoNo";
            dailyStaffReqGrid.Rebind();
        }
        protected DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT TOP (100) AutoNo, ReqNo, date_, DLEcodeCompanyName, VesselName, ReportingPoint FROM vwDailyReq WHERE ReqNo LIKE @ReqNo + '%' ORDER BY AutoNo DESC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    adapter.SelectCommand.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = txtSearchStaffReq.Text;
                    try
                    {
                        connection.Open();
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
            return dt;
        }

        protected void dailyStaffReqGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                Response.Redirect("/Operations/Daily/EditDailyReq.aspx?reqno=" + item["ReqNo"].Text);
            }
        }

        protected void dailyStaffReqGrid_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            string reqno = item["ReqNo"].Text;
            CheckBox chkSumbit = item["Submitted"].Controls[0] as CheckBox;
            bool submitted = chkSumbit.Checked;
            if (submitted)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Cost Sheet Submitted...Cannot Delete', 'Error');", true);
                return;
            }
            CheckBox chkApproved = item["Approved"].Controls[0] as CheckBox;
            bool approved = chkApproved.Checked;
            if (approved)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Cost Sheet Approved...Cannot Delete', 'Error');", true);
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spDeleteDailyReq", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = reqno;
                    command.Parameters.Add("@DeleteBy", SqlDbType.VarChar).Value = Context.User.Identity.Name;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        if (retVal == 0)
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