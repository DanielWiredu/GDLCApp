using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace GDLCApp.Audit.PayrollProcess
{
    public partial class DailyPayroll : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime nowdate = DateTime.Now;
                lblMsg.InnerText = "NOTE : Current Date is " + nowdate.ToLongDateString();

                dpStartDate.SelectedDate = nowdate;
                dpStartDate.FocusedDate = nowdate;

                dpEndDate.SelectedDate = nowdate;
                dpEndDate.FocusedDate = nowdate;
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            if (dpStartDate.SelectedDate > dpEndDate.SelectedDate)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Start Date cannot be greater than End Date...Please try again', 'Error');", true);
                return;
            }
            //continue processing
            //System.Threading.Thread.Sleep(3000);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spProcessDailyReq", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@startdate", SqlDbType.DateTime).Value = dpStartDate.SelectedDate.Value.ToString();
                    command.Parameters.Add("@enddate", SqlDbType.DateTime).Value = dpEndDate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
                    command.Parameters.Add("@processedby", SqlDbType.VarChar).Value = User.Identity.Name;
                    command.Parameters.Add("@processedCostSheets", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int processed = Convert.ToInt32(command.Parameters["@processedCostSheets"].Value);
                        if (processed == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.warning('There are No Approved Cost Sheets within the selected date range', 'Unsuccessful');", true);
                            return;
                        }
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        if (retVal == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('" + processed.ToString() + " Cost Sheets Processed Successfully', 'Success');", true);
                        }
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Processed Successfully', 'Success');", true);
        }
    }
}