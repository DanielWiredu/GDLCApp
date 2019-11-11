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
    public partial class vwWorkersIDCard : System.Web.UI.Page
    {
        rptWorkersIDCard rpt = new rptWorkersIDCard();
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

        protected void WorkerIDCardReport_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from vwWorkersIDCard", connection);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwWorkersIDCard");
            rpt.SetDataSource(ds);

            adapter.Dispose();
            connection.Dispose();

            WorkerIDCardReport.ReportSource = rpt;

            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Context.Response, false, String.Empty);
        }
    }
}