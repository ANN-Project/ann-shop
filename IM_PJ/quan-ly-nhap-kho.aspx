<%@ Page Title="Nhập kho" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="quan-ly-nhap-kho.aspx.cs" Inherits="IM_PJ.quan_ly_nhap_kho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .select2-container--default .select2-selection--single .select2-selection__rendered {
            line-height: 40px;
            height: 40px;
        }

        .select2-container .select2-selection--single {
            appearance: none;
            -webkit-appearance: none;
            -moz-appearance: none;
            -ms-appearance: none;
            -o-appearance: none;
            height: 40px;
            float: left;
            border: solid 1px #eee;
            width: 100%;
            background: url(/App_Themes/Ann/image/icon-select.png) no-repeat right 15px center;
        }

        .select2-container--default .select2-selection--single .select2-selection__arrow b {
            border-style: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panelborderheading">
                        <div class="panel-heading clear">
                            <h3 class="page-title left not-margin-bot">Nhập sản phẩm</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-row">
                                <input type="text" id="txtSearch" class="form-control" placeholder="Nhập tên sản phẩm hoặc mã SKU"
                                    style="width: 40%; float: left; margin-right: 10px" />
                                <select id="typeinout" class="form-control" style="width: 20%; float: left; margin-right: 10px">
                                    <option value="2">Mã SKU</option>
                                    <option value="1">Tên sản phẩm</option>
                                </select>
                                <asp:Literal ID="ltrSupplier" runat="server"></asp:Literal>
                                <a href="javascript:;" class="btn primary-btn fw-btn not-fullwidth" style="margin-right: 10px"
                                    onclick="searchProduct()">Tìm sản phẩm</a>

                            </div>
                            <div class="form-row">
                            </div>
                            <div class="form-row">
                                <h3 class="no-margin float-left">Kết quả tìm kiếm: <span class="result-numsearch"></span></h3>
                                <div class="float-right excute-in"><a href="javascript:;" class="btn primary-btn fw-btn not-fullwidth" onclick="show_messageorder('')">Nhập hàng</a></div>
                            </div>
                            <div class="form-row" style="border: solid 1px #ccc; padding: 10px;">
                                <table class="table table-checkable table-product">
                                    <thead>
                                        <tr>
                                            <th>
                                                <input type="checkbox" id="check-all" onchange="check_all()" /></th>
                                            <th>Ảnh</th>
                                            <th>Tên sản phẩm</th>
                                            <th>SKU</th>
                                            <th>Nhà cung cấp</th>
                                            <th>Thuộc tính</th>
                                            <th>Kho</th>
                                            <th>Số lượng</th>
                                            <th>Thao tác</th>
                                        </tr>
                                    </thead>
                                    <tbody class="content-product">
                                        <%--<tr class="product-result" data-sku="CS001" data-type="1" data-productid="2">
                                            <td>
                                                <img src="/App_Themes/Ann/image/sp_demo.png" alt="" style="width: 50px" /></td>
                                            <td>Áo thun nam cá sấu Adidas</td>
                                            <td>CS001</td>
                                            <td>Color:Xanh rêu|Size:XXXL</td>
                                            <td>
                                                <input type="number" min="0" class="in-quanlity" value="0" /></td>
                                        </tr>
                                        <tr class="product-result" data-sku="CS001" data-type="1" data-productid="2">
                                            <td>
                                                <img src="/App_Themes/Ann/image/sp_demo.png" alt="" style="width: 50px" /></td>
                                            <td>Áo thun nam cá sấu Adidas</td>
                                            <td>CS001</td>
                                            <td>Color:Xanh rêu|Size:XXXL</td>
                                            <td>
                                                <input type="number" min="0" class="in-quanlity" value="0" /></td>
                                        </tr>
                                        <tr class="product-result" data-sku="CS001" data-type="1" data-productid="2">
                                            <td>
                                                <img src="/App_Themes/Ann/image/sp_demo.png" alt="" style="width: 50px" /></td>
                                            <td>Áo thun nam cá sấu Adidas</td>
                                            <td>CS001</td>
                                            <td>Color:Xanh rêu|Size:XXXL</td>
                                            <td>
                                                <input type="number" min="0" class="in-quanlity" value="0" /></td>
                                        </tr>--%>
                                    </tbody>
                                </table>
                            </div>
                            <div class="form-row excute-in">
                                <div class="float-right"><a href="javascript:;" class="btn primary-btn fw-btn not-fullwidth" onclick="show_messageorder('')">Nhập hàng</a></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdfvalue" runat="server" />
        <asp:HiddenField ID="hdfNote" runat="server" />
        <asp:HiddenField ID="hdfBarcode" runat="server" />
        <asp:Button ID="btnImport" runat="server" OnClick="btnImport_Click" Style="display: none" />
        <div id="printcontent" style="display: none">
            <asp:Literal ID="ltrprint" runat="server"></asp:Literal>
        </div>
    </main>
    <script type="text/javascript">
        $(document).ready(function () {

            $('input.in-quanlity').keyup(function (e) {
                if (e.which == 40) { // down 
                    $(this).closest('tr').next().find('td:eq(' + $(this).closest('td').index() + ')').find('input.in-quanlity').focus();

                } else if (e.which == 38) { // up
                    $(this).closest('tr').prev().find('td:eq(' + $(this).closest('td').index() + ')').find('input.in-quanlity').focus();
                }
            });
        });
    </script>

    <script type="text/javascript">
        $('#txtSearch').keydown(function (event) {
            if (event.which === 13) {
                searchProduct();
                event.preventDefault();
                return false;
            }
        });

        function printPhieuchi() {
            //var html = "";
            //html += "<div class=\"print\">";
            //html += "     <div class=\"logo\"><img src=\"App_Themes/Ann/image/logo.png\" alt=\"\" /></div>";
            //html += "     <div class=\"bill-row text-align-center\">K4C Bửu Long, Phường 15, Quận 10, TP. HCM</div>";
            //html += "     <div class=\"bill-row text-align-center\"><h1>Hóa đơn bán hàng</h1></div>";
            //html += "     <div class=\"bill-row text-align-right\"><p>Ngày: 13/12/2017 11:15</p></div>";
            //html += "     <div class=\"product-list\">";
            //html += "         <div class=\"product-row border-bot-solid\">";
            //html += "             <div class=\"row-content\">";
            //html += "                 <div class=\"p-variable text-align-center\"><strong>Loại</strong></div>";
            //html += "                 <div class=\"p-amount text-align-center\"><strong>Số lượng</strong></div>";
            //html += "                 <div class=\"p-price text-align-right\"><strong>Đơn giá</strong></div>";
            //html += "             </div>";
            //html += "         </div>";
            //html += "         <div class=\"product-row font-size-13\">";
            //html += "             <div class=\"row-header\"><strong>Áo khoác cặp Adidas 07</strong></div>";
            //html += "             <div class=\"row-content\">";
            //html += "                 <div class=\"p-variable text-align-right\">Color:Xanh rêu, Size:XXL</div>";
            //html += "                 <div class=\"p-amount text-align-center\">7</div>";
            //html += "                 <div class=\"p-price text-align-right\">595,000</div>";
            //html += "             </div>";
            //html += "         </div>";
            //html += "         <div class=\"product-row font-size-12\">";
            //html += "             <div class=\"row-header\"><strong class=\"\">Áo khoác cặp Adidas 07</strong></div>";
            //html += "             <div class=\"row-content\">";
            //html += "                 <div class=\"p-variable text-align-right\">Color:Xanh rêu, Size:XXL</div>";
            //html += "                 <div class=\"p-amount text-align-center\">7</div>";
            //html += "                 <div class=\"p-price text-align-right\">595,000</div>";
            //html += "             </div>";
            //html += "         </div>";
            //html += "     </div>";
            //html += "     <div class=\"total\">";
            //html += "         <div class=\"row-content\">";
            //html += "             <div class=\"p-variable text-align-right\"><strong>Tổng cộng</strong></div>";
            //html += "             <div class=\"p-amount text-align-center\"><strong>7</strong></div>";
            //html += "             <div class=\"p-price text-align-right\"><strong>595,000</strong></div>";
            //html += "         </div>";
            //html += "     </div>";
            //html += "     <div class=\"thanks-full\"><i>Cám ơn quý khách - Hẹn gặp lại</i></div>";
            //html += "</div>";

            //$("#printcontent").html(html);

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

        //function check_all()
        //{
        //    $("#check-all").change(function () {
        //        $("input:checkbox").prop('checked', $(this).prop("checked"));
        //    });
        //}



        $("#check-all").change(function () {
            $(".check-popup").prop('checked', $(this).prop("checked"));
        });



        function check() {
            var temp = 0;
            var temp2 = 0;
            $(".product-result").each(function () {
                if ($(this).find(".check-popup").is(':checked')) {
                    temp++;
                }
                else {
                    temp2++;
                }
                if (temp2 > 0) {
                    $("#check-all").prop('checked', false);
                }
                else {
                    $("#check-all").prop('checked', true);
                }
            });
        }

        function searchProduct() {
            var textsearch = $("#txtSearch").val();
            var typeinout = $("#typeinout").val();
            var supplier = $("#supplierList").val();
            if (!isBlank(textsearch)) {
                $.ajax({
                    type: "POST",
                    url: "/quan-ly-nhap-kho.aspx/getProduct",
                    data: "{textsearch:'" + textsearch + "',typeinout:'" + typeinout + "'}",
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
                                var supplierID = item.SupplierID;
                                var check = false;
                                $(".product-result").each(function () {
                                    var existedSKU = $(this).attr("data-sku");
                                    if (sku == existedSKU) {
                                        check = true;
                                    }
                                });
                                if (supplier != 0) {
                                    if (supplierID == supplier) {
                                        if (check == false) {
                                            html += "<tr class=\"product-result\" data-productimageorigin=\"" + item.ProductImageOrigin + "\" data-productvariable=\"" + item.ProductVariable + "\" data-productname=\"" + item.ProductName + "\" data-sku=\"" + item.SKU + "\" data-producttype=\"" + item.ProductType + "\" data-id=\"" + item.ID + "\" data-productnariablename=\"" + item.ProductVariableName + "\" data-productvariablevalue =\"" + item.ProductVariableValue + "\">";
                                            html += " <td><input type=\"checkbox\" class=\"check-popup\" onchange=\"check()\"  /></td>";
                                            html += "   <td>" + item.ProductImage + "";
                                            html += "   <td>" + item.ProductName + "</td>";
                                            html += "   <td>" + item.SKU + "</td>";
                                            html += "   <td>" + item.SupplierName + "</td>";
                                            html += "   <td>" + item.ProductVariable + "</td>";
                                            html += "   <td>" + item.WarehouseQuantity + "</td>";
                                            html += "   <td><input type=\"text\" min=\"1\" class=\"form-control in-quanlity\" style=\"width: 40%;margin: 0 auto;\" value=\"1\" /></td>";
                                            html += "   <td><a href=\"javascript:;\" onclick=\"deleteRow($(this))\">Xóa</a></td>";
                                            html += "</tr>";
                                        }
                                        else {
                                            $(".product-result").each(function () {
                                                var skuFind = $(this).attr("data-sku");
                                                if (skuFind == sku) {
                                                    var quantityOld = parseFloat($(this).find(".in-quanlity").val());
                                                    var quantityNew = quantityOld + 1;
                                                    $(this).find(".in-quanlity").val(quantityNew);
                                                }
                                            });
                                        }
                                        count++;
                                    }
                                    else {
                                        swal('Thông báo', 'Không tìm thấy sản phẩm', 'error');
                                    }
                                }
                                else {
                                    if (check == false) {
                                        html += "<tr class=\"product-result\" data-productimageorigin=\"" + item.ProductImageOrigin + "\" data-productvariable=\"" + item.ProductVariable + "\" data-productname=\"" + item.ProductName + "\" data-sku=\"" + item.SKU + "\" data-producttype=\"" + item.ProductType + "\" data-id=\"" + item.ID + "\" data-productnariablename=\"" + item.ProductVariableName + "\" data-productvariablevalue =\"" + item.ProductVariableValue + "\">";
                                        html += " <td><input type=\"checkbox\" class=\"check-popup\" onchange=\"check()\"  /></td>";
                                        html += "   <td>" + item.ProductImage + "";
                                        html += "   <td>" + item.ProductName + "</td>";
                                        html += "   <td>" + item.SKU + "</td>";
                                        html += "   <td>" + item.SupplierName + "</td>";
                                        html += "   <td>" + item.ProductVariable + "</td>";
                                        html += "   <td>" + item.WarehouseQuantity + "</td>";
                                        html += "   <td><input type=\"text\" min=\"1\" class=\"form-control in-quanlity\" style=\"width: 40%;margin: 0 auto;\" value=\"1\" /></td>";
                                        html += "   <td><a href=\"javascript:;\" onclick=\"deleteRow($(this))\">Xóa</a></td>";
                                        html += "</tr>";
                                    }
                                    else {
                                        $(".product-result").each(function () {
                                            var skuFind = $(this).attr("data-sku");
                                            if (skuFind == sku) {
                                                var quantityOld = parseFloat($(this).find(".in-quanlity").val());
                                                var quantityNew = quantityOld + 1;
                                                $(this).find(".in-quanlity").val(quantityNew);
                                            }
                                        });
                                    }
                                    count++;
                                }
                            }
                            $(".content-product").append(html);
                            $("#txtSearch").val("");
                            if (count > 0) {
                                $(".excute-in").show();
                            }
                        }
                        else {
                            swal('Thông báo', 'Không tìm thấy sản phẩm', 'error');
                        }
                    },
                    //error: function (xmlhttprequest, textstatus, errorthrow) {
                    //    alert('lỗi');
                    //}
                });
            }
            else {
                alert('Vui lòng nhập nội dung tìm kiếm');
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
                var barcode = "";
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

                    if (quantity > 0)
                        list += id + "," + sku + "," + producttype + "," + productnariablename + "," + productvariablevalue + "," + quantity + "," + productname + "," + productimageorigin + "," + productvariable + ";";
                    if ($(this).find(".check-popup").is(':checked')) {
                        barcode += sku + "," + quantity + ";";
                    }
                });
                $("#<%=hdfBarcode.ClientID%>").val(barcode);
                $("#<%=hdfNote.ClientID%>").val(note);
                $("#<%=hdfvalue.ClientID%>").val(list);
                $("#<%=btnImport.ClientID%>").click();
            }
            else {
                alert("Vui lòng nhập sản phẩm");
            }
        }
        function show_messageorder(content) {
            var obj = $('body');
            $(obj).css('overflow', 'hidden');
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


    </script>
</asp:Content>
