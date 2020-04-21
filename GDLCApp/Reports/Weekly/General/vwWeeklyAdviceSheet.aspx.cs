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

namespace GDLCApp.Reports.Weekly.General
{
    public partial class vwWeeklyAdviceSheet : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string cachedReports = "rptWeeklyAdviceSheet";
            if (Session[cachedReports] == null)
            {
                loadReport(cachedReports);
            }
            else
            {
                WeeklyAdviceSheetReport.ReportSource = Session[cachedReports];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loadReport(string cachedReports)
        {
            //int rptCacheTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("rptCacheTimeout").ToString());
            rptAdviceSheet rpt = new rptAdviceSheet();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            string startdate = Request.QueryString["st"].ToString();
            string enddate = Request.QueryString["ed"].ToString();
            adapter = new SqlDataAdapter("select * from vwLabourAdviceDetails where LabourType='Weekly' and (date_ between @startdate and @enddate)", connection);
            adapter.SelectCommand.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startdate;
            adapter.SelectCommand.Parameters.Add("@enddate", SqlDbType.DateTime).Value = enddate;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwLabourAdviceDetails");
            rpt.SetDataSource(ds);

            adapter.Dispose();
            connection.Dispose();
            //Cache.Insert(cachedReports, rpt, null, DateTime.MaxValue, TimeSpan.FromMinutes(rptCacheTimeout));
            Session[cachedReports] = rpt;
            WeeklyAdviceSheetReport.ReportSource = rpt;
        }
    }
}