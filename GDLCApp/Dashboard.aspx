<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="GDLCApp.Dashboard" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                       <p>Dashboard</p>
                       
                       <div class="row" >
           <%-- <div class="col-lg-3">
                <div class="widget style1 blue-bg">
                        <div class="row">
                            <div class="col-xs-4 text-center">
                                <i class="fa fa-trophy fa-5x"></i>
                            </div>
                            <div class="col-xs-8 text-right">
                                <span> Today income </span>
                                <h2 class="font-bold">$ 4,232</h2>
                            </div>
                        </div>
                </div>
            </div>--%>
            <div class="col-lg-3">
                <div class="widget style1 navy-bg">
                    <div class="row">
                        <%--<div class="col-xs-4">
                            <i class="fa fa-cloud fa-5x"></i>
                        </div>--%>
                        <div class="col-xs-12 text-right">
                            <span> Companies </span>
                            <a style="color:white" href="/Tools/DLECompanies.aspx">
                                    <h2 class="font-bold" runat="server" id="lblCompanies"> 642</h2>
                                    </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="widget style1 lazur-bg">
                    <div class="row">
                        <%--<div class="col-xs-4">
                            <i class="fa fa-envelope-o fa-5x"></i>
                        </div>--%>
                        <div class="col-xs-12 text-right">
                            <span> Trade Groups </span>
                            <a style="color:white" href="/Tools/TradeGroup.aspx">
                                <h2 class="font-bold" runat="server" id="lblTradeGroups">5 </h2>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="widget style1 yellow-bg">
                    <div class="row">
                       <%-- <div class="col-xs-4">
                            <i class="fa fa-music fa-5x"></i>
                        </div>--%>
                        <div class="col-xs-12 text-right">
                            <span>Gangs</span>
                            <a style="color:white" href="/Setups/Gangs.aspx">
                                <h2 class="font-bold" runat="server" id="lblGangs"> 23 </h2>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="widget style1 red-bg">
                    <div class="row">
                       <%-- <div class="col-xs-4">
                            <i class="fa fa-music fa-5x"></i>
                        </div>--%>
                        <div class="col-xs-12 text-right">
                            <span> System Users </span>
                            <a style="color:white" href="/Security/Users.aspx">
                                <h2 class="font-bold" runat="server" id="lblUsers">12  </h2>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

                        <div class="row" >
                    <div class="col-lg-3">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <span class="label label-primary pull-right">Active</span>
                                <h5>Workers</h5>
                            </div>
                            <div class="ibox-content">
                                <a style="color:black" runat="server" id="lnkActiveWorkers" onserverclick="lnkActiveWorkers_ServerClick">
                                    <h1 class="no-margins" runat="server" id="lblActiveWorkers">40 886,200</h1>
                                </a>
                                
                                <small>Active</small>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <span class="label label-info pull-right">InActive</span>
                                <h5>Workers</h5>
                            </div>
                            <div class="ibox-content">
                                <a style="color:black" runat="server" id="lnkInActiveWorkers" onserverclick="lnkInActiveWorkers_ServerClick">
                                    <h1 class="no-margins" runat="server" id="lblInActiveWorkers">275,800</h1>
                                </a>
                                
                                <small>Inactive & Not Approved Yet</small>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <span class="label label-warning pull-right">Incapacitated</span>
                                <h5>Workers</h5>
                            </div>
                            <div class="ibox-content">
                                <a style="color:black" runat="server" id="lnkIncWorkers" onserverclick="lnkIncWorkers_ServerClick">
                                    <h1 class="no-margins" runat="server" id="lblIncapacitatedWorkers">106,120</h1>
                                </a>
                                
                                <small>Incapacitated</small>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <span class="label label-danger pull-right">Suspended</span>
                                <h5>Workers</h5>
                            </div>
                            <div class="ibox-content">
                                <a style="color:black" runat="server" id="lnkSusWorkers" onserverclick="lnkSusWorkers_ServerClick">
                                    <h1 class="no-margins" runat="server" id="lblSuspendedWorkers">80,600</h1>
                                </a>
                                
                                <small>Suspened</small>
                            </div>
                        </div>
            </div>
        </div>


                        <div class="row">
                            
                        </div>
                    </div>
                </div>
            </div>

                </div>
        </div>
</asp:Content>
