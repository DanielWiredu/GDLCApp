<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BulkSMS.aspx.cs" Inherits="GDLCApp.Setups.BulkSMS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Bulk SMS</h5>
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
                      <asp:Button ID="btnNewSMS" runat="server" Text="New SMS" CssClass="btn btn-success" OnClick="btnNewSMS_Click" CausesValidation="false" />
                        </ContentTemplate>
                </asp:UpdatePanel>

                        <telerik:RadGrid ID="contactGrid" runat="server" AllowMultiRowSelection="true" AllowFilteringByColumn="True" AllowPaging="False" AllowSorting="True" DataSourceID="contactSource" GroupPanelPosition="Top" OnItemDataBound="contactGrid_ItemDataBound">
                             <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                <Selecting AllowRowSelect="true" />
                               <Scrolling AllowScroll="true" ScrollHeight="350px" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                           <ExportSettings IgnorePaging="true" ExportOnlyData="true" OpenInNewWindow="true" FileName="contact_list" >
                               <Pdf AllowPrinting="true" AllowCopy="true" PaperSize="Letter" PageTitle="Contact List" PageWidth="400"></Pdf>
                           </ExportSettings>
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="contactSource" CommandItemDisplay="Top" >
                                  <CommandItemSettings ShowExportToPdfButton="true" ShowExportToExcelButton="true" ShowAddNewRecordButton="false" />
                                <Columns>
                                    <telerik:GridClientSelectColumn Exportable="false">
                                        <HeaderStyle Width="20px" />
                                    </telerik:GridClientSelectColumn>
                                     <telerik:GridBoundColumn DataField="Id" UniqueName="Id" SortExpression="Id" FilterControlAltText="Filter Id column" HeaderText="Id" Display="true" AllowFiltering="false">
                                    <HeaderStyle Width="60px" />
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="Fullname" FilterControlAltText="Filter Fullname column" HeaderText="Fullname" SortExpression="Fullname" UniqueName="Fullname" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="160px">
                                    <HeaderStyle Width="200px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ContactNo" FilterControlAltText="Filter ContactNo column" HeaderText="ContactNo" SortExpression="ContactNo" UniqueName="ContactNo" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100px">
                                    <HeaderStyle Width="120px" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="contactSource" runat="server" ConnectionString="Data Source=localhost;Initial Catalog=BulkSMSDb;Persist Security Info=True;User ID=pascal;Password=Bsuccess91" SelectCommand="SELECT * FROM [Receipients]">
                        </asp:SqlDataSource>

                    </div>
                </div>
        </div>

     <div class="modal fade" id="SMSmodal">
    <div class="modal-dialog" style="width:50%">
        <asp:UpdatePanel runat="server" ID="upMessage">
            <ContentTemplate>
                  <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">New SMS</h4>
                </div>
                        <div class="modal-body">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upMessage">
                                <ProgressTemplate>
                                    Sending....
                                    <img alt="" src="/Content/dist/img/loader.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                              <div class="form-group">
                               <label>Send As</label>
                               <asp:TextBox ID="txtHeader" runat="server" Width="100%" MaxLength="20"></asp:TextBox>
                               <asp:RequiredFieldValidator runat="server" ControlToValidate="txtHeader" Display="Dynamic" ForeColor="Red" ErrorMessage="Required Field" SetFocusOnError="true" ValidationGroup="sms"></asp:RequiredFieldValidator>
                           </div>
                         <div class="form-group">
                               <label>Message</label>
                               <asp:TextBox ID="txtMessage" runat="server" Width="100%" TextMode="MultiLine" Rows="5"></asp:TextBox>
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMessage" Display="Dynamic" ForeColor="Red" ErrorMessage="Required Field" SetFocusOnError="true" ValidationGroup="sms"></asp:RequiredFieldValidator>
                           </div>
                       </div>
                <div class="modal-footer">
                     <button type="button" class="btn btn-warning" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSendSMS" runat="server" Text="Send" CssClass="btn btn-primary" OnClick="btnSendSMS_Click" ValidationGroup="sms" />
                </div>

            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>

       <script type="text/javascript">
        function newSMSModal() {
            $('#SMSmodal').modal('show');
            $('#SMSmodal').appendTo($("form:first"));
        }
        function closeSMSModal() {
            $('#SMSmodal').modal('hide');
        }
    </script>
</asp:Content>
