<%@ Page Title="" Language="C#" MasterPageFile="~/CustomizePayroll/CSHome.Master" AutoEventWireup="true" CodeBehind="MonthlyStore.aspx.cs" Inherits="GDLCApp.CustomizePayroll.Audit.PayrollStore.MonthlyStore" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/css/updateProgress.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Monthly Payroll Store</h5>
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
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="upProcess">
                           <ProgressTemplate>
                            <div class="divWaiting">            
	                            <asp:Label ID="lblWait" runat="server" Text="Processing... " />
	                              <asp:Image ID="imgWait" runat="server" ImageAlign="Top" ImageUrl="/Content/img/loader.gif" />
                                </div>
                             </ProgressTemplate>
                       </asp:UpdateProgress>
                         <asp:UpdatePanel ID="upProcess" runat="server" >
                    <ContentTemplate>
                        <div runat="server" id="lblMsg" class="alert alert-info"></div>
                  
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-3">
                                   <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upProcess">
                                        <ProgressTemplate>
                                            Processing....
                                            <img alt="" src="/Content/img/loader.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>--%>
                                </div>
                                <div class="col-md-3">
                                    <label>Start Date</label>
                                    <telerik:RadDatePicker runat="server" ID="dpStartDate" DateInput-ReadOnly="true" Width="100%"></telerik:RadDatePicker>
                                </div>
                                <div class="col-md-3">
                                     <label>End Date</label>
                                    <telerik:RadDatePicker runat="server" ID="dpEndDate" DateInput-ReadOnly="true" Width="100%"></telerik:RadDatePicker>
                                </div>
                                <div class="col-md-3">

                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnProcess" Text="Store Payroll" CssClass="btn btn-primary" OnClick="btnProcess_Click" OnClientClick="if (Page_IsValid) {this.value='Storing...';this.disabled=true; }" UseSubmitBehavior="false" />
                        </div> 

                        <div hidden="hidden" class="alert alert-info">Remove Processed Cost Sheets from Store</div>
                        <br />

                        <div hidden="hidden" class="form-group">
                            <div class="row">
                                <div class="col-md-3">
                                  
                                </div>
                                <div class="col-md-3">
                                    <label>Start Date</label>
                                    <telerik:RadDatePicker runat="server" ID="dpSdate" DateInput-ReadOnly="true" Width="100%"></telerik:RadDatePicker>
                                </div>
                                <div class="col-md-3">
                                     <label>End Date</label>
                                    <telerik:RadDatePicker runat="server" ID="dpEdate" DateInput-ReadOnly="true" Width="100%"></telerik:RadDatePicker>
                                </div>
                                <div class="col-md-3">

                                </div>
                            </div>
                        </div>
                        <div hidden="hidden" class="modal-footer">
                            <asp:Button runat="server" ID="btnDeleteStored" Text="DELETE Stored Payroll" CssClass="btn btn-danger" OnClick="btnDeleteStored_Click" OnClientClick="if (Page_IsValid) {this.value='Deleting...';this.disabled=true; }" UseSubmitBehavior="false" />
                        </div>
                          
                    </ContentTemplate>
                </asp:UpdatePanel>
                    </div>
                </div>
        </div>
</asp:Content>
