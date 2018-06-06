<%@ Page Title="Tạo mã vạch" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="tao-ma-vach.aspx.cs" Inherits="IM_PJ.tao_ma_vach" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="parent" runat="server">
        <main id="main-wrap">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title left">In mã vạch</h3>
                        <div class="right above-list-btn">
                            <asp:Literal ID="ltrBack" runat="server"></asp:Literal>
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
                                    <a href="javascript:;" class="link-btn" onclick="Show_popup_search()"><i class="fa fa-search"></i></a>
                                </div>
                            </div>
                            <div class="post-body search-product-content clear fix">
                                <table class="table table-checkable table-product custom-font-size-12">
                                    <thead>
                                        <tr>
                                            <th>Ảnh</th>
                                            <th>Sản phẩm</th>
                                            <th>Mã</th>
                                            <th>Thuộc tính</th>
                                            <th>Giá sỉ</th>
                                            <th>Kho</th>
                                            <th>Số lượng in</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody class="content-product">
                                    </tbody>
                                </table>
                            </div>
                            <div class="post-table-links clear">
                                <a href="javascript:;" class="btn link-btn" style="background-color: #f87703; float: right" onclick="payall()">In</a>
                                <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" Style="display: none" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <asp:HiddenField ID="hdfCheckCustomer" runat="server" Value="0" />
            <asp:HiddenField ID="hdfOrderType" runat="server" />
            <asp:HiddenField ID="hdfTotalPrice" runat="server" />
            <asp:HiddenField ID="hdfTotalPriceNotDiscount" runat="server" />
            <asp:HiddenField ID="hdfListProduct" runat="server" />
            <asp:HiddenField ID="hdfIsDiscount" runat="server" />
            <asp:HiddenField ID="hdfDiscountAmount" runat="server" />
            <asp:HiddenField ID="hdfTotalPriceNotDiscountNotFee" runat="server" />
            <asp:HiddenField ID="hdfListSearch" runat="server" />
            <asp:HiddenField ID="hdfTotalQuantity" runat="server" />
            <asp:HiddenField ID="hdfcheck" runat="server" />
            <div id="printcontent" style="display: none">
                <asp:Literal ID="ltrprint" runat="server"></asp:Literal>
            </div>
        </main>
    </asp:Panel>
    <style>
        .search-product-content {
            height: 500px;
            background: #fff;
            overflow-y: scroll;
            padding: 5px;
        }

        #popup_content2 {
            min-height: 10px;
            position: fixed;
            background-color: #fff;
            top: 15%;
            z-index: 9999;
            left: 0;
            /* margin-left: -340px; */
            /*border-radius: 10px; */
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            width: 45%;
            padding: 20px 40px;
            right: 0%;
            margin: 0 auto;
        }
    </style>
  
        <script type="text/javascript">
            // end

            function printPhieuchi() {
              
                printDiv('printcontent');
            }
            function printDiv(divid) {
                var divToPrint = document.getElementById('' + divid + '');
                var newWin = window.open('', 'Print-Window');
                newWin.document.open();
                newWin.document.write('<html><head><link rel="stylesheet" href="/App_Themes/Ann/css/Barcode.css" type="text/css"/><link rel="stylesheet" href="/App_Themes/Ann/barcode/style.css" type="text/css"/><link rel="stylesheet" href="/App_Themes/Ann/css/responsive.css" type="text/css"/></head><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
                newWin.document.close();
                setTimeout(function () { newWin.close(); }, 10);
            }


            function check_all() {
                if ($('#check-all').is(":checked")) {
                    $(".check-popup").prop('checked', true);
                }
                else {
                    $(".check-popup").prop('checked', false);
                }

            }
            function check(obj) {
                var temp = 0;
                var temp2 = 0;
                $(".search-popup").each(function () {
                    if ($(this).find(".check-popup").is(':checked')) {
                        temp++;
                    }
                    else {
                        temp2++;
                    }
                    if (temp2 > 0) {
                        obj.parent().parent().parent().find("#check-all").prop('checked', false);
                    }
                    else {
                        obj.parent().parent().parent().find("#check-all").prop('checked', true);
                        //$("#check-all").prop('checked', true);
                    }
                });
            }



            $('#txtSearch').keydown(function (event) {
                if (event.which === 13) {
                    //searchProduct();
                    Show_popup_search();
                    event.preventDefault();
                    return false;
                }
            });



            //N.A
            function GetProduct(list, list2) {
                var textsearch = $("#<%=hdfListSearch.ClientID%>").val();
                var customerType = $(".customer-type").val();
                $.ajax({
                    type: "POST",
                    url: "/tao-ma-vach.aspx/getProduct",
                    data: "{textsearch:'" + textsearch + "', gettotal: 1 }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var data = JSON.parse(msg.d);
                        if (data.length > 0) {
                            var html = "";
                            for (var j = 0; j < list.length - 1; j++) {
                                var key = list[j];
                                for (var i = 0; i < data.length; i++) {
                                    var item = data[i];
                                    var sku = item.SKU;
                                    var check = false;
                                    if (key == sku) {
                                        $(".product-result").each(function () {
                                            var existedSKU = $(this).attr("data-sku");
                                            if (sku == existedSKU) {
                                                check = true;
                                            }
                                        });
                                        if (check == false) {
                                            html += "<tr class=\"product-result\" data-giabansi=\"" + item.Giabansi + "\" data-giabanle=\"" + item.Giabanle + "\" " +
                                                "data-quantityinstock=\"" + item.QuantityInstock + "\" data-productimageorigin=\"" + item.ProductImageOrigin + "\" " +
                                                "data-productvariable=\"" + item.ProductVariable + "\" data-productname=\"" + item.ProductName + "\" " +
                                                "data-sku=\"" + item.SKU + "\" data-producttype=\"" + item.ProductType + "\" data-id=\"" + item.ID + "\" " +
                                                "data-productnariablename=\"" + item.ProductVariableName + "\" " +
                                                "data-productvariablevalue =\"" + item.ProductVariableValue + "\" " +
                                                "data-productvariablesave =\"" + item.ProductVariableSave + "\">";
                                            html += "   <td>" + item.ProductImage + "";
                                            html += "   <td>" + item.ProductName + "</td>";
                                            html += "   <td>" + item.SKU + "</td>";
                                            html += "   <td>" + item.ProductVariable + "</td>";
                                            html += "   <td class=\"gia-san-pham\" data-price=\"" + item.Giabansi + "\">" + item.stringGiabansi + "</td>";
                                            html += "   <td>" + item.QuantityInstockString + "</td>";

                                            html += "   <td><input type=\"text\" class=\"form-control in-quanlity\" value=\"" + list2[j] + "\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";

                                            html += "   <td><a href=\"javascript:;\" class=\"link-btn\" onclick=\"deleteRow($(this))\"><i class=\"fa fa-trash\"></i></a></td>";
                                            html += "</tr>";
                                        }
                                        else if (check == true) {
                                            $(".product-result").each(function () {
                                                var existedSKU = $(this).attr("data-sku");
                                                if (sku == existedSKU) {
                                                    var quantityinstock = parseFloat($(this).attr("data-quantityinstock"));
                                                    var quantityCurrent = parseFloat($(this).find(".in-quanlity").val());
                                                    var newquantity = quantityCurrent + parseInt(list2[j]);
                                                    if (newquantity <= quantityinstock) {
                                                        $(this).find(".in-quanlity").val(newquantity);

                                                    }
                                                }
                                            });
                                        }
                                    }
                                }
                            }
                            $(".content-product").append(html);
                            $("#txtSearch").val("");
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
            function Show_popup_search() {
                var textsearch = $("#txtSearch").val();
                $("#<%=hdfListSearch.ClientID%>").val(textsearch);
                var customerType = $(".customer-type").val();
                if (!isBlank(textsearch)) {
                    $.ajax({
                        type: "POST",
                        url: "/tao-ma-vach.aspx/getProduct",
                        data: "{textsearch:'" + textsearch + "', gettotal: 0 }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {

                            var data = JSON.parse(msg.d);
                            if (data.length > 1) {
                                var html = "";
                                var listGet = "";
                                html += ("<table class=\"table table-checkable table-product\">");
                                html += ("<tr>");
                                html += ("<td>");
                                html += ("<input type=\"checkbox\" id=\"check-all\"onchange=\"check_all()\"/>");
                                html += ("</td>");
                                html += ("<td>Ảnh</td>");
                                html += ("<td>Sản phẩm</td>");
                                html += ("<td>Mã</td>");
                                html += ("<td>Thuộc tính</td>");
                                html += ("<td>Số lượng</td>");
                                html += ("</tr>");
                                for (var i = 0; i < data.length; i++) {
                                    var item = data[i];
                                    html += ("<tr class=\"search-popup\" id=\"search-key\";>");
                                    html += ("<td>");
                                    html += ("<input id=\"" + item.ID + "\" type=\"checkbox\" class=\"check-popup\" />");
                                    html += ("</td>");
                                    html += ("<td>" + item.ProductImage + "</td>");
                                    html += ("<td>" + item.ProductName + "</td>");
                                    html += ("<td class=\"key\">" + item.SKU + "</td>");
                                    html += ("<td>" + item.ProductVariable + "</td>");
                                    html += ("<td><input class=\"quantity\" type=\"text\" value=\"1\"></td>");
                                    html += ("</tr>");
                                }
                                html += ("</table>");
                                html += ("<div>");
                                html += ("<a href=\"javascript:;\" class=\"btn link-btn\" onclick=\"Submitproduct()\">Chọn</a>");
                                html += ("</div >");
                                $("#txtSearch").val("");
                                search_detail(html);
                            }
                            else if (data.length == 1) {

                                var item = data[0];
                                var sku = item.SKU;
                                var check = false;
                                $(".product-result").each(function () {
                                    var existedSKU = $(this).attr("data-sku");
                                    if (sku == existedSKU) {
                                        check = true;
                                    }
                                });
                                if (check == false) {
                                    html += "<tr class=\"product-result\" data-giabansi=\"" + item.Giabansi + "\" data-giabanle=\"" + item.Giabanle + "\" " +
                                        "data-quantityinstock=\"" + item.QuantityInstock + "\" data-productimageorigin=\"" + item.ProductImageOrigin + "\" " +
                                        "data-productvariable=\"" + item.ProductVariable + "\" data-productname=\"" + item.ProductName + "\" " +
                                        "data-sku=\"" + item.SKU + "\" data-producttype=\"" + item.ProductType + "\" data-id=\"" + item.ID + "\" " +
                                        "data-productnariablename=\"" + item.ProductVariableName + "\" " +
                                        "data-productvariablevalue =\"" + item.ProductVariableValue + "\" " +
                                        "data-productvariablesave =\"" + item.ProductVariableSave + "\">";
                                    html += "   <td>" + item.ProductImage + "";
                                    html += "   <td>" + item.ProductName + "</td>";
                                    html += "   <td>" + item.SKU + "</td>";
                                    html += "   <td>" + item.ProductVariable + "</td>";
                                    html += "   <td class=\"gia-san-pham\" data-price=\"" + item.Giabansi + "\">" + item.stringGiabansi + "</td>";
                                    html += "   <td>" + item.QuantityInstockString + "</td>";
                                    html += "   <td><input type=\"text\" class=\"form-control in-quanlity\" value=\"1\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                                    html += "   <td><a href=\"javascript:;\" class=\"link-btn\" onclick=\"deleteRow($(this))\"><i class=\"fa fa-trash\"></i></a></td>";
                                    html += "</tr>";
                                }
                                else if (check == true) {
                                    $(".product-result").each(function () {
                                        var existedSKU = $(this).attr("data-sku");
                                        if (sku == existedSKU) {
                                            var quantityinstock = parseFloat($(this).attr("data-quantityinstock"));
                                            var quantityCurrent = parseFloat($(this).find(".in-quanlity").val());
                                            var newquantity = quantityCurrent + 1;
                                            if (newquantity <= quantityinstock) {
                                                $(this).find(".in-quanlity").val(newquantity);

                                            }
                                        }
                                    });
                                }

                                $(".content-product").append(html);
                                $("#txtSearch").val("");
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

            function search_detail(content) {
                var obj = $('body');
                //$(obj).css('overflow', 'hidden');
                $(obj).attr('onkeydown', 'keyclose_ms(event)');
                var bg = "<div id='bg_popup1' style='opacity: 0.7;position: fixed;width: 100%;height: 100%;background-color: #333;opacity: 0.7;filter: alpha(opacity=70);left: 0px;top: 0px;z-index: 9999;opacity: 0;filter: alpha(opacity=0);opacity: 0.7;'></div>";
                var fr = "<div id='pupip1' class=\"columns-container1\"><div class=\"container\" id=\"columns\"><div class='row'>" +
                    "  <div class=\"center_column col-xs-12 col-sm-5\" id=\"popup_content\"><a style='cursor:pointer;right:5px;' onclick='close_popup_ms1()' class='close_message'></a>";
                fr += "     <div class=\"changeavatar\">";


                fr += content;

                fr += "     </div>";
                fr += "   </div>";
                fr += "</div></div></div>";
                $(bg).appendTo($(obj)).show().animate({ "opacity": 0.7 }, 800);
                $(fr).appendTo($(obj));
                setTimeout(function () {
                    $('#pupip1').show().animate({ "opacity": 1, "top": 20 + "%" }, 200);
                    $("#bg_popup1").attr("onclick", "close_popup_ms1()");
                }, 1000);
            }

            function close_popup_ms1() {
                $("#pupip1").animate({ "opacity": 0 }, 400);
                $("#bg_popup1").animate({ "opacity": 0 }, 400);
                setTimeout(function () {
                    $("#pupip1").remove();
                    $(".zoomContainer1").remove();
                    $("#bg_popup1").remove();
                    $('body').css('overflow', 'auto').attr('onkeydown', '');
                }, 500);
            }

            function Submitproduct() {
                var list = "";
                var value = "";
                $(".search-popup").each(function () {
                    if ($(this).find(".check-popup").is(':checked')) {
                        var sku = $(this).find("td.key").html();
                        var quantity = $(this).find("input.quantity").val();
                        value += quantity + "*";
                        list += sku + "*";
                    }
                });
                var item = list.split("*");
                var item2 = value.split("*");
                GetProduct(item, item2);
                $("#pupip1").remove();
                $("#bg_popup1").remove();
            }
            //End

            function searchProduct() {
                var textsearch = $("#txtSearch").val();
                if (!isBlank(textsearch)) {
                    $.ajax({
                        type: "POST",
                        url: "/tao-ma-vach.aspx/getProduct",
                        data: "{textsearch:'" + textsearch + "', gettotal: 0 }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            var data = JSON.parse(msg.d);
                            if (data.length > 0) {
                                var html = "";

                                for (var i = 0; i < data.length; i++) {
                                    var item = data[i];
                                    var sku = item.SKU;
                                    var check = false;
                                    $(".product-result").each(function () {
                                        var existedSKU = $(this).attr("data-sku");
                                        if (sku == existedSKU) {
                                            check = true;
                                        }
                                    });
                                    if (check == false) {
                                        html += "<tr class=\"product-result\" data-giabansi=\"" + item.Giabansi + "\" data-giabanle=\"" + item.Giabanle + "\" " +
                                            "data-quantityinstock=\"" + item.QuantityInstock + "\" data-productimageorigin=\"" + item.ProductImageOrigin + "\" " +
                                            "data-productvariable=\"" + item.ProductVariable + "\" data-productname=\"" + item.ProductName + "\" " +
                                            "data-sku=\"" + item.SKU + "\" data-producttype=\"" + item.ProductType + "\" data-id=\"" + item.ID + "\" " +
                                            "data-productnariablename=\"" + item.ProductVariableName + "\" " +
                                            "data-productvariablevalue =\"" + item.ProductVariableValue + "\" " +
                                            "data-productvariablesave =\"" + item.ProductVariableSave + "\">";
                                        html += "   <td>" + item.ProductImage + "";
                                        html += "   <td>" + item.ProductName + "</td>";
                                        html += "   <td>" + item.SKU + "</td>";
                                        html += "   <td>" + item.ProductVariable + "</td>";
                                        html += "   <td class=\"gia-san-pham\" data-price=\"" + item.Giabansi + "\">" + item.stringGiabansi + "</td>";
                                        html += "   <td>" + item.QuantityInstockString + "</td>";
                                        html += "   <td><input type=\"text\" class=\"form-control in-quanlity\" value=\"1\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                                        html += "   <td><a href=\"javascript:;\" class=\"link-btn\" onclick=\"deleteRow($(this))\"><i class=\"fa fa-trash\"></i></a></td>";
                                        html += "</tr>";
                                    }
                                    else if (check == true) {
                                        $(".product-result").each(function () {
                                            var existedSKU = $(this).attr("data-sku");
                                            if (sku == existedSKU) {
                                                var quantityinstock = parseFloat($(this).attr("data-quantityinstock"));
                                                var quantityCurrent = parseFloat($(this).find(".in-quanlity").val());
                                                var newquantity = quantityCurrent + 1;
                                                if (newquantity <= quantityinstock) {
                                                    $(this).find(".in-quanlity").val(newquantity);
                                                }
                                            }
                                        });
                                    }
                                }
                                $(".content-product").append(html);
                                $("#txtSearch").val("");
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

            function payall() {

                if ($(".product-result").length > 0) {
                    var list = "";

                    var ordertype = $(".customer-type").val();
                    $(".product-result").each(function () {
                        var id = $(this).attr("data-id");
                        var sku = $(this).attr("data-sku");
                        var quantity = $(this).find(".in-quanlity").val();
                        if (quantity > 0) {
                            list += id + "," + sku + "," + quantity + ";";
                        }
                    });
                    $("#<%=hdfOrderType.ClientID %>").val(ordertype);
                    $("#<%=hdfListProduct.ClientID%>").val(list);
                    $("#<%=btnOrder.ClientID%>").click();
                }
                else {
                    alert("Hãy nhập sản phẩm để in mã vạch");
                }
            }

            function deleteRow(obj) {
                var c = confirm('Bạn muốn xóa sản phẩm này?');
                if (c) {
                    obj.parent().parent().remove();
                    if ($(".product-result").length == 0) {
                        $(".excute-in").hide();
                    }
                }
            }

            function inProduct() {
                if ($(".product-result").length > 0) {
                    var note = $("#txtnote").val();
                    var list = "";
                    var count = 0;
                    $(".product-result").each(function () {
                        var id = $(this).attr("data-id");
                        var sku = $(this).attr("data-sku");
                        var producttype = $(this).attr("data-producttype");
                        var productnariablename = $(this).attr("data-productnariablename");
                        var productvariablevalue = $(this).attr("data-productvariablevalue");
                        var quantity = $(this).find(".in-quanlity").val();
                        var productname = $(this).attr("data-productname");
                        var productimageorigin = $(this).attr("data-productimageorigin");
                        var productvariable = $(this).attr("data-productvariable");
                        var productvariablesave = $(this).attr("data-productvariablesave");
                        if (quantity > 0) {
                            list += id + "," + sku + "," + producttype + "," + productnariablename + "," + productvariablevalue + "," + quantity + "," + productname + "," + productimageorigin + "," + productvariablesave + "," + productvariablesave + ";";
                            count++;
                        }
                    });
                    if (count > 0) {

                    }
                    else {
                        alert('Vui lòng nhập số lượng để xuất kho');
                    }
                }
                else {
                    alert("Vui lòng nhập sản phẩm");
                }
            }

            function show_detail(content, discountinfo) {
                var obj = $('body');
                //$(obj).css('overflow', 'hidden');
                $(obj).attr('onkeydown', 'keyclose_ms(event)');
                var bg = "<div id='bg_popup'></div>";
                var fr = "<div id='pupip' class=\"columns-container1\"><div class=\"container\" id=\"columns\"><div class='row'>" +
                    "  <div class=\"center_column col-xs-12 col-sm-5\" id=\"popup_content\"><a style='cursor:pointer;right:5px;' onclick='close_popup_ms()' class='close_message'></a>";
                fr += "     <div class=\"changeavatar\">";

                fr += "         <label class=\"lbl-popup\" style=\"font-size:18px;\">Thông tin khách hàng</label>";
                fr += content;
                fr += "         <label class=\"lbl-popup\" style=\"font-size:18px;margin:10px 0 5px 0\">Các chiết khấu của khách</label>";
                fr += discountinfo;
                fr += "     </div>";
                fr += "   </div>";
                fr += "</div></div></div>";
                $(bg).appendTo($(obj)).show().animate({ "opacity": 0.7 }, 800);
                $(fr).appendTo($(obj));
                setTimeout(function () {
                    $('#pupip').show().animate({ "opacity": 1, "top": 20 + "%" }, 200);
                    $("#bg_popup").attr("onclick", "close_popup_ms()");
                }, 1000);
            }
            function show_messageorder(content) {
                var obj = $('body');
                //$(obj).css('overflow', 'hidden');
                $(obj).attr('onkeydown', 'keyclose_ms(event)');
                var bg = "<div id='bg_popup'></div>";
                var fr = "<div id='pupip' class=\"columns-container1\"><div class=\"container\" id=\"columns\"><div class='row'>" +
                    "  <div class=\"center_column col-xs-12 col-sm-5\" id=\"popup_content\"><a style='cursor:pointer;right:5px;' onclick='close_popup_ms()' class='close_message'></a>";
                fr += "     <div class=\"changeavatar\">";
                fr += content;
                fr += "         <label class=\"lbl-popup\">Nội dung nhập hàng</label>";
                fr += "         <textarea id=\"txtnote\" class=\"form-control\"/>";
                fr += "         <div class=\"clearfix\"></div>";
                fr += "         <div class=\"clearfix\"></div>";
                fr += "         <div class=\"btn-content\">";
                fr += "             <a class=\"btn primary-btn fw-btn not-fullwidth\" style=\"padding:10px 30px;float:right;margin:10px 0\" href=\"javascript:;\" onclick=\"inProduct()\" >Xác nhận</a>";
                fr += "         </div>";
                fr += "     </div>";
                fr += "   </div>";
                fr += "</div></div></div>";
                $(bg).appendTo($(obj)).show().animate({ "opacity": 0.7 }, 800);
                $(fr).appendTo($(obj));
                setTimeout(function () {
                    $('#pupip').show().animate({ "opacity": 1, "top": 20 + "%" }, 200);
                    $("#bg_popup").attr("onclick", "close_popup_ms()");
                }, 1000);
            }
            function keyclose_ms(e) {
                if (e.keyCode == 27) {
                    close_popup_ms();
                }
            }
            function close_popup_ms() {
                $("#pupip").animate({ "opacity": 0 }, 400);
                $("#bg_popup").animate({ "opacity": 0 }, 400);
                setTimeout(function () {
                    $("#pupip").remove();
                    $(".zoomContainer").remove();
                    $("#bg_popup").remove();
                    $('body').css('overflow', 'auto').attr('onkeydown', '');
                }, 500);
            }
            function checkQuantiy(obj) {
                var instock = parseFloat(obj.parent().parent().attr("data-quantityinstock"));
                var currentVal = parseFloat(obj.val());
                var check = true;
                if (currentVal == 0) {
                    obj.val("1");
                }
                else if (currentVal > instock) {
                    obj.val("");
                    obj.val(instock);
                }

            }

            function keypress(e) {
                var keypressed = null;
                if (window.event) {
                    keypressed = window.event.keyCode; //IE
                }
                else {
                    keypressed = e.which; //NON-IE, Standard
                }
                if (keypressed < 48 || keypressed > 57) {
                    if (keypressed == 8 || keypressed == 127) {
                        return;
                    }
                    return false;
                }
            }
            var formatThousands = function (n, dp) {
                var s = '' + (Math.floor(n)), d = n % 1, i = s.length, r = '';
                while ((i -= 3) > 0) { r = ',' + s.substr(i, 3) + r; }
                return s.substr(0, i + 3) + r +
                    (d ? '.' + Math.round(d * Math.pow(10, dp || 2)) : '');
            };
        </script>
   </asp:Content>
