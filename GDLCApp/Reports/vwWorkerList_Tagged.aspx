<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwWorkerList_Tagged.aspx.cs" Inherits="GDLCApp.Reports.vwWorkerList_Tagged" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="cboCurrentPrinters" runat="server">

        </asp:DropDownList>
        <asp:Button runat="server" ID="btnPrinttoPrinter" Text="Print to Printer" OnClick="btnPrinttoPrinter_Click" />

        <%--<asp:DropDownList ID="cboDefaultPrinters" runat="server" Width="300px">

        </asp:DropDownList>--%>
        <%--<asp:DropDownList ID="DropDownList1" runat="server" Width="215px">
            <asp:ListItem>Portable Document (PDF)</asp:ListItem>
            <asp:ListItem>Rich Text (RTF)</asp:ListItem>
            <asp:ListItem>MS Word (DOC)</asp:ListItem>
            <asp:ListItem>MS Excel (XLS)</asp:ListItem>
        </asp:DropDownList>--%>
        <asp:Button ID="btnExport" runat="server" Text="Export to Browser"  OnClick="btnExport_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPrint" runat="server" Text="Print to Default Printer"  OnClick="btnPrint_Click" />

        <input type="button" id="btnPrintReport" value="Print Page" onclick="Print()" />
    <div id="dvReport">
        <CR:CrystalReportViewer ID="WorkerListTaggedReport" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false" BestFitPage="False" Width="100%" Height="750px"  PrintMode="ActiveX" />
    </div>
    </form>

    <script type="text/javascript">
function Print() {
    var dvReport = document.getElementById("dvReport");
    var frame1 = dvReport.getElementsByTagName("iframe")[0];
    if (navigator.appName.indexOf("Internet Explorer") != -1) {
        frame1.name = frame1.id;
        window.frames[frame1.id].focus();
        window.frames[frame1.id].print();
    }
    else {
        var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
        frameDoc.print();
    }
}
</script>

</body>
</html>
