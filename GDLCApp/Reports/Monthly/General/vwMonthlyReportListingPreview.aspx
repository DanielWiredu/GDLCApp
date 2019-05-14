<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwMonthlyReportListingPreview.aspx.cs" Inherits="GDLCApp.Reports.Monthly.General.vwMonthlyReportListingPreview" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="MonthlyReportListingPreviewReport" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false" BestFitPage="False" Width="100%" Height="750px" HasToggleGroupTreeButton="false" />
    </div>
    </form>
</body>
</html>
