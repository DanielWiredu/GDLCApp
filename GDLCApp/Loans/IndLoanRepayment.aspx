<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="IndLoanRepayment.aspx.cs" Inherits="GDLCApp.Loans.IndLoanRepayment" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/css/aspControlStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5> Loan Repayment</h5>
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
                         <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div runat="server" id="lblMsg"></div>
                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Loan No</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtLoanNo" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Loan Scheme</label>
                                    <div class="col-sm-8">
                                        <telerik:RadComboBox ID="dlLoanScheme" runat="server" Width="100%" DataSourceID="schemeSource" MaxHeight="200" EmptyMessage="Select Loan Scheme" Filter="Contains" MarkFirstMatch="true" DataTextField="LoanScheme" DataValueField="Id"></telerik:RadComboBox>
                                        <asp:SqlDataSource ID="schemeSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Id,LoanScheme FROM [tblLoanSchemes]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dlLoanScheme" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                   <div class="form-group">
                                    <label class="col-sm-4 control-label">Loan Date</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDatePicker runat="server" ID="dpLoanDate" Width="100%" DateInput-ReadOnly="true"></telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dpLoanDate" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Loan Amount</label>
                                    <div class="col-sm-8">
                                        <telerik:RadNumericTextBox ID="txtLoanAmount" runat="server" Width="100%" MinValue="0" Value="0"></telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLoanAmount" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Repayment Amount</label>
                                    <div class="col-sm-8">
                                        <telerik:RadNumericTextBox ID="txtRepayAmount" runat="server" Width="100%" MinValue="0" Value="0"></telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRepayAmount" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Monthly Limit</label>
                                    <div class="col-sm-8">
                                        <telerik:RadNumericTextBox ID="txtMonthlyLimit" runat="server" Width="100%" MinValue="0" Value="0"></telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMonthlyLimit" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Repaid Amount</label>
                                    <div class="col-sm-8">
                                        <telerik:RadNumericTextBox ID="txtRepaidAmount" runat="server" Width="100%" Enabled="false" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Loan Balance</label>
                                    <div class="col-sm-8">
                                        <telerik:RadNumericTextBox ID="txtLoanBalance" runat="server" Width="100%" Enabled="false" Value="0"></telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:CheckBox ID="chkAutoDeduct" runat="server" Text="Auto Deduct" ForeColor="Green" TextAlign="Left" />
                                    </div>
                                </div>
                                    <div class="form-group">
                                        <div class="col-sm-12">
                                            <asp:CheckBox ID="chkApproved" runat="server" Enabled="false" Text="Approved" ForeColor="Green" TextAlign="Left" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                                <label>Name</label> 
                            <telerik:RadTextBox runat="server" ID="txtWorkerId" ReadOnly="true" Width="15%" ShowButton="true" EmptyMessage="Select Worker">
                                <EmptyMessageStyle Resize="None" /></telerik:RadTextBox>
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="txtWorkerId" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox runat="server" ID="txtWorkerName" Width="30%" Enabled="false"></asp:TextBox>
                             <label>Ezwich No</label>
                               <asp:TextBox runat="server" ID="txtEzwichNo" Width="20%" Enabled="false" ForeColor="Red"></asp:TextBox>
                            <label>WorkerType</label>
                               <asp:TextBox runat="server" ID="txtWorkerType" Width="15%" Enabled="false" ForeColor="Red"></asp:TextBox>
                        </div>

                         <div class="row">
                            <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                       <%-- <div runat="server" id="lblDays" class="bg-info">Total Days : </div>--%>
                             <telerik:RadGrid ID="loanRepayGrid" runat="server" ShowFooter="true" DataSourceID="indLoanRepaySource" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowPaging="False" AllowSorting="True" CellSpacing="-1" GridLines="Both" OnItemCommand="loanRepayGrid_ItemCommand" OnDeleteCommand="loanRepayGrid_DeleteCommand">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="250px" />
                                <Selecting AllowRowSelect="true" />
                                <%--<ClientEvents OnRowDblClick="WorkGrdRowDblClick" />--%>
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />

                                 <MasterTableView DataKeyNames="AutoId" DataSourceID="indLoanRepaySource" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add Repayment" AllowAutomaticDeletes="false">
                                     <Columns>
                                        <telerik:GridButtonColumn CommandName="Delete" UniqueName="Delete" ConfirmText="Delete Record?" ButtonType="FontIconButton" Exportable="false">
                                            <HeaderStyle Width="20px" />
                                        </telerik:GridButtonColumn>
                                         <telerik:GridBoundColumn Display="true" DataField="AutoId" DataType="System.Int32" Aggregate="Count" FooterText="Count : " FilterControlAltText="Filter AutoId column" HeaderText="AutoId" SortExpression="AutoId" UniqueName="AutoId">
                                         <HeaderStyle Width="60px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridDateTimeColumn DataField="RepayDate" FilterControlAltText="Filter RepayDate column" HeaderText="RepayDate" ReadOnly="True" SortExpression="RepayDate" UniqueName="RepayDate" DataFormatString="{0:dd-MMM-yyyy}">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridDateTimeColumn>
                                         <telerik:GridBoundColumn DataField="RepayAmount" DataType="System.Double" Aggregate="Sum" FooterText="Sum : " FilterControlAltText="Filter RepayAmount column" HeaderText="RepayAmount" SortExpression="RepayAmount" UniqueName="RepayAmount" DataFormatString="{0:N02}">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ReqNo" FilterControlAltText="Filter ReqNo column" HeaderText="ReqNo" SortExpression="ReqNo" UniqueName="ReqNo">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridCheckBoxColumn DataField="Approved" DataType="System.Boolean" FilterControlAltText="Filter Approved column" HeaderText="A" SortExpression="Approved" UniqueName="Approved" StringTrueValue="1" StringFalseValue="0" >
                                         <HeaderStyle Width="30px" />
                                         </telerik:GridCheckBoxColumn>
                                         <telerik:GridButtonColumn CommandName="Approve" UniqueName="Approve" Text="Approve" ConfirmText="Approve Payment?" ButtonType="PushButton" ButtonCssClass="btn-primary" Exportable="false">
                                            <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                     </Columns>
                                 </MasterTableView>

                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="indLoanRepaySource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT AutoId, RepayDate, RepayAmount, ReqNo, Approved FROM tblLoanRepayments WHERE (LoanNo = @LoanNo) ORDER BY AutoId DESC" DeleteCommand="DELETE FROM tblLoanRepayments WHERE AutoId=@AutoId">
                            <SelectParameters>
                                <asp:ControlParameter Name="LoanNo" ControlID="txtLoanNo" Type="String" PropertyName="Text" ConvertEmptyStringToNull="false" DefaultValue=" " />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:Parameter Name="AutoId" Type="Int32" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </div>                       
                  
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnReturn" Text="Return" CssClass="btn btn-warning" CausesValidation="false" style="margin-bottom:0px" PostBackUrl="~/Loans/LoanRepayments.aspx" />
                            <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="btn btn-info" OnClick="btnPrint_Click"  />
                        </div>   
                    </ContentTemplate>
                             <Triggers>
                                 <asp:AsyncPostBackTrigger ControlID="loanRepayGrid" EventName="ItemCommand" />
                             </Triggers>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>

    <!-- new modal -->
         <div class="modal fade" id="newmodal">
    <div class="modal-dialog" style="width:40%">
        <%--<asp:Panel runat="server" DefaultButton="btnSearch">--%>
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                 <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">New Repayment</h4>
                </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label>Payment Date</label>
                                <telerik:RadDatePicker ID="dpPaymentDate" runat="server" DateInput-ReadOnly="true" Width="100%"></telerik:RadDatePicker>
                                 <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="dpPaymentDate" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="new"></asp:RequiredFieldValidator>
                            </div>
                             <div class="form-group">
                                        <label>Amount</label>
                                 <telerik:RadNumericTextBox ID="txtAmount" runat="server" Width="100%" Value="0"></telerik:RadNumericTextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtAmount" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="new"></asp:RequiredFieldValidator>
                             </div>
                            <%--<div class="form-group">
                                <label>Receipt No</label>
                                <asp:TextBox ID="txtReceiptNo" runat="server" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtReceiptNo" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="new"></asp:RequiredFieldValidator>
                            </div>--%>
                            <div>
                            </div>
                       </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"  OnClick="btnSave_Click" ValidationGroup="new" />
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--</asp:Panel>--%>
        </div>
         </div>

    <script type="text/javascript">
        function newModal() {
            $('#newmodal').modal('show');
            $('#newmodal').appendTo($("form:first"));
        }
        $('#newmodal').on('shown.bs.modal', function () {
            // jQuery code is in here
            $('#txtSearchValue').focus();
        });
        function closenewModal() {
            $('#newmodal').modal('hide');
        }
    </script>
</asp:Content>
