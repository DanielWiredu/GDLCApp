using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace GDLCApp.Reports.Queries
{
    public partial class AgedWorkers : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpFilter.SelectedDate = DateTime.Now;
            }
        }

        protected void workersGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        DataTable dTable = new DataTable();
                        //GridDataItem item = e.Item as GridDataItem;
                        var item = workersGrid.Items[e.CommandArgument.ToString()];
                        string workerid = item.GetDataKeyValue("WorkerID").ToString();
                        string selectquery = "select WorkerID, WorkerType, SName + ' ' + OName + ' ' + Pname as fullname, RegDate, PhoneNo, Date_Birth, SSFNo, NHIS, NAT, GangName,";
                        selectquery += " TradegroupNAME, TradetypeNAME, Kin, Addr1, flags, ezwichid, Sex, Age from vwWorkerDetails where workerid = @workerid";
                        adapter.SelectCommand = new SqlCommand(selectquery, connection);
                        adapter.SelectCommand.Parameters.Add("@workerid", SqlDbType.VarChar).Value = workerid;
                        try
                        {
                            connection.Open();
                            adapter.Fill(dTable);
                            RadListView2.DataSource = dTable;
                            RadListView2.DataBind();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showWorkerModal();", true);
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message + "', 'Error');", true);
                        }
                    }
                }
            }
            else if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                Response.Redirect("/Workers/EditWorker.aspx?workerId=" + item["WorkerID"].Text);
            }
            else if (e.CommandName == "Delete")
            {
                if (!User.IsInRole("Data Entry"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Sorry, you do not have the privilege to delete a worker. Please contact the System Administrator', 'Error');", true);
                    return;
                }
                GridDataItem item = e.Item as GridDataItem;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("spDeleteWorker", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@WorkerID", SqlDbType.VarChar).Value = item["WorkerID"].Text;
                        command.Parameters.Add("@DeletedBy", SqlDbType.VarChar).Value = User.Identity.Name;
                        command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                            if (retVal == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Deleted Successfully', 'Success');", true);
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

        protected void btnExcelExport_Click(object sender, EventArgs e)
        {
            workersGrid.MasterTableView.ExportToExcel();
        }

        protected void workersGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell Age = item["Age"];
                TableCell WorkerID = item["WorkerID"];
                if (int.Parse(Age.Text) > 60)
                {
                    WorkerID.BackColor = Color.Pink;
                }
            }
        }
    }
}