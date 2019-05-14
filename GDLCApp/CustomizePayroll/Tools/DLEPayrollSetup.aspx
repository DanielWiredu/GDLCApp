<%@ Page Title="" Language="C#" MasterPageFile="~/CustomizePayroll/CSHome.Master" AutoEventWireup="true" CodeBehind="DLEPayrollSetup.aspx.cs" Inherits="GDLCApp.CustomizePayroll.Tools.DLEPayrollSetup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5> DLE Payroll Setup</h5>
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
                                        <div class="col-sm-4 pull-right" style="width:inherit">

                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">
                                                <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="Add New" PostBackUrl="~/CustomizePayroll/Tools/NewDLEPayrollSetup.aspx" />  
                                            </div>
                                        </div>
                                    </div>

                             <telerik:RadGrid ID="dleGrid" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" CellSpacing="-1" GridLines="Both" DataSourceID="dleSource" OnItemCommand="dleGrid_ItemCommand" OnItemDeleted="dleGrid_ItemDeleted">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                                 <MasterTableView DataKeyNames="DleCompanyId" DataSourceID="dleSource" AllowAutomaticDeletes="true">
                                     <Columns>
<%--                                         <telerik:GridBoundColumn Display="false" DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID">
                                         </telerik:GridBoundColumn>--%>
                                         <telerik:GridBoundColumn Display="false" DataField="DleCompanyId" DataType="System.Int32" FilterControlAltText="Filter DleCompanyId column" HeaderText="Company ID" ReadOnly="True" SortExpression="DleCompanyId" UniqueName="DleCompanyId">
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="DLEcodeCompanyName" FilterControlAltText="Filter DLEcodeCompanyName column" HeaderText="DLE CompanyName" SortExpression="DLEcodeCompanyName" UniqueName="DLEcodeCompanyName" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="250px">
                                         <HeaderStyle Width="300px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Edit" ButtonCssClass="btn-info" Text="Edit" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn Display="false" Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Delete Record?" ButtonType="PushButton" ButtonCssClass="btn-danger" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                     </Columns>
                                 </MasterTableView>
                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="dleSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="spDeleteDLEPayrollSetup" DeleteCommandType="StoredProcedure" SelectCommand="SELECT [DleCompanyId], [DLEcodeCompanyName] FROM [vwPayrollSetupDLE_CS] ORDER BY [ID]">
                            <DeleteParameters>
                                <asp:Parameter Name="DleCompanyId" Type="Int32" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>
</asp:Content>
