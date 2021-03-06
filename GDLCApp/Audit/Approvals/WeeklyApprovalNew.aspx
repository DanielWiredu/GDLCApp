﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="WeeklyApprovalNew.aspx.cs" Inherits="GDLCApp.Audit.Approvals.WeeklyApprovalNew" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="/Content/css/telerikCombo.css" rel="stylesheet" />
    <link href="/Content/css/aspControlStyle.css" rel="stylesheet" />
    <link href="/Content/css/updateProgress.css" rel="stylesheet" />
    <style type="text/css">
        table {
    border-collapse: collapse;
    width: 100%;
}

/*th {
    padding: 8px;
    text-align: left;
    border-bottom: 3px solid #000000;
    font-size:larger;
}*/
h4 {
    text-align: left;
    /*border-bottom: 2px solid #000000;*/
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5> Weekly Requisition Approval</h5>
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
                         <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div runat="server" id="lblMsg"></div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Requisition No</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtAutoNo" runat="server" Width="49%" Enabled="false"></asp:TextBox>
                                        <asp:TextBox ID="txtReqNo" runat="server" Width="49%" ReadOnly="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtReqNo" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">DLE Company</label>
                                    <div class="col-sm-8">
                                        <telerik:RadComboBox ID="dlCompany" runat="server" Width="100%" DataSourceID="dleSource" EmptyMessage="Select Company" Filter="Contains"
                                           OnItemDataBound="dlCompany_ItemDataBound"  >
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
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Reporting Point</label>
                                    <div class="col-sm-8">
                                        <telerik:RadComboBox ID="dlReportingPoint" runat="server" Width="100%" DataSourceID="repPointSource" EmptyMessage="Select Reporting Point" Filter="Contains"
                                           OnItemDataBound="dlReportingPoint_ItemDataBound" >
                                             <HeaderTemplate>
                <ul>
                    <li class="ncolfull">REPORTING POINT</li>
                </ul>
            </HeaderTemplate>
            <ItemTemplate>
                <ul>
                    <li class="ncolfull">
                        <%# DataBinder.Eval(Container.DataItem, "ReportingPoint")%></li>
                </ul>
            </ItemTemplate>
            <FooterTemplate>
                A total of
                <asp:Literal runat="server" ID="repPointCount" />
                items
            </FooterTemplate>
                                        </telerik:RadComboBox>
                                        <asp:SqlDataSource ID="repPointSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Location</label>
                                    <div class="col-sm-8">
                                        <telerik:RadComboBox ID="dlLocation" runat="server" Width="100%" DataSourceID="locationSource" EmptyMessage="Select Location" Filter="Contains"
                                          OnItemDataBound="dlLocation_ItemDataBound" >
                                            <HeaderTemplate>
                <ul>
                    <li class="ncolfull">LOCATION</li>
                </ul>
            </HeaderTemplate>
            <ItemTemplate>
                <ul>
                    <li class="ncolfull">
                        <%# DataBinder.Eval(Container.DataItem, "Location")%></li>
                </ul>
            </ItemTemplate>
            <FooterTemplate>
                A total of
                <asp:Literal runat="server" ID="locationCount" />
                items
            </FooterTemplate>
                                        </telerik:RadComboBox>
                                        <asp:SqlDataSource ID="locationSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
                                    </div>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Requisition Date</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDatePicker runat="server" ID="dpRegdate" Width="100%" DateInput-ReadOnly="true" DateInput-DateFormat="dd-MMM-yyyy"></telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dpRegdate" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <%--<div class="form-group">
                                    <label class="col-sm-4 control-label">Approval Date</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDatePicker runat="server" ID="dpApprovalDate" Width="100%" DateInput-ReadOnly="true" SelectedDate="01/01/2000" Enabled="false"></telerik:RadDatePicker>
                                    </div>
                                </div>--%>
                                    <%--<div class="form-group">
                                    <label class="col-sm-4 control-label" style="color:red">Approved</label>
                                    <div class="col-sm-8">
                                        <asp:CheckBox ID="chkApproved" runat="server" Enabled="false" />
                                    </div>
                                </div>--%>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Period Ending</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtJobDescription" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Group</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox runat="server" ID="txtGroupName" Width="100%" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Category</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox runat="server" ID="txtCategory" Width="100%" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                               <asp:HiddenField runat="server" ID="hfTradegroup" />
                               <asp:HiddenField runat="server" ID="hfTradetype" />
                                <label>Name</label> 
                            <telerik:RadTextBox runat="server" ID="txtWorkerId" ReadOnly="true" Width="15%" ShowButton="true" EmptyMessage="Select Worker">
                                </telerik:RadTextBox>
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="txtWorkerId" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox runat="server" ID="txtWorkerName" Width="30%" Enabled="false"></asp:TextBox>
                            <label>Ezwich No</label>
                               <asp:TextBox runat="server" ID="txtEzwichNo" Width="40%" Enabled="false" ForeColor="Red"></asp:TextBox>
                        </div>
                        
                        <div class="row">
                            <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div runat="server" id="lblDays" class="bg-info">Total Days : </div>
                             <telerik:RadGrid ID="subStaffReqGrid" runat="server" DataSourceID="subStaffReqSource" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowPaging="False" AllowSorting="True" CellSpacing="-1" GridLines="Both" OnDataBound="subStaffReqGrid_DataBound" Enabled="false">
                            <ClientSettings AllowKeyboardNavigation="true">
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="200px" />
                                <Selecting AllowRowSelect="true" />
                                <KeyboardNavigationSettings AllowActiveRowCycle="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />

                                 <MasterTableView DataKeyNames="AutoId" DataSourceID="subStaffReqSource" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add Work Date" AllowAutomaticDeletes="true">
                                     <Columns>
                                        <telerik:GridButtonColumn CommandName="Delete" UniqueName="Delete" ConfirmText="Delete Record?" ButtonType="FontIconButton" Exportable="false">
                                            <HeaderStyle Width="20px" />
                                        </telerik:GridButtonColumn>
                                         <telerik:GridBoundColumn Display="false" DataField="AutoId" DataType="System.Int32" FilterControlAltText="Filter AutoId column" HeaderText="AutoId" SortExpression="AutoId" UniqueName="AutoId">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridDateTimeColumn DataField="TransDate" FilterControlAltText="Filter TransDate column" HeaderText="Date" ReadOnly="True" SortExpression="TransDate" UniqueName="TransDate" DataFormatString="{0:dd-MMM-yyyy}">
                                         <HeaderStyle Width="130px" />
                                         </telerik:GridDateTimeColumn>
                                         <telerik:GridBoundColumn DataField="Normal" FilterControlAltText="Filter Normal column" HeaderText="Normal" SortExpression="Normal" UniqueName="Normal">
                                         <HeaderStyle Width="80px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Overtime" FilterControlAltText="Filter Overtime column" HeaderText="Overtime" SortExpression="Overtime" UniqueName="Overtime">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Night" FilterControlAltText="Filter Night column" HeaderText="Night" SortExpression="Night" UniqueName="Night">
                                         <HeaderStyle Width="80px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Weekends" FilterControlAltText="Filter Weekends column" HeaderText="Weekends" SortExpression="Weekends" UniqueName="Weekends">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Holiday" FilterControlAltText="Filter Holiday column" HeaderText="Holiday" SortExpression="Holiday" UniqueName="Holiday">
                                         <HeaderStyle Width="90px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Remarks" FilterControlAltText="Filter Remarks column" HeaderText="Remarks" SortExpression="Remarks" UniqueName="Remarks">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="VesselName" FilterControlAltText="Filter VesselName column" HeaderText="Vessel Name" SortExpression="VesselName" UniqueName="VesselName">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridCheckBoxColumn DataField="OnBoardAllowance" FilterControlAltText="Filter OnBoardAllowance column" HeaderText="Ship Side" SortExpression="OnBoardAllowance" UniqueName="OnBoardAllowance">
                                           <HeaderStyle Width="80px" />
                                            </telerik:GridCheckBoxColumn>
                                         <telerik:GridBoundColumn DataField="transport" FilterControlAltText="Filter transport column" HeaderText="*" SortExpression="transport" UniqueName="transport" EmptyDataText="" ConvertEmptyStringToNull="false">
                                         <HeaderStyle Width="20px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridButtonColumn ButtonType="PushButton" ButtonCssClass="btn-success" CommandName="Transport" UniqueName="Transport" Text="t" Exportable="false">
                                        <HeaderStyle Width="25px" />
                                        </telerik:GridButtonColumn>
                                     </Columns>
                                 </MasterTableView>

                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="subStaffReqSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM vwSubStaffWReq WHERE (ReqNo = @ReqNo) ORDER BY TransDate" DeleteCommand="DELETE FROM tblSubStaffWReq WHERE AutoId=@AutoId">
                            <SelectParameters>
                                <asp:ControlParameter Name="ReqNo" ControlID="txtReqNo" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" DefaultValue=" " />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:Parameter Name="AutoId" Type="Int32" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </div>
                  
                        <div class="modal-footer">
                            <label>Advice No</label>
                               <asp:TextBox runat="server" ID="txtAdviceNo" Enabled="false" ForeColor="Red"></asp:TextBox>
                                <asp:Button runat="server" ID="btnViewAdvice" CssClass="btn-info" Text="View" OnClick="btnViewAdvice_Click" />
                             <asp:CheckBox ID="chkProcessed" runat="server" Text="Processed" TextAlign="Left" Visible="false" />
                             <asp:CheckBox ID="chkStored" runat="server" Text="Stored" TextAlign="Left" Visible="false" />
                            <asp:CheckBox ID="chkConfirmed" runat="server" Text="Confirmed" TextAlign="Left" Visible="false" />
                            <asp:CheckBox ID="chkApproved" style="color:red;font-size:medium" runat="server" Text="Approved" TextAlign="Left" Enabled="true" />
                            <label style="color:green">Approval Date</label>
                            <telerik:RadDatePicker runat="server" ID="dpApprovalDate" Enabled="true" DateInput-ReadOnly="true" SelectedDate="10/01/2019" DateInput-DateFormat="dd-MMM-yyyy"></telerik:RadDatePicker>
                            <asp:Button runat="server" ID="btnReturn" Text="Return" CssClass="btn btn-warning" CausesValidation="false" PostBackUrl="~/Dashboard.aspx" style="margin-bottom:0px" />
                            <asp:Button runat="server" ID="btnFind" Text="Find" CssClass="btn btn-success" OnClientClick="newModal()" CausesValidation="false" />
                            <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="btn btn-info" OnClick="btnPrint_Click"  />
                            <asp:Button runat="server" ID="btnApprove" Text="Approve" CssClass="btn btn-primary" OnClick="btnApprove_Click" />
                            <asp:Button runat="server" ID="btnDisapprove" Text="Disapprove" CssClass="btn btn-danger" OnClick="btnDisapprove_Click" />
                        </div>   

                         <div class="panel-body">
                                <div class="panel-group" id="accordion">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseAdvice">Advice Details</a>
                                            </h5>
                                        </div>
                                        <div id="collapseAdvice" class="panel-collapse collapse in">
                                            <div class="panel-body">
                                                 <asp:Panel ID="Panel2" runat="server">
                                                   <telerik:RadListView ID="RadListView1" RenderMode="Lightweight" Width="100%" AllowPaging="True" runat="server" DataSourceID="vwAdviceSource" DataKeyNames="AutoId"
                ItemPlaceholderID="adviceHolder">
                <LayoutTemplate>
                                <table>
                                    <tr>
                                        <td class="tdlabel" style="width:10%">TransDate
                                            </td>
                                        <td class="tdlabel" style="width:10%">Time In
                                            </td>
                                        <td class="tdlabel" style="width:10%">Time Out
                                            </td>
                                        <td class="tdlabel" style="width:8%">Normal
                                            </td>
                                        <td class="tdlabel" style="width:8%">Overtime
                                            </td>
                                        <td class="tdlabel" style="width:7%">Night
                                            </td>
                                        <td class="tdlabel" style="width:10%">Weekends
                                            </td>
                                        <td class="tdlabel" style="width:8%">Holiday
                                            </td>
                                        <td class="tdlabel" style="width:15%">VesselName
                                            </td>
                                        <td class="tdlabel" style="width:7%">ShipSide
                                            </td>
                                        <td class="tdlabel" style="width:7%">Transport
                                            </td>
                                    </tr>
                                    </table>                    
                    <fieldset class="layoutFieldset" id="FieldSet2">
                        <asp:Panel ID="adviceHolder" runat="server">
                        </asp:Panel>
                    </fieldset>
                </LayoutTemplate>
                <ItemTemplate>
                                <table>
                                        <tr> 
                                            <td style="width:10%">
                                                 <%# DataBinder.Eval(Container.DataItem, "TransDate", "{0:dd-MMM-yyyy}") %>
                                            </td>
                                            <td style="width:10%">
                                                <%# Eval("HrsFrom") %>
                                            </td>
                                            <td style="width:10%">
                                                <%# Eval("HrsTo") %>
                                            </td>
                                            <td style="width:8%">
                                                <%# Eval("Normal") %>
                                            </td>
                                            <td style="width:8%">
                                                <%# Eval("Overtime") %>
                                            </td>
                                            <td style="width:7%">
                                                <%# Eval("Night") %>
                                            </td>
                                            <td style="width:10%">
                                                <%# Eval("Weekends") %>
                                            </td>
                                            <td style="width:8%">
                                                <%# Eval("Holiday") %>
                                            </td>
                                            <td style="width:15%">
                                                <%# Eval("VesselName") %>
                                            </td>
                                            <td style="width:7%">
                                               <%# Eval("OnboardAllowance") %>
                                            </td>
                                            <td style="width:7%">
                                                <%# Eval("Transport") %>
                                            </td>
                                        </tr>
                                    </table>
                </ItemTemplate>
            </telerik:RadListView>
                                                    <asp:SqlDataSource ID="vwAdviceSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select AutoId, AdviceNo, TransDate, Normal, Overtime, Night, Weekends, Holiday, Remarks, VesselberthID, VesselName, Transport, OnBoardAllowance, HrsFrom, HrsTo FROM vwLabourAdviceDays where AdviceNo = @AdviceNo order by TransDate">
                            <SelectParameters>
                                <asp:ControlParameter Name="AdviceNo" ControlID="txtAdviceNo" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" DefaultValue=" " />
                            </SelectParameters>
                        </asp:SqlDataSource>
                                                 </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>

             <!-- new modal -->
         <div class="modal fade" id="newmodal">
    <div class="modal-dialog" style="width:40%">
        <asp:Panel runat="server" DefaultButton="btnSearch">
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                 <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Find Cost Sheet</h4>
                </div>
                        <div class="modal-body">
                             <div class="form-group">
                                        <label>Enter Requisition No</label>
                                       <asp:TextBox runat="server" ID="txtSearchValue" Width="100%" MaxLength="50" ClientIDMode="Static" ></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtSearchValue" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="search"></asp:RequiredFieldValidator>
                             </div>
                            <div>
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

    <!--  Advice modal -->
   <%-- <div class="modal fade" id="advicemodal">
    <div class="modal-dialog" style="width:90%">
      <asp:UpdatePanel runat="server">
          <ContentTemplate>
               <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Cost Sheet Advice</h4>
                </div>
                        <div class="modal-body">
                             <asp:Panel ID="Panel1" runat="server">
            <telerik:RadListView ID="lvAdvice" RenderMode="Lightweight" Width="97%" AllowPaging="True" runat="server"
                ItemPlaceholderID="adviceHolder">
                <LayoutTemplate>
                                <table>
                                    <tr>
                                        <td class="tdlabel" style="width:10%">TransDate
                                            </td>
                                        <td class="tdlabel" style="width:10%">HrsFrom
                                            </td>
                                        <td class="tdlabel" style="width:10%">HrsTo
                                            </td>
                                        <td class="tdlabel" style="width:8%">Normal
                                            </td>
                                        <td class="tdlabel" style="width:8%">Overtime
                                            </td>
                                        <td class="tdlabel" style="width:7%">Night
                                            </td>
                                        <td class="tdlabel" style="width:10%">Weekends
                                            </td>
                                        <td class="tdlabel" style="width:8%">Holiday
                                            </td>
                                        <td class="tdlabel" style="width:15%">VesselName
                                            </td>
                                        <td class="tdlabel" style="width:7%">Transport
                                            </td>
                                        <td class="tdlabel" style="width:7%">ShipSide
                                            </td>
                                    </tr>
                                    </table>                    
                    <fieldset class="layoutFieldset" id="FieldSet2">
                        <asp:Panel ID="adviceHolder" runat="server">
                        </asp:Panel>
                    </fieldset>
                </LayoutTemplate>
                <ItemTemplate>
                                <table>
                                        <tr> 
                                            <td style="width:10%">
                                                 <%# DataBinder.Eval(Container.DataItem, "TransDate", "{0:dd-MMM-yyyy}") %>
                                            </td>
                                            <td style="width:10%">
                                                <%# Eval("HrsFrom") %>
                                            </td>
                                            <td style="width:10%">
                                                <%# Eval("HrsTo") %>
                                            </td>
                                            <td style="width:8%">
                                                <%# Eval("Normal") %>
                                            </td>
                                            <td style="width:8%">
                                                <%# Eval("Overtime") %>
                                            </td>
                                            <td style="width:7%">
                                                <%# Eval("Night") %>
                                            </td>
                                            <td style="width:10%">
                                                <%# Eval("Weekends") %>
                                            </td>
                                            <td style="width:8%">
                                                <%# Eval("Holiday") %>
                                            </td>
                                            <td style="width:15%">
                                                <%# Eval("VesselName") %>
                                            </td>
                                            <td style="width:7%">
                                                <%# Eval("Transport") %>
                                            </td>
                                            <td style="width:7%">
                                               <%# Eval("OnboardAllowance") %>
                                            </td>
                                        </tr>
                                    </table>
                </ItemTemplate>
            </telerik:RadListView>
        </asp:Panel>
                       </div>
            </div>
          </ContentTemplate>
      </asp:UpdatePanel>
        </div>
    </div>--%>

        <script type="text/javascript">
            function newModal() {
                $('#newmodal').modal('show');
                $('#newmodal').appendTo($("form:first"));
            }
            $('#newmodal').on('shown.bs.modal', function () {
                $('#txtSearchValue').focus();
            });
            function closenewModal() {
                $('#newmodal').modal('hide');
            }
            function showAdviceModal() {
                $('#advicemodal').modal('show');
            }
    </script>
</asp:Content>
