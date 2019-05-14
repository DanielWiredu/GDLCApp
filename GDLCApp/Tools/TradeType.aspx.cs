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
    public partial class TradeType : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int rows = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnExcelExport_Click(object sender, EventArgs e)
        {
            tradetypeGrid.MasterTableView.ExportToExcel();
        }

        protected void btnPDFExport_Click(object sender, EventArgs e)
        {
            tradetypeGrid.MasterTableView.ExportToPdf();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tblTradeType(TradetypeNAME,TRNOTE,TradegroupID,prefixname) VALUES(@TradetypeNAME,@TRNOTE,@TradegroupID,@prefixname)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@TradetypeNAME", SqlDbType.VarChar).Value = txtTradeType.Text;
                    command.Parameters.Add("@TRNOTE", SqlDbType.NText).Value = txtNotes.Text;
                    command.Parameters.Add("@TradegroupID", SqlDbType.Int).Value = dlTradeGroup.SelectedValue;
                    command.Parameters.Add("@prefixname", SqlDbType.VarChar).Value = txtPrefix.Text;
                    try
                    {
                        connection.Open();
                        rows = command.ExecuteNonQuery();
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Trade Type Saved Successfully', 'Success');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
                            tradetypeGrid.Rebind();
                            txtTradeType.Text = "";
                            txtPrefix.Text = "";
                            txtNotes.Text = "";
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
            string query = "Update tblTradeType SET TradetypeNAME=@TradetypeNAME,TRNOTE=@TRNOTE,TradegroupID=@TradegroupID,prefixname=@prefixname where TradetypeID=@TradetypeID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@TradetypeNAME", SqlDbType.VarChar).Value = txtTradeType1.Text;
                    command.Parameters.Add("@TRNOTE", SqlDbType.NText).Value = txtNotes1.Text;
                    command.Parameters.Add("@TradegroupID", SqlDbType.Int).Value = dlTradeGroup1.SelectedValue;
                    command.Parameters.Add("@prefixname", SqlDbType.VarChar).Value = txtPrefix1.Text;
                    command.Parameters.Add("@TradetypeID", SqlDbType.Int).Value = ViewState["ID"].ToString();
                    try
                    {
                        connection.Open();
                        rows = command.ExecuteNonQuery();
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Trade Type Updated Successfully', 'Success');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closeeditModal();", true);
                            tradetypeGrid.Rebind();
                        }
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }

        protected void tradetypeGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                ViewState["ID"] = item["TradetypeID"].Text;
                txtTradeType1.Text = item["TradetypeNAME"].Text;
                txtNotes1.Text = item["TRNOTE"].Text;
                dlTradeGroup1.SelectedValue = item["TradegroupID"].Text;
                txtPrefix1.Text = item["prefixname"].Text;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "editModal();", true);
                e.Canceled = true;
            }
        }

        protected void tradetypeGrid_ItemDeleted(object sender, GridDeletedEventArgs e)
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
    }
}