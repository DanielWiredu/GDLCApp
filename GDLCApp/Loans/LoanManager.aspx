<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="LoanManager.aspx.cs" Inherits="GDLCApp.Loans.LoanManager" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Loan Manager</h5>
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
                                           
                                           <%--<asp:Button runat="server" ID="btnExcelExport" CssClass="btn btn-primary" Text="Excel" CausesValidation="false" OnClick="btnExcelExport_Click"/>--%>
                                            <%--<asp:Button runat="server" ID="btnPDFExport" CssClass="btn btn-warning" Text="PDF" CausesValidation="false" OnClick="btnPDFExport_Click"/>--%>
                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">
                                                <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="Add" CausesValidation="false" PostBackUrl="~/Loans/NewLoan.aspx" />  
                                            </div>
                                        </div>
                                    </div>
                             <telerik:RadGrid ID="loanGrid" runat="server" DataSourceID="loanSource" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowPaging="False" AllowSorting="True" CellSpacing="-1" GridLines="Both" OnItemCommand="loanGrid_ItemCommand" OnDeleteCommand="loanGrid_DeleteCommand">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="400px" />
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />

                                 <MasterTableView DataKeyNames="LoanNo" DataSourceID="loanSource">
                                     <Columns>
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
                                         <HeaderStyle Width="200px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="LoanScheme" FilterControlAltText="Filter LoanScheme column" HeaderText="LoanScheme" SortExpression="LoanScheme" UniqueName="LoanScheme">
                                         <HeaderStyle Width="200px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="LoanAmount" DataType="System.Double" FilterControlAltText="Filter LoanAmount column" HeaderText="LoanAmount" SortExpression="LoanAmount" UniqueName="LoanAmount" DataFormatString="{0:N02}">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="RepaidAmount" DataType="System.Double" FilterControlAltText="Filter RepaidAmount column" HeaderText="RepaidAmount" SortExpression="RepaidAmount" UniqueName="RepaidAmount" DataFormatString="{0:N02}">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="LoanBalance" DataType="System.Double" FilterControlAltText="Filter LoanBalance column" HeaderText="LoanBalance" SortExpression="LoanBalance" UniqueName="LoanBalance" DataFormatString="{0:N02}">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="MonthlyLimit" DataType="System.Double" FilterControlAltText="Filter MonthlyLimit column" HeaderText="MonthlyLimit" SortExpression="MonthlyLimit" UniqueName="MonthlyLimit" DataFormatString="{0:N02}">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridCheckBoxColumn DataField="Approved" DataType="System.Boolean" FilterControlAltText="Filter Approved column" HeaderText="A" SortExpression="Approved" UniqueName="Approved" StringTrueValue="1" StringFalseValue="0" >
                                         <HeaderStyle Width="30px" />
                                         </telerik:GridCheckBoxColumn>
                                         <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Edit" ButtonCssClass="btn-info" Text="Edit" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Delete Record?" ButtonType="PushButton" ButtonCssClass="btn-danger" Exportable="false">
                                        <HeaderStyle Width="60px" />
                                        </telerik:GridButtonColumn>
                                     </Columns>
                                 </MasterTableView>

                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="loanSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP (200) AutoId, LoanNo, LoanDate, WorkerId, WorkerName, LoanScheme, LoanAmount, RepaidAmount, LoanBalance, MonthlyLimit, Approved FROM vwLoans WHERE (LoanNo LIKE '%' + @LoanNo + '%') OR (WorkerId LIKE '%' + @WorkerId + '%') OR (WorkerName LIKE '%' + @WorkerName + '%') ORDER BY AutoId DESC">
                            <SelectParameters>
                                <asp:ControlParameter Name="LoanNo" ControlID="txtSearch" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" />
                                <asp:ControlParameter Name="WorkerId" ControlID="txtSearch" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" />
                                <asp:ControlParameter Name="WorkerName" ControlID="txtSearch" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" />
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
</asp:Content>
