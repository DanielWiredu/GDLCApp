<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="WorkersIDCard.aspx.cs" Inherits="GDLCApp.Workers.WorkersIDCard" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/css/aspControlStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Worker ID Cards</h5>
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
                         <asp:UpdatePanel runat="server" >
                    <ContentTemplate>
                        <div class="row">
                                        <div class="col-sm-4 pull-right" >
                                            <asp:TextBox runat="server" ID="txtSearchWorker" Width="100%" placeholder="Worker ID / Name..." OnTextChanged="txtSearchWorker_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">
                                                <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="Add" CausesValidation="false" OnClientClick="showWorkersModal();" />  
                                                <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-info" Text="Generate Card" CausesValidation="false" OnClick="btnPrint_Click" />  
                                                <asp:Button runat="server" ID="btnClearWorkers" CssClass="btn btn-danger" Text="Clear" CausesValidation="false" OnClick="btnClearWorkers_Click" />  
                                            </div>
                                        </div>
                                    </div>
                        <hr />
                             <telerik:RadGrid ID="workerIDCardGrid" runat="server" DataSourceID="workerIDCardSource" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowPaging="False" AllowSorting="True" CellSpacing="-1" GridLines="Both" OnItemDeleted="workerIDCardGrid_ItemDeleted">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="400px" />
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />

                                 <MasterTableView DataKeyNames="WorkerId" DataSourceID="workerIDCardSource" AllowAutomaticDeletes="true">
                                     <Columns>
                                         <telerik:GridBoundColumn DataField="WorkerId" FilterControlAltText="Filter WorkerId column" HeaderText="WorkerId" ReadOnly="True" SortExpression="WorkerId" UniqueName="WorkerId">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="WorkerName" FilterControlAltText="Filter WorkerName column" HeaderText="Worker Name" SortExpression="WorkerName" UniqueName="WorkerName">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridDateTimeColumn DataField="Date_Birth" DataType="System.DateTime" FilterControlAltText="Filter Date_Birth column" HeaderText="Date_Birth" SortExpression="Date_Birth" UniqueName="Date_Birth" DataFormatString="{0:dd-MMM-yyyy}">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridDateTimeColumn>
                                         <telerik:GridBoundColumn DataField="WorkerType" FilterControlAltText="Filter WorkerType column" HeaderText="WorkerType" SortExpression="WorkerType" UniqueName="WorkerType">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridDateTimeColumn DataField="RegDate" DataType="System.DateTime" FilterControlAltText="Filter RegDate column" HeaderText="RegDate" SortExpression="RegDate" UniqueName="RegDate" DataFormatString="{0:dd-MMM-yyyy}">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridDateTimeColumn>
                                         <telerik:GridDateTimeColumn DataField="ValidFrom" DataType="System.DateTime" FilterControlAltText="Filter ValidFrom column" HeaderText="ValidFrom" SortExpression="ValidFrom" UniqueName="ValidFrom" DataFormatString="{0:dd-MMM-yyyy}">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridDateTimeColumn>
                                         <telerik:GridDateTimeColumn DataField="ValidTo" DataType="System.DateTime" FilterControlAltText="Filter ValidTo column" HeaderText="ValidTo" SortExpression="ValidTo" UniqueName="ValidTo" DataFormatString="{0:dd-MMM-yyyy}">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridDateTimeColumn>
                                        <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Delete Record?" ButtonType="FontIconButton" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                     </Columns>
                                 </MasterTableView>

                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="workerIDCardSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM vwWorkersIDCard WHERE (WorkerId LIKE '%' + @SearchValue + '%' OR WorkerName LIKE '%' + @SearchValue + '%')" DeleteCommand="DELETE FROM [tblWorkersIDCard] WHERE [WorkerId] = @WorkerId">
                            <DeleteParameters>
                                <asp:Parameter Name="WorkerId" Type="String" />
                            </DeleteParameters>
                            <SelectParameters>
                                <asp:ControlParameter Name="SearchValue" ControlID="txtSearchWorker" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                             <%--<Triggers>
                                  <asp:PostBackTrigger ControlID="btnSearch" />
                              </Triggers>--%>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>


      <!-- workers modal -->
         <div class="modal fade" id="workersmodal">
    <div class="modal-dialog" style="width:70%">
        <asp:Panel runat="server" DefaultButton="btnSearch">
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                 <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Workers</h4>
                </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:RadioButtonList ID="rdSearchType" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                                    <asp:ListItem Text="WorkerID" Value="WorkerID" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="SSF No" Value="SSFNo"></asp:ListItem>
                                    <asp:ListItem Text="NHIS No" Value="NHISNo"></asp:ListItem>
                                    <asp:ListItem Text="Gang" Value="Gang"></asp:ListItem>
                                    <asp:ListItem Text="Surname" Value="Surname"></asp:ListItem>
                                    <asp:ListItem Text="Other Names" Value="Othernames"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                             <div class="form-group">
                                        <%--<label>Enter Value</label>--%>
                                       <asp:TextBox runat="server" ID="txtSearchValue" Width="100%" MaxLength="50" ClientIDMode="Static" ></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtSearchValue" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="search"></asp:RequiredFieldValidator>
                             </div>
                            <div>
                                <telerik:RadGrid ID="workersGrid" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowPaging="true" CellSpacing="-1" GridLines="Both" OnItemCommand="workersGrid_ItemCommand" OnNeedDataSource="workersGrid_NeedDataSource">
                            <ClientSettings >
                                <%--<Virtualization EnableVirtualization="true" InitiallyCachedItemsCount="100" ItemsPerView="100" />--%>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="350px" SaveScrollPosition="false" />
                                <Selecting AllowRowSelect="true" />
                                <ClientEvents OnRowDblClick="RowDblClick" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />

                                 <MasterTableView DataKeyNames="WorkerID" AllowSorting="false" AllowFilteringByColumn="false" PageSize="50">
                                     <Columns>
                                        <%--<telerik:GridButtonColumn ButtonType="FontIconButton" CommandName="Edit" Text="Add" Exportable="false">
                                        <HeaderStyle Width="30px" />
                                        </telerik:GridButtonColumn>--%>
                                         <telerik:GridBoundColumn DataField="WorkerID" FilterControlAltText="Filter WorkerID column" HeaderText="Worker ID" ReadOnly="True" SortExpression="WorkerID" UniqueName="WorkerID" AutoPostBackOnFilter="true" ShowFilterIcon="false" AllowFiltering="false">
                                         <HeaderStyle Width="80px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="SName" FilterControlAltText="Filter SName column" HeaderText="Surname" SortExpression="SName" UniqueName="SName" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="110px">
                                         <HeaderStyle Width="140px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="OName" FilterControlAltText="Filter OName column" HeaderText="Othernames" SortExpression="OName" UniqueName="OName" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="140px">
                                         <HeaderStyle Width="170px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="GangName" FilterControlAltText="Filter GangName column" HeaderText="Gang" SortExpression="GangName" UniqueName="GangName" AutoPostBackOnFilter="true" ShowFilterIcon="false" AllowFiltering="false">
                                         <HeaderStyle Width="130px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="SSFNo" FilterControlAltText="Filter SSFNo column" HeaderText="SSF No" SortExpression="SSFNo" UniqueName="SSFNo" AutoPostBackOnFilter="true" ShowFilterIcon="false" AllowFiltering="false">
                                         <HeaderStyle Width="130px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn Display="false" DataField="TradegroupID" SortExpression="TradegroupID" UniqueName="TradegroupID">
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="TradegroupNAME" FilterControlAltText="Filter TradegroupNAME column" HeaderText="Trade Group" SortExpression="TradegroupNAME" UniqueName="TradegroupNAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" AllowFiltering="false">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn Display="false" DataField="TradetypeID" SortExpression="TradetypeID" UniqueName="TradetypeID">
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="TradetypeNAME" FilterControlAltText="Filter TradetypeNAME column" HeaderText="Trade Category" SortExpression="TradetypeNAME" UniqueName="TradetypeNAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" AllowFiltering="false">
                                         <HeaderStyle Width="140px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="NHIS" FilterControlAltText="Filter NHIS column" HeaderText="NHIS No" SortExpression="NHIS" UniqueName="NHIS" AutoPostBackOnFilter="true" ShowFilterIcon="false" AllowFiltering="false">
                                         <HeaderStyle Width="130px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn Display="false" DataField="flags" FilterControlAltText="Filter flags column" HeaderText="flags" SortExpression="flags" UniqueName="flags">
                                         <HeaderStyle Width="50" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn Display="false" DataField="ezwichid" FilterControlAltText="Filter ezwichid column" HeaderText="ezwichid" SortExpression="ezwichid" UniqueName="ezwichid" EmptyDataText="">
                                         <HeaderStyle Width="50" />
                                         </telerik:GridBoundColumn>
                                     </Columns>
                                 </MasterTableView>

                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="workerSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [WorkerID], [SName], [OName], [GangName], [SSFNo], [TradegroupID], [TradegroupNAME] ,[TradetypeID], [TradetypeNAME], [NHIS], [flags], [ezwichid] FROM [vwWorkers]">
                        </asp:SqlDataSource>
                            </div>
                       </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSearch" runat="server" Text="Find" CssClass="btn btn-primary"  OnClick="btnSearch_Click" ValidationGroup="search" />
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel>
        </div>
         </div>

     <script type="text/javascript">
            function showWorkersModal() {
                $('#workersmodal').modal('show');
                $('#workersmodal').appendTo($("form:first"));
            }
            $('#workersmodal').on('shown.bs.modal', function () {
                $('#txtSearchValue').focus();
            });
            function closeWorkersModal() {
                $('#workersmodal').modal('hide');
            }
    </script>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                var editedRow = eventArgs.get_itemIndexHierarchical();
                sender.get_masterTableView().fireCommand("AddWorker", editedRow);
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
