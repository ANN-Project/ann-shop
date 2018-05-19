<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dang-nhap.aspx.cs" Inherits="IM_PJ.dang_nhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=yes" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="robots" content="noindex, nofollow" />
    <title>Đăng nhập hệ thống</title>
    <link rel="stylesheet" href="/App_Themes/Ann/css/style.css" media="all" />
    <link rel="stylesheet" href="/App_Themes/Ann/css/style-P.css" media="all" />
    <script src="/App_Themes/Ann/js/jquery-1.9.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="side-full-cont">
            <div class="logo">
                <a href="javascrip:;">
                    <img src="/App_Themes/Ann/image/logo.png" alt="THỜI TRANG GIÁ SỈ ANN" /></a>
            </div>
            <div class="form form-login">
                <div class="form-row">
                    <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                </div>
                <div class="form-row">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Tên đăng nhập"></asp:TextBox>
                </div>
                <div class="form-row">
                    <asp:RequiredFieldValidator ID="req" runat="server" ControlToValidate="txtUsername" ErrorMessage="Không để trống"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-row">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Không để trống"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-row">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn primary-btn fw-btn" Text="Đăng nhập" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>

        <a href="javascript:;" class="scroll-top-link" id="scroll-top"><i class="fa fa-angle-up"></i></a>
        <script src="/App_Themes/Ann/js/bootstrap.min.js"></script>
        <script src="/App_Themes/Ann/js/bootstrap-table/bootstrap-table.js"></script>
        <script src="/App_Themes/Ann/js/chartjs.min.js"></script>
        <script src="/App_Themes/Ann/js/master.js"></script>
    </form>
</body>
</html>
