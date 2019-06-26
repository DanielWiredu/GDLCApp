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
using System.Security.Permissions;
using System.Net.Mail;

namespace GDLCApp.Operations.Daily
{
    public partial class NewDailyReq : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        static string onlineConnectionString = ConfigurationManager.ConnectionStrings["onlineConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpRegdate.SelectedDate = DateTime.Now;
                //dpRegdate.FocusedDate = DateTime.Now;

                workersGrid.DataSource = new DataTable();
                //workersGrid.DataBind();

                txtReqNo.Text = getNewReqNo();
                btnSave.Enabled = true;

            }
        }

        protected string getNewReqNo()
        {
            string reqno = "";
            string userkey = Request.Cookies.Get("userkey").Value;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetNewDailyReqNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@userKey", SqlDbType.VarChar, 2).Value = userkey;
                    command.Parameters.Add("@DailyReqNo", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        reqno = command.Parameters["@DailyReqNo"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
            return reqno;
        }

        protected void subStaffReqGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {

            if (e.CommandName == "Transport")
            {
                //toogle transport on Cost Sheet
                GridDataItem item = e.Item as GridDataItem;
                string autoId = item["AutoId"].Text;
                string transport = item["transport"].Text;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("spToogleWorkerTransport", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@AutoId", SqlDbType.Int).Value = autoId;
                        command.Parameters.Add("@transport", SqlDbType.Char).Value = transport;
                        command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                            if (retVal == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Transport Toggled', 'Success');", true);
                                subStaffReqGrid.Rebind();
                            }
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                        }
                    }
                }
            }
            if (e.CommandName == "InitInsert")
            {
                if (String.IsNullOrEmpty(txtAutoNo.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Please Save ReqNo before adding workers', 'Error');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "newModal();", true);
                }
                e.Canceled = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT top(500) [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS], [flags], [TradetypeID] FROM [vwWorkers] WHERE WorkerID LIKE '% ' @SearchValue + '%'";
            if (rdSearchType.SelectedValue == "WorkerID")
                query = "SELECT top(500) [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS], [flags], [TradetypeID] FROM [vwWorkers] WHERE WorkerID LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "SSFNo")
                query = "SELECT top(500) [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS], [flags], [TradetypeID] FROM [vwWorkers] WHERE SSFNo LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "NHISNo")
                query = "SELECT top(500) [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS], [flags], [TradetypeID] FROM [vwWorkers] WHERE NHIS LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "Gang")
                query = "SELECT top(500) [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS], [flags], [TradetypeID] FROM [vwWorkers] WHERE GangName LIKE '%' + @SearchValue + '%'";
            else if (rdSearchType.SelectedValue == "Surname")
                query = "SELECT top(500) [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS], [flags], [TradetypeID] FROM [vwWorkers] WHERE SName LIKE '%' + @SearchValue + '%' ORDER BY [OName]";
            else if (rdSearchType.SelectedValue == "Othernames")
                query = "SELECT top(500) [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeNAME], [NHIS], [flags], [TradetypeID] FROM [vwWorkers] WHERE OName LIKE '%' + @SearchValue + '%' ORDER BY [SName]";
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

        protected void workersGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "AddWorker")
            {
                //get customer's details and add to Cost Sheet
                ////GridDataItem item = e.Item as GridDataItem;
                var item = workersGrid.Items[e.CommandArgument.ToString()];
                string workerId = item["WorkerID"].Text;
                string flag = item["flags"].Text;
                if (flag != "ACT")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('This Worker " + workerId + " is tagged. Please contact the Administrator', 'Error');", true);
                    e.Canceled = true;
                    return;
                }
                string tradegroupId = item["TradegroupID"].Text;
                string tradeTypeId = item["TradetypeID"].Text;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("spAddSubStaffReq", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = txtReqNo.Text;
                        command.Parameters.Add("@WorkerID", SqlDbType.VarChar).Value = workerId;
                        command.Parameters.Add("@TradegroupID", SqlDbType.Int).Value = tradegroupId;
                        command.Parameters.Add("@transport", SqlDbType.Char).Value = "*";
                        command.Parameters.Add("@TradetypeID", SqlDbType.Int).Value = tradeTypeId;
                        command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                            if (retVal == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Saved Successfully', 'Success');", true);
                                subStaffReqGrid.Rebind();
                            }
                            else if (retVal == -73)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Only one Headman is permitted to work on a requisition', 'Error');", true);
                            }
                            //else if (retVal == -98)
                            //{
                            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Only one Gangwayman is permitted to work on a requisition', 'Error');", true);
                            //}
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                        }
                    }
                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);

                //reset Grid
                //workersGrid.DataSource = new DataTable();
                //workersGrid.DataBind();
                //txtSearchValue.Text = "";
                //rdSearchType.SelectedValue = "WorkerID";

                e.Canceled = true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //workersGrid.MasterTableView.AllowSorting = true;
            //workersGrid.MasterTableView.AllowFilteringByColumn = true;
            workersGrid.Rebind();
        }

        protected void dlVessel_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = ((DataRowView)e.Item.DataItem)["VesselName"].ToString();
            e.Item.Value = ((DataRowView)e.Item.DataItem)["VesselId"].ToString();
        }

        protected void dlVessel_DataBound(object sender, EventArgs e)
        {
            //set the initial footer label
            ((Literal)dlVessel.Footer.FindControl("vesselCount")).Text = Convert.ToString(dlVessel.Items.Count);
        }

        protected void dlVessel_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            String sql = "SELECT top(30) VesselId, VesselName FROM tblVessel WHERE VesselName LIKE '%" + e.Text.ToUpper() + "%'";
            vesselSource.SelectCommand = sql;
            dlVessel.DataBind();
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

        protected void dlReportingPoint_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = ((DataRowView)e.Item.DataItem)["ReportingPoint"].ToString();
            e.Item.Value = ((DataRowView)e.Item.DataItem)["ReportingPointId"].ToString();
        }

        protected void dlReportingPoint_DataBound(object sender, EventArgs e)
        {
            //set the initial footer label
            ((Literal)dlReportingPoint.Footer.FindControl("repPointCount")).Text = Convert.ToString(dlReportingPoint.Items.Count);
        }

        protected void dlReportingPoint_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            String sql = "SELECT top(30) ReportingPointId,ReportingPoint FROM [tblReportingPoint] WHERE ReportingPoint LIKE '%" + e.Text.ToUpper() + "%'";
            repPointSource.SelectCommand = sql;
            dlReportingPoint.DataBind();
        }

        protected void dlLocation_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = ((DataRowView)e.Item.DataItem)["Location"].ToString();
            e.Item.Value = ((DataRowView)e.Item.DataItem)["LocationId"].ToString();
        }

        protected void dlLocation_DataBound(object sender, EventArgs e)
        {
            //set the initial footer label
            ((Literal)dlLocation.Footer.FindControl("locationCount")).Text = Convert.ToString(dlLocation.Items.Count);
        }

        protected void dlLocation_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            String sql = "SELECT top(30) LocationId,Location FROM [tblLocation] WHERE Location LIKE '%" + e.Text.ToUpper() + "%'";
            locationSource.SelectCommand = sql;
            dlLocation.DataBind();
        }

        protected void dlCargo_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = ((DataRowView)e.Item.DataItem)["CargoName"].ToString();
            e.Item.Value = ((DataRowView)e.Item.DataItem)["CargoId"].ToString();
        }

        protected void dlCargo_DataBound(object sender, EventArgs e)
        {
            //set the initial footer label
            ((Literal)dlCargo.Footer.FindControl("cargoCount")).Text = Convert.ToString(dlCargo.Items.Count);
        }

        protected void dlCargo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            String sql = "SELECT top(30) CargoId,CargoName FROM [tblCargo] WHERE CargoName LIKE '%" + e.Text.ToUpper() + "%'";
            cargoSource.SelectCommand = sql;
            dlCargo.DataBind();
        }

        protected void dlGang_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = ((DataRowView)e.Item.DataItem)["GangName"].ToString();
            e.Item.Value = ((DataRowView)e.Item.DataItem)["GangId"].ToString();
        }

        protected void dlGang_DataBound(object sender, EventArgs e)
        {
            //set the initial footer label
            ((Literal)dlGang.Footer.FindControl("gangCount")).Text = Convert.ToString(dlGang.Items.Count);
        }

        protected void dlGang_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            String sql = "SELECT top(30) GangId,GangName FROM [tblGangs] WHERE GangName LIKE '%" + e.Text.ToUpper() + "%'";
            gangSource.SelectCommand = sql;
            dlGang.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dlCompany.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Select a Company', 'Error');", true);
                return;
            }
            if (dlVessel.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Select a Vessel', 'Error');", true);
                return;
            }
            if (dlGang.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Select a Gang', 'Error');", true);
                return;
            }
            int repPointId = 0;
            if (!String.IsNullOrEmpty(dlReportingPoint.SelectedValue))
                repPointId = Convert.ToInt32(dlReportingPoint.SelectedValue);
            int locationId = 0;
            if (!String.IsNullOrEmpty(dlLocation.SelectedValue))
                locationId = Convert.ToInt32(dlLocation.SelectedValue);
            int cargoId = 0;
            if (!String.IsNullOrEmpty(dlCargo.SelectedValue))
                cargoId = Convert.ToInt32(dlCargo.SelectedValue);
            //int gangId = 0;
            //if (!String.IsNullOrEmpty(dlGang.SelectedValue))
            //    gangId = Convert.ToInt32(dlGang.SelectedValue);

            bool weekend = false;
            DateTime reqdate = dpRegdate.SelectedDate.Value;
            if (reqdate.DayOfWeek == DayOfWeek.Saturday || reqdate.DayOfWeek == DayOfWeek.Sunday || chkWeekend.Checked)
                weekend = true;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spAddDailyReq", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = txtReqNo.Text;
                    command.Parameters.Add("@DLEcodeCompanyID", SqlDbType.Int).Value = dlCompany.SelectedValue;
                    command.Parameters.Add("@VesselberthID", SqlDbType.Int).Value = dlVessel.SelectedValue;
                    command.Parameters.Add("@locationID", SqlDbType.Int).Value = locationId;
                    command.Parameters.Add("@ReportpointID", SqlDbType.Int).Value = repPointId;
                    command.Parameters.Add("@cargoID", SqlDbType.Int).Value = cargoId;
                    command.Parameters.Add("@gangID", SqlDbType.Int).Value = dlGang.SelectedValue;
                    command.Parameters.Add("@job", SqlDbType.VarChar).Value = txtJobDescription.Text;
                    command.Parameters.Add("@date_", SqlDbType.DateTime).Value = dpRegdate.SelectedDate;
                    command.Parameters.Add("@Normal", SqlDbType.Float).Value = txtNormalHrs.Text;
                    command.Parameters.Add("@Overtime", SqlDbType.Float).Value = txtOvertimeHrs.Text;
                    command.Parameters.Add("@Weekends", SqlDbType.Bit).Value = weekend;
                    command.Parameters.Add("@Night", SqlDbType.Bit).Value = chkNight.Checked;
                    command.Parameters.Add("@Adate", SqlDbType.DateTime).Value = dpApprovalDate.SelectedDate;
                    command.Parameters.Add("@Preparedby", SqlDbType.VarChar).Value = User.Identity.Name;
                    command.Parameters.Add("@OnBoardAllowance", SqlDbType.Bit).Value = chkShipSide.Checked;
                    command.Parameters.Add("@NormalHrsFrom", SqlDbType.Time).Value = tpNormalFrom.SelectedTime;
                    command.Parameters.Add("@NormalHrsTo", SqlDbType.Time).Value = tpNormalTo.SelectedTime;
                    command.Parameters.Add("@OvertimeHrsFrom", SqlDbType.Time).Value = tpOvertimeFrom.SelectedTime;
                    command.Parameters.Add("@OvertimeHrsTo", SqlDbType.Time).Value = tpOvertimeTo.SelectedTime;
                    command.Parameters.Add("@AutoNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        long autoID = Convert.ToInt64(command.Parameters["@AutoNo"].Value);
                        if (retVal == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Saved Successfully', 'Success');", true);
                            txtAutoNo.Text = autoID.ToString();
                            chkWeekend.Checked = weekend;
                            btnPrint.Enabled = true;
                            btnPrintCopy.Enabled = true;
                            btnSave.Enabled = false;

                            btnSubmitOnline.Enabled = User.IsInRole("Operations Manager");
                        }
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                        //lblMsg.InnerText = ex.Message.Replace("'", "").Replace("\r\n", "");
                        //lblMsg.Attributes["class"] = "alert alert-danger";
                    }
                }
            }
        }

        protected void subStaffReqGrid_DataBound(object sender, EventArgs e)
        {
            lblGangs.InnerText = "Total Members : " + subStaffReqGrid.Items.Count;
        }

        protected void subStaffReqGrid_ItemDeleted(object sender, GridDeletedEventArgs e)
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

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            subStaffReqGrid.Enabled = false;
            if (!String.IsNullOrEmpty(txtReqNo.Text))
            {
                string startdate = dpRegdate.SelectedDate.Value.ToString();
                string enddate = dpRegdate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyCostSheet.aspx?reqno=" + txtReqNo.Text + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }

        protected void btnPrintCopy_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtReqNo.Text))
            {
                string startdate = dpRegdate.SelectedDate.Value.ToString();
                string enddate = dpRegdate.SelectedDate.Value.ToShortDateString() + " 11:59:59 PM";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/Daily/General/vwDailyCostSheet_Copy.aspx?reqno=" + txtReqNo.Text + "&st=" + startdate + "&ed=" + enddate + "');", true);
            }
        }

        protected void workersGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            workersGrid.DataSource = GetDataTable();
        }

        protected void btnGenReqNo_Click(object sender, EventArgs e)
        {
            generateCostSheetFromLabourRequest(txtRequestNo.Text.Trim());
        }
        protected void generateCostSheetFromLabourRequest(string requestno)
        {
            if (dlCompany.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Select a Company', 'Error');", true);
                return;
            }
            if (dlVessel.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Select a Vessel', 'Error');", true);
                return;
            }
            if (dlGang.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Select a Gang', 'Error');", true);
                return;
            }
            int repPointId = 0;
            if (!String.IsNullOrEmpty(dlReportingPoint.SelectedValue))
                repPointId = Convert.ToInt32(dlReportingPoint.SelectedValue);
            int locationId = 0;
            if (!String.IsNullOrEmpty(dlLocation.SelectedValue))
                locationId = Convert.ToInt32(dlLocation.SelectedValue);
            int cargoId = 0;
            if (!String.IsNullOrEmpty(dlCargo.SelectedValue))
                cargoId = Convert.ToInt32(dlCargo.SelectedValue);
            //int gangId = 0;
            //if (!String.IsNullOrEmpty(dlGang.SelectedValue))
            //    gangId = Convert.ToInt32(dlGang.SelectedValue);

            bool weekend = false;
            DateTime reqdate = dpRegdate.SelectedDate.Value;
            if (reqdate.DayOfWeek == DayOfWeek.Saturday || reqdate.DayOfWeek == DayOfWeek.Sunday || chkWeekend.Checked)
                weekend = true;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spAddDailyReq_Allocation", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@batchNo", SqlDbType.Int).Value = Convert.ToInt32(requestno);
                    command.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = txtReqNo.Text;
                    command.Parameters.Add("@DLEcodeCompanyID", SqlDbType.Int).Value = dlCompany.SelectedValue;
                    command.Parameters.Add("@VesselberthID", SqlDbType.Int).Value = dlVessel.SelectedValue;
                    command.Parameters.Add("@locationID", SqlDbType.Int).Value = locationId;
                    command.Parameters.Add("@ReportpointID", SqlDbType.Int).Value = repPointId;
                    command.Parameters.Add("@cargoID", SqlDbType.Int).Value = cargoId;
                    command.Parameters.Add("@gangID", SqlDbType.Int).Value = dlGang.SelectedValue;
                    command.Parameters.Add("@job", SqlDbType.VarChar).Value = txtJobDescription.Text;
                    command.Parameters.Add("@date_", SqlDbType.DateTime).Value = dpRegdate.SelectedDate;
                    command.Parameters.Add("@Normal", SqlDbType.Float).Value = txtNormalHrs.Text;
                    command.Parameters.Add("@Overtime", SqlDbType.Float).Value = txtOvertimeHrs.Text;
                    command.Parameters.Add("@Weekends", SqlDbType.Bit).Value = weekend;
                    command.Parameters.Add("@Night", SqlDbType.Bit).Value = chkNight.Checked;
                    command.Parameters.Add("@Adate", SqlDbType.DateTime).Value = dpApprovalDate.SelectedDate;
                    command.Parameters.Add("@Preparedby", SqlDbType.VarChar).Value = User.Identity.Name;
                    command.Parameters.Add("@OnBoardAllowance", SqlDbType.Bit).Value = chkShipSide.Checked;
                    command.Parameters.Add("@AutoNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);

                        if (retVal == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Saved Successfully', 'Success');", true);
                            txtAutoNo.Text = Convert.ToInt64(command.Parameters["@AutoNo"].Value).ToString();
                            chkWeekend.Checked = weekend;
                            btnPrint.Enabled = true;
                            btnPrintCopy.Enabled = true;
                            btnSave.Enabled = false;
                            subStaffReqGrid.Rebind();
                            btnLoadRequest.Enabled = false;
                            btnGenReqNo.Enabled = false;
                        }
                        //else if (retVal == -15)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('No pending allocation to generate Cost Sheet', 'Error');", true);
                        //}
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }
        protected void btnFindRequest_Click(object sender, EventArgs e)
        {
            dlCompany.ClearSelection();
            dlVessel.ClearSelection();
            dlReportingPoint.ClearSelection();
            dlGang.ClearSelection();
            int labourRequestReturn = loadLabourRequest(txtRequestNo.Text.Trim());
            if (labourRequestReturn == 0) //labour request not processed
            {
                //generate cost sheet now
                btnGenReqNo.Enabled = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closeRequestModal();", true);
            }
            else if (labourRequestReturn == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Labour Request already processed', 'Error');", true);
            }
        }

        private int loadLabourRequest(string batchno)
        {
            string query = "select DLEcodeCompanyID,VesselberthID,ReportpointID,gangID,job,date_,WorkShift,Processed from tblAllocationBatch where Id=@BatchNo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@BatchNo", SqlDbType.VarChar).Value = batchno;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            bool processed = Convert.ToBoolean(reader["Processed"]);
                            if (processed)
                                return 1;
                            string companyId = reader["DLEcodeCompanyID"].ToString();
                            query = "SELECT DLEcodeCompanyID, DLEcodeCompanyName FROM tblDLECompany WHERE DLEcodeCompanyID ='" + companyId + "'";
                            dleSource.SelectCommand = query;
                            dlCompany.DataBind();
                            dlCompany.SelectedValue = companyId;
                            string vesselId = reader["VesselberthID"].ToString();
                            query = "SELECT VesselId, VesselName FROM tblVessel WHERE VesselId ='" + vesselId + "'";
                            vesselSource.SelectCommand = query;
                            dlVessel.DataBind();
                            dlVessel.SelectedValue = vesselId;
                            string repPoint = reader["ReportpointID"].ToString();
                            query = "SELECT ReportingPointId, ReportingPoint FROM tblReportingPoint WHERE ReportingPointId = '" + repPoint + "'";
                            repPointSource.SelectCommand = query;
                            dlReportingPoint.DataBind();
                            dlReportingPoint.SelectedValue = repPoint;
                            string gangId = reader["GangId"].ToString();
                            query = "SELECT GangId, GangName FROM tblGangs WHERE GangId = '" + gangId + "'";
                            gangSource.SelectCommand = query;
                            dlGang.DataBind();
                            dlGang.SelectedValue = gangId;

                            txtJobDescription.Text = reader["job"].ToString();
                            dpRegdate.SelectedDate = Convert.ToDateTime(reader["date_"]);
                            string workshift = reader["WorkShift"].ToString();
                            if (workshift == "Day")
                                chkNight.Checked = false;
                            else if (workshift == "Night")
                                chkNight.Checked = true;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "getrequest", "toastr.error('Labour Request No not found', 'Error');", true);
                            return 2;
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "getrequest", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
            return 0;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Operations Manager")]
        protected void btnSubmitOnline_Click(object sender, EventArgs e)
        {
            if (subStaffReqGrid.Items.Count < 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('No worker on Cost Sheet...Cannot Submit', 'Error');", true);
                return;
            }
            try
            {
                using (SqlConnection sourceConnection = new SqlConnection(connectionString))
                {
                    string sourceQuery = "select * from tblStaffReq where ReqNo=@ReqNo and Approved = 0";
                    using (SqlCommand sourceCommand = new SqlCommand(sourceQuery, sourceConnection))
                    {
                        sourceCommand.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = txtReqNo.Text;
                        sourceConnection.Open();
                        SqlDataReader sourceReader = sourceCommand.ExecuteReader();
                        if (!sourceReader.HasRows)
                        {
                            sourceReader.Close();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Cost Sheet Approved. Not available for submission', 'Error');", true);
                            return;
                        }
                        using (SqlConnection destinationConnection = new SqlConnection(onlineConnectionString))
                        {
                            destinationConnection.Open();

                            using (SqlTransaction transaction = destinationConnection.BeginTransaction())
                            {
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.FireTriggers, transaction))
                                {
                                    bulkCopy.BatchSize = 1;
                                    bulkCopy.DestinationTableName = "dbo.tblStaffReq";

                                    // Write from the source to the destination. 
                                    // This should fail with a duplicate key error. 
                                    try
                                    {
                                        bulkCopy.WriteToServer(sourceReader);
                                        transaction.Commit();

                                        if (!pushSubStaffReq())
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Workers details could not be submitted...Retry', 'Error');", true);
                                            return;
                                        }

                                        SqlConnection connection = new SqlConnection(connectionString);
                                        SqlCommand command = new SqlCommand("update tblStaffReq set Submitted = 1, SubmittedDate = @SubmittedDate where ReqNo = @ReqNo", connection);
                                        command.Parameters.Add("@SubmittedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
                                        command.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = txtReqNo.Text;
                                        connection.Open();
                                        int rows = command.ExecuteNonQuery();
                                        if (rows == 1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Submitted Successfully', 'Success');", true);
                                        }
                                        command.Dispose();
                                        connection.Dispose();

                                        //get Company Email and sent cost sheet
                                        getCostSheetCompanyEmail();
                                    }
                                    catch (Exception ex)
                                    {
                                        transaction.Rollback();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                                    }
                                    finally
                                    {
                                        sourceReader.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
            }
        }
        protected bool pushSubStaffReq()
        {
            bool workersPushed = false;
            try
            {
                using (SqlConnection sourceConnection = new SqlConnection(connectionString))
                {
                    string sourceQuery = "select * from tblSubStaffReq where ReqNo=@ReqNo";
                    using (SqlCommand sourceCommand = new SqlCommand(sourceQuery, sourceConnection))
                    {
                        sourceCommand.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = txtReqNo.Text;
                        sourceConnection.Open();
                        SqlDataReader sourceReader = sourceCommand.ExecuteReader();
                        if (!sourceReader.HasRows)
                        {
                            sourceReader.Close();
                            return false;
                        }
                        using (SqlConnection destinationConnection = new SqlConnection(onlineConnectionString))
                        {
                            destinationConnection.Open();

                            using (SqlTransaction transaction = destinationConnection.BeginTransaction())
                            {
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection, SqlBulkCopyOptions.KeepIdentity, transaction))
                                {
                                    bulkCopy.BatchSize = 100;
                                    bulkCopy.DestinationTableName = "dbo.tblSubStaffReq";

                                    // Write from the source to the destination. 
                                    // This should fail with a duplicate key error. 
                                    try
                                    {
                                        bulkCopy.WriteToServer(sourceReader);
                                        transaction.Commit();
                                        workersPushed = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        transaction.Rollback();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                                    }
                                    finally
                                    {
                                        sourceReader.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
            }
            return workersPushed;
        }
        protected void getCostSheetCompanyEmail()
        {
            if (dlCompany.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "getEmail", "toastr.error('Select a Company', 'Error');", true);
                return;
            }
            string query = "select DLEcodeCompanyID, DLEcodeCompanyName, Email from tblDLECompany where DLEcodeCompanyID=@DLEcodeCompanyID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@DLEcodeCompanyID", SqlDbType.Int).Value = dlCompany.SelectedValue;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string dleEmail = reader["Email"].ToString();
                            if (!String.IsNullOrEmpty(dleEmail))
                            {
                                sendCostSheetEmail(reader["DLEcodeCompanyName"].ToString(), dleEmail, txtReqNo.Text);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "getEmail", "toastr.error('DLE Email Address not found', 'Error');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "getEmail", "toastr.error('DLE Email Address not found', 'Error');", true);
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "getEmail", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }
        protected void sendCostSheetEmail(string companyName, string emailAddress, string reqno)
        {
            try
            {
                string mailSubject = "GDLC - COST SHEET";
                string message = "Dear " + companyName + ", <br><br>";
                message += "Please note that, cost sheet <strong>" + reqno + "</strong> has been submitted to you by Ghana Dock Labour Company. <br><br> ";
                message += "<strong><a href='http://www.gdlcwave.com/' target='_blank'>Click here</a></strong> to log on to the client portal for more details. <br /><br />";
                message += "<strong>This is an auto generated email. Please do not reply.</strong>";
                MailMessage myMessage = new MailMessage();
                myMessage.From = (new MailAddress("admin@gdlcwave.com", "GDLC Client Portal"));
                myMessage.To.Add(new MailAddress(emailAddress));
                myMessage.Subject = mailSubject;
                myMessage.Body = message;
                myMessage.IsBodyHtml = true;
                SmtpClient mySmtpClient = new SmtpClient();
                mySmtpClient.Send(myMessage);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mailsuccess", "toastr.success('Email Sent Successfully', 'Success');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mailerror", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
            }
        }
    }
}