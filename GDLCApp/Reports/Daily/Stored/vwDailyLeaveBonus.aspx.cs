﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CrystalDecisions.Shared;

namespace GDLCApp.Reports.Daily.Stored
{
    public partial class vwDailyLeaveBonus : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string cachedReports = "rptDailyLeaveBonus";
            if (Cache[cachedReports] == null)
            {
                loadReport(cachedReports);
            }
            else
            {
                DailyLeaveBonusReport.ReportSource = Cache[cachedReports];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loadReport(string cachedReports)
        {
            int rptCacheTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("rptCacheTimeout").ToString());
            rptDailyLeaveBonus rpt = new rptDailyLeaveBonus();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string startdate = Request.QueryString["st"].ToString();
            string enddate = Request.QueryString["ed"].ToString();

            ParameterValues parameters = new ParameterValues();
            ParameterDiscreteValue sdate = new ParameterDiscreteValue();
            ParameterDiscreteValue edate = new ParameterDiscreteValue();

            sdate.Value = startdate;
            edate.Value = enddate;

            adapter = new SqlDataAdapter("select * from vwDailyLeaveBonus where (Adate between @startdate and @enddate)", connection);
            adapter.SelectCommand.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startdate;
            adapter.SelectCommand.Parameters.Add("@enddate", SqlDbType.DateTime).Value = enddate;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwDailyLeaveBonus");
            rpt.SetDataSource(ds);

            parameters.Add(sdate);
            rpt.DataDefinition.ParameterFields["Startdate"].ApplyCurrentValues(parameters);
            parameters.Add(edate);
            rpt.DataDefinition.ParameterFields["Enddate"].ApplyCurrentValues(parameters);

            adapter.Dispose();
            connection.Dispose();
            Cache.Insert(cachedReports, rpt, null, DateTime.MaxValue, TimeSpan.FromMinutes(rptCacheTimeout));
            DailyLeaveBonusReport.ReportSource = rpt;
        }
    }
}