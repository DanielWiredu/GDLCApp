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
    public partial class TradeGroupRate : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int rows = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTradeGroup.InnerText = Request.QueryString["tradeGroup"].ToString();
                dpEffectiveDate.SelectedDate = DateTime.UtcNow;
            }
        }

        protected void tradeGroupRateGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                ViewState["ID"] = item["ID"].Text;
                string query = "select * from tblTradeGroupRates where ID=@ID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = ViewState["ID"].ToString();
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
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
                                dpEffectiveDate1.SelectedDate = Convert.ToDateTime(reader["EffectiveDate"]);
                                if (!DBNull.Value.Equals(reader["EndDate"]))
                                    dpEndDate1.SelectedDate = Convert.ToDateTime(reader["EndDate"]);
                                else
                                    dpEndDate1.Clear();

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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spAddTradeGroupRate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@TradegroupID", SqlDbType.Int).Value = Request.QueryString["tradeGroupId"].ToString(); ;
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
                    command.Parameters.Add("@EffectiveDate", SqlDbType.DateTime).Value = dpEffectiveDate.SelectedDate;
                    command.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Context.User.Identity.Name;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        if (retVal == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Trade Group Rate Saved Successfully', 'Success');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
                            tradeGroupRateGrid.Rebind();
                        }
                        else if (retVal == -20)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('A rate with the same effective date already exist for this Group', 'Error');", true);
                        }
                        else if (retVal == -19)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Effective Date should be greater than that of existing rate for this Group', 'Error');", true);
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
            string query = "update tblTradeGroupRates set DBWage=@DBWage,DBWageWkend=@DBWageWkend,";
            query += "HourOtimeWkday=@HourOtimeWkday,HourOtimeWkend=@HourOtimeWkend,NAWkday=@NAWkday,NAWkend=@NAWkend,Transport=@Transport,";
            query += "DBWageDLE=@DBWageDLE,DBWageWkendDLE=@DBWageWkendDLE,HourOtimeWkdayDLE=@HourOtimeWkdayDLE,HourOtimeWkendDLE=@HourOtimeWkendDLE,";
            query += "NAWkdayDLE=@NAWkdayDLE,NAWkendDLE=@NAWkendDLE,Subsidy=@Subsidy,PPEMedical=@PPEMedical,Bussing=@Bussing,UpdateStatus=@UpdateStatus,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate where ID=@ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
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
                    command.Parameters.Add("@UpdateStatus", SqlDbType.Bit).Value = 1;
                    command.Parameters.Add("@UpdatedBy", SqlDbType.VarChar).Value = Context.User.Identity.Name;
                    command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = ViewState["ID"].ToString();
                    try
                    {
                        connection.Open();
                        rows = command.ExecuteNonQuery();
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Trade Group Rate Updated Successfully', 'Success');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closeeditModal();", true);
                            tradeGroupRateGrid.Rebind();
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