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
    public partial class vwLabourRequestList : System.Web.UI.Page
    {
        rptLabourRequestList rpt = new rptLabourRequestList();
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LabourRequestListReport_Load(object sender, EventArgs e)
        {
            string reqno = Request.QueryString["reqno"].ToString();
            adapter = new SqlDataAdapter("select * from vwDailyCostSheet where Reqno = @reqno", connection);
            adapter.SelectCommand.Parameters.Add("@reqno", SqlDbType.VarChar).Value = reqno;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwDailyCostSheet");
            rpt.SetDataSource(ds);

            adapter.Dispose();
            connection.Dispose();

            LabourRequestListReport.ReportSource = rpt;

            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Context.Response, false, String.Empty);
        }
    }
}