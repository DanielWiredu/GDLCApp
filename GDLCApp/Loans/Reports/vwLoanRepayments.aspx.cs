using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CrystalDecisions.Shared;

namespace GDLCApp.Loans.Reports
{
    public partial class vwLoanRepayments : System.Web.UI.Page
    {
        rptLoanRepayments rpt = new rptLoanRepayments();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadReport();
            }
        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            rpt.Close();
            rpt.Dispose();
        }

        protected void loadReport()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string loanno = Request.QueryString["loanno"].ToString();

            adapter = new SqlDataAdapter("select * from vwLoanRepayments where (LoanNo = @LoanNo)", connection);
            adapter.SelectCommand.Parameters.Add("@LoanNo", SqlDbType.VarChar).Value = loanno;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwLoanRepayments");
            rpt.SetDataSource(ds);

            adapter.Dispose();
            connection.Dispose();

            LoanRepaymentReport.ReportSource = rpt;

            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Context.Response, false, String.Empty);
        }
    }
}