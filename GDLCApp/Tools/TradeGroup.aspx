<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TradeGroup.aspx.cs" Inherits="GDLCApp.Tools.TradeGroup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Trade Group</h5>
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
                                           <asp:Button runat="server" ID="btnExcelExport" CssClass="btn btn-primary" Text="Excel" CausesValidation="false" OnClick="btnExcelExport_Click"/>
                                            <asp:Button runat="server" ID="btnPDFExport" CssClass="btn btn-warning" Text="PDF" CausesValidation="false" OnClick="btnPDFExport_Click"/>
                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">
                                                <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="Add Group" CausesValidation="false" OnClientClick="newModal()" />  
                                            </div>
                                        </div>
                                    </div>

                             <telerik:RadGrid ID="tradeGroupGrid" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" CellSpacing="-1" GridLines="Both" DataSourceID="tradeGroupSource" OnItemCommand="tradeGroupGrid_ItemCommand" OnItemDeleted="tradeGroupGrid_ItemDeleted">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                                 <ExportSettings IgnorePaging="true" ExportOnlyData="true" OpenInNewWindow="true" FileName="tradegroup_list" HideStructureColumns="true"  >
                                        <Pdf AllowPrinting="true" AllowCopy="true" PaperSize="Letter" PageTitle="Trade Group List" PageWidth="700"></Pdf>
                                    </ExportSettings>
                                 <MasterTableView DataKeyNames="TradegroupID" DataSourceID="tradeGroupSource" AllowAutomaticDeletes="true">
                                     <Columns>
                                         <telerik:GridBoundColumn Display="false" DataField="TradegroupID" DataType="System.Int32" FilterControlAltText="Filter TradegroupID column" HeaderText="TradegroupID" ReadOnly="True" SortExpression="TradegroupID" UniqueName="TradegroupID">
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="TradegroupNAME" FilterControlAltText="Filter TradegroupNAME column" HeaderText="TradeGroup Name" SortExpression="TradegroupNAME" UniqueName="TradegroupNAME" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="160px">
                                         <HeaderStyle Width="200px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="DNOTES" FilterControlAltText="Filter DNOTES column" HeaderText="Notes" SortExpression="DNOTES" UniqueName="DNOTES" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="200px">
                                         <HeaderStyle Width="300px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Edit" ButtonCssClass="btn-info" Text="Edit" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Delete Record?" ButtonType="PushButton" ButtonCssClass="btn-danger" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                     </Columns>
                                 </MasterTableView>
                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="tradeGroupSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [tblTradeGroup] WHERE [TradegroupID] = @TradegroupID" SelectCommand="SELECT [TradegroupID], [TradegroupNAME], [DNOTES] FROM [tblTradeGroup]">
                            <DeleteParameters>
                                <asp:Parameter Name="TradegroupID" Type="Int32" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                             <Triggers>
                                  <asp:PostBackTrigger ControlID="btnExcelExport" />
                                  <asp:PostBackTrigger ControlID="btnPDFExport" />
                              </Triggers>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>


    <!-- new modal -->
         <div class="modal fade" id="newmodal">
    <div class="modal-dialog" style="width:70%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                 <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">New Group </h4>
                </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-horizontal">
                                     <div class="form-group">
                                     <label class="col-sm-2 control-label">Group Name </label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" ID="txtTradeGroup" Width="100%" MaxLength="50"></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtTradeGroup" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="new"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8">
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
                                <div class="col-md-4">
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
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-horizontal">
                                     <div class="form-group">
                                     <label class="col-sm-2 control-label">Notes </label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" ID="txtNotes" Width="100%" MaxLength="50"></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                                </div>
                            </div>                            
                       </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" ValidationGroup="new" OnClick="btnSave_Click" />
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
         </div>


    <!-- edit modal -->
         <div class="modal fade" id="editmodal">
    <div class="modal-dialog" style="width:70%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                 <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Edit Group </h4>
                </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-horizontal">
                                     <div class="form-group">
                                     <label class="col-sm-2 control-label">Group Name </label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" ID="txtTradeGroup1" Width="100%" MaxLength="50"></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtTradeGroup1" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8">
                                       <div class="form-group bg-primary">Rate for Workers</div>
                                   
                                        <div class="form-horizontal">

                                     <div class="form-group">
                                    <label class="col-sm-5 control-label">Daily Basic Wage</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtDBWage1" runat="server" Width="100%" MinValue="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-5 control-label">Daily Basic Wage Weekend</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtDBWageWknd1" runat="server" Width="100%" MinValue="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-5 control-label">1 Hour Overtime Weekday</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtHourOvertimeWkday1" runat="server" Width="100%" MinValue="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">1 Hour Overtime Weekend</label>
                                    <div class="col-sm-7">
                                    <telerik:RadNumericTextBox ID="txtHourOvertimeWknd1" runat="server" Width="100%" MinValue="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Night Allowance Weekday</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtNightAllowanceWkday1" runat="server" Width="100%" ></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Night Allowance Weekend</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtNightAllowanceWknd1" runat="server" Width="100%"> </telerik:RadNumericTextBox>
                                    </div>
                                </div>     
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Transport Allowance </label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtTransportAllowance1" runat="server" Width="100%"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Subsidy</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtSubsidy1" runat="server" Width="100%" ></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">PPE Medicals</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtPPEMedicals1" runat="server" Width="100%"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-5 control-label">Bussing</label>
                                    <div class="col-sm-7">
                                        <telerik:RadNumericTextBox ID="txtBussing1" runat="server" Width="100%"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                            </div>
                                </div>
                                <div class="col-md-4">
                                     <div class="form-group bg-primary">Rate for DLE Companies</div>
                                   
                                    <div class="form-horizontal">

                                        <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtDBWageDLE1" runat="server" Width="100%" MinValue="0" Height="24px"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                            <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtDBWageWkndDLE1" runat="server" Width="100%" MinValue="0" Height="24px"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtHourOvertimeWkdayDLE1" runat="server" Width="100%" MinValue="0" Height="24px"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtHourOvertimeWkndDLE1" runat="server" Width="100%" MinValue="0" Height="24px"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtNightAllowanceWkdayDLE1" runat="server" Width="100%" MinValue="0" Height="24px"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <div class="col-sm-12">
                                        <telerik:RadNumericTextBox ID="txtNightAllowanceWkndDLE1" runat="server" Width="100%" MinValue="0" Height="24px"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-horizontal">
                                     <div class="form-group">
                                     <label class="col-sm-2 control-label">Notes </label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" ID="txtNotes1" Width="100%" MaxLength="50"></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                                </div>
                            </div>                            
                       </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" ValidationGroup="edit" OnClick="btnUpdate_Click" />
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
         </div>

    <script type="text/javascript">
            function newModal() {
                $('#newmodal').modal('show');
                $('#newmodal').appendTo($("form:first"));
            }
            function closenewModal() {
                $('#newmodal').modal('hide');
            }
            function editModal() {
                $('#editmodal').modal('show');
                $('#editmodal').appendTo($("form:first"));
            }
            function closeeditModal() {
                $('#editmodal').modal('hide');
            }
    </script>
</asp:Content>
