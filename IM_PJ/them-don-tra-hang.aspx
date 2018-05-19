<%@ Page Title="Thêm đơn trả hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="them-don-tra-hang.aspx.cs" Inherits="IM_PJ.them_don_tra_hang" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="parent" runat="server">
        <main id="main-wrap">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title left">Đổi trả hàng</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panelborderheading">
                            <div class="panel-heading clear">
                                <h3 class="page-title left not-margin-bot">Thông tin khách hàng</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-row">
                                    Số điện thoại
                                     <a href="javascript:;" style="text-decoration: underline; float: right; font-size: 12px; font-style: italic;" onclick="checkCustomer()">Kiểm tra</a>
                                </div>
                                <div class="form-row">
                                    <asp:TextBox ID="fullnamephone" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-row">
                                    Họ tên
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullname" ErrorMessage="(*)"
                                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-row">
                                    <asp:TextBox ID="txtFullname" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-row">
                                    Địa chỉ
                                </div>
                                <div class="form-row">
                                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-row">
                                    Zalo                                   
                                </div>
                                <div class="form-row">
                                    <asp:TextBox ID="txtZalo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-row">
                                    Facebook                                   
                                </div>
                                <div class="form-row">
                                    <asp:TextBox ID="txtFacebook" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-row result-check">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel-post">
                            <div class="post-above clear">
                                <div class="search-box left" style="width: 96%;">
                                    <input type="text" id="txtSearch" class="form-control" placeholder="SKU">
                                </div>
                                <div class="right">
                                    <a href="javascript:;" class="link-btn" onclick="searchProduct()"><i class="fa fa-search"></i></a>
                                </div>
                            </div>
                            <div class="post-body search-product-content clear">
                                <table class="table table-checkable table-product custom-font-size-12">
                                    <thead>
                                        <tr>
                                            <th>Mã đơn hàng</th>
                                            <th>Tên sản phẩm</th>
                                            <th>SKU</th>
                                            <th>Giá gốc</th>
                                            <th>Giá đã bán</th>
                                            <th>Tổng số lượng</th>
                                            <th>Sl tối đa</th>
                                            <th>Sl cần đổi</th>
                                            <th>Hình thức</th>
                                            <th>Phí đổi hàng</th>
                                            <th>Thành tiền</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody class="content-product">
                                    </tbody>
                                </table>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Tổng cộng</div>
                                <div class="right totalpriceorder"></div>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Tổng số lượng sản phẩm</div>
                                <div class="right totalproductQuantity"></div>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Phí đổi hàng</div>
                                <div class="right totalrefund"></div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panelborderheading">
                            <div class="panel-heading clear">
                                <h3 class="page-title left not-margin-bot">Thông tin trạng thái đơn</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-row">
                                    <div class="row-left">
                                        Trạng thái
                                    </div>
                                    <div class="row-right">
                                        <asp:DropDownList ID="ddlRefundStatus" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="Chưa trừ tiền"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Đã trừ tiền"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="row-left">
                                        Ghi chú đơn hàng
                                    </div>
                                    <div class="row-right">
                                        <asp:TextBox ID="txtRefundsNote" runat="server" CssClass="form-control" placeholder="Ghi chú"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="post-table-links clear">
                                    <a href="javascript:;" class="btn link-btn" style="background-color: #f87703; float: right; color: #fff;" onclick="payall()">Thanh toán</a>
                                    <a href="javascript:;" class="btn link-btn" style="background-color: #f87703; float: right; margin-right: 10px; color: #fff;" onclick="deleteProduct()">Xóa</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Style="display: none" />
            <asp:HiddenField ID="hdfIsRefund" runat="server" />
            <asp:HiddenField ID="hdfTotalCanchange" runat="server" Value="0" />
            <asp:HiddenField ID="hdfPhone" runat="server" />
            <asp:HiddenField ID="hdfTotalQuantity" runat="server" Value="0" />
            <asp:HiddenField ID="hdfTotalPrice" runat="server" Value="0" />
            <asp:HiddenField ID="hdfTotalRefund" runat="server" Value="0" />
            <asp:HiddenField ID="hdfListProduct" runat="server" />
        </main>
    </asp:Panel>
    <style>
        .search-product-content {
            height: 350px;
            background: #fff;
            overflow-y: scroll;
            padding: 5px;
        }
    </style>
    <telerik:RadAjaxManager ID="rAjax" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnOrder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="parent" LoadingPanelID="rxLoading"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadScriptBlock ID="sc" runat="server">
        <script type="text/javascript">
            $('#txtSearch').keydown(function (event) {
                if (event.which === 13) {
                    searchProduct();
                    event.preventDefault();
                    return false;
                }
            });
            function payall() {
                if ($(".product-result").length > 0) {
                    var totalCanchange = parseFloat($("#<%=hdfTotalCanchange.ClientID%>").val());
                    var totalRequest = 0;
                    var list = "";
                    $(".product-result").each(function () {

                        var quantity = parseFloat($(this).find(".soluongcandoi").val());
                        totalRequest += quantity;
                    });
                    if (totalRequest <= totalCanchange) {
                        $(".product-result").each(function () {
                            var sku = $(this).attr("data-sku");
                            var orderID = $(this).attr("data-orderID");
                            var orderDetailID = $(this).attr("data-orderDetailID");
                            var ProductName = $(this).attr("data-ProductName");
                            var ProductType = $(this).attr("data-ProductType");
                            var Giagoc = $(this).attr("data-Giagoc");
                            var Giadaban = $(this).attr("data-Giadaban");
                            var TienGiam = $(this).attr("data-TienGiam");
                            var Soluongtoida = $(this).attr("data-Soluongtoida");
                            var RefundType = $(this).find(".changeType").val();
                            var quantity = parseFloat($(this).find(".soluongcandoi").val());
                            var RefundFee = $(this).find(".phidoihang").attr("data-RefundFee");
                            var priceRow = $(this).find(".thanhtien").attr("data-thanhtien");
                            if (quantity > 0) {
                                list += sku + ";" + orderID + ";" + orderDetailID + ";" + ProductName + ";" + ProductType + ";" + Giagoc + ";" + Giadaban + ";" +
                                    TienGiam + ";" + Soluongtoida + ";" + RefundType + ";" + quantity + ";" + RefundFee + ";" + priceRow + "|";
                            }
                            $("#<%=hdfListProduct.ClientID%>").val(list);
                            $("#<%=btnSave.ClientID%>").click();
                        });
                    }
                    else {
                        alert('Số lượng cần đổi đã vượt quá số lượng cho phép');
                    }


                }
                else {
                    alert('Vui lòng chọn sản phẩm đổi trả');
                }
            }
            function deleteProduct() {
                var c = confirm("Bạn muốn xóa tất cả sản phẩm?");
                if (c == true) {
                    $(".product-result").remove();
                    getAllPrice();
                    $(".totalpriceorder").html("0");
                    $(".totalproductQuantity").html("0");
                    $(".totalrefund").html("0");
                }
            }
            function getAllPrice() {
                if ($(".product-result").length > 0) {
                    var totalprice = 0;
                    var productquantity = 0;
                    var totalRefund = 0;
                    $(".product-result").each(function () {
                        var giadaban = parseFloat($(this).attr("data-giadaban"));
                        var feeRefund = parseFloat($(this).attr("data-RefundFee"));
                        var changetype = $(this).find(".changeType").val();
                        var quantity = parseFloat($(this).find(".soluongcandoi").val());
                        var refundRow = 0;
                        if (changetype == 2) {
                            refundRow = feeRefund * quantity;
                            $(this).find(".phidoihang").html(formatThousands(feeRefund, ","));
                            $(this).find(".phidoihang").attr("data-RefundFee", feeRefund);
                        }
                        else {
                            $(this).find(".phidoihang").html("0");
                            $(this).find(".phidoihang").attr("data-RefundFee", "0");
                        }
                        var totalRow = giadaban * quantity - refundRow;
                        totalprice += totalRow;
                        productquantity += quantity;
                        totalRefund += refundRow;
                        $(this).find(".thanhtien").attr("data-thanhtien", totalRow);
                        $(this).find(".thanhtien").html(formatThousands(totalRow, ","));

                    });


                    $(".totalpriceorder").html(formatThousands(totalprice, ","));
                    $(".totalproductQuantity").html(formatThousands(productquantity, ","));
                    $(".totalrefund").html(formatThousands(totalRefund, ","));

                    $("#<%=hdfTotalQuantity.ClientID%>").val(productquantity);
                    $("#<%=hdfTotalRefund.ClientID%>").val(totalRefund);
                    $("#<%=hdfTotalPrice.ClientID%>").val(totalprice);
                }
            }
            function searchProduct() {
                var phone = $("#<%=hdfPhone.ClientID%>").val();
                var sl = 0;
                var t = $(".product-result").length;
                var textsearch = $("#txtSearch").val();
                var list = "";
                var checkx = false;
                if (t > 0) {
                    $(".product-result").each(function () {
                        var sku = $(this).attr("data-sku");
                        var orderID = $(this).attr("data-orderID");
                        var orderDetailID = $(this).attr("data-orderDetailID");
                        var ProductName = $(this).attr("data-ProductName");
                        var quantity = parseFloat($(this).find(".soluongcandoi").val());
                        var Soluongtoida = $(this).attr("data-Soluongtoida");
                        if (textsearch.toUpperCase() == sku) {
                            if (quantity < Soluongtoida) {
                                $("#txtSearch").val("");
                                var number = quantity + 1;
                                $(this).find(".soluongcandoi").val(number);
                                checkx = true;
                            }
                            sl++;
                        }


                        if (quantity > 0) {
                            list += sku + ";" + orderID + ";" + orderDetailID + ";" + Soluongtoida + ";" + quantity + "|";
                        }
                    })
                }
                if (isBlank(phone)) {
                    alert('Vui lòng nhập số điện thoại.');
                }
                else {
                    var numcanchange = parseFloat($("#<%=hdfTotalCanchange.ClientID%>").val());
                    if (numcanchange > 0) {
                        if (checkx == false) {
                            if (!isBlank(textsearch)) {
                                $.ajax({
                                    type: "POST",
                                    url: "/them-don-tra-hang.aspx/getProduct",
                                    data: "{textsearch:'" + textsearch + "',phone:'" + phone + "',sl:'" + sl + "',list:'" + list + "'}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (msg) {
                                        var count = 0;
                                        var data = JSON.parse(msg.d);
                                        if (data.length > 0) {
                                            var html = "";

                                            for (var i = 0; i < data.length; i++) {
                                                var item = data[i];
                                                var sku = item.SKU;
                                                var order = item.orderID;
                                                var check = false;
                                                $(".product-result").each(function () {
                                                    var existedSKU = $(this).attr("data-sku");
                                                    var existedorderID = $(this).attr("data-orderID");
                                                    if (sku == existedSKU && order == existedorderID) {
                                                        check = true;
                                                    }
                                                });
                                                if (check == false) {
                                                    html += "<tr class=\"product-result\" data-sku=\"" + item.SKU + "\" data-orderID=\"" + item.orderID
                                                        + "\" data-orderDetailID=\"" + item.orderDetailID + "\" data-ProductName=\"" + item.ProductName
                                                        + "\" data-ProductType=\"" + item.ProductType + "\" data-Giagoc=\"" + item.Giagoc
                                                        + "\" data-stringGiagoc=\"" + item.stringGiagoc + "\" data-Giadaban=\"" + item.Giadaban
                                                        + "\" data-stringGiadaban=\"" + item.stringGiadaban + "\" data-TienGiam=\"" + item.TienGiam
                                                        + "\" data-stringTienGiam=\"" + item.stringTienGiam + "\" data-stringSoluongtoida=\"" + item.stringSoluongtoida
                                                        + "\" data-Soluongtoida=\"" + item.Soluongtoida + "\" data-RefundFee=\"" + item.RefundFee
                                                        + "\" data-stringRefundFee=\"" + item.stringRefundFee + "\"  >";
                                                    html += "   <td>" + item.orderID + "</td>";
                                                    html += "   <td>" + item.ProductName + "</td>";
                                                    html += "   <td>" + item.SKU + "</td>";
                                                    html += "   <td class=\"giagoc\" data-giagoc=\"" + item.Giagoc + "\">" + item.stringGiagoc + "</td>";
                                                    html += "   <td class=\"giadaban\" data-giadaban=\"" + item.Giadaban + "\">" + item.stringGiadaban + " " + item.stringTienGiam + "</td>";
                                                    html += "   <td class=\"slmax\" data-soluongmax=\"" + item.soluongmax + "\">" + item.soluongmax + "</td>";
                                                    html += "   <td class=\"sltoida\" data-soluongtoida=\"" + item.Soluongtoida + "\">" + item.Soluongtoida + "</td>";
                                                    html += "   <td class=\"slcandoi\"><input type=\"text\" min=\"1\" max=\"" + item.Soluongtoida + "\" class=\"form-control soluongcandoi\" style=\"width: 40%;margin: 0 auto;\" value=\"1\"  onkeyup=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                                                    html += "   <td><select class=\"changeType form-control\" onchange=\"getAllPrice()\">"
                                                        + "            <option value=\"1\">Đổi size</option>"
                                                        + "            <option value=\"2\">Đổi sản phẩm khác</option>"
                                                        + "            <option value=\"3\">Đổi hàng lỗi</option>"
                                                        + "        </select>"
                                                        + "    </td>";
                                                    html += "   <td class=\"phidoihang\">0</td>";
                                                    var thanhtien = parseFloat(item.Giadaban) * parseFloat(item.Soluongtoida);
                                                    html += "   <td class=\"thanhtien\" data-thanhtien=\"" + thanhtien + "\">" + formatThousands(thanhtien, ",") + "</td>";
                                                    html += "   <td><a href=\"javascript:;\" class=\"link-btn\" onclick=\"deleteRow($(this))\"><i class=\"fa fa-trash\"></i></a></td>";
                                                    html += "</tr>";
                                                }
                                            }
                                            $(".content-product").append(html);
                                            $("#txtSearch").val("");
                                            if (count > 0) {
                                                $(".excute-in").show();
                                            }
                                            getAllPrice();
                                            if (data.length < sl+1)
                                            {
                                                alert('Số lượng sản phẩm đổi trả đã đạt tối đa!');
                                            }
                                        }
                                        else {
                                            alert('Không tìm thấy sản phẩm');
                                        }
                                    },
                                    error: function (xmlhttprequest, textstatus, errorthrow) {
                                        alert('lỗi');
                                    }
                                });
                            }
                            else {
                                alert('Vui lòng nhập nội dung tìm kiếm');
                            }
                        }
                    }
                    else {
                        alert('Bạn đã hết hạn đổi trả');
                    }
                }
            }
            function checkQuantiy(obj) {
                var instock = parseFloat(obj.parent().parent().attr("data-Soluongtoida"));
                var currentVal = parseFloat(obj.val());
                var check = true;
                if (currentVal == 0) {
                    obj.val("1");
                }
                else if (currentVal > instock) {
                    obj.val("");
                    obj.val(instock);
                }
                getAllPrice();
            }
            function deleteRow(obj) {
                var c = confirm('Bạn muốn xóa sản phẩm này?');
                if (c) {
                    obj.parent().parent().remove();
                    if ($(".product-result").length == 0) {
                        $(".excute-in").hide();

                    }
                    getAllPrice();
                }
            }

            function checkCustomer() {
                var phone = $("#<%=fullnamephone.ClientID%>").val();
                if (isBlank(phone)) {
                    alert('Vui lòng nhập số điện thoại.');
                }
                else {
                    $.ajax({
                        type: "POST",
                        url: "/them-don-tra-hang.aspx/checkphone",
                        data: "{phonefullname:'" + phone + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            if (msg.d != "0") {
                                var data = JSON.parse(msg.d);
                                if (data.CustleftCanchange == "full") {
                                    alert('Bạn đã đổi hết số lượng sản phẩm được phép đổi');
                                }
                                else if (data.CustleftCanchange == "nocustomer") {
                                    alert('Không tìm thấy khách hàng trong hệ thống');
                                }
                                else {
                                    $("#<%= txtFullname.ClientID%>").val(data.CustName).prop('disabled', true);
                                    $("#<%= txtAddress.ClientID%>").val(data.CustAddress).prop('disabled', true);
                                    $("#<%= txtFacebook.ClientID%>").val(data.CustFB).prop('disabled', true);
                                    $("#<%= txtZalo.ClientID%>").val(data.CustZalo).prop('disabled', true);
                                    $("#<%= fullnamephone.ClientID%>").val(data.CustPhone);
                                    $(".result-check").html("<span class=\"numcanchange\">Số lượng sản phẩm được phép đổi tối đa: " + data.CustleftCanchange + " sản phẩm</span>");
                                    $("#<%=hdfTotalCanchange.ClientID%>").val(data.CustleftCanchange);
                                    $("#<%=hdfPhone.ClientID%>").val(phone);
                                }
                            }
                        },
                        error: function (xmlhttprequest, textstatus, errorthrow) {
                            alert('lỗi');
                        }
                    });
                }
            }
            var formatThousands = function (n, dp) {
                var s = '' + (Math.floor(n)), d = n % 1, i = s.length, r = '';
                while ((i -= 3) > 0) { r = ',' + s.substr(i, 3) + r; }
                return s.substr(0, i + 3) + r +
                    (d ? '.' + Math.round(d * Math.pow(10, dp || 2)) : '');
            };
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
