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

namespace GDLCApp.Loans.Audit
{
    public partial class LoanApproval : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnFind.Focus();
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

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
                            txtSearchValue.Text = "";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Loan Number not found', 'Error');", true);
                            txtSearchValue.Focus();
                        }

                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                        txtSearchValue.Focus();
                    }
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (chkApproved.Checked)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Loan Already Approved...', 'Error');", true);
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spApproveLoan", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@loanNo", SqlDbType.VarChar).Value = txtLoanNo.Text;
                    command.Parameters.Add("@approvedBy", SqlDbType.VarChar).Value = User.Identity.Name;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        if (retVal == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Approved Successfully', 'Success');", true);
                            chkApproved.Checked = true;
                        }
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getLoanNoDetails(txtSearchValue.Text.Trim().ToUpper());
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
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