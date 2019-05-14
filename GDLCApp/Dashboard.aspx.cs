using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace GDLCApp
{
    public partial class Dashboard : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDashboard();
            }
        }
        protected void loadDashboard()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetAdminDash", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@dles", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@tradegroups", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@gangs", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@users", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@activeworkers", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@inactiveworkers", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@incapacitatedworkers", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@suspendedworkers", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        lblCompanies.InnerText = command.Parameters["@dles"].Value.ToString();
                        lblTradeGroups.InnerText = command.Parameters["@tradegroups"].Value.ToString();
                        lblGangs.InnerText = command.Parameters["@gangs"].Value.ToString();
                        lblUsers.InnerText = command.Parameters["@users"].Value.ToString();
                        lblActiveWorkers.InnerText = Convert.ToInt32(command.Parameters["@activeworkers"].Value).ToString("N00");
                        lblInActiveWorkers.InnerText = Convert.ToInt32(command.Parameters["@inactiveworkers"].Value).ToString("N00");
                        lblIncapacitatedWorkers.InnerText = Convert.ToInt32(command.Parameters["@incapacitatedworkers"].Value).ToString("N00");
                        lblSuspendedWorkers.InnerText = Convert.ToInt32(command.Parameters["@suspendedworkers"].Value).ToString("N00");
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }

        protected void lnkActiveWorkers_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Workers/WorkerStatus.aspx?WorkerStatus=Active");
        }

        protected void lnkInActiveWorkers_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Workers/WorkerStatus.aspx?WorkerStatus=InActive");
        }

        protected void lnkIncWorkers_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Workers/WorkerStatus.aspx?WorkerStatus=Incapacitated");
        }

        protected void lnkSusWorkers_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Workers/WorkerStatus.aspx?WorkerStatus=Suspended");
        }
    }
}