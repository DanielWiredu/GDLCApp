<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwDailyInvoice_ByCompany.aspx.cs" Inherits="GDLCApp.Reports.Daily.Approved.vwDailyInvoice_ByCompany" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  
    <%--Format:
    <asp:RadioButtonList ID="rbFormat" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Text="PDF" Value="PDF" Selected="True" />
        <asp:ListItem Text="Excel" Value="Excel" />
        <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
    </asp:RadioButtonList>
 
    <asp:Button ID="btnEmail" Text="SEND EMAIL" runat="server" OnClick="btnEmail_Click" CssClass="btn-success" />
        <br />--%>

        <CR:CrystalReportViewer ID="DailyInvoiceReport_ByCompany" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false" BestFitPage="False" Width="100%" Height="750px" HasToggleGroupTreeButton="false" />
        
        
    </div>
    </form>
</body>
</html>
