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

namespace GDLCApp.Reports
{
    public partial class vwWorkerDetails : System.Web.UI.Page
    {
        rptWorkerDetails rpt = new rptWorkerDetails();
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            rpt.Close();
            rpt.Dispose();
        }

        protected void WorkerDetailsReport_Load(object sender, EventArgs e)
        {
            string workerid = Request.QueryString["workerid"].ToString();
            adapter = new SqlDataAdapter("select * from vwWorkerDetails_Report where WorkerID =  @WorkerID", connection);
            adapter.SelectCommand.Parameters.Add("@WorkerID", SqlDbType.VarChar).Value = workerid;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwWorkerDetails_Report");
            rpt.SetDataSource(ds);

            adapter.Dispose();
            connection.Dispose();

            WorkerDetailsReport.ReportSource = rpt;

            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Context.Response, false, String.Empty);
        }
    }
}