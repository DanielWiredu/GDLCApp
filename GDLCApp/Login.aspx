﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GDLCApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

     <title>Labour Management System</title>

    <link href="/Content/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet"/>
    <link href="/Content/css/animate.css" rel="stylesheet"/>
    <link href="/Content/css/style.css" rel="stylesheet"/>
    <link href="/Content/css/plugins/toastr/toastr.min.css" rel="stylesheet"/>
</head>

<body class="gray-bg">
    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>

                <h1 class="logo-name" style="font-size:110px">LAMS</h1>

            </div>
            <h3>Welcome to Ghana Dock <br /> Labour Company</h3>

            <p>Please enter your username and password.</p>
         <form runat="server" class="m-t" defaultbutton="btnLogin">
                 <asp:ScriptManager runat="server" ></asp:ScriptManager>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                   
                <div class="form-group">
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" Width="100%" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" Width="100%" Height="30px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
                <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-primary block full-width m-b" OnClick="btnLogin_Click" />
            
                </ContentTemplate>
            </asp:UpdatePanel>
         </form>
            <p class="m-t"> <small>Ghana Dock Labour Company. &copy; <%=DateTime.Now.Year.ToString() %> </small> </p>
        </div>
    </div>

    <!-- Mainly scripts -->
    <script src="/Content/js/jquery-2.1.1.js"></script>
    <script src="/Content/js/bootstrap.min.js"></script>
    <script src="/Content/js/plugins/toastr/toastr.min.js"></script>
    <script>
        $(document).ready(function () {
            setTimeout(function () {
                toastr.options = {
                    closeButton: true,
                    progressBar: true,
                    showMethod: 'slideDown',
                    timeOut: 10000
                };
                //toastr.info('Please note that LAMS has been updated recently. Kindly report any error encounterd to the System Adminstrator for prompt resolution', 'LAMS');
            }, 1300);
        });
    </script>
</body>
</html>
