<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="MonthlySubmissions.aspx.cs" Inherits="GDLCApp.ClientPortal.MonthlySubmissions" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Monthly Requisition</h5>
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
                                        <div class="col-sm-10 pull-right">
                                            <%--<asp:TextBox runat="server" ID="txtSearchStaffReq" placeholder="Req No..." OnTextChanged="txtSearchStaffReq_TextChanged" AutoPostBack="true" Width="40%"></asp:TextBox>--%>
                                            <telerik:RadDatePicker ID="dpStartDate" runat="server" DateInput-ReadOnly="true" Width="30%"></telerik:RadDatePicker>
                                            <telerik:RadDatePicker ID="dpEndDate" runat="server" DateInput-ReadOnly="true" Width="30%"></telerik:RadDatePicker>
                                            <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-success" Text="Reload" CausesValidation="false" OnClick="btnSearch_Click" Width="15%" />  
                                        </div>
                                        <div class="col-sm-2 pull-left">
                                            <div class="toolbar-btn-action">
                                                <asp:Button runat="server" ID="btnExcelExport" CssClass="btn-primary" Text="Excel" OnClick="btnExcelExport_Click" CausesValidation="false" />
                                            </div>
                                        </div>
                                    </div>
                             <telerik:RadGrid ID="monthlyStaffReqGrid" runat="server" DataSourceID="monthlyStaffReqSource" AllowFilteringByColumn="true" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowPaging="True" AllowSorting="True" CellSpacing="-1" GridLines="Both">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="400px" />
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                                 <ExportSettings IgnorePaging="true" ExportOnlyData="true" OpenInNewWindow="true" FileName="monthlycostsheets" HideStructureColumns="true"  >
                                    </ExportSettings>
                                 <MasterTableView DataKeyNames="ReqNo" DataSourceID="monthlyStaffReqSource" AllowFilteringByColumn="true" PageSize="100">
                                     <Columns>
                                         <telerik:GridBoundColumn Display="false" DataField="AutoNo" DataType="System.Int32" FilterControlAltText="Filter AutoNo column" HeaderText="AutoNo" SortExpression="AutoNo" UniqueName="AutoNo" AllowFiltering="false">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ReqNo" FilterControlAltText="Filter ReqNo column" HeaderText="Req No" ReadOnly="True" SortExpression="ReqNo" UniqueName="ReqNo" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridDateTimeColumn DataField="date_" DataType="System.DateTime" FilterControlAltText="Filter date_ column" HeaderText="Date" SortExpression="date_" UniqueName="date_" DataFormatString="{0:dd-MMM-yyyy}" AutoPostBackOnFilter="true" ShowFilterIcon="false" AllowFiltering="false">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridDateTimeColumn>
                                         <telerik:GridBoundColumn DataField="DLEcodeCompanyName" FilterControlAltText="Filter DLEcodeCompanyName column" HeaderText="DLE Company" SortExpression="DLEcodeCompanyName" UniqueName="DLEcodeCompanyName" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="150px">
                                         <HeaderStyle Width="200px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="WorkerId" FilterControlAltText="Filter WorkerId column" HeaderText="WorkerId" SortExpression="WorkerId" UniqueName="WorkerId">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="WorkerName" FilterControlAltText="Filter WorkerName column" HeaderText="Worker Name" SortExpression="WorkerName" UniqueName="WorkerName">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridCheckBoxColumn DataField="Confirmed" DataType="System.Boolean" FilterControlAltText="Filter Confirmed column" HeaderText="C" SortExpression="Confirmed" UniqueName="Confirmed" AutoPostBackOnFilter="true" ShowFilterIcon="true">
                                         <HeaderStyle Width="50px" />
                                         </telerik:GridCheckBoxColumn>
                                         <telerik:GridCheckBoxColumn DataField="Approved" DataType="System.Boolean" FilterControlAltText="Filter Approved column" HeaderText="A" SortExpression="Approved" UniqueName="Approved" AutoPostBackOnFilter="true" ShowFilterIcon="true" >
                                         <HeaderStyle Width="50px" />
                                         </telerik:GridCheckBoxColumn>
                                         <telerik:GridCheckBoxColumn DataField="Processed" DataType="System.Boolean" FilterControlAltText="Filter Processed column" HeaderText="P" SortExpression="Processed" UniqueName="Processed" AutoPostBackOnFilter="true" ShowFilterIcon="true">
                                         <HeaderStyle Width="50px" />
                                         </telerik:GridCheckBoxColumn>
                                     </Columns>
                                 </MasterTableView>

                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="monthlyStaffReqSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP (2000) AutoNo, ReqNo, date_, Approved, DLEcodeCompanyName, WorkerID, WorkerName, Confirmed, Processed FROM vwMonthlyReq WHERE (date_ BETWEEN @StartDate AND @EndDate) ORDER BY AutoNo DESC">
                        <SelectParameters>
                            <asp:ControlParameter Name="StartDate" ControlID="dpStartDate" Type="DateTime" PropertyName="SelectedDate" ConvertEmptyStringToNull="false" />
                            <asp:ControlParameter Name="EndDate" ControlID="dpEndDate" Type="DateTime" PropertyName="SelectedDate" ConvertEmptyStringToNull="false" />
                        </SelectParameters>
                        </asp:SqlDataSource>
                        <%--<asp:SqlDataSource ID="dailyStaffReqSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP (500) AutoNo, ReqNo, date_, Approved, DLEcodeCompanyName, VesselName, ReportingPoint, Submitted, Processed FROM vwDailyReq WHERE (Submitted = 1 AND ReqNo LIKE '%' + @ReqNo + '%' AND date_ = @ReqDate) ORDER BY AutoNo DESC">
                            <SelectParameters>
                                <asp:ControlParameter Name="ReqNo" ControlID="txtSearchStaffReq" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" />
                                <asp:ControlParameter Name="ReqDate" ControlID="dpReqDate" Type="DateTime" PropertyName="SelectedDate" ConvertEmptyStringToNull="false" />
                            </SelectParameters>
                        </asp:SqlDataSource>--%>
                    </ContentTemplate>
                             <Triggers>
                                  <%--<asp:PostBackTrigger ControlID="btnSearch" />--%>
                                 <asp:PostBackTrigger ControlID="btnExcelExport" />
                              </Triggers>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>
</asp:Content>
