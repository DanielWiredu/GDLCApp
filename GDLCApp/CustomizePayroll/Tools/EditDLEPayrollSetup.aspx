<%@ Page Title="" Language="C#" MasterPageFile="~/CustomizePayroll/CSHome.Master" AutoEventWireup="true" CodeBehind="EditDLEPayrollSetup.aspx.cs" Inherits="GDLCApp.CustomizePayroll.Tools.EditDLEPayrollSetup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/css/telerikCombo.css" rel="stylesheet" />
    <link href="/Content/css/aspControlStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Edit DLE Payroll Setup</h5>
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
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-2">

                                </div>
                                <div class="col-md-8">
                                     <telerik:RadComboBox ID="dlCompany" AllowCustomText="false" runat="server" Width="100%" DataSourceID="dleSource" MaxHeight="0" Filter="None"
                                           OnItemDataBound="dlCompany_ItemDataBound" >
                                            <HeaderTemplate>
                <ul>
                    <li class="ncolfull">DLE COMPANY</li>
                </ul>
            </HeaderTemplate>
            <ItemTemplate>
                <ul>
                    <li class="ncolfull">
                        <%# DataBinder.Eval(Container.DataItem, "DLEcodeCompanyName")%></li>
                </ul>
            </ItemTemplate>
            <FooterTemplate>
                A total of
                <asp:Literal runat="server" ID="companyCount" />
                items
            </FooterTemplate>
                                        </telerik:RadComboBox>
                                        <asp:SqlDataSource ID="dleSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dlCompany" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">

                                </div>
                                       
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-3">
                                    <label>Union Dues</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtUnionDues" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Welfare</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtWelfare" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>SSF (Employee) %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtSSFEmployee" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>SSF (Employer) %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtSSFEmployer" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-3">
                                    <label>Provident Fund Employee %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtPFEmployee" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Provident Fund Employer %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtPFEmployer" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Annual Bonus %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtAnnualBonus" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Annual Leave %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtAnnualLeave" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-3">
                                    <label>Premium Shareholder %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtPremShareholder" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Premium Non Shareholder %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtPremNonShareholder" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Premium Without Transport %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtPremWithoutTransport" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Tax on Bonus %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtTaxOnBonus" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-3">
                                    <label>Tax on Basic %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtTaxOnBasic" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Tax on Overtime %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtTaxOnOvertime" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Tax on Provident Fund %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtTaxOnPF" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Tax on Transport %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtTaxOnTransport" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-3">
                                    <label>On Board Allowance</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtOnBoardAllowance" Width="100%" MinValue="0"  NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>VAT %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtVAT" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Get Fund %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtGetFund" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>NHIL %</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtNHIL" Width="100%" MinValue="0" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                        </div>
                      <%--  <hr />--%>
                        <div class="row">
                                <div class="col-md-6">
                                       <div class="form-group bg-primary">Rate for Workers</div>
                                
                                        <div class="form-horizontal">

                                     <div class="form-group">
                                    <label class="col-sm-5 control-label">Daily Basic Wage</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtDBWage" runat="server" Width="100%" MinValue="0" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-5 control-label">Daily Basic Wage Weekend</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtDBWageWknd" runat="server" Width="100%" MinValue="0" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-5 control-label">1 Hour Overtime Weekday</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtHourOvertimeWkday" runat="server" Width="100%" MinValue="0" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">1 Hour Overtime Weekend</label>
                                    <div class="col-sm-7">
                                    <telerik:RadNumericTextBox ID="txtHourOvertimeWknd" runat="server" Width="100%" MinValue="0" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Night Allowance Weekday</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtNightAllowanceWkday" runat="server" Width="100%" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Night Allowance Weekend</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtNightAllowanceWknd" runat="server" Width="100%" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>     
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Transport Allowance </label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtTransportAllowance" runat="server" Width="100%" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Subsidy</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtSubsidy" runat="server" Width="100%" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">PPE Medicals</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtPPEMedicals" runat="server" Width="100%" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Bussing</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtBussing" runat="server" Width="100%" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                            </div>
                                </div>
                                <div class="col-md-6">
                                     <div class="form-group bg-primary">Rate for DLE Companies</div>
                                   
                                    <div class="form-horizontal">

                                        <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtDBWageDLE" runat="server" Width="100%" MinValue="0" Height="24px" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                            <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtDBWageWkndDLE" runat="server" Width="100%" MinValue="0" Height="24px" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtHourOvertimeWkdayDLE" runat="server" Width="100%" MinValue="0" Height="24px" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtHourOvertimeWkndDLE" runat="server" Width="100%" MinValue="0" Height="24px" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtNightAllowanceWkdayDLE" runat="server" Width="100%" MinValue="0" Height="24px" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtNightAllowanceWkndDLE" runat="server" Width="100%" MinValue="0" Height="24px" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                    </div>
                                </div>
                            </div>
                     
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnReturn" Text="Return" CssClass="btn btn-warning" PostBackUrl="~/CustomizePayroll/Tools/DLEPayrollSetup.aspx" CausesValidation="false" style="margin-bottom:0px" />
                            <asp:Button runat="server" ID="btnSave" Text="Save Changes" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        </div> 
                    </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>
</asp:Content>
