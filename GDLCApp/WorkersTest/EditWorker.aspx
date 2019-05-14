<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EditWorker.aspx.cs" Inherits="GDLCApp.WorkersTest.EditWorker" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
          function previewFile() {
              var preview = document.querySelector('#<%=Image1.ClientID %>');
            var file = document.querySelector('#<%=avatarUpload.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
          }
    </script>
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Edit Worker</h5>
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
                         <div runat="server" id="lblMsg"></div>
                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Registration Date</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDatePicker runat="server" ID="dpRegdate" Width="100%" DateInput-ReadOnly="true" MinDate="1/1/1850"></telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dpRegdate" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Auto Number</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtAutoNumber" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Worker ID</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtWorkerID" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtWorkerID" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Gender</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDropDownList ID="dlGender" runat="server" Width="100%" >
                                            <Items>
                                                <telerik:DropDownListItem Text="Male" Value="M" />
                                                <telerik:DropDownListItem Text="Female" Value="F" />
                                            </Items>
                                        </telerik:RadDropDownList>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Worker Type</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDropDownList ID="dlWorkerType" runat="server" Width="100%">
                                            <Items>
                                                <telerik:DropDownListItem Text="Daily" Value="D" />
                                                <telerik:DropDownListItem Text="Weekly" Value="W" />
                                                <telerik:DropDownListItem Text="Monthly" Value="M" />
                                            </Items>
                                        </telerik:RadDropDownList>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Full name</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtFullname" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                            </div>
                                        <div class="col-md-2">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <%--<label class="col-sm-4 control-label">Comments</label>--%>
                                    <div class="col-sm-12">
                                        <asp:Image ID="Image1" runat="server" Width="100%" Height="130px" BackColor="#cccccc" />
                            <input id="avatarUpload" type="file" name="file" onchange="previewFile()"  runat="server" />
                                    </div>
                                </div>
                                </div>
                            </div>
                        </div>


                            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="0" AutoPostBack="false" CausesValidation="false" >
                <Tabs>
                    <telerik:RadTab runat="server" Text="Personal" >
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Official" Enabled="true">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Worker IDs" Enabled="true">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Track Records" Enabled="false">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Training/Workshops" Enabled="false">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
                            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" RenderSelectedPageOnly="false" >
                                <telerik:RadPageView ID="upPersonal" runat="server" Height="100%">
                                    <div class="row">
                            <div class="col-md-6">
                                <hr />
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Date of Birth</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDatePicker ID="dpDOB" runat="server" Width="100%" DateInput-ReadOnly="false" MinDate="1/1/1850"></telerik:RadDatePicker>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="dpDOB" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Nationality</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDropDownList ID="dlNationality" runat="server" Width="100%" DataSourceID="nationalitySource" DataTextField="Nationality" DataValueField="Id" DropDownHeight="200px" DefaultMessage="Select Nationality"></telerik:RadDropDownList>
                                        <asp:SqlDataSource ID="nationalitySource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Id,Nationality FROM [tblNationality]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dlNationality" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Surname</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtSurname" runat="server" Width="100%"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSurname" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Othernames</label>
                                    <div class="col-sm-8">
                                       <asp:TextBox ID="txtOthernames" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-4 control-label">Previous Name</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtPreviousName" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-4 control-label">Address 1</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtAddress1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Address 2</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtAddress2" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-4 control-label">Phone Number</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtPhoneNumber" runat="server" Width="100%" ></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Numbers only up to 10 characters" ControlToValidate="txtPhoneNumber" ValidationExpression="^[0-9]{10,10}$" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Education</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtEducation" placeholder="Qualification..." runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <hr />
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Next of Kin</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtNextOfKin" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-4 control-label">Relation</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtNOKRelation" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-4 control-label">Address</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtNOKAddress" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-4 control-label">Phone No</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtNOKPhoneNo" runat="server" Width="100%"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Numbers only up to 10 characters" ControlToValidate="txtNOKPhoneNo" ValidationExpression="^[0-9]{10,10}$" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-4 control-label">Contact Person</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtContactPerson" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-4 control-label">Contact Address</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtContactAddress" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="form-group">
                                    <label class="col-sm-4 control-label">Contact Phone No</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtContactPhoneNo" runat="server" Width="100%"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Numbers only up to 10 characters" ControlToValidate="txtContactPhoneNo" ValidationExpression="^[0-9]{7,10}$" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                                    </div>
                                </div>
                                </div>
                            </div>
                        </div>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="upOfficial" runat="server" Height="100%">
                                    <div class="row">
                            <div class="col-md-6">
                                <hr />
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label"></label>
                                    <div class="col-sm-8">
                                        <asp:Label runat="server" ID="lblStatus" ForeColor="Red" Font-Bold="true" Visible="true"></asp:Label>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Tax</label>
                                    <div class="col-sm-8">
                                        <asp:CheckBox runat="server" ID="chkTax" />
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Charge Premium</label>
                                    <div class="col-sm-8">
                                        <asp:CheckBox runat="server" ID="chkChargePremium" />
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">SSF No</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtSSFNo" Width="100%" ></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Alphanumeric between 8 to 15 characters" ControlToValidate="txtSSFNo" ValidationExpression="^[a-zA-Z0-9\s]{8,15}$" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                                        <asp:RequiredFieldValidator Enabled="true" runat="server" ControlToValidate="txtSSFNo" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">NHIS Reg No</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtNHISNo" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">New ID No</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtNewIDNo" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Shoe Size</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtShoeSize" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Height</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtHeight" Width="100%" ></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Trade Group</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDropDownList ID="dlTradeGroup" runat="server" Width="100%" DataSourceID="tradeGroupSource" DataTextField="TradegroupNAME" DataValueField="TradegroupID" DefaultMessage="Select Group" DropDownHeight="200px" AutoPostBack="true" CausesValidation="false" OnItemSelected="dlTradeGroup_ItemSelected"></telerik:RadDropDownList>
                                        <asp:SqlDataSource ID="tradeGroupSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TradegroupID,TradegroupNAME FROM [tblTradeGroup]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dlTradeGroup" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Trade Category</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDropDownList ID="dlTradeCategory" runat="server" Width="100%" DataSourceID="tradeTypeSource" DataTextField="TradetypeNAME" DataValueField="TradetypeID" DefaultMessage="Select Category" DropDownHeight="200px"></telerik:RadDropDownList>
                                        <asp:SqlDataSource ID="tradeTypeSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TradetypeID,TradetypeNAME FROM [tblTradeType] WHERE TradegroupID=@TradeGroupID">
                                            <SelectParameters>
                                                <asp:ControlParameter Name="TradeGroupID" ControlID="dlTradeGroup" Type="Int32" PropertyName="SelectedValue" DefaultValue="0" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dlTradeCategory" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator> 
                                    </div>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <hr />
                                <div class="form-horizontal">
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label"></label>
                                    <div class="col-sm-8">
                                        <asp:Label runat="server" ID="lblAge" ForeColor="Red" Font-Bold="true" Width="100%" Visible="true"></asp:Label>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">E-zwich Number</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtEzwichNo" Width="100%"></asp:TextBox>
                                        <asp:RequiredFieldValidator Enabled="false" runat="server" ControlToValidate="txtEzwichNo" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator> 
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Must be between 6 to 15 characters" ControlToValidate="txtEzwichNo" ValidationExpression="^[\s\S]{6,15}$" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">TIN</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtTIN" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">National ID No</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtNationalIDNo" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Gang</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDropDownList ID="dlGang" runat="server" Width="100%" DefaultMessage="Select Gang" DataSourceID="gangSource" DataTextField="GangName" DataValueField="GangId" DropDownHeight="200px"></telerik:RadDropDownList>
                                        <asp:SqlDataSource ID="gangSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT GangId,GangName FROM [tblGangs]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dlGang" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Bank</label>
                                    <div class="col-sm-8">
                                        <telerik:RadDropDownList ID="dlBank" runat="server" Width="100%" DefaultMessage="Select Bank" DataSourceID="bankSource" DataTextField="BankName" DataValueField="BankId" DropDownHeight="200px"></telerik:RadDropDownList>
                                        <asp:SqlDataSource ID="bankSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT BankId,BankName FROM [tblBanks]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator Enabled="false" runat="server" ControlToValidate="dlBank" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Bank Branch</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtBankBranch" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Bank Number</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtBankNo" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group">
                                    <label class="col-sm-4 control-label">Notes & Comments</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" ID="txtComments" Width="100%" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                            </div>
                        </div>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="upWorkerIDs" runat="server" Height="100%">
                                    <hr />
                                    <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row">
                                        <div class="col-sm-4 pull-right" style="width:inherit">
                                           <%--<asp:Button runat="server" ID="btnExcelExport" CssClass="btn-success" Text="Excel" CausesValidation="false" OnClick="btnExcelExport_Click"/>--%>
                                            <%--<asp:Button runat="server" ID="btnPDFExport" CssClass="btn-warning" Text="PDF" CausesValidation="false" OnClick="btnPDFExport_Click"/>--%>
                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">
                                                <asp:Button runat="server" CssClass="btn-primary" Text="Add ID" CausesValidation="false" OnClientClick="newIDModal()" />  
                                            </div>
                                        </div>
                                    </div>
                        <hr />
                        <telerik:RadGrid ID="WorkerIdGrid" runat="server" AutoGenerateColumns="False" DataSourceID="workerIdSource" GroupPanelPosition="Top" AllowPaging="True" AllowSorting="True" CellSpacing="-1" GridLines="Both">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="200px"/>
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                            <MasterTableView DataKeyNames="Id" DataSourceID="workerIdSource" PageSize="10">
                                     <Columns>
                                         <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Edit" ButtonCssClass="btn-info" Text="Edit" Exportable="false">
                                        <HeaderStyle Width="50px" />
                                        </telerik:GridButtonColumn>
                                         <telerik:GridBoundColumn DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" UniqueName="Id" Display="false">
                                         <HeaderStyle Width="70px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="SSFNo" HeaderText="SSF No" SortExpression="SSFNo" UniqueName="SSFNo">
                                         <HeaderStyle Width="140px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="WorkerID"  HeaderText="Worker ID" SortExpression="WorkerID" UniqueName="WorkerID">
                                         <HeaderStyle Width="120px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="TradegroupID" SortExpression="TradegroupID" UniqueName="TradegroupID" Display="false">
                                         <HeaderStyle Width="70px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="TradegroupNAME" HeaderText="Trade Group" SortExpression="TradegroupNAME" UniqueName="TradegroupNAME" AutoPostBackOnFilter="true">
                                         <HeaderStyle Width="100px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="TradetypeID" SortExpression="TradetypeID" UniqueName="TradetypeID" Display="false">
                                         <HeaderStyle Width="70px" />
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="TradetypeNAME" HeaderText="Trade Category" SortExpression="TradetypeNAME" UniqueName="TradetypeNAME">
                                         <HeaderStyle Width="150px" />
                                         </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Delete Record?" ButtonType="PushButton" ButtonCssClass="btn-danger" Exportable="false">
                                        <HeaderStyle Width="60px" />
                                        </telerik:GridButtonColumn>
                                     </Columns>
                                 </MasterTableView>
                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="workerIdSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [WorkerID], [SSFNo], [TradegroupID], [TradegroupNAME], [TradetypeID], [TradetypeNAME] FROM [vwWorkersTrade] WHERE SSFNo = @SSFNo" DeleteCommand="spDeleteWorker" DeleteCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtSSFNo" Type="String" PropertyName="Text" Name="SSFNo" />
                        </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>

                                </telerik:RadPageView>
                                <telerik:RadPageView ID="pvTrackRecord" runat="server" Height="100%">
                                    <hr />
                                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>
                        <div class="row">
                                        <div class="col-sm-4 pull-right" style="width:inherit">
                                           <%--<asp:Button runat="server" ID="btnExcelExport" CssClass="btn-success" Text="Excel" CausesValidation="false" OnClick="btnExcelExport_Click"/>--%>
                                            <%--<asp:Button runat="server" ID="btnPDFExport" CssClass="btn-warning" Text="PDF" CausesValidation="false" OnClick="btnPDFExport_Click"/>--%>
                                        </div>
                                        <div class="col-sm-8 pull-left">
                                            <div class="toolbar-btn-action">
                                                <asp:Button runat="server" CssClass="btn-primary" Text="Add Record" CausesValidation="false" OnClientClick="newModal()" />  
                                            </div>
                                        </div>
                                    </div>
                        <telerik:RadGrid ID="actionGrid" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" CellSpacing="-1" GridLines="Both">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="200px"/>
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <GroupingSettings CaseSensitive="false" />
                            <ExportSettings IgnorePaging="true" ExportOnlyData="true" OpenInNewWindow="true" FileName="service_list" HideStructureColumns="true"  >
                                        <Pdf AllowPrinting="true" AllowCopy="true" PaperSize="Letter" PageTitle="Service List" PageWidth="1000"></Pdf>
                                    </ExportSettings>

                        </telerik:RadGrid>
                    </ContentTemplate>
                                        <%--<Triggers>
                                  <asp:PostBackTrigger ControlID="btnExcelExport" />
                                  <asp:PostBackTrigger ControlID="btnPDFExport" />
                              </Triggers>--%>
                </asp:UpdatePanel>

                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnReturn" Text="Return" CssClass="btn btn-warning" CausesValidation="false" style="margin-bottom:0px" PostBackUrl="~/Workers/Workers.aspx" />
                            <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="btn btn-info" OnClick="btnPrint_Click" CausesValidation="false" />
                            <asp:Button runat="server" ID="btnFind" Text="Find" CssClass="btn btn-success" OnClientClick="newModal()" CausesValidation="false" />
                            <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                        </div>   
                    </ContentTemplate>
                              <Triggers>
                                 <asp:PostBackTrigger ControlID="btnUpdate" />
                             </Triggers>
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
                    <h4 class="modal-title">Find Worker</h4>
                </div>
                        <div class="modal-body">
                             <div class="form-group">
                                        <label>Enter Worker ID</label>
                                       <asp:TextBox runat="server" ID="txtSearchWorker" ClientIDMode="Static" Width="100%" MaxLength="50" ></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ControlToValidate="txtSearchWorker" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="search"></asp:RequiredFieldValidator>
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

    <script type="text/javascript">
                function newModal() {
                $('#newmodal').modal('show');
                $('#newmodal').appendTo($("form:first"));
                }

                $('#newmodal').on('shown.bs.modal', function () {                    
                    // jQuery code is in here
                    $('#txtSearchWorker').focus();
                });

            function closenewModal() {
                $('#newmodal').modal('hide');
            }
    </script>
</asp:Content>
