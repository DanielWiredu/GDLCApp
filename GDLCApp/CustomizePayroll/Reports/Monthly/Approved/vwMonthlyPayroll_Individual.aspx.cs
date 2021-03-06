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

namespace GDLCApp.CustomizePayroll.Reports.Monthly.Approved
{
    public partial class vwMonthlyPayroll_Individual : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string cachedReports = "rptMonthlyPayroll_Individual_CS";
            if (Session[cachedReports] == null)
            {
                loadReportNew(cachedReports);
            }
            else
            {
                MonthlyPayrollReport.ReportSource = Session[cachedReports];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loadReportNew(string cachedReports)
        {
            rptMonthlyApprovedCostSheetNew rpt = new rptMonthlyApprovedCostSheetNew();
            //int rptCacheTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("rptCacheTimeout").ToString());
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string workerid = Request.QueryString["workerid"].ToString();
            string startdate = Request.QueryString["st"].ToString();
            string enddate = Request.QueryString["ed"].ToString();
            ParameterValues parameters = new ParameterValues();
            ParameterDiscreteValue sdate = new ParameterDiscreteValue();
            ParameterDiscreteValue edate = new ParameterDiscreteValue();
            sdate.Value = startdate;
            edate.Value = enddate;
            adapter = new SqlDataAdapter("select * from vwMonthlyApprovedCostSheet_CS where workerid = @workerid and (Adate between @startdate and @enddate)", connection);
            adapter.SelectCommand.Parameters.Add("@workerid", SqlDbType.VarChar).Value = workerid;
            adapter.SelectCommand.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startdate;
            adapter.SelectCommand.Parameters.Add("@enddate", SqlDbType.DateTime).Value = enddate;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            adapter.Fill(ds, "vwMonthlyApprovedCostSheet_CS");
            rpt.SetDataSource(ds);
            parameters.Add(sdate);
            rpt.DataDefinition.ParameterFields["Startdate"].ApplyCurrentValues(parameters);
            parameters.Add(edate);
            rpt.DataDefinition.ParameterFields["Enddate"].ApplyCurrentValues(parameters);
            adapter.Dispose();
            connection.Dispose();
            //Cache.Insert(cachedReports, rpt, null, DateTime.MaxValue, TimeSpan.FromMinutes(rptCacheTimeout));
            Session[cachedReports] = rpt;
            MonthlyPayrollReport.ReportSource = rpt;
        }
    }
}