using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace GDLCApp.Loans
{
    public partial class EditLoan : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getLoanNoDetails(Request.QueryString["loanno"].ToString());

                workersGrid.DataSource = new DataTable();
                //workersGrid.DataBind();
            }
        }
        protected void getLoanNoDetails(string loanNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetLoanNoDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@LoanNo", SqlDbType.VarChar).Value = loanNo;
                    command.Parameters.Add("@WorkerId", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@LoanSchemeId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@LoanDate", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@LoanAmount", SqlDbType.Float).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@RepayAmount", SqlDbType.Float).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@MonthlyLimit", SqlDbType.Float).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@RepaidAmount", SqlDbType.Float).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@LoanBalance", SqlDbType.Float).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@AutoDeduct", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@Approved", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    command.Parameters.Add("@WorkerName", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@ezwichid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@workerType", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                    //command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        string workerId = command.Parameters["@WorkerId"].Value.ToString();
                        if (!String.IsNullOrEmpty(workerId))
                        {
                            txtLoanNo.Text = loanNo;
                            txtWorkerId.Text = workerId;
                            dlLoanScheme.SelectedValue = command.Parameters["@LoanSchemeId"].Value.ToString();
                            dpLoanDate.SelectedDate = Convert.ToDateTime(command.Parameters["@LoanDate"].Value);
                            txtLoanAmount.Text = command.Parameters["@LoanAmount"].Value.ToString();
                            txtRepayAmount.Text = command.Parameters["@RepayAmount"].Value.ToString();
                            txtMonthlyLimit.Text = command.Parameters["@MonthlyLimit"].Value.ToString();
                            txtRepaidAmount.Text = command.Parameters["@RepaidAmount"].Value.ToString();
                            txtLoanBalance.Text = command.Parameters["@LoanBalance"].Value.ToString();
                            chkAutoDeduct.Checked = Convert.ToBoolean(command.Parameters["@AutoDeduct"].Value);
                            chkApproved.Checked = Convert.ToBoolean(command.Parameters["@Approved"].Value);

                            txtWorkerName.Text = command.Parameters["@WorkerName"].Value.ToString();
                            txtEzwichNo.Text = command.Parameters["@ezwichid"].Value.ToString();
                            txtWorkerType.Text = command.Parameters["@workerType"].Value.ToString();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Loan Number not found', 'Error');", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }
        protected DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT top(200) [WorkerID], [WorkerType], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeID], [TradetypeNAME], [NHIS], [flags], [ezwichid] FROM [vwWorkers] WHERE WorkerID LIKE '% ' @SearchValue + '%'";
            if (rdSearchType.SelectedValue == "WorkerID")
                query = "SELECT top(200) [WorkerID], [WorkerType], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME] ,[TradetypeID], [TradetypeNAME], [NHIS], [flags], [ezwichid] FROM [vwWorkers] WHERE WorkerID LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "SSFNo")
                query = "SELECT top(200) [WorkerID], [WorkerType], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME] ,[TradetypeID], [TradetypeNAME], [NHIS], [flags], [ezwichid] FROM [vwWorkers] WHERE SSFNo LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "NHISNo")
                query = "SELECT top(200) [WorkerID], [WorkerType], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME] ,[TradetypeID], [TradetypeNAME], [NHIS], [flags], [ezwichid] FROM [vwWorkers] WHERE NHIS LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "Gang")
                query = "SELECT top(200) [WorkerID], [WorkerType], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME] ,[TradetypeID], [TradetypeNAME], [NHIS], [flags], [ezwichid] FROM [vwWorkers] WHERE GangName LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "Surname")
                query = "SELECT top(200) [WorkerID], [WorkerType], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME] ,[TradetypeID], [TradetypeNAME], [NHIS], [flags], [ezwichid] FROM [vwWorkers] WHERE SName LIKE '%' + @SearchValue + '%' ORDER BY [OName]";
            else if (rdSearchType.SelectedValue == "Othernames")
                query = "SELECT top(200) [WorkerID], [WorkerType], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME] ,[TradetypeID], [TradetypeNAME], [NHIS], [flags], [ezwichid] FROM [vwWorkers] WHERE OName LIKE '%' + @SearchValue + '%' ORDER BY [SName]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    adapter.SelectCommand.Parameters.Add("@SearchValue", SqlDbType.VarChar).Value = txtSearchValue.Text.Trim();
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
        protected void workersGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            workersGrid.DataSource = GetDataTable();
        }
        protected void workersGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "AddWorker")
            {
                //get customer's details
                //GridDataItem item = e.Item as GridDataItem;
                var item = workersGrid.Items[e.CommandArgument.ToString()];
                string workerId = item["WorkerID"].Text;
                string flag = item["flags"].Text;
                if (flag != "ACT")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('This Worker " + workerId + " is tagged. Please contact the Administrator', 'Error');", true);
                    e.Canceled = true;
                    return;
                }
                txtWorkerId.Text = item["WorkerID"].Text;
                txtWorkerName.Text = item["SName"].Text + " " + item["OName"].Text;
                //hfTradegroup.Value = item["TradegroupID"].Text;
                //hfTradetype.Value = item["TradetypeID"].Text;
                txtEzwichNo.Text = item["ezwichid"].Text;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closeWorkersModal();", true);

                //reset Grid
                //workersGrid.DataSource = new DataTable();
                //workersGrid.DataBind();
                //txtSearchValue.Text = "";
                //rdSearchType.SelectedValue = "WorkerID";

                //int loans = getOutstandingLoans(txtWorkerId.Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "loans", "toastr.warning('Worker has " + getOutstandingLoans(txtWorkerId.Text) + " outstanding loan(s)', 'Prompt');", true);

                e.Canceled = true;
            }
        }
        protected int getOutstandingLoans(string workerId)
        {
            int loans = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("select isnull(count(loanno),0) as loans from tblLoans where workerid=@WorkerId and loanbalance > 0", connection))
                {
                    command.Parameters.Add("@WorkerId", SqlDbType.VarChar).Value = workerId;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            loans = Convert.ToInt16(reader["loans"]);
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
            return loans;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //workersGrid.DataSource = GetDataTable();
            //workersGrid.DataBind();

            workersGrid.MasterTableView.AllowSorting = true;
            workersGrid.MasterTableView.AllowFilteringByColumn = true;
            workersGrid.Rebind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (chkApproved.Checked)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Loan Approved...Cannot Modify', 'Error');", true);
                return;
            }
            if (dlLoanScheme.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Select a Loan Scheme', 'Error');", true);
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spUpdateLoan", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@LoanNo", SqlDbType.VarChar).Value = txtLoanNo.Text;
                    command.Parameters.Add("@WorkerId", SqlDbType.VarChar).Value = txtWorkerId.Text;
                    command.Parameters.Add("@LoanSchemeId", SqlDbType.Int).Value = dlLoanScheme.SelectedValue;
                    command.Parameters.Add("@LoanDate", SqlDbType.DateTime).Value = dpLoanDate.SelectedDate;
                    command.Parameters.Add("@LoanAmount", SqlDbType.Float).Value = txtLoanAmount.Text;
                    command.Parameters.Add("@RepayAmount", SqlDbType.Float).Value = txtRepayAmount.Text;
                    command.Parameters.Add("@MonthlyLimit", SqlDbType.Float).Value = txtMonthlyLimit.Text;
                    command.Parameters.Add("@RepaidAmount", SqlDbType.Float).Value = txtRepaidAmount.Text;
                    command.Parameters.Add("@AutoDeduct", SqlDbType.Bit).Value = chkAutoDeduct.Checked;
                    command.Parameters.Add("@UpdatedBy", SqlDbType.VarChar).Value = User.Identity.Name;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        if (retVal == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Updated Successfully', 'Success');", true);
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