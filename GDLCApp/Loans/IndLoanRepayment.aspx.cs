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
    public partial class IndLoanRepayment : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getLoanNoDetails(Request.QueryString["loanno"].ToString());
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

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Loans/Reports/vwLoanRepayments.aspx?loanno=" + txtLoanNo.Text + "');", true);
        }

        protected void loanRepayGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "InitInsert")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "newModal();", true);
                e.Canceled = true;
            }
            else if (e.CommandName == "Approve")
            {
                if (!User.IsInRole("Loans-Audit"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Sorry, You are not authorized to perform this transaction.Contact the System Administrator...', 'Error');", true);
                    return;
                }
                GridDataItem item = e.Item as GridDataItem;
                string autoId = item["AutoId"].Text;
                CheckBox chk = item["Approved"].Controls[0] as CheckBox;
                bool approved = chk.Checked;
                if (approved)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Payment Already Approved...', 'Error');", true);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("spApproveLoanRepayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@AutoId", SqlDbType.Int).Value = autoId;
                        command.Parameters.Add("@LoanNo", SqlDbType.VarChar).Value = txtLoanNo.Text;
                        command.Parameters.Add("@ApprovedBy", SqlDbType.VarChar).Value = User.Identity.Name;
                        command.Parameters.Add("@LoanRepaidAmount", SqlDbType.Float).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@LoanBalance", SqlDbType.Float).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                            if (retVal == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Approved Successfully', 'Success');", true);
                                loanRepayGrid.Rebind();
                                txtRepaidAmount.Text = command.Parameters["@LoanRepaidAmount"].Value.ToString();
                                txtLoanBalance.Text = command.Parameters["@LoanBalance"].Value.ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!chkApproved.Checked)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Loan Not Yet Approved...Repayments Cannot Be Accepted', 'Error');", true);
                return;
            }
            if (txtLoanBalance.Value <= 0.0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Loan has NO outstanding balance...Repayments Cannot Be Accepted', 'Error');", true);
                return;
            }
            //receipt nos should not start with D,W,M,C as they are prefixes for Daily,Weekly,Monthly and Customized Cost Sheets
            //if (txtReceiptNo.Text.StartsWith("D") || txtReceiptNo.Text.StartsWith("W") || txtReceiptNo.Text.StartsWith("M") || txtReceiptNo.Text.StartsWith("C"))
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Receipt No cannot start with D, W , M or C. Codes reserved for cost sheet repayments', 'Error');", true);
            //    return;
            //}
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spAddLoanRepayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@LoanNo", SqlDbType.VarChar).Value = txtLoanNo.Text;
                    command.Parameters.Add("@WorkerId", SqlDbType.VarChar).Value = txtWorkerId.Text;
                    command.Parameters.Add("@RepayDate", SqlDbType.DateTime).Value = dpPaymentDate.SelectedDate;
                    command.Parameters.Add("@RepayAmount", SqlDbType.Float).Value = txtAmount.Text;
                    //command.Parameters.Add("@ReceiptNo", SqlDbType.VarChar).Value = txtReceiptNo.Text;
                    command.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = User.Identity.Name;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        if (retVal == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Saved Successfully', 'Success');", true);
                            dpPaymentDate.Clear();
                            txtAmount.Value = 0;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
                            loanRepayGrid.Rebind();
                        }
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }

        protected void loanRepayGrid_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            string autoId = item["AutoId"].Text;
            CheckBox chk = item["Approved"].Controls[0] as CheckBox;
            bool approved = chk.Checked;
            if (approved)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Payment Approved...Cannot Delete', 'Error');", true);
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spDeleteLoanRepayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@AutoId", SqlDbType.Int).Value = autoId;
                    //command.Parameters.Add("@LoanNo", SqlDbType.VarChar).Value = txtLoanNo.Text;
                    //command.Parameters.Add("@LoanRepaidAmount", SqlDbType.Float).Direction = ParameterDirection.Output;
                    //command.Parameters.Add("@LoanBalance", SqlDbType.Float).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        if (retVal == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Deleted Successfully', 'Success');", true);
                            //txtRepaidAmount.Text = command.Parameters["@LoanRepaidAmount"].Value.ToString();
                            //txtLoanBalance.Text = command.Parameters["@LoanBalance"].Value.ToString();
                            loanRepayGrid.Rebind();
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