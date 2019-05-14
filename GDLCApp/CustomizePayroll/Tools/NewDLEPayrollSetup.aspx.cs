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

namespace GDLCApp.CustomizePayroll.Tools
{
    public partial class NewDLEPayrollSetup : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int rows = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select * from tblPayrollSetup_CS";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                txtUnionDues.Text = reader["UnionDues"].ToString();
                                txtWelfare.Text = reader["Welfare"].ToString();
                                txtSSFEmployee.Text = reader["SSFemployee"].ToString();
                                txtSSFEmployer.Text = reader["SSFemployer"].ToString();
                                txtPFEmployee.Text = reader["ProvidentFundEmployee"].ToString();
                                txtPFEmployer.Text = reader["ProvidentFundEmployer"].ToString();
                                txtAnnualBonus.Text = reader["AnnualBonus"].ToString();
                                txtAnnualLeave.Text = reader["AnnualLeave"].ToString();
                                txtPremShareholder.Text = reader["PremiumShareHolder"].ToString();
                                txtPremNonShareholder.Text = reader["PremiumNonShareHolder"].ToString();
                                txtPremWithoutTransport.Text = reader["PremiumWithoutTT"].ToString();
                                txtTaxOnBonus.Text = reader["TaxOnBonus"].ToString();
                                txtTaxOnBasic.Text = reader["TaxOnBasic"].ToString();
                                txtTaxOnOvertime.Text = reader["TaxOnOvertime"].ToString();
                                txtTaxOnPF.Text = reader["TaxOnProvidentFund"].ToString();
                                txtTaxOnTransport.Text = reader["TaxOnTransport"].ToString();
                                txtOnBoardAllowance.Text = reader["OnBoardAllowance"].ToString();
                                txtVAT.Text = reader["Vat"].ToString();
                                txtGetFund.Text = reader["GetFund"].ToString();
                                txtNHIL.Text = reader["NHIL"].ToString();

                                txtDBWage.Text = reader["DBWage"].ToString();
                                txtDBWageWknd.Text = reader["DBWageWkend"].ToString();
                                txtHourOvertimeWkday.Text = reader["HourOtimeWkday"].ToString();
                                txtHourOvertimeWknd.Text = reader["HourOtimeWkend"].ToString();
                                txtNightAllowanceWkday.Text = reader["NAWkday"].ToString();
                                txtNightAllowanceWknd.Text = reader["NAWkend"].ToString();
                                txtTransportAllowance.Text = reader["Transport"].ToString();
                                txtDBWageDLE.Text = reader["DBWageDLE"].ToString();
                                txtDBWageWkndDLE.Text = reader["DBWageWkendDLE"].ToString();
                                txtHourOvertimeWkdayDLE.Text = reader["HourOtimeWkdayDLE"].ToString();
                                txtHourOvertimeWkndDLE.Text = reader["HourOtimeWkendDLE"].ToString();
                                txtNightAllowanceWkdayDLE.Text = reader["NAWkdayDLE"].ToString();
                                txtNightAllowanceWkndDLE.Text = reader["NAWkendDLE"].ToString();
                                txtSubsidy.Text = reader["Subsidy"].ToString();
                                txtPPEMedicals.Text = reader["PPEMedical"].ToString();
                                txtBussing.Text = reader["Bussing"].ToString();
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
        protected void dlCompany_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = ((DataRowView)e.Item.DataItem)["DLEcodeCompanyName"].ToString();
            e.Item.Value = ((DataRowView)e.Item.DataItem)["DLEcodeCompanyID"].ToString();
        }

        protected void dlCompany_DataBound(object sender, EventArgs e)
        {
            //set the initial footer label
            ((Literal)dlCompany.Footer.FindControl("companyCount")).Text = Convert.ToString(dlCompany.Items.Count);
        }

        protected void dlCompany_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            String sql = "SELECT top(30) DLEcodeCompanyID,DLEcodeCompanyName FROM [tblDLECompany] WHERE Active = 1 AND DLEcodeCompanyName LIKE '%" + e.Text.ToUpper() + "%'";
            dleSource.SelectCommand = sql;
            dlCompany.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dlCompany.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Select a Company', 'Error');", true);
                return;
            }
            string query = "Insert Into tblPayrollSetupDLE_CS (DleCompanyId,UnionDues,Welfare,SSFemployee,SSFemployer,ProvidentFundEmployee,ProvidentFundEmployer,";
            query += "AnnualBonus,AnnualLeave,PremiumShareHolder,PremiumNonShareHolder,PremiumWithoutTT,TaxOnBonus,TaxOnBasic,TaxOnOvertime,TaxOnProvidentFund,";
            query += "TaxOnTransport,OnBoardAllowance,Vat,GetFund,NHIL,DBWage,DBWageWkend,HourOtimeWkday,HourOtimeWkend,NAWkday,NAWkend,Transport,";
            query += "DBWageDLE,DBWageWkendDLE,HourOtimeWkdayDLE,HourOtimeWkendDLE,NAWkdayDLE,NAWkendDLE,Subsidy,PPEMedical,Bussing) ";
            query += "Values(@DleCompanyId,@UnionDues,@Welfare,@SSFemployee,@SSFemployer,@ProvidentFundEmployee,@ProvidentFundEmployer,";
            query += "@AnnualBonus,@AnnualLeave,@PremiumShareHolder,@PremiumNonShareHolder,@PremiumWithoutTT,@TaxOnBonus,@TaxOnBasic,@TaxOnOvertime,@TaxOnProvidentFund,";
            query += "@TaxOnTransport,@OnBoardAllowance,@Vat,@GetFund,@NHIL,@DBWage,@DBWageWkend,@HourOtimeWkday,@HourOtimeWkend,@NAWkday,@NAWkend,@Transport,";
            query += "@DBWageDLE,@DBWageWkendDLE,@HourOtimeWkdayDLE,@HourOtimeWkendDLE,@NAWkdayDLE,@NAWkendDLE,@Subsidy,@PPEMedical,@Bussing)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@DleCompanyId", SqlDbType.Int).Value = dlCompany.SelectedValue;
                    command.Parameters.Add("@UnionDues", SqlDbType.Float).Value = txtUnionDues.Text;
                    command.Parameters.Add("@Welfare", SqlDbType.Float).Value = txtWelfare.Text;
                    command.Parameters.Add("@SSFemployee", SqlDbType.Float).Value = txtSSFEmployee.Text;
                    command.Parameters.Add("@SSFemployer", SqlDbType.Float).Value = txtSSFEmployer.Text;
                    command.Parameters.Add("@ProvidentFundEmployee", SqlDbType.Float).Value = txtPFEmployee.Text;
                    command.Parameters.Add("@ProvidentFundEmployer", SqlDbType.Float).Value = txtPFEmployer.Text;
                    command.Parameters.Add("@AnnualBonus", SqlDbType.Float).Value = txtAnnualBonus.Text;
                    command.Parameters.Add("@AnnualLeave", SqlDbType.Float).Value = txtAnnualLeave.Text;
                    command.Parameters.Add("@PremiumShareHolder", SqlDbType.Float).Value = txtPremShareholder.Text;
                    command.Parameters.Add("@PremiumNonShareHolder", SqlDbType.Float).Value = txtPremNonShareholder.Text;
                    command.Parameters.Add("@PremiumWithoutTT", SqlDbType.Float).Value = txtPremWithoutTransport.Text;
                    command.Parameters.Add("@TaxOnBonus", SqlDbType.Float).Value = txtTaxOnBonus.Text;
                    command.Parameters.Add("@TaxOnBasic", SqlDbType.Float).Value = txtTaxOnBasic.Text;
                    command.Parameters.Add("@TaxOnOvertime", SqlDbType.Float).Value = txtTaxOnOvertime.Text;
                    command.Parameters.Add("@TaxOnProvidentFund", SqlDbType.Float).Value = txtTaxOnPF.Text;
                    command.Parameters.Add("@TaxOnTransport", SqlDbType.Float).Value = txtTaxOnTransport.Text;
                    command.Parameters.Add("@OnBoardAllowance", SqlDbType.Float).Value = txtOnBoardAllowance.Text;
                    command.Parameters.Add("@Vat", SqlDbType.Float).Value = txtVAT.Text;
                    command.Parameters.Add("@GetFund", SqlDbType.Float).Value = txtGetFund.Text;
                    command.Parameters.Add("@NHIL", SqlDbType.Float).Value = txtNHIL.Text;

                    command.Parameters.Add("@DBWage", SqlDbType.Float).Value = txtDBWage.Text;
                    command.Parameters.Add("@DBWageWkend", SqlDbType.Float).Value = txtDBWageWknd.Text;
                    command.Parameters.Add("@HourOtimeWkday", SqlDbType.Float).Value = txtHourOvertimeWkday.Text;
                    command.Parameters.Add("@HourOtimeWkend", SqlDbType.Float).Value = txtHourOvertimeWknd.Text;
                    command.Parameters.Add("@NAWkday", SqlDbType.Float).Value = txtNightAllowanceWkday.Text;
                    command.Parameters.Add("@NAWkend", SqlDbType.Float).Value = txtNightAllowanceWknd.Text;
                    command.Parameters.Add("@Transport", SqlDbType.Float).Value = txtTransportAllowance.Text;
                    command.Parameters.Add("@DBWageDLE", SqlDbType.Float).Value = txtDBWageDLE.Text;
                    command.Parameters.Add("@DBWageWkendDLE", SqlDbType.Float).Value = txtDBWageWkndDLE.Text;
                    command.Parameters.Add("@HourOtimeWkdayDLE", SqlDbType.Float).Value = txtHourOvertimeWkdayDLE.Text;
                    command.Parameters.Add("@HourOtimeWkendDLE", SqlDbType.Float).Value = txtHourOvertimeWkndDLE.Text;
                    command.Parameters.Add("@NAWkdayDLE", SqlDbType.Float).Value = txtNightAllowanceWkdayDLE.Text;
                    command.Parameters.Add("@NAWkendDLE", SqlDbType.Float).Value = txtNightAllowanceWkndDLE.Text;
                    command.Parameters.Add("@Subsidy", SqlDbType.Float).Value = txtSubsidy.Text;
                    command.Parameters.Add("@PPEMedical", SqlDbType.Float).Value = txtPPEMedicals.Text;
                    command.Parameters.Add("@Bussing", SqlDbType.Float).Value = txtBussing.Text;

                    try
                    {
                        connection.Open();
                        rows = command.ExecuteNonQuery();
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Company Payroll Setup Created Successfully', 'Success');", true);
                            btnSave.Enabled = false;
                        }
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}