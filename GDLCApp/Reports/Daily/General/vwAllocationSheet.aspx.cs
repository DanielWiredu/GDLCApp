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

namespace GDLCApp.Reports.Daily.General
{
    public partial class vwAllocationSheet : System.Web.UI.Page
    {
        rptAllocationSheet rpt = new rptAllocationSheet();
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AllocationSheetReport_Load(object sender, EventArgs e)
        {
            string batchno = Request.QueryString["batchno"].ToString();
            adapter = new SqlDataAdapter("select * from vwAllocationSheet where Id = @batchno", connection);
            adapter.SelectCommand.Parameters.Add("@batchno", SqlDbType.VarChar).Value = batchno;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwAllocationSheet");
            rpt.SetDataSource(ds);

            adapter.Dispose();
            connection.Dispose();

            AllocationSheetReport.ReportSource = rpt;

            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Context.Response, false, String.Empty);
        }
    }
}