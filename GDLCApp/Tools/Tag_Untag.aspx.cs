using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace GDLCApp.Tools
{
    public partial class Tag_Untag : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                workersGrid.DataSource = new DataTable();
                //workersGrid.DataBind();
            }
        }
        protected DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            string query = "";
            if (rdSearchType.SelectedValue == "WorkerID")
                query = "SELECT [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS] FROM [vwWorkers] WHERE WorkerID LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "SSFNo")
                query = "SELECT [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS] FROM [vwWorkers] WHERE SSFNo LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "NHISNo")
                query = "SELECT [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS] FROM [vwWorkers] WHERE NHIS LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "Gang")
                query = "SELECT [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS] FROM [vwWorkers] WHERE GangName LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "Surname")
                query = "SELECT [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS] FROM [vwWorkers] WHERE SName LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "Othernames")
                query = "SELECT [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS] FROM [vwWorkers] WHERE OName LIKE '%' + @SearchValue + '%'";
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //workersGrid.DataSource = GetDataTable();
            //workersGrid.DataBind();

            workersGrid.MasterTableView.AllowFilteringByColumn = true;
            workersGrid.MasterTableView.AllowSorting = true;
            workersGrid.Rebind();
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            setWorkerStatus("ACT");
        }

        protected void btnInactive_Click(object sender, EventArgs e)
        {
            setWorkerStatus("INA");
        }

        protected void btnIncapacitated_Click(object sender, EventArgs e)
        {
            setWorkerStatus("INC");
        }

        protected void btnSuspended_Click(object sender, EventArgs e)
        {
            setWorkerStatus("SUS");
        }
        protected void setWorkerStatus(string flag)
        {
            if (workersGrid.SelectedItems.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.warning('No Worker(s) Selected', 'Info');", true);
                return;
            }
            //if (workersGrid.SelectedItems.Count > 10)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.warning('Maximum number of workers to select is 10', 'Info');", true);
            //    return;
            //}
            string workerID = "";
            foreach (GridDataItem worker in workersGrid.SelectedItems)
            {
                workerID = worker["WorkerID"].Text;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("spSetWorkerStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@WorkerID", SqlDbType.VarChar).Value = workerID;
                        command.Parameters.Add("@flag", SqlDbType.VarChar).Value = flag;
                        command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                            if (retVal == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Worker Tagged_Untagged Successfully', 'Success');", true);
                                //subStaffReqGrid.Rebind();
                            }
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                        }
                    }
                }
            }
        }

        //protected void workersGrid_SortCommand(object sender, GridSortCommandEventArgs e)
        //{
        //    workersGrid.DataSource = GetDataTable();
        //    workersGrid.DataBind();
        //}

        protected void workersGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            workersGrid.DataSource = GetDataTable();
        }
    }
}