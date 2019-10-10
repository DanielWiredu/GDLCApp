using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GDLCApp.Reports.Weekly.General
{
    public partial class vwWorkerList : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string cachedReports = "rptWorkerList";
            if (Session[cachedReports] == null)
            {
                loadReport(cachedReports);
            }
            else
            {
                WorkerListReport.ReportSource = Session[cachedReports];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loadReport(string cachedReports)
        {
            rptWorkerList rpt = new rptWorkerList();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter("select * from vwWorkerList where WorkerType = 'W'", connection);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwWorkerList");
            rpt.SetDataSource(ds);

            adapter.Dispose();
            connection.Dispose();

            Session[cachedReports] = rpt;
            WorkerListReport.ReportSource = rpt;
        }
    }
}