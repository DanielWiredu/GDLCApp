﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwMonthlyProcessed_ByCompany.aspx.cs" Inherits="GDLCApp.CustomizePayroll.Reports.Monthly.Approved.vwMonthlyProcessed_ByCompany" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="MonthlyProcessedReport_ByCompany" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false" HasCrystalLogo="False" BestFitPage="False" Width="100%" Height="750px" HasToggleGroupTreeButton="false"/>
    </div>
    </form>
</body>
</html>
