<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AuditTrail.aspx.cs" Inherits="GDLCApp.Security.AuditTrail" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Audit Trail</h5>
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
                                            <asp:TextBox runat="server" ID="txtSearch" Width="100%" placeholder="Cost Sheet / UserName / Action ..." AutoPostBack="true"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">

                                            </div>
                                        </div>
                                    </div>
                        <hr />

                             <telerik:RadGrid ID="auditTrailGrid" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowFilteringByColumn="false" AllowPaging="True" AllowSorting="True" CellSpacing="-1" DataSourceID="auditTrailSource" GridLines="Both">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="400px" />
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                                 <MasterTableView DataSourceID="auditTrailSource" PageSize="100">
                                     <Columns>
                                         <telerik:GridBoundColumn DataField="ActionID" FilterControlAltText="Filter ActionID column" HeaderText="ActionID" SortExpression="ActionID" UniqueName="ActionID" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="80px">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ActionBy" FilterControlAltText="Filter ActionBy column" HeaderText="ActionBy" SortExpression="ActionBy" UniqueName="ActionBy" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="150px">
                                         <HeaderStyle Width="200px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ActionDescription" FilterControlAltText="Filter ActionDescription column" HeaderText="ActionDescription" SortExpression="ActionDescription" UniqueName="ActionDescription" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="250px">
                                         <HeaderStyle Width="300px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridDateTimeColumn DataField="ActionDate" DataType="System.DateTime" FilterControlAltText="Filter ActionDate column" HeaderText="ActionDate" SortExpression="ActionDate" UniqueName="ActionDate" DataFormatString="{0:dd-MMM-yyyy h:mm tt}" AutoPostBackOnFilter="true">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridDateTimeColumn>
                                     </Columns>
                                 </MasterTableView>
                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="auditTrailSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT top(1000) * FROM [tblAuditTrail] WHERE (ActionID LIKE '%' + @SearchValue + '%' OR ActionBy LIKE '%' + @SearchValue + '%' OR ActionDescription LIKE '%' + @SearchValue + '%') ORDER BY ActionDate">
                        <SelectParameters>
                                <asp:ControlParameter Name="SearchValue" ControlID="txtSearch" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>
</asp:Content>
