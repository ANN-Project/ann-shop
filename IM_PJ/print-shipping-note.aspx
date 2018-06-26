<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print-shipping-note.aspx.cs" Inherits="IM_PJ.print_shipping_note" %>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <title>ann</title>
    <script src="/App_Themes/Ann/js/jquery-2.1.3.min.js"></script>
    <link href="/App_Themes/NewUI/js/sweet/sweet-alert.css" rel="stylesheet" type="text/css" />
  <style>
    
    body {
        font-size: 17px;
        font-family: sans-serif;
        margin-left: 0;
        margin-top: 0;
    }
    p {
        line-height: 1.5;
        margin-top: 5px;
        margin-bottom: 5px;
    }
    .table {
        display: block;
        width: 190mm;
        height: 79mm;
        position: relative;
        border-right: dashed 2px #000;
        border-left: dashed 2px #000;
    }
    .top-left {
        position: absolute;
        top: 0;
        left: 3mm;
        width: 105mm;
    }
    .top-right {
        position: absolute;
        top: 0;
        right: 3mm;
        width: 100mm;
        text-align: right;
    }
    .bottom-left {
        position: absolute;
        bottom: 0;
        left: 3mm;
        width: 70mm;
    }
    .bottom-right {
        position: absolute;
        bottom: 0;
        right: 3mm;
        width: 120mm;
    }
    .cod {
        font-size: 19px;
        font-weight: bold;
    }
    .address {
        text-transform: capitalize;
    }
    .web {
        text-decoration: underline;
    }
    .delivery {
        margin-top: 0;
        text-transform: uppercase;
    }
    .name {
        font-size: 24px;
        text-transform: uppercase;
        font-weight: bold;
    }
    .phone {
        font-size: 22px;
        font-weight: bold;
    }
    .img {
        margin-top: 5px;
        margin-bottom: 10px;
        width: 45%;
    }
    .btn {
        display: inline-block;
        appearance: none;
        -webkit-appearance: none;
        -moz-appearance: none;
        -ms-appearance: none;
        -o-appearance: none;
        border: none;
        color: #fff;
        line-height: 20px;
        background-color: #f87703;
        -webkit-transition: all 0.3s ease-in-out;
        -moz-transition: all 0.3s ease-in-out;
        -o-transition: all 0.3s ease-in-out;
        -ms-transition: all 0.3s ease-in-out;
        transition: all 0.3s ease-in-out;
        padding: 10px 15px;
        border-radius: 2px;
        text-align: center;
        text-decoration: none;
        margin-right: 30px;
        float: left;
    }
    @media print { 
        body {
            -ms-transform:rotate(-90deg);
            -o-transform:rotate(-90deg);
            transform:rotate(-90deg);
            margin-top: 127mm;
            margin-left: 0;
        }
    }
  </style>
</head>

<body class="receipt">
    <asp:Literal ID="ltrShippingNote" runat="server"></asp:Literal>
    <asp:Literal ID="ltrPrintEnable"  runat="server"></asp:Literal>
    <script src="/App_Themes/NewUI/js/sweet/sweet-alert.js" type="text/javascript"></script>
    <script type="text/javascript">
        function printIt() {
            swal({
                title: "Coi lại lần cuối nờ",
                text: "Phiếu gửi hàng đúng thông tin hết chưa?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Đúng rồi sếp! In ếp ơi..",
                cancelButtonText: "Để em coi lại lần nữa..",
                closeOnConfirm: true,
                html: false
            }, function () {
                removeDiv();
            });
        }
        function removeDiv() {
            $(".print-it").hide();
            $(".sweet-alert").hide().empty();
            $(".sweet-overlay").hide().empty();
            window.print();
            window.close();
        }
    </script> 
</body>
</html>
