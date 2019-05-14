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
using System.IO;

namespace GDLCApp.WorkersTest
{
    public partial class NewWorker : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int rows = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpRegdate.SelectedDate = DateTime.Now;

                btnSave.Enabled = User.IsInRole("Data Entry");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void dlTradeGroup_ItemSelected(object sender, DropDownListEventArgs e)
        {
            dlTradeCategory.ClearSelection();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Byte[] imgByte = new byte[0];
            if (avatarUpload.PostedFile.ContentLength != 0 && avatarUpload.PostedFile.FileName != "")
            {
                HttpPostedFile File = avatarUpload.PostedFile;
                if (File.ContentLength / 1024 > 512)
                {
                    lblMsg.InnerText = "Image should not be greater than 512KB";
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
            // Read the file and convert it to Byte Array
            //string filePath = "";
            //string filePath = Server.MapPath(avatarUpload.PostedFile.FileName);
            //string filename = Path.GetFileName(filePath);
            //Byte[] bytes = new Byte[0];
            //if (!String.IsNullOrEmpty(filename))
            //{
            //    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //    BinaryReader br = new BinaryReader(fs);
            //    bytes = br.ReadBytes((Int32)fs.Length);
            //    br.Close();
            //    fs.Close();
            //}

            //string query = "INSERT INTO tblWorkers(WorkerID,WorkerType,SName,OName,Pname,Addr1,Addr2,PhoneNo,Date_Birth,nationalityID,Kin,Relation,KinAddr,KinAddrPhone,";
            //query += "RegDate,ContPer,Contaddr,ContPhone,SSFNo,NHIS,NAT,ShoeSize,Height,TradegroupID,TradetypeID,GangID,BankID,BankBranch, BankNumber,";
            //query += "OfficialComm,flags,Sex,Tax,ChargePremium,Pics,WHO,WHOtime,ezwichid,NationalID,Age) ";
            //query += "VALUES(@WorkerID,@WorkerType,@SName,@OName,@Pname,@Addr1,@Addr2,@PhoneNo,@Date_Birth,@nationalityID,@Kin,@Relation,@KinAddr,@KinAddrPhone,";
            //query += "@RegDate,@ContPer,@Contaddr,@ContPhone,@SSFNo,@NHIS,@NAT,@ShoeSize,@Height,@TradegroupID,@TradetypeID,@GangID,@BankID,@BankBranch,@BankNumber,";
            //query += "@OfficialComm,@flags,@Sex,@Tax,@ChargePremium,@Pics,@WHO,@WHOtime,@ezwichid,@NationalID,@Age)";
            int bankId = 0;
            if (!String.IsNullOrEmpty(dlBank.SelectedValue))
                bankId = Convert.ToInt32(dlBank.SelectedValue);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spAddWorker", connection))
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
                    command.Parameters.Add("@BankBranch", SqlDbType.VarChar).Value = txtBankBranch.Text;
                    command.Parameters.Add("@BankNumber", SqlDbType.VarChar).Value = txtBankNo.Text;
                    command.Parameters.Add("@OfficialComm", SqlDbType.VarChar).Value = txtComments.Text;
                    command.Parameters.Add("@flags", SqlDbType.VarChar).Value = "NAY";
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
                    command.Parameters.Add("@AutoID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@return_value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int retVal = Convert.ToInt16(command.Parameters["@return_value"].Value);
                        long autoID = Convert.ToInt64(command.Parameters["@AutoID"].Value);
                        if (retVal == 0)
                        {
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "toastr.success('Worker Saved Successfully', 'Success');", true);
                            lblMsg.InnerText = "Worker Saved Successfully";
                            lblMsg.Attributes["class"] = "alert alert-success";
                            txtAutoNumber.Text = autoID.ToString();
                            lblStatus.Text = "Not Approved Yet";
                            lblAge.Text = age + " Years";
                            txtFullname.Text = txtSurname.Text + " " + txtOthernames.Text;
                            txtWorkerID.ReadOnly = true;
                            btnSave.Enabled = false;
                            btnPrint.Enabled = true;
                            //Image1.ImageUrl = "~" + path + "?" + DateTime.Now.Ticks.ToString();
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
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtWorkerID.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newTab", "window.open('/Reports/vwWorkerDetails.aspx?workerid=" + txtWorkerID.Text + "');", true);
            }
        }
    }
}