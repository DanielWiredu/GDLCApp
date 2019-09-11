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

namespace GDLCApp.Workers
{
    public partial class EditWorker : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int rows = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnUpdate.Enabled = User.IsInRole("Data Entry");

                loadWorkerDetails(Request.QueryString["workerId"].ToString());
            }
        }
        protected bool loadWorkerDetails(string workerId)
        {
            bool workerFound = false;
            string query = "select * from vwTblWorkers where WorkerID=@WorkerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@WorkerID", SqlDbType.VarChar).Value = workerId;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txtAutoNumber.Text = reader["AutoID"].ToString();
                            txtWorkerID.Text = reader["WorkerID"].ToString();
                            dlWorkerType.SelectedValue = reader["WorkerType"].ToString();
                            txtSurname.Text = reader["SName"].ToString();
                            txtOthernames.Text = reader["OName"].ToString();
                            txtFullname.Text = txtSurname.Text + " " + txtOthernames.Text;
                            txtPreviousName.Text = reader["Pname"].ToString();
                            txtAddress1.Text = reader["Addr1"].ToString();
                            txtAddress2.Text = reader["Addr2"].ToString();
                            txtPhoneNumber.Text = reader["PhoneNo"].ToString();
                            dpDOB.SelectedDate = Convert.ToDateTime(reader["Date_Birth"]);
                            dlNationality.SelectedValue = reader["nationalityID"].ToString();
                            txtEducation.Text = reader["education"].ToString();
                            txtNextOfKin.Text = reader["Kin"].ToString();
                            txtNOKRelation.Text = reader["Relation"].ToString();
                            txtNOKAddress.Text = reader["KinAddr"].ToString();
                            txtNOKPhoneNo.Text = reader["KinAddrPhone"].ToString();
                            dpRegdate.SelectedDate = Convert.ToDateTime(reader["RegDate"]);
                            txtContactPerson.Text = reader["ContPer"].ToString();
                            txtContactAddress.Text = reader["Contaddr"].ToString();
                            txtContactPhoneNo.Text = reader["ContPhone"].ToString();
                            txtSSFNo.Text = reader["SSFNo"].ToString();
                            txtNHISNo.Text = reader["NHIS"].ToString();
                            txtNewIDNo.Text = reader["NAT"].ToString();
                            txtShoeSize.Text = reader["ShoeSize"].ToString();
                            txtHeight.Text = reader["Height"].ToString();
                            dlTradeGroup.SelectedValue = reader["TradegroupID"].ToString();
                            dlTradeCategory.SelectedValue = reader["TradetypeID"].ToString();
                            dlGang.SelectedValue = reader["GangID"].ToString();
                            dlBank.SelectedValue = reader["BankID"].ToString();
                            string bankBranchId = reader["BankBranchId"].ToString();
                            query = "SELECT BranchId, BranchName, SortCode FROM [tblBankBranches] WHERE BranchId = '" + bankBranchId + "'";
                            bankBranchSource.SelectCommand = query;
                            dlBankBranch.DataBind();
                            dlBankBranch.SelectedValue = bankBranchId;
                            string repPoint = reader["DepartmentId"].ToString();
                            query = "SELECT ReportingPointId, ReportingPoint FROM tblReportingPoint WHERE ReportingPointId = '" + repPoint + "'";
                            repPointSource.SelectCommand = query;
                            dlReportingPoint.DataBind();
                            dlReportingPoint.SelectedValue = repPoint;
                            txtBankNo.Text = reader["BankNumber"].ToString();
                            dlPaymentOption.SelectedText = reader["PaymentOption"].ToString();
                            txtComments.Text = reader["OfficialComm"].ToString();
                            string flags = reader["flags"].ToString();
                            if (flags == "ACT")
                                lblStatus.Text = "Status : Active";
                            else if (flags == "INA")
                                lblStatus.Text = "Status : Inactive";
                            else if (flags == "NAY")
                                lblStatus.Text = "Status : Not Approved Yet";
                            else if (flags == "INC")
                                lblStatus.Text = "Status : Incapacitated";
                            else if (flags == "SUS")
                                lblStatus.Text = "Status : Suspended";
                            else if (flags == "DTH")
                                lblStatus.Text = "Status : Death";
                            dlGender.SelectedValue = reader["Sex"].ToString();
                            chkTax.Checked = Convert.ToBoolean(reader["Tax"]);
                            chkChargePremium.Checked = Convert.ToBoolean(reader["ChargePremium"]);
                            //Pics
                            byte[] bytes = new byte[0];
                            if (!Convert.IsDBNull(reader["Pics"]))
                                bytes = (byte[])reader["Pics"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            Image1.ImageUrl = "data:image/png;base64," + base64String;
                            ViewState["Image"] = bytes;
                            //SubHeader
                            txtEzwichNo.Text = reader["ezwichid"].ToString();
                            txtTIN.Text = reader["TIN"].ToString();
                            txtNationalIDNo.Text = reader["NationalID"].ToString();
                            lblAge.Text = reader["Age"].ToString() + " Years";

                            workerFound = true;
                        }
                        reader.Close();   
                    }
                    catch (SqlException ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                    }
                }
            }
            return workerFound;
        }
        protected void dlTradeGroup_ItemSelected(object sender, DropDownListEventArgs e)
        {
            dlTradeCategory.ClearSelection();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Byte[] imgByte = (byte[])ViewState["Image"];
            if (avatarUpload.PostedFile.ContentLength != 0 && avatarUpload.PostedFile.FileName != "")
            {
                HttpPostedFile File = avatarUpload.PostedFile;
                if (File.ContentLength / 1024 > 100)
                {
                    lblMsg.InnerText = "Image should not be greater than 100KB";
                    lblMsg.Attributes["class"] = "alert alert-danger";
                    return;
                }
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            //else
            //{
            //    lblMsg.InnerText = "Image Required";
            //    lblMsg.Attributes["class"] = "alert alert-danger";
            //    return;
            //}
            //calculate age
            DateTime dob = dpDOB.SelectedDate.Value;
            DateTime nowdate = DateTime.Now;
            int age = nowdate.Year - dob.Year;
            if (nowdate.Month < dob.Month || (nowdate.Month == dob.Month && nowdate.Day < dob.Day))// Are we before the birth date this year? If so subtract one year from the mix
            {
                age--;
            }
            if (age < 0)
            {
                lblMsg.InnerText = "Invalid Date of Birth selected. Please try again........";
                lblMsg.Attributes["class"] = "alert alert-danger";
                return;
            }

            //string query = "Update tblWorkers set WorkerType=@WorkerType,SName=@SName,OName=@OName,Pname=@Pname,Addr1=@Addr1,Addr2=@Addr2,PhoneNo=@PhoneNo,Date_Birth=@Date_Birth,nationalityID=@nationalityID,Kin=@Kin,Relation=@Relation,KinAddr=@KinAddr,KinAddrPhone=@KinAddrPhone,";
            //query += "RegDate=@RegDate,ContPer=@ContPer,Contaddr=@Contaddr,ContPhone=@ContPhone,SSFNo=@SSFNo,NHIS=@NHIS,NAT=@NAT,ShoeSize=@ShoeSize,Height=@Height,TradegroupID=@TradegroupID,TradetypeID=@TradetypeID,GangID=@GangID,BankID=@BankID,BankBranch=@BankBranch,BankNumber=@BankNumber,";
            //query += "OfficialComm=@OfficialComm,Sex=@Sex,Tax=@Tax,ChargePremium=@ChargePremium,Pics=@Pics,WHO=@WHO,WHOtime=@WHOtime,ezwichid=@ezwichid,NationalID=@NationalID,Age=@Age where AutoID=@AutoID";
            int bankId = 0;
            if (!String.IsNullOrEmpty(dlBank.SelectedValue))
                bankId = Convert.ToInt32(dlBank.SelectedValue);
            int repPointId = 0;
            if (!String.IsNullOrEmpty(dlReportingPoint.SelectedValue))
                repPointId = Convert.ToInt32(dlReportingPoint.SelectedValue);
            int bankBranchId = 0;
            if (!String.IsNullOrEmpty(dlBankBranch.SelectedValue))
                bankBranchId = Convert.ToInt32(dlBankBranch.SelectedValue);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spUpdateWorker", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@WorkerID", SqlDbType.VarChar).Value = txtWorkerID.Text;
                    command.Parameters.Add("@WorkerType", SqlDbType.VarChar).Value = dlWorkerType.SelectedValue;
                    command.Parameters.Add("@SName", SqlDbType.VarChar).Value = txtSurname.Text;
                    command.Parameters.Add("@OName", SqlDbType.VarChar).Value = txtOthernames.Text;
                    command.Parameters.Add("@Pname", SqlDbType.VarChar).Value = txtPreviousName.Text;
                    command.Parameters.Add("@Addr1", SqlDbType.VarChar).Value = txtAddress1.Text;
                    command.Parameters.Add("@Addr2", SqlDbType.VarChar).Value = txtAddress2.Text;
                    command.Parameters.Add("@PhoneNo", SqlDbType.VarChar).Value = txtPhoneNumber.Text;
                    command.Parameters.Add("@Date_Birth", SqlDbType.DateTime).Value = dob;
                    command.Parameters.Add("@nationalityID", SqlDbType.Int).Value = dlNationality.SelectedValue;
                    command.Parameters.Add("@education", SqlDbType.VarChar).Value = txtEducation.Text;
                    command.Parameters.Add("@Kin", SqlDbType.VarChar).Value = txtNextOfKin.Text;
                    command.Parameters.Add("@Relation", SqlDbType.VarChar).Value = txtNOKRelation.Text;
                    command.Parameters.Add("@KinAddr", SqlDbType.VarChar).Value = txtNOKAddress.Text;
                    command.Parameters.Add("@KinAddrPhone", SqlDbType.VarChar).Value = txtNOKPhoneNo.Text;
                    command.Parameters.Add("@RegDate", SqlDbType.DateTime).Value = dpRegdate.SelectedDate;
                    command.Parameters.Add("@ContPer", SqlDbType.VarChar).Value = txtContactPerson.Text;
                    command.Parameters.Add("@Contaddr", SqlDbType.VarChar).Value = txtContactAddress.Text;
                    command.Parameters.Add("@ContPhone", SqlDbType.VarChar).Value = txtContactPhoneNo.Text;
                    command.Parameters.Add("@SSFNo", SqlDbType.VarChar).Value = txtSSFNo.Text;
                    command.Parameters.Add("@NHIS", SqlDbType.VarChar).Value = txtNHISNo.Text;
                    command.Parameters.Add("@NAT", SqlDbType.VarChar).Value = txtNewIDNo.Text;
                    command.Parameters.Add("@ShoeSize", SqlDbType.NVarChar).Value = txtShoeSize.Text;
                    command.Parameters.Add("@Height", SqlDbType.NVarChar).Value = txtHeight.Text;
                    command.Parameters.Add("@TradegroupID", SqlDbType.Int).Value = dlTradeGroup.SelectedValue;
                    command.Parameters.Add("@TradetypeID", SqlDbType.Int).Value = dlTradeCategory.SelectedValue;
                    command.Parameters.Add("@GangID", SqlDbType.Int).Value = dlGang.SelectedValue;
                    command.Parameters.Add("@BankID", SqlDbType.Int).Value = bankId;
                    command.Parameters.Add("@BankBranchId", SqlDbType.Int).Value = bankBranchId;
                    command.Parameters.Add("@BankNumber", SqlDbType.VarChar).Value = txtBankNo.Text;
                    command.Parameters.Add("@OfficialComm", SqlDbType.VarChar).Value = txtComments.Text;
                    //command.Parameters.Add("@flags", SqlDbType.VarChar).Value = "NAY";
                    command.Parameters.Add("@Sex", SqlDbType.VarChar).Value = dlGender.SelectedValue;
                    command.Parameters.Add("@Tax", SqlDbType.Bit).Value = chkTax.Checked;
                    command.Parameters.Add("@ChargePremium", SqlDbType.Bit).Value = chkChargePremium.Checked;
                    //
                    command.Parameters.Add("@Pics", SqlDbType.Image).Value = imgByte;
                    command.Parameters.Add("@WHO", SqlDbType.VarChar).Value = Context.User.Identity.Name;
                    command.Parameters.Add("@WHOtime", SqlDbType.DateTime).Value = nowdate;
                    command.Parameters.Add("@ezwichid", SqlDbType.VarChar).Value = txtEzwichNo.Text;
                    command.Parameters.Add("@NationalID", SqlDbType.VarChar).Value = txtNationalIDNo.Text;
                    command.Parameters.Add("@TIN", SqlDbType.VarChar).Value = txtTIN.Text;
                    command.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = repPointId;
                    command.Parameters.Add("@PaymentOption", SqlDbType.VarChar).Value = dlPaymentOption.SelectedText;
                    command.Parameters.Add("@AutoID", SqlDbType.Int).Value = txtAutoNumber.Text;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        rows = command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        if (retVal == 0)
                        {
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Worker Saved Successfully', 'Success');", true);
                            lblMsg.InnerText = "Worker Updated Successfully";
                            lblMsg.Attributes["class"] = "alert alert-success";
                            lblAge.Text = age + " Years";
                            txtFullname.Text = txtSurname.Text + " " + txtOthernames.Text;

                            string base64String = Convert.ToBase64String(imgByte, 0, imgByte.Length);
                            Image1.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }
                    catch (Exception ex)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('" + ex.Message.Replace("'", "").Replace("\r\n", "") + "', 'Error');", true);
                        lblMsg.InnerText = ex.Message.Replace("'", "").Replace("\r\n", "");
                        lblMsg.Attributes["class"] = "alert alert-danger";
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bool workerFound =  loadWorkerDetails(txtSearchWorker.Text.Trim());
            if (workerFound)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "closenewModal();", true);
                txtSearchWorker.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.error('Worker not found', 'Error');", true);
                txtSearchWorker.Focus();
            }
            
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtWorkerID.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/vwWorkerDetails.aspx?workerid=" + txtWorkerID.Text + "');", true);
            }
        }
        protected void dlBankBranch_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = ((DataRowView)e.Item.DataItem)["BranchName"].ToString() + " - " + ((DataRowView)e.Item.DataItem)["SortCode"].ToString();
            e.Item.Value = ((DataRowView)e.Item.DataItem)["BranchId"].ToString();
        }

        protected void dlBankBranch_DataBound(object sender, EventArgs e)
        {
            //set the initial footer label
            ((Literal)dlBankBranch.Footer.FindControl("branchCount")).Text = Convert.ToString(dlBankBranch.Items.Count);
        }

        protected void dlBankBranch_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            String sql = "SELECT top (30) BranchId, BranchName, SortCode FROM [tblBankBranches] WHERE BankId = '" + dlBank.SelectedValue + "' AND (BranchName LIKE '%" + e.Text.ToUpper() + "%' OR SortCode LIKE '%" + e.Text.ToUpper() + "%')";
            bankBranchSource.SelectCommand = sql;
            dlBankBranch.DataBind();
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

        protected void dlBank_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            dlBankBranch.ClearSelection();
        }
    }
}