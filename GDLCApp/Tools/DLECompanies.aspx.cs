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
    public partial class DLECompanies : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int rows = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnExcelExport_Click(object sender, EventArgs e)
        {
            dleGrid.MasterTableView.ExportToExcel();
        }

        protected void btnPDFExport_Click(object sender, EventArgs e)
        {
            dleGrid.MasterTableView.ExportToPdf();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tblDLECompany(DLEcodeCompanyName, DLEaddr, DLEtel, Email, FContp, Ftel, FEmail, Pattern, OContp, Otel, OEmail, AContp, Atel, AEmail, SharePerc) ";
            query += "VALUES(@DLEcodeCompanyName, @DLEaddr, @DLEtel, @Email, @FContp, @Ftel, @FEmail, @Pattern, @OContp, @Otel, @OEmail, @AContp, @Atel, @AEmail, @SharePerc)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@DLEcodeCompanyName", SqlDbType.VarChar).Value = txtDLEName.Text;
                    command.Parameters.Add("@DLEaddr", SqlDbType.VarChar).Value = txtDLEAddress.Text;
                    command.Parameters.Add("@DLEtel", SqlDbType.VarChar).Value = txtDLETel.Text;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtDLEEmail.Text;
                    command.Parameters.Add("@FContp", SqlDbType.VarChar).Value = txtFinance.Text;
                    command.Parameters.Add("@Ftel", SqlDbType.VarChar).Value = txtFTel.Text;
                    command.Parameters.Add("@FEmail", SqlDbType.VarChar).Value = txtFEmail.Text;
                    command.Parameters.Add("@Pattern", SqlDbType.VarChar).Value = dlDLEStatus.SelectedText;
                    command.Parameters.Add("@OContp", SqlDbType.VarChar).Value = txtOperation.Text;
                    command.Parameters.Add("@Otel", SqlDbType.VarChar).Value = txtOTel.Text;
                    command.Parameters.Add("@OEmail", SqlDbType.VarChar).Value = txtOEmail.Text;
                    command.Parameters.Add("@AContp", SqlDbType.VarChar).Value = txtAdministration.Text;
                    command.Parameters.Add("@Atel", SqlDbType.VarChar).Value = txtATel.Text;
                    command.Parameters.Add("@AEmail", SqlDbType.VarChar).Value = txtAEmail.Text;
                    command.Parameters.Add("@SharePerc", SqlDbType.Float).Value = txtDLEPerc.Text;
                    try
                    {
                        connection.Open();
                        rows = command.ExecuteNonQuery();
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('DLE Saved Successfully', 'Success');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
                            dleGrid.Rebind();
                            txtDLEName.Text = "";
                            txtDLEPerc.Value = 0;
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
            string query = "Update tblDLECompany set DLEcodeCompanyName=@DLEcodeCompanyName, DLEaddr=@DLEaddr, DLEtel=@DLEtel, Email=@Email, FContp=@FContp, Ftel=@Ftel, FEmail=@FEmail,";
            query += "Pattern=@Pattern, OContp=@OContp, Otel=@Otel, OEmail=@OEmail, AContp=@AContp, Atel=@Atel, AEmail=@AEmail, SharePerc=@SharePerc where DLEcodeCompanyID=@DLEcodeCompanyID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@DLEcodeCompanyName", SqlDbType.VarChar).Value = txtDLEName1.Text;
                    command.Parameters.Add("@DLEaddr", SqlDbType.VarChar).Value = txtDLEAddress1.Text;
                    command.Parameters.Add("@DLEtel", SqlDbType.VarChar).Value = txtDLETel1.Text;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtDLEEmail1.Text;
                    command.Parameters.Add("@FContp", SqlDbType.VarChar).Value = txtFinance1.Text;
                    command.Parameters.Add("@Ftel", SqlDbType.VarChar).Value = txtFTel1.Text;
                    command.Parameters.Add("@FEmail", SqlDbType.VarChar).Value = txtFEmail1.Text;
                    command.Parameters.Add("@Pattern", SqlDbType.VarChar).Value = dlDLEStatus1.SelectedText;
                    command.Parameters.Add("@OContp", SqlDbType.VarChar).Value = txtOperation1.Text;
                    command.Parameters.Add("@Otel", SqlDbType.VarChar).Value = txtOTel1.Text;
                    command.Parameters.Add("@OEmail", SqlDbType.VarChar).Value = txtOEmail1.Text;
                    command.Parameters.Add("@AContp", SqlDbType.VarChar).Value = txtAdministration1.Text;
                    command.Parameters.Add("@Atel", SqlDbType.VarChar).Value = txtATel1.Text;
                    command.Parameters.Add("@AEmail", SqlDbType.VarChar).Value = txtAEmail1.Text;
                    command.Parameters.Add("@SharePerc", SqlDbType.Float).Value = txtDLEPerc1.Text;
                    command.Parameters.Add("@DLEcodeCompanyID", SqlDbType.Int).Value = ViewState["ID"].ToString();
                    try
                    {
                        connection.Open();
                        rows = command.ExecuteNonQuery();
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('DLE Updated Successfully', 'Success');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closeeditModal();", true);
                            dleGrid.Rebind();
                        }
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
        }

        protected void dleGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                ViewState["ID"] = item["DLEcodeCompanyID"].Text;
                string query = "select * from tblDLECompany where DLEcodeCompanyID=@DLEcodeCompanyID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@DLEcodeCompanyID", SqlDbType.Int).Value = ViewState["ID"].ToString();
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                txtDLEName1.Text = reader["DLEcodeCompanyName"].ToString();
                                txtDLEAddress1.Text = reader["DLEaddr"].ToString();
                                txtDLETel1.Text = reader["DLEtel"].ToString();
                                txtDLEEmail1.Text = reader["Email"].ToString();
                                txtFinance1.Text = reader["FContp"].ToString();
                                txtFTel1.Text = reader["Ftel"].ToString();
                                txtFEmail1.Text = reader["FEmail"].ToString();
                                dlDLEStatus1.SelectedText = reader["Pattern"].ToString();
                                txtOperation1.Text = reader["OContp"].ToString();
                                txtOTel1.Text = reader["Otel"].ToString();
                                txtOEmail1.Text = reader["OEmail"].ToString();
                                txtAdministration1.Text = reader["AContp"].ToString();
                                txtATel1.Text = reader["Atel"].ToString();
                                txtAEmail1.Text = reader["AEmail"].ToString();
                                txtDLEPerc1.Value = Convert.ToDouble(reader["SharePerc"]);

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

            if (e.CommandName == "ToggleActive")
            {
                //Get the GridEditFormInsertItem(for Editform mode) of the RadGrid  
                GridDataItem dataItem = (GridDataItem)e.Item;

                string dleID = dataItem.GetDataKeyValue("DLEcodeCompanyID").ToString();
                CheckBox currenctActive = dataItem["Active"].Controls[0] as CheckBox;
                bool newstatus = true;
                if (currenctActive.Checked)
                {
                    newstatus = false;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "update tblDLECompany set active = @active where DLEcodeCompanyID = '" + dleID + "'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@active", SqlDbType.Bit).Value = newstatus;
                        try
                        {
                            connection.Open();
                            rows = command.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Active Status Changed Successfully', 'Success');", true);
                                dleGrid.Rebind();
                            }
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                            e.Canceled = true;
                        }
                    }
                }
            }
        }

        protected void dleGrid_ItemDeleted(object sender, GridDeletedEventArgs e)
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