<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="quen-mat-khau.aspx.cs" Inherits="IM_PJ.quen_mat_khau" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=yes">
    <meta name="format-detection" content="telephone=no">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta property="og:title" content="">
    <meta property="og:type" content="website">
    <meta property="og:url" content="">
    <meta property="og:image" content="">
    <meta property="og:site_name" content="">
    <meta property="og:description" content="">

    <title>Quên mật khẩu</title>


    <link rel="stylesheet" href="/App_Themes/Ann/css/style.css" media="all">
    <script src="/App_Themes/Ann/js/jquery-1.9.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="side-full-bg" style="background-image: url(/App_Themes/Ann/image/bg-register.jpg)"></div>
        <div class="side-full-cont register-cont" id="">
            <div class="logo">
                <a href="javascript:;">
                    <img src="/App_Themes/Ann/image/logo.png" alt="" /></a>
            </div>
            <p class="small-tt">Quên mật khẩu?</p>
            <p class="slogan">Nhập lại email của bạn để lấy lại mật khẩu!</p>
            <div class="form form-register">
                <div class="form-row">
                    <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                </div>
                <div class="form-row">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email của bạn"></asp:TextBox>

                </div>
                <div class="form-row clear">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Vui lòng điền email"
                        ForeColor="Red" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtEmail" ForeColor="Red"
                        ErrorMessage="Sai định dạng Email" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                        ValidationGroup="a" Display="Dynamic" />
                </div>
                <div class="form-row">
                    <asp:Button ID="btnLogin" runat="server" ValidationGroup="a" CssClass="btn tim-btn fw-btn" Text="Lấy lại mật khẩu" OnClick="btnLogin_Click" />
                </div>
            </div>
            <%--<div class="form-row grey-text3">
                <p>5 Sign in</p>
                <p>5 Sign up</p>
                <p>5 Didn't receive confirmation instructions?</p>
            </div>--%>

        </div>

        <a href="javascript:;" class="scroll-top-link" id="scroll-top"><i class="fa fa-angle-up"></i></a>
        <script src="/App_Themes/Ann/js/bootstrap.min.js"></script>
        <script src="/App_Themes/Ann/js/bootstrap-table/bootstrap-table.js"></script>
        <script src="/App_Themes/Ann/js/chartjs.min.js"></script>
        <script src="/App_Themes/Ann/js/master.js"></script>
    </form>
</body>
</html>
