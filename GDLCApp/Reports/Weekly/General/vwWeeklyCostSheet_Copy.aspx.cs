using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDLCApp.Reports.Weekly.General
{
    public partial class vwWeeklyCostSheet_Copy : System.Web.UI.Page
    {
        rptWeeklyCostSheet___Copy rpt = new rptWeeklyCostSheet___Copy();
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

        protected void WeeklyCostSheetReport_Copy_Load(object sender, EventArgs e)
        {
            string startdate = Request.QueryString["st"].ToString();
            string enddate = Request.QueryString["ed"].ToString();
            string reqno = Request.QueryString["reqno"].ToString();

            adapter = new SqlDataAdapter("select * from vwWeeklyCostSheet where Reqno like '%' + @reqno + '%' and (date_ between @startdate and @enddate)", connection);
            adapter.SelectCommand.Parameters.Add("@reqno", SqlDbType.VarChar).Value = reqno;
            adapter.SelectCommand.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startdate;
            adapter.SelectCommand.Parameters.Add("@enddate", SqlDbType.DateTime).Value = enddate;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwWeeklyCostSheet");
            rpt.SetDataSource(ds);

            adapter.Dispose();
            connection.Dispose();

            WeeklyCostSheetReport_Copy.ReportSource = rpt;

            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Context.Response, false, String.Empty);
        }
    }
}