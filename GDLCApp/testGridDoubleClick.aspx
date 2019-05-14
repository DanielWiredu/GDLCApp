<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="testGridDoubleClick.aspx.cs" Inherits="GDLCApp.testGridDoubleClick" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            var isDoubleClick = false;
            var clickHandler = null;
            var ClikedDataKey = null;

            function RowClick(sender, args) {
                ClikedDataKey = args._dataKeyValues.ID;
                isDoubleClick = false;
                if (clickHandler) {
                    window.clearTimeout(clickHandler);
                    clickHandler = null;
                }
                clickHandler = window.setTimeout(ActualClick, 200);
            }
            function RowClick2(sender, eventArgs) {
                var editedRow = eventArgs.get_itemIndexHierarchical();
                sender.get_masterTableView().fireCommand("RowDoubleClick", editedRow);
            }
            function RowDblClick(sender, args) {
                ClikedDataKey = args.get_itemIndexHierarchical();
                isDoubleClick = true;
                if (clickHandler) {
                    window.clearTimeout(clickHandler);
                    clickHandler = null;
                }
                clickHandler = window.setTimeout(ActualClick, 200);
            }

            function ActualClick() {
                if (isDoubleClick) {
                    var grid = $find("<%=RadGrid1.ClientID %>");
                    if (grid) {
                        var MasterTable = grid.get_masterTableView();
                        var Rows = MasterTable.get_dataItems();
                        for (var i = 0; i < Rows.length; i++) {
                            var row = Rows[i];
                            if (ClikedDataKey != null && ClikedDataKey == row.get_itemIndexHierarchical()) {
                                MasterTable.fireCommand("RowDoubleClick", ClikedDataKey);
                            }
                        }
                    }
                }
                else {
                    var grid = $find("<%=RadGrid1.ClientID %>");
                    if (grid) {
                        var MasterTable = grid.get_masterTableView();
                        var Rows = MasterTable.get_dataItems();
                        for (var i = 0; i < Rows.length; i++) {
                            var row = Rows[i];
                            if (ClikedDataKey != null && ClikedDataKey == row.getDataKeyValue("ID")) {
                                MasterTable.fireCommand("RowSingleClick", ClikedDataKey);
                            }
                        }
                    }
                }
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Nationality</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="close-link">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                         <%--<asp:UpdatePanel runat="server" >
                    <ContentTemplate>--%>
                        <div class="row">
                                        <div class="col-sm-4 pull-right">
                                           
                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">

                                            </div>
                                        </div>
                                    </div>
                            

                           
    <script type="text/javascript">
        //Put your JavaScript code here.
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel" />
                    <telerik:AjaxUpdatedControl ControlID="Label1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div>
        <telerik:RadGrid ID="RadGrid1" AllowFilteringByColumn="true" runat="server" AutoGenerateColumns="False" OnNeedDataSource="RadGrid1_NeedDataSource"
            OnItemCommand="RadGrid1_ItemCommand">
             <ClientSettings EnablePostBackOnRowClick="true">
                <ClientEvents OnRowDblClick="RowClick2"  />
                <Selecting AllowRowSelect="true" />
            </ClientSettings>
            <MasterTableView DataKeyNames="ID" ClientDataKeyNames="ID">
                <Columns>
                    <telerik:GridBoundColumn DataField="ID" HeaderText="ID" UniqueName="ID" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" HeaderText="Name" UniqueName="Name">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>

                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                    </div>
                </div>
        </div>

</asp:Content>
