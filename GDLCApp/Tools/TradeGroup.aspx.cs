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

namespace GDLCApp.Tools
{
    public partial class TradeGroup : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int rows = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tradeGroupGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                ViewState["ID"] = item["TradegroupID"].Text;
                string query = "select * from tblTradeGroup where TradegroupID=@TradegroupID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@TradegroupID", SqlDbType.Int).Value = ViewState["ID"].ToString();
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                txtTradeGroup1.Text = reader["TradegroupNAME"].ToString();
                                txtNotes1.Text = reader["DNOTES"].ToString();
                                txtDBWage1.Text = reader["DBWage"].ToString();
                                txtDBWageWknd1.Text = reader["DBWageWkend"].ToString();
                                txtHourOvertimeWkday1.Text = reader["HourOtimeWkday"].ToString();
                                txtHourOvertimeWknd1.Text = reader["HourOtimeWkend"].ToString();
                                txtNightAllowanceWkday1.Text = reader["NAWkday"].ToString();
                                txtNightAllowanceWknd1.Text = reader["NAWkend"].ToString();
                                txtTransportAllowance1.Text = reader["Transport"].ToString();
                                txtDBWageDLE1.Text = reader["DBWageDLE"].ToString();
                                txtDBWageWkndDLE1.Text = reader["DBWageWkendDLE"].ToString();
                                txtHourOvertimeWkdayDLE1.Text = reader["HourOtimeWkdayDLE"].ToString();
                                txtHourOvertimeWkndDLE1.Text = reader["HourOtimeWkendDLE"].ToString();
                                txtNightAllowanceWkdayDLE1.Text = reader["NAWkdayDLE"].ToString();
                                txtNightAllowanceWkndDLE1.Text = reader["NAWkendDLE"].ToString();
                                txtSubsidy1.Text = reader["Subsidy"].ToString();
                                txtPPEMedicals1.Text = reader["PPEMedical"].ToString();
                                txtBussing1.Text = reader["Bussing"].ToString();

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "editModal();", true);
                                e.Canceled = true;
                            }
                            reader.Close();
                        }
                        catch (SqlException ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                        }
                    }
                }
            }
        }

        protected void tradeGroupGrid_ItemDeleted(object sender, GridDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + e.Exception.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Deleted Successfully', 'Success');", true);
            }
        }
        protected void btnExcelExport_Click(object sender, EventArgs e)
        {
            tradeGroupGrid.MasterTableView.ExportToExcel();
        }

        protected void btnPDFExport_Click(object sender, EventArgs e)
        {
            tradeGroupGrid.MasterTableView.ExportToPdf();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tblTradeGroup(TradegroupNAME,DNOTES,DBWage,DBWageWkend,HourOtimeWkday,HourOtimeWkend,NAWkday,NAWkend,Transport,";
            query += "DBWageDLE,DBWageWkendDLE,HourOtimeWkdayDLE,HourOtimeWkendDLE,NAWkdayDLE,NAWkendDLE,Subsidy,PPEMedical,Bussing) ";
            query += "VALUES(@TradegroupNAME,@DNOTES,@DBWage,@DBWageWkend,@HourOtimeWkday,@HourOtimeWkend,@NAWkday,@NAWkend,@Transport,";
            query += "@DBWageDLE,@DBWageWkendDLE,@HourOtimeWkdayDLE,@HourOtimeWkendDLE,@NAWkdayDLE,@NAWkendDLE,@Subsidy,@PPEMedical,@Bussing)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@TradegroupNAME", SqlDbType.VarChar).Value = txtTradeGroup.Text;
                    command.Parameters.Add("@DNOTES", SqlDbType.VarChar).Value = txtNotes.Text;
                    command.Parameters.Add("@DBWage", SqlDbType.Float).Value = txtDBWage.Text;
                    command.Parameters.Add("@DBWageWkend", SqlDbType.VarChar).Value = txtDBWageWknd.Text;
                    command.Parameters.Add("@HourOtimeWkday", SqlDbType.VarChar).Value = txtHourOvertimeWkday.Text;
                    command.Parameters.Add("@HourOtimeWkend", SqlDbType.VarChar).Value = txtHourOvertimeWknd.Text;
                    command.Parameters.Add("@NAWkday", SqlDbType.VarChar).Value = txtNightAllowanceWkday.Text;
                    command.Parameters.Add("@NAWkend", SqlDbType.VarChar).Value = txtNightAllowanceWknd.Text;
                    command.Parameters.Add("@Transport", SqlDbType.VarChar).Value = txtTransportAllowance.Text;
                    command.Parameters.Add("@DBWageDLE", SqlDbType.VarChar).Value = txtDBWageDLE.Text;
                    command.Parameters.Add("@DBWageWkendDLE", SqlDbType.VarChar).Value = txtDBWageWkndDLE.Text;
                    command.Parameters.Add("@HourOtimeWkdayDLE", SqlDbType.VarChar).Value = txtHourOvertimeWkdayDLE.Text;
                    command.Parameters.Add("@HourOtimeWkendDLE", SqlDbType.VarChar).Value = txtHourOvertimeWkndDLE.Text;
                    command.Parameters.Add("@NAWkdayDLE", SqlDbType.VarChar).Value = txtNightAllowanceWkdayDLE.Text;
                    command.Parameters.Add("@NAWkendDLE", SqlDbType.VarChar).Value = txtNightAllowanceWkndDLE.Text;
                    command.Parameters.Add("@Subsidy", SqlDbType.VarChar).Value = txtSubsidy.Text;
                    command.Parameters.Add("@PPEMedical", SqlDbType.VarChar).Value = txtPPEMedicals.Text;
                    command.Parameters.Add("@Bussing", SqlDbType.VarChar).Value = txtBussing.Text;
                    try
                    {
                        connection.Open();
                        rows = command.ExecuteNonQuery();
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Trade Group Saved Successfully', 'Success');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
                            tradeGroupGrid.Rebind();
                            txtTradeGroup.Text = "";
                        }
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "update tblTradeGroup set TradegroupNAME=@TradegroupNAME,DNOTES=@DNOTES,DBWage=@DBWage,DBWageWkend=@DBWageWkend,";
            query += "HourOtimeWkday=@HourOtimeWkday,HourOtimeWkend=@HourOtimeWkend,NAWkday=@NAWkday,NAWkend=@NAWkend,Transport=@Transport,";
            query += "DBWageDLE=@DBWageDLE,DBWageWkendDLE=@DBWageWkendDLE,HourOtimeWkdayDLE=@HourOtimeWkdayDLE,HourOtimeWkendDLE=@HourOtimeWkendDLE,";
            query += "NAWkdayDLE=@NAWkdayDLE,NAWkendDLE=@NAWkendDLE,Subsidy=@Subsidy,PPEMedical=@PPEMedical,Bussing=@Bussing where TradegroupID=@TradegroupID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@TradegroupNAME", SqlDbType.VarChar).Value = txtTradeGroup1.Text;
                    command.Parameters.Add("@DNOTES", SqlDbType.VarChar).Value = txtNotes1.Text;
                    command.Parameters.Add("@DBWage", SqlDbType.Float).Value = txtDBWage1.Text;
                    command.Parameters.Add("@DBWageWkend", SqlDbType.VarChar).Value = txtDBWageWknd1.Text;
                    command.Parameters.Add("@HourOtimeWkday", SqlDbType.VarChar).Value = txtHourOvertimeWkday1.Text;
                    command.Parameters.Add("@HourOtimeWkend", SqlDbType.VarChar).Value = txtHourOvertimeWknd1.Text;
                    command.Parameters.Add("@NAWkday", SqlDbType.VarChar).Value = txtNightAllowanceWkday1.Text;
                    command.Parameters.Add("@NAWkend", SqlDbType.VarChar).Value = txtNightAllowanceWknd1.Text;
                    command.Parameters.Add("@Transport", SqlDbType.VarChar).Value = txtTransportAllowance1.Text;
                    command.Parameters.Add("@DBWageDLE", SqlDbType.VarChar).Value = txtDBWageDLE1.Text;
                    command.Parameters.Add("@DBWageWkendDLE", SqlDbType.VarChar).Value = txtDBWageWkndDLE1.Text;
                    command.Parameters.Add("@HourOtimeWkdayDLE", SqlDbType.VarChar).Value = txtHourOvertimeWkdayDLE1.Text;
                    command.Parameters.Add("@HourOtimeWkendDLE", SqlDbType.VarChar).Value = txtHourOvertimeWkndDLE1.Text;
                    command.Parameters.Add("@NAWkdayDLE", SqlDbType.VarChar).Value = txtNightAllowanceWkdayDLE1.Text;
                    command.Parameters.Add("@NAWkendDLE", SqlDbType.VarChar).Value = txtNightAllowanceWkndDLE1.Text;
                    command.Parameters.Add("@Subsidy", SqlDbType.VarChar).Value = txtSubsidy1.Text;
                    command.Parameters.Add("@PPEMedical", SqlDbType.VarChar).Value = txtPPEMedicals1.Text;
                    command.Parameters.Add("@Bussing", SqlDbType.VarChar).Value = txtBussing1.Text;
                    command.Parameters.Add("@TradegroupID", SqlDbType.Int).Value = ViewState["ID"].ToString();
                    try
                    {
                        connection.Open();
                        rows = command.ExecuteNonQuery();
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Trade Group Updated Successfully', 'Success');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closeeditModal();", true);
                            tradeGroupGrid.Rebind();
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