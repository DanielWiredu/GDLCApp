﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwMonthlyPreviewCostSheet.aspx.cs" Inherits="GDLCApp.CustomizePayroll.Reports.Monthly.General.vwMonthlyPreviewCostSheet" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <CR:CrystalReportViewer ID="MonthlyPreviewCostSheetReport" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false" BestFitPage="False" Width="100%" Height="750px" />
    </div>
    </form>
</body>
</html>
