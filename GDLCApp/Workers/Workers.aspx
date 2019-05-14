<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Workers.aspx.cs" Inherits="GDLCApp.Workers.Workers" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
table {
    border-collapse: collapse;
    width: 100%;
}

th {
    padding: 8px;
    text-align: left;
    border-bottom: 3px solid #000000;
    font-size:larger;
}
h3 {
    text-align: left;
    border-bottom: 2px solid #000000;
    font-weight:bold;
}
td {
    padding: 5px;
    text-align: left;
    border-bottom: 1px solid #ddd;
}
.tdlabel {
    padding: 5px;
    text-align: left;
    border-bottom: 1px solid #ddd;
    font-weight:bold;
}
tr:hover{background-color:#f5f5f5}
/*tr:nth-child(odd) {background-color: #f2f2f2}*/
</style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                var editedRow = eventArgs.get_itemIndexHierarchical();
                sender.get_masterTableView().fireCommand("View", editedRow);
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Workers</h5>
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
                         <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                        <div class="row">
                                        <div class="col-sm-4 pull-right" style="width:inherit">
                                           <asp:Button runat="server" ID="btnExcelExport" CssClass="btn-primary" Text="Excel" CausesValidation="false" OnClick="btnExcelExport_Click"/>
                                            <%--<asp:Button runat="server" ID="btnPDFExport" CssClass="btn btn-warning" Text="PDF" CausesValidation="false" OnClick="btnPDFExport_Click"/>--%>
                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">
                                                <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="Add Worker" CausesValidation="false" PostBackUrl="~/Workers/NewWorker.aspx" />  
                                            </div>
                                        </div>
                                    </div>

                             <telerik:RadGrid ID="workersGrid" runat="server" ShowFooter="true" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" CellSpacing="-1" GridLines="Both" DataSourceID="workerSource" OnItemCommand="workersGrid_ItemCommand">
                            <ClientSettings>
                                <ClientEvents OnRowDblClick="RowDblClick" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="400px" />
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                                 <ExportSettings IgnorePaging="true" ExportOnlyData="true" OpenInNewWindow="true" FileName="workers_list" HideStructureColumns="true"  >
                                        <Pdf AllowPrinting="true" AllowCopy="true" PaperSize="Letter" PageTitle="Workers List" PageWidth="1250"></Pdf>
                                    </ExportSettings>

                                 <MasterTableView DataKeyNames="WorkerID" DataSourceID="workerSource" PageSize="100" ToolTip="Double click to show details">
                                     <Columns>
                                         <%--<telerik:GridButtonColumn Text="View" CommandName="View" UniqueName="View" ButtonType="PushButton" ButtonCssClass="btn-info">
                                               <HeaderStyle Width="50px" />
                                           </telerik:GridButtonColumn>--%>
                                         <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Edit" ButtonCssClass="btn-info" Text="Edit" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                         <telerik:GridBoundColumn DataField="WorkerID" Aggregate="Count" FooterText="Total: " FilterControlAltText="Filter WorkerID column" HeaderText="Worker ID" ReadOnly="True" SortExpression="WorkerID" UniqueName="WorkerID" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="80px">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="SName" FilterControlAltText="Filter SName column" HeaderText="Surname" SortExpression="SName" UniqueName="SName" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="120px">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="OName" FilterControlAltText="Filter OName column" HeaderText="Othernames" SortExpression="OName" UniqueName="OName" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="140px">
                                         <HeaderStyle Width="180px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridDateTimeColumn DataField="Date_Birth" DataType="System.DateTime" FilterControlAltText="Filter Date_Birth column" HeaderText="Date of Birth" SortExpression="Date_Birth" UniqueName="Date_Birth" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="120px" DataFormatString="{0:dd-MMM-yyyy}">
                                           <HeaderStyle Width="140px" />
                                           </telerik:GridDateTimeColumn>
                                         <telerik:GridBoundColumn DataField="GangName" FilterControlAltText="Filter GangName column" HeaderText="Gang" SortExpression="GangName" UniqueName="GangName" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="110px">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="SSFNo" FilterControlAltText="Filter SSFNo column" HeaderText="SSF No" SortExpression="SSFNo" UniqueName="SSFNo" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="110px">
                                         <HeaderStyle Width="140px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="TradegroupNAME" FilterControlAltText="Filter TradegroupNAME column" HeaderText="Trade Group" SortExpression="TradegroupNAME" UniqueName="TradegroupNAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="80px" CurrentFilterFunction="EndsWith">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="TradetypeNAME" FilterControlAltText="Filter TradetypeNAME column" HeaderText="Trade Category" SortExpression="TradetypeNAME" UniqueName="TradetypeNAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="120px">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ezwichid" FilterControlAltText="Filter ezwichid column" HeaderText="Ezwich No" SortExpression="ezwichid" UniqueName="ezwichid" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100px">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="NHIS" FilterControlAltText="Filter NHIS column" HeaderText="NHIS No" SortExpression="NHIS" UniqueName="NHIS" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100px">
                                         <HeaderStyle Width="140px" />
                                         </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Delete Record?" ButtonType="PushButton" ButtonCssClass="btn-danger" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                     </Columns>
                                 </MasterTableView>

                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="workerSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [WorkerID], [SName], [OName], [Date_Birth], [GangName], [SSFNo], [TradegroupNAME], [TradetypeNAME], [NHIS], [ezwichid] FROM [vwWorkers]" DeleteCommand="spDeleteWorker" DeleteCommandType="StoredProcedure">
                            <%--<DeleteParameters>
                                <asp:Parameter Name="WorkerID" Type="String" />
                                <asp:ControlParameter Name="DeletedBy" Type="String" ControlID="hfUsername" PropertyName="Value" />
                            </DeleteParameters>--%>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                             <Triggers>
                                  <asp:PostBackTrigger ControlID="btnExcelExport" />
                                  <%--<asp:PostBackTrigger ControlID="btnPDFExport" />--%>
                              </Triggers>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>


     <!--  Worker Details modal -->
    <div class="modal fade" id="workerdetailsmodal">

    <div class="modal-dialog" style="width:80%">
      <asp:UpdatePanel runat="server">
          <ContentTemplate>
               <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">View </h4>
                </div>
                        <div class="modal-body">
                             <asp:Panel ID="ListViewPanel2" runat="server">
            <telerik:RadListView ID="RadListView2" RenderMode="Lightweight" Width="97%" AllowPaging="True" runat="server"
                ItemPlaceholderID="ProductsHolder" DataKeyNames="WorkerID">
                <LayoutTemplate>
                    <fieldset class="layoutFieldset" id="FieldSet2">
                        <asp:Panel ID="ProductsHolder" runat="server">
                        </asp:Panel>
                    </fieldset>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="itemWrapper">
                        <h3>Worker Details</h3>
                        <div class="row">
                            <div class="col-md-6">
                                <table id="Table3" border="0" class="module">
                                        <tr>
                                            <td class="tdlabel">Worker ID:
                                            </td>
                                            <td>
                                                <%# Eval("workerid") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Fullname:
                                            </td>
                                            <td>
                                                <%# Eval("fullname") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Worker Type:
                                            </td>
                                            <td>
                                               <%# Eval("workertype") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Gender:
                                            </td>
                                            <td>
                                                <%# Eval("sex") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Phone No:
                                            </td>
                                            <td>
                                                <%# Eval("phoneno") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Address:
                                            </td>
                                            <td>
                                               <%# Eval("addr1") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Status:
                                            </td>
                                            <td>
                                               <%# Eval("flags") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Date Registered:
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "regdate", "{0:dd-MMM-yyyy}") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Date of Birth:
                                            </td>
                                            <td>
                                               <%# DataBinder.Eval(Container.DataItem, "date_birth", "{0:dd-MMM-yyyy}") %>
                                            </td>
                                        </tr>
                                    </table>
                            </div>
                            <div class="col-md-6">
                                <table id="Table1" border="0" class="module">
                             
                                        <tr>
                                            <td class="tdlabel">GangName: 
                                            </td>
                                            <td>
                                                <%# Eval("gangname") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Trade Group: </td>
                                            <td>
                                                <%# Eval("TradegroupNAME") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Trade Type: </td>
                                            <td>
                                                <%# Eval("TradetypeNAME") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Nexk of Kin: </td>
                                            <td>
                                                <%# Eval("kin") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Ezwich No: </td>
                                            <td>
                                                <%# Eval("ezwichid") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">SSNIT No: </td>
                                            <td>
                                                <%# Eval("ssfno") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">NHIS No: </td>
                                            <td>
                                                <%# Eval("nhis") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">National ID: </td>
                                            <td>
                                                <%# Eval("nat") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Age: </td>
                                            <td>
                                                <%# Eval("age") %>
                                            </td>
                                        </tr>
                                    </table>
                            </div>
                        </div>
                        <%--<table id="Table2" cellspacing="2" cellpadding="1" width="100%" border="0" rules="none"
                            style="border-collapse: collapse;">
                            <tr >
                                <td style="width:50%">
                                    <table id="Table3" border="0" class="module">
                                        <tr>
                                            <td class="tdlabel">Worker ID:
                                            </td>
                                            <td>
                                                <%# Eval("workerid") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Fullname:
                                            </td>
                                            <td>
                                                <%# Eval("fullname") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Worker Type:
                                            </td>
                                            <td>
                                               <%# Eval("workertype") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Gender:
                                            </td>
                                            <td>
                                                <%# Eval("sex") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Phone No:
                                            </td>
                                            <td>
                                                <%# Eval("phoneno") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Address:
                                            </td>
                                            <td>
                                               <%# Eval("addr1") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Status:
                                            </td>
                                            <td>
                                               <%# Eval("flags") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Date Registered:
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "regdate", "{0:dd-MMM-yyyy}") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Date of Birth:
                                            </td>
                                            <td>
                                               <%# DataBinder.Eval(Container.DataItem, "date_birth", "{0:dd-MMM-yyyy}") %>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:50%">
                                    <table id="Table1" border="0" class="module">
                             
                                        <tr>
                                            <td class="tdlabel">GangName: 
                                            </td>
                                            <td>
                                                <%# Eval("gangname") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdlabel">Trade Group: </td>
                                            <td>
                                                <%# Eval("TradegroupNAME") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Trade Type: </td>
                                            <td>
                                                <%# Eval("TradetypeNAME") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Nexk of Kin: </td>
                                            <td>
                                                <%# Eval("kin") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Ezwich No: </td>
                                            <td>
                                                <%# Eval("ezwichid") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">SSNIT No: </td>
                                            <td>
                                                <%# Eval("ssfno") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">NHIS No: </td>
                                            <td>
                                                <%# Eval("nhis") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">National ID: </td>
                                            <td>
                                                <%# Eval("nat") %>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="tdlabel">Age: </td>
                                            <td>
                                                <%# Eval("age") %>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>--%>
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
        </asp:Panel>

                            <%--<telerik:RadDataPager RenderMode="Lightweight" ID="RadDataPager2" runat="server" PagedControlID="RadListView2"
                        PageSize="1">
                        <Fields>
                            <telerik:RadDataPagerButtonField FieldType="FirstPrev"></telerik:RadDataPagerButtonField>
                            <telerik:RadDataPagerButtonField FieldType="Numeric"></telerik:RadDataPagerButtonField>
                            <telerik:RadDataPagerButtonField FieldType="NextLast"></telerik:RadDataPagerButtonField>
                        </Fields>
                    </telerik:RadDataPager>--%>


                       </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Return</button>
                </div>
            </div>
          </ContentTemplate>
      </asp:UpdatePanel>
        </div>
    </div>

           <script type="text/javascript">
            function showWorkerModal() {
                $('#workerdetailsmodal').modal('show');
            }
    </script>
</asp:Content>
