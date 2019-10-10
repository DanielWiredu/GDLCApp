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
    public partial class NewPayrollSetup : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpEffectiveDate.SelectedDate = DateTime.UtcNow;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spAddPayrollSetup", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Payroll Setup Created Successfully', 'Success');", true);
                            btnSave.Enabled = false;
                        }
                        else if (retVal == -20)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('A rate with the same effective date already exist', 'Error');", true);
                        }
                        else if (retVal == -19)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Effective Date should be greater than that of all existing rates', 'Error');", true);
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