<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print-shipping-note.aspx.cs" Inherits="IM_PJ.print_shipping_note" %>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <title>ann</title>
<script src="/App_Themes/Ann/js/jquery-2.1.3.min.js"></script>
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
    <script type="text/javascript">
        window.onload = function () {
            if ($(".print-enable").hasClass("true")) {
                window.print();
                setTimeout(function () { window.close(); }, 1);
            }
        }
    </script> 
</body>
</html>
