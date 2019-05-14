<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="LoanLastRepayment.aspx.cs" Inherits="GDLCApp.Loans.LoanLastRepayment" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Loan Last Repayments</h5>
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
                                            <asp:TextBox runat="server" ID="txtSearch" Width="100%" placeholder="Loan No / WorkerId / WorkerName..." OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                                           
                                           
                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">
                                               <asp:Button runat="server" ID="btnExcelExport" CssClass="btn-primary" Text="Excel" CausesValidation="false" OnClick="btnExcelExport_Click"/>
                                            </div>
                                        </div>
                                    </div>
                        <hr />
                             <telerik:RadGrid ID="loanGrid" runat="server" DataSourceID="loanSource" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowPaging="true" AllowSorting="True" CellSpacing="-1" GridLines="Both">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="400px" />
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                                 <ExportSettings IgnorePaging="true" ExportOnlyData="true" OpenInNewWindow="true" FileName="loan_last_repayment_list" HideStructureColumns="true" >
                                     
                                 </ExportSettings>
                                 <MasterTableView DataKeyNames="LoanNo" DataSourceID="loanSource" PageSize="100">
                                     <Columns>
                                         <%--<telerik:GridButtonColumn ButtonType="PushButton" CommandName="Select" ButtonCssClass="btn-info" Text="Select" Exportable="false">
                                        <HeaderStyle Width="60px" />
                                        </telerik:GridButtonColumn>--%>
                                         <telerik:GridBoundColumn DataField="LoanNo" FilterControlAltText="Filter LoanNo column" HeaderText="Loan No" ReadOnly="True" SortExpression="LoanNo" UniqueName="LoanNo">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridDateTimeColumn DataField="LoanDate" DataType="System.DateTime" FilterControlAltText="Filter LoanDate column" HeaderText="Loan Date" SortExpression="LoanDate" UniqueName="LoanDate" DataFormatString="{0:dd-MMM-yyyy}">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridDateTimeColumn>
                                         <telerik:GridBoundColumn DataField="WorkerId" FilterControlAltText="Filter WorkerId column" HeaderText="Worker Id" SortExpression="WorkerId" UniqueName="WorkerId">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="WorkerName" FilterControlAltText="Filter WorkerName column" HeaderText="Worker Name" SortExpression="WorkerName" UniqueName="WorkerName">
                                         <HeaderStyle Width="190px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="LoanScheme" FilterControlAltText="Filter LoanScheme column" HeaderText="LoanScheme" SortExpression="LoanScheme" UniqueName="LoanScheme">
                                         <HeaderStyle Width="200px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="LoanAmount" DataType="System.Double" FilterControlAltText="Filter LoanAmount column" HeaderText="LoanAmount" SortExpression="LoanAmount" UniqueName="LoanAmount" DataFormatString="{0:N02}">
                                         <HeaderStyle Width="90px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="LoanBalance" DataType="System.Double" FilterControlAltText="Filter LoanBalance column" HeaderText="LoanBalance" SortExpression="LoanBalance" UniqueName="LoanBalance" DataFormatString="{0:N02}">
                                         <HeaderStyle Width="90px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridDateTimeColumn DataField="LastRepaymentDate" DataType="System.DateTime" FilterControlAltText="Filter LastRepaymentDate column" HeaderText="LastRepaymentDate" SortExpression="LastRepaymentDate" UniqueName="LastRepaymentDate" DataFormatString="{0:dd-MMM-yyyy}">
                                         <HeaderStyle Width="130px" />
                                         </telerik:GridDateTimeColumn>
                                     </Columns>
                                 </MasterTableView>

                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="loanSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="spGetLoanLastRepayment" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter Name="SearchValue" ControlID="txtSearch" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                             <Triggers>
                                  <asp:PostBackTrigger ControlID="btnExcelExport" />
                              </Triggers>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>
</asp:Content>
