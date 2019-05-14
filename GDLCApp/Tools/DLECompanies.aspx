<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DLECompanies.aspx.cs" Inherits="GDLCApp.Tools.DLECompanies" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>DLE Companies</h5>
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
                                                <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-success" Text="Add DLECompany" CausesValidation="false" OnClientClick="newModal()" />  
                                            </div>
                                        </div>
                                    </div>

                             <telerik:RadGrid ID="dleGrid" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" CellSpacing="-1" GridLines="Both" DataSourceID="dleSource" OnItemCommand="dleGrid_ItemCommand" OnItemDeleted="dleGrid_ItemDeleted">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                                 <ExportSettings IgnorePaging="true" ExportOnlyData="true" OpenInNewWindow="true" FileName="dleCompany_list" HideStructureColumns="true"  >
                                        <Pdf AllowPrinting="true" AllowCopy="true" PaperSize="Letter" PageTitle="DLE Company List" PageWidth="700"></Pdf>
                                    </ExportSettings>
                                 <MasterTableView DataKeyNames="DLEcodeCompanyID" DataSourceID="dleSource" AllowAutomaticDeletes="true">
                                     <Columns>
                                         <telerik:GridButtonColumn ButtonType="PushButton" ConfirmDialogType="RadWindow" ButtonCssClass="btn-warning" CommandName="ToggleActive" UniqueName="ToggleActive" Text="ToogleActive" ConfirmText="Change Company's Active Status?" Exportable="false">
                                        <HeaderStyle Width="70px" />
                                        </telerik:GridButtonColumn>
                                         <telerik:GridBoundColumn Display="false" DataField="DLEcodeCompanyID" DataType="System.Int32" FilterControlAltText="Filter DLEcodeCompanyID column" HeaderText="DLEcodeCompanyID" ReadOnly="True" SortExpression="DLEcodeCompanyID" UniqueName="DLEcodeCompanyID">
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="DLEcodeCompanyName" FilterControlAltText="Filter DLEcodeCompanyName column" HeaderText="DLE CompanyName" SortExpression="DLEcodeCompanyName" UniqueName="DLEcodeCompanyName" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="250px">
                                         <HeaderStyle Width="300px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Pattern" FilterControlAltText="Filter Pattern column" HeaderText="Pattern" SortExpression="Pattern" UniqueName="Pattern" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="120px">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridNumericColumn DataField="SharePerc" DataType="System.Double" FilterControlAltText="Filter SharePerc column" HeaderText="SharePerc" SortExpression="SharePerc" UniqueName="SharePerc" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="60px" DataFormatString="{0:0.00}">
                                         <HeaderStyle Width="80px" />
                                         </telerik:GridNumericColumn>
                                         <telerik:GridCheckBoxColumn DataField="Active" DataType="System.Boolean" FilterControlAltText="Filter Active column" HeaderText="A" SortExpression="Active" UniqueName="Active" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                         <HeaderStyle Width="30px" />
                                         </telerik:GridCheckBoxColumn>
                                         <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Edit" ButtonCssClass="btn-info" Text="Edit" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Delete Record?" ButtonType="PushButton" ButtonCssClass="btn-danger" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                     </Columns>
                                 </MasterTableView>
                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="dleSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [tblDLECompany] WHERE [DLEcodeCompanyID] = @DLEcodeCompanyID" SelectCommand="SELECT [DLEcodeCompanyID], [DLEcodeCompanyName], [Pattern], [SharePerc], [Active] FROM [tblDLECompany] ORDER BY [DLEcodeCompanyName]">
                            <DeleteParameters>
                                <asp:Parameter Name="DLEcodeCompanyID" Type="Int32" />
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
    <div class="modal-dialog" style="width:80%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                 <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">New DLE </h4>
                </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6">
                                        <div class="form-horizontal">
                                <div class="form-group">
                                    <b><label class="col-sm-3 control-label">DLE Name </label></b>
                                    <div class="col-sm-9">
                                        <asp:TextBox runat="server" ID="txtDLEName" Width="100%" MaxLength="50"></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtDLEName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="new"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label" style="font-weight:bolder">DLE Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtDLEAddress" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">DLE Telephone</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtDLETel" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Email Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtDLEEmail" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Status</label>
                                    <div class="col-sm-9">
                                    <telerik:RadDropDownList ID="dlDLEStatus" runat="server" Width="100%">
                                    <Items>
                                 <telerik:DropDownListItem Text="Share Holder"/>
                                 <telerik:DropDownListItem Text="Non Share Holder" />
                                 <telerik:DropDownListItem Text="Non Share Holder Agencies"  />
                                 <telerik:DropDownListItem Text="Members without Transport" />
                                 <telerik:DropDownListItem Text="Others" />
                             </Items>
                         </telerik:RadDropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Share %</label>
                                    <div class="col-sm-9">
                                        <telerik:RadNumericTextBox ID="txtDLEPerc" runat="server" Width="100%" ShowSpinButtons="true" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     
                                
                            </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                    <label class="col-sm-3 control-label">Finance</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtFinance" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                            <div class="form-group">
                                    <label class="col-sm-3 control-label">Telephone</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtFTel" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Email Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtFEmail" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Operation</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtOperation" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Telephone</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtOTel" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Email Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtOEmail" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Administration</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtAdministration" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Telephone</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtATel" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Email Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtAEmail" runat="server" Width="100%"></asp:TextBox>
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
    <div class="modal-dialog" style="width:80%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                 <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Edit DLE</h4>
                </div>
                        
                     <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6">
                                        <div class="form-horizontal">
                                <div class="form-group">
                                    <b><label class="col-sm-3 control-label">DLE Name </label></b>
                                    <div class="col-sm-9">
                                        <asp:TextBox runat="server" ID="txtDLEName1" Width="100%" MaxLength="50"></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtDLEName1" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label" style="font-weight:bolder">DLE Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtDLEAddress1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">DLE Telephone</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtDLETel1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Email Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtDLEEmail1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Status</label>
                                    <div class="col-sm-9">
                                    <telerik:RadDropDownList ID="dlDLEStatus1" runat="server" Width="100%">
                                    <Items>
                                 <telerik:DropDownListItem Text="Share Holder"/>
                                 <telerik:DropDownListItem Text="Non Share Holder" />
                                 <telerik:DropDownListItem Text="Non Share Holder Agencies"  />
                                 <telerik:DropDownListItem Text="Members without Transport" />
                                 <telerik:DropDownListItem Text="Others" />
                             </Items>
                         </telerik:RadDropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Share %</label>
                                    <div class="col-sm-9">
                                        <telerik:RadNumericTextBox ID="txtDLEPerc1" runat="server" Width="100%" ShowSpinButtons="true"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                     
                                
                            </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                    <label class="col-sm-3 control-label">Finance</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtFinance1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                            <div class="form-group">
                                    <label class="col-sm-3 control-label">Telephone</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtFTel1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Email Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtFEmail1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Operation</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtOperation1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Telephone</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtOTel1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Email Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtOEmail1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Administration</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtAdministration1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Telephone</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtATel1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-3 control-label">Email Address</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtAEmail1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                    </div>
                                </div>
                            </div>                            
                       </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" ValidationGroup="edit" OnClick="btnUpdate_Click"/>
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
