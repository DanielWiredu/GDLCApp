﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DailyCostSheet1.aspx.cs" Inherits="GDLCApp.Reports.Daily.DailyCostSheet1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="/Content/css/telerikCombo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Daily Reports</h5>
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
                         <asp:UpdatePanel ID="upProcess" runat="server" >
                    <ContentTemplate>
                        <div runat="server" id="lblMsg" class="alert alert-info"> Generate All Daily Reports Here</div>
                  
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-1">

                                </div>
                                <div class="col-md-4">
                                    <label>Report Type</label>
                                    <telerik:RadDropDownList runat="server" ID="dlReportType" Width="100%" DefaultMessage="Select Report Type" DropDownHeight="350px">
                                        <Items >
                                            <telerik:DropDownListItem Text="Daily Active Worker Record" />
                                            <telerik:DropDownListItem Text="Labour Request List" />
                                            <telerik:DropDownListItem Text="Daily Worker List" />
                                            <telerik:DropDownListItem Text="Daily Active Worker List" />
                                            <telerik:DropDownListItem Text="Daily Active Vessel List" />
                                            <telerik:DropDownListItem Text="Daily Cost Sheet" />
                                            <telerik:DropDownListItem Text="Daily Cost Sheet - Unapproved" />
                                            <telerik:DropDownListItem Text="Daily Approved Cost Sheet" />
                                            <telerik:DropDownListItem Text="Daily Processed" />
                                            <telerik:DropDownListItem Text="Daily Processed - New" />
                                            <telerik:DropDownListItem Text="Temporal Approved Cost Sheet" />
                                            <telerik:DropDownListItem Text="Daily Invoice" />
                                            <telerik:DropDownListItem Text="Daily Invoice - New" />
                                            <telerik:DropDownListItem Text="Daily Payroll" />
                                            <telerik:DropDownListItem Text="Daily Payroll - Individual" />
                                            <telerik:DropDownListItem Text="Daily Report Listing" />
                                            <telerik:DropDownListItem Text="Daily Statistics" />
                                            <telerik:DropDownListItem Text="Daily Statistics - New" />
                                            <telerik:DropDownListItem Text=" " Enabled="false"/>
                                            <telerik:DropDownListItem Text="STORED RECORDS BELOW" Font-Bold="true" Enabled="false" Font-Size="Medium" Font-Underline="true" />
                                            <telerik:DropDownListItem Text="Daily Invoice (Stored)" />
                                            <telerik:DropDownListItem Text="Daily Invoice (Stored) - New" />
                                            <telerik:DropDownListItem Text="Daily Report Listing (Stored)" />
                                            <telerik:DropDownListItem Text="Daily Statistics (Stored)" />
                                            <telerik:DropDownListItem Text="Daily Statistics (Stored) - New" />
                                            <telerik:DropDownListItem Text="SSF Report" />
                                            <telerik:DropDownListItem Text="SSF Report - Contributors" />
                                            <telerik:DropDownListItem Text="SSF Report - NonContributors" />
                                            <telerik:DropDownListItem Text="Leave and Bonus" />
                                            <telerik:DropDownListItem Text="Provident Fund" />
                                            <telerik:DropDownListItem Text="Tax Report" />
                                            <telerik:DropDownListItem Text="Stored Date Range" />
                                            <telerik:DropDownListItem Text=" " Enabled="false"/>
                                            <telerik:DropDownListItem Text="DISAPPROVED Daily Report Listing" />
                                        </Items>
                                    </telerik:RadDropDownList>
                                     <asp:RequiredFieldValidator runat="server" ControlToValidate="dlReportType" Display="Dynamic" ErrorMessage="Select Report Type" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <label>Start Date</label>
                                    <telerik:RadDatePicker runat="server" ID="dpStartDate" DateInput-ReadOnly="false" Width="100%"></telerik:RadDatePicker>
                                     <asp:RequiredFieldValidator runat="server" ControlToValidate="dpStartDate" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                     <label>End Date</label>
                                    <telerik:RadDatePicker runat="server" ID="dpEndDate" DateInput-ReadOnly="false" Width="100%"></telerik:RadDatePicker>
                                     <asp:RequiredFieldValidator runat="server" ControlToValidate="dpEndDate" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                 <div class="col-md-1">

                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnProcess" Text="Generate Report" CssClass="btn btn-primary" OnClick="btnProcess_Click" />
                        </div>   



                        <div runat="server" id="Div1" class="alert alert-info"> Generate Daily Reports By Company</div>
                  
                        <div class="form-group">
                            <div class="row">
                                 <div class="col-md-3">
                                     <label>Company</label>
                                     <telerik:RadComboBox ID="dlCompanies" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" runat="server" Width="100%" DataSourceID="companySource" DataTextField="DLEcodeCompanyName" DataValueField="DLEcodeCompanyID" Filter="None" MarkFirstMatch="false" Text="Select Companies" EmptyMessage="Select 1 or more companies" MaxHeight="200px"></telerik:RadComboBox>
                          <asp:SqlDataSource ID="companySource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DLEcodeCompanyID,DLEcodeCompanyName FROM [tblDLECompany]"></asp:SqlDataSource>  

                                        <%--<telerik:RadComboBox ID="dlCompany" runat="server" Width="100%" DataSourceID="dleSource" MaxHeight="200" EmptyMessage="Select Company" Filter="Contains"
                                           OnItemDataBound="dlCompany_ItemDataBound" OnDataBound="dlCompany_DataBound" OnItemsRequested="dlCompany_ItemsRequested" EnableLoadOnDemand="true"
                                            OnClientItemsRequested="UpdateCompanyItemCountField" HighlightTemplatedItems="true" MarkFirstMatch="true"  >
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
                                        <asp:SqlDataSource ID="dleSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT top (30) DLEcodeCompanyID,DLEcodeCompanyName FROM [tblDLECompany]"></asp:SqlDataSource>--%>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dlCompanies" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red" ValidationGroup="company"></asp:RequiredFieldValidator>


                                </div>
                                <div class="col-md-3">
                                    <label>Report Type</label>
                                    <telerik:RadDropDownList runat="server" ID="dlReportTypeByCompany" Width="100%" DefaultMessage="Select Report Type">
                                        <Items >
                                            <telerik:DropDownListItem Text="Daily Cost Sheet" />
                                            <telerik:DropDownListItem Text="Daily Invoice" />
                                            <telerik:DropDownListItem Text="Daily Invoice - New" />
                                            <telerik:DropDownListItem Text="Daily Report Listing" />
                                            <telerik:DropDownListItem Text="Daily Processed" />
                                            <telerik:DropDownListItem Text="Daily Processed - New" />
                                            <telerik:DropDownListItem Text="Daily Approved Cost Sheet" />
                                            <telerik:DropDownListItem Text="Daily Statictics" />
                                            <telerik:DropDownListItem Text="Daily Statictics - New" />
                                            <telerik:DropDownListItem Text=" " Enabled="false" />
                                            <telerik:DropDownListItem Text="STORED RECORDS BELOW" Font-Bold="true" Enabled="false" Font-Size="Medium" Font-Underline="true" />
                                            <telerik:DropDownListItem Text="Daily Invoice (Stored)" />
                                            <telerik:DropDownListItem Text="Daily Invoice (Stored) - New" />
                                            <telerik:DropDownListItem Text="Daily Report Listing (Stored)" />
                                        </Items>
                                    </telerik:RadDropDownList>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="dlReportTypeByCompany" Display="Dynamic" ErrorMessage="Select Report Type" SetFocusOnError="true" ForeColor="Red" ValidationGroup="company"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <label>Start Date</label>
                                    <telerik:RadDatePicker runat="server" ID="dpSdate" DateInput-ReadOnly="false" Width="100%"></telerik:RadDatePicker>
                                     <asp:RequiredFieldValidator runat="server" ControlToValidate="dpSdate" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red" ValidationGroup="company"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                     <label>End Date</label>
                                    <telerik:RadDatePicker runat="server" ID="dpEdate" DateInput-ReadOnly="false" Width="100%"></telerik:RadDatePicker>
                                     <asp:RequiredFieldValidator runat="server" ControlToValidate="dpEdate" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red" ValidationGroup="company"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnPrint" Text="Generate Report" CssClass="btn btn-primary" OnClick="btnPrint_Click" ValidationGroup="company" />
                        </div>


                        <%--<div class="form-group">
                            <telerik:RadComboBox ID="dlCompanies" CheckBoxes="true" EnableCheckAllItemsCheckBox="true" runat="server" Width="50%" DataSourceID="companySource" DataTextField="DLEcodeCompanyName" DataValueField="DLEcodeCompanyID" Filter="None" MarkFirstMatch="false" Text="Select Companies" EmptyMessage="Select 1 or more companies" MaxHeight="300px"></telerik:RadComboBox>
                          <asp:SqlDataSource ID="companySource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DLEcodeCompanyID,DLEcodeCompanyName FROM [tblDLECompany]"></asp:SqlDataSource>  
                        </div>--%>

                                            </ContentTemplate>
                </asp:UpdatePanel> 
                    </div>
                </div>
        </div>


    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function UpdateCompanyItemCountField(sender, args) {
                //Set the footer text.
                sender.get_dropDownElement().lastChild.innerHTML = "A total of " + sender.get_items().get_count() + " items";
            }
        </script>
    </telerik:RadScriptBlock>

             <!-- new modal -->
         <div class="modal fade" id="newmodal">
    <div class="modal-dialog" style="width:40%">
        <asp:Panel runat="server" DefaultButton="btnReportByWorker">
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                 <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Worker ID</h4>
                </div>
                        <div class="modal-body">
                             <div class="form-group">
                                        <label>Enter Worker ID</label>
                                       <asp:TextBox runat="server" ID="txtWorkerID" ClientIDMode="Static" Width="100%" MaxLength="50" ></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtWorkerID" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="worker"></asp:RequiredFieldValidator>
                             </div>
                            <div>
                            </div>
                       </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnReportByWorker" runat="server" Text="Continue" CssClass="btn btn-primary" OnClick="btnReportByWorker_Click" ValidationGroup="worker" />
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel>
        </div>
         </div>

    <!-- reqno modal -->
         <div class="modal fade" id="reqmodal">
    <div class="modal-dialog" style="width:40%">
        <asp:Panel runat="server" DefaultButton="btnLabourRequestReport">
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                 <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Cost Sheet No</h4>
                </div>
                        <div class="modal-body">
                             <div class="form-group">
                                        <label>Enter Cost Sheet No</label>
                                       <asp:TextBox runat="server" ID="txtReqNo" ClientIDMode="Static" Width="100%" MaxLength="10" ></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtReqNo" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="req"></asp:RequiredFieldValidator>
                             </div>
                            <div>
                            </div>
                       </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnLabourRequestReport" runat="server" Text="Continue" CssClass="btn btn-primary" OnClick="btnLabourRequestReport_Click" ValidationGroup="req" />
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel>
        </div>
         </div>

            <script type="text/javascript">
                function newModal() {
                $('#newmodal').modal('show');
                $('#newmodal').appendTo($("form:first"));
                }

                $('#newmodal').on('shown.bs.modal', function () {                    
                    // jQuery code is in here
                    $('#txtWorkerID').focus();
                });
            function closenewModal() {
                $('#newmodal').modal('hide');
            }

            function reqModal() {
                $('#reqmodal').modal('show');
                $('#reqmodal').appendTo($("form:first"));
            }

            $('#reqmodal').on('shown.bs.modal', function () {
                // jQuery code is in here
                $('#txtReqNo').focus();
            });
            function closereqModal() {
                $('#reqmodal').modal('hide');
            }
                </script>
</asp:Content>
