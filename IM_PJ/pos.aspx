<%@ Page Title="Máy tính tiền" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="pos.aspx.cs" Inherits="IM_PJ.pos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="parent" runat="server">
        <main id="main-wrap">
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <div class="panel panelborderheading">
                            <div class="panel-heading clear">
                                <h3 class="page-title left not-margin-bot">Thông tin khách hàng</h3>
                                <a href="javascript:;" class="search-customer" onclick="searchCustomer()"><i class="fa fa-search" aria-hidden="true"></i> Tìm khách hàng (F1)</a>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label>Họ tên</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullname" ErrorMessage="(*)"
                                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtFullname" CssClass="form-control" runat="server" placeholder="(F2)"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Điện thoại</label>
                                    <asp:RequiredFieldValidator ID="re" runat="server" ControlToValidate="txtPhone" ErrorMessage="(*)"
                                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Nick đặt hàng</label>
                                    <asp:TextBox ID="txtNick" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" style="display: none">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Địa chỉ</label>
                                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-row view-detail" style="display: none">
                                </div>
                                <div class="form-row discount-info" style="display: none">
                                </div>
                            </div>
                        </div>
                        <div class="panel-post">
                            <div class="post-row clear">
                                <div class="left">Số lượng</div>
                                <div class="right totalproductQuantity"></div>
                            </div>
                            <div class="post-row clear subtotal hide">
                                <div class="left">Thành tiền</div>
                                <div class="right totalpriceorder"></div>
                            </div>
                            <div class="post-row clear discount hide">
                                <div class="left">Chiết khấu</div>
                                <div class="right totalDiscount">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pDiscount" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0"
                                        oninput="countTotal()">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="post-row clear discount hide">
                                <div class="left">Sau chiết khấu</div>
                                <div class="right priceafterchietkhau"></div>
                            </div>
                            <div class="post-row clear shipping hide">
                                <div class="left">Phí vận chuyển</div>
                                <div class="right totalDiscount">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pFeeShip" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0"
                                        oninput="countTotal()">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Tổng tiền</div>
                                <div class="right totalpriceorderall price-red"></div>
                            </div>
                            <div class="post-row clear returnorder hide">
                                <div class="left">
                                    Đơn hàng trả
                                    <a href="javascript:;" class="find3 hide" style="text-decoration: underline; float: right; font-size: 12px; font-style: italic; padding-left: 10px;" onclick="searchReturnOrder()">(Tìm đơn khác)</a>
                                    <a href="javascript:;" class="find3 hide" style="text-decoration: underline; float: right; font-size: 12px; font-style: italic; padding-left: 10px;" onclick="deleteReturnOrder()">(Bỏ qua)</a>
                                    <a href="javascript:;" class="find2 hide" style="text-decoration: underline; float: right; font-size: 12px; font-style: italic; padding-left: 10px;"></a>
                                </div>
                                <div class="right totalpriceorderrefund"></div>
                            </div>
                            <div class="post-row clear refund hide">
                                <div class="left">Tổng tiền còn lại</div>
                                <div class="right totalpricedetail"></div>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Tiền khách trả (F4)</div>
                                <div class="right totalDiscount">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pGuestPaid" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0"
                                        oninput="countGuestChange()">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Tiền thối lại</div>
                                <div class="right totalGuestChange"></div>
                            </div>
                            <div class="post-table-links clear">
                                <a href="javascript:;" class="btn link-btn" style="background-color: #ffad00" onclick="searchReturnOrder()"><i class="fa fa-refresh"></i> Đổi trả</a>
                                <a href="javascript:;" class="btn link-btn" style="background-color: #00a2b7" onclick="showShipping()"><i class="fa fa-truck"></i> Vận chuyển</a>
                                <a href="javascript:;" class="btn link-btn" style="background-color: #453288" onclick="showDiscount()"><i class="fa fa-tag"></i> Chiết khấu</a>
                                <a href="javascript:;" class="btn link-btn" style="background-color: #f87703;" onclick="payAll()"><i class="fa fa-floppy-o"></i> Thanh toán</a>
                                <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" Style="display: none" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-8">
                        <div class="panel-post">
                            <select class="form-control customer-type" onchange="getProductPrice($(this))">
                                <option value="2">Khách mua sỉ</option>
                                <option value="1">Khách mua lẻ</option>
                            </select>
                            <div class="post-above clear">
                                <div class="search-box left" style="width: 90%;">
                                    <input type="text" id="txtSearch" class="form-control" placeholder="SKU (F3)">
                                </div>
                                <div class="right">
                                    <a href="javascript:;" class="link-btn" onclick="searchProduct()"><i class="fa fa-search"></i></a>
                                    <a href="/quan-ly-nhap-kho" class="link-btn" target="_blank"><i class="fa fa-cube"></i></a>
                                </div>
                            </div>
                            <div class="post-body clear">
                                <table class="table table-checkable table-product custom-font-size-12">
                                    <thead>
                                        <tr>
                                            <th class="image-item">Ảnh</th>
                                            <th class="name-item">Sản phẩm</th>
                                            <th class="sku-item">Mã</th>
                                            <th class="variable-item">Thuộc tính</th>
                                            <th class="price-item">Giá</th>
                                            <th class="quantity-item">Số lượng</th>
                                            <th class="total-item">Thành tiền</th>
                                            <th class="trash-item"></th>
                                            <th class="space-item"></th>
                                        </tr>
                                    </thead>
                                </table>
                                <div class="search-product-content">
                                    <table class="table table-checkable table-product custom-font-size-12">
                                        <tbody class="content-product">
                                        </tbody>
                                    </table>
                                </div>
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
            <asp:HiddenField ID="hdfChietKhau" runat="server" />
            <asp:HiddenField ID="hdfDonHangTra" runat="server" />
            <asp:HiddenField ID="hdfTongTienConLai" runat="server" />
            <div id="printcontent" style="display: none">
                <asp:Literal ID="ltrprint" runat="server"></asp:Literal>
            </div>
        </main>
    </asp:Panel>
    <style>
        .menuin #main-wrap {
            left: 0;
            width: 100%;
            margin-bottom: 0;
            margin-top: 0;
            padding-top: 0;
            padding-bottom: 0;
        }

        #main-wrap {
            top: 5px;
        }

        .search-product-content {
            background: #fff;
            overflow-y: scroll;
        }

        #popup_content2 {
            min-height: 10px;
            position: fixed;
            background-color: #fff;
            top: 15%;
            z-index: 9999;
            left: 0;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            padding: 20px 20px;
            right: 0%;
            margin: 0 auto;
        }

        .panel-post .post-table-links .btn {
            width: 25%;
            padding-left: 5px;
            padding-right: 5px;
        }

        @media (min-width: 992px){
            .container {
                width: 100%;
            }
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
            // set height for div product list
            $(".search-product-content").height($(window).height() - 150);

            // hide header in template
            $("#header").html("");

            // search Product by SKU
            $("#txtSearch").keydown(function(event) {
                if (event.which === 13) {
                    searchProduct();
                    event.preventDefault();
                    return false;
                }
            });

            // focus to searchProduct input when page on ready
            $(document).ready(function() {
                $("#txtSearch").focus();
            });

            // check data before close page or refresh page
            function stopNavigate(event) {
                $(window).off('beforeunload');
            }

            $(window).bind('beforeunload', function(e) {
                if ($(".product-result").length > 0 || $("#<%=txtPhone.ClientID%>").val() != "" || $("#<%= txtFullname.ClientID%>").val() != "") return true;
                else e = null;
            });

            // key press F1 - F4
            $(document).keydown(function(e) {
                if (e.which == 112) { //F1 Search Customer
                    searchCustomer();
                    return false;
                }
                if (e.which == 113) { //F2 Input Fullname
                    $("#<%= txtFullname.ClientID%>").focus();
                    return false;
                }
                if (e.which == 114) { //F3 Search Product
                    $("#txtSearch").focus();
                    return false;
                }
                if (e.which == 115) { //F4 GuestPaid
                    $("#<%=pGuestPaid.ClientID%>").focus();
                    return false;
                }
            });

            // quickly input change
            $("#<%=pGuestPaid.ClientID%>").keydown(function(e) {
                if (e.which == 13) {
                    var value = $("#<%=pGuestPaid.ClientID%>").val() + "000";
                    $("#<%=pGuestPaid.ClientID%>").val(value);
                    getAllPrice();
                    $("#<%=pGuestPaid.ClientID%>").blur();
                    return false;
                }
            });

            // get highest customer discount
            function getCustomerDiscount(custID) {
                $.ajax({
                    type: "POST",
                    url: "/pos.aspx/getCustomerDiscount",
                    data: "{ID:'" + custID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        var data = msg.d;
                        if (data != 0) {
                            $(".discount-info").html("<strong>Khách hàng được chiết khấu: " + formatThousands(data, ",") + " vnđ/sản phẩm.</strong>").show();
                            $("#<%=hdfIsDiscount.ClientID%>").val("1");
                            $("#<%=hdfDiscountAmount.ClientID%>").val(data);
                            $(".subtotal").removeClass("hide");
                            $(".discount").removeClass("hide");
                        } else {
                            $(".discount-info").hide();
                            $("#<%=hdfIsDiscount.ClientID%>").val("0");
                            $("#<%=hdfDiscountAmount.ClientID%>").val("0");
                        }
                        getAllPrice();
                    },
                    error: function(xmlhttprequest, textstatus, errorthrow) {
                        alert('lỗi');
                    }
                });
            }

            // view Customer detail by click button
            function viewCustomerDetail(custID) {
                $.ajax({
                    type: "POST",
                    url: "/pos.aspx/getCustomerDetail",
                    data: "{ID:'" + custID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        if (msg.d != "null") {
                            $("#<%=hdfCheckCustomer.ClientID%>").val("1");
                            var alldata = JSON.parse(msg.d);

                            var data = alldata.Customer;
                            var dataDiscout = alldata.AllDiscount;
                            var jsonDate = data.CreatedDate;
                            var dateString = jsonDate.substr(6);
                            var currentTime = new Date(parseInt(dateString));
                            var month = currentTime.getMonth() + 1;
                            var day = currentTime.getDate();
                            var year = currentTime.getFullYear();
                            var date = day + "/" + month + "/" + year;
                            var html = "";
                            html += "<div class=\"responsive-table\">";
                            html += "<table class=\"table table-checkable table-product\">";
                            html += "   <thead>";
                            html += "       <tr>";
                            html += "           <td style=\"width:25%;\">Khách hàng:</td>";
                            html += "           <td>" + data.CustomerName + "</td>";
                            html += "       </tr>";
                            html += "       <tr>";
                            html += "           <td style=\"width:25%;\">Nick đặt hàng:</td>";
                            html += "           <td>" + data.Nick + "</td>";
                            html += "       </tr>";
                            html += "       <tr>";
                            html += "           <td style=\"width:25%;\">Điện thoại</td>";
                            html += "           <td>" + data.CustomerPhone + "</td>";
                            html += "       </tr>";
                            html += "       <tr>";
                            html += "           <td style=\"width:25%;\">Địa chỉ</td>";
                            html += "           <td>" + data.CustomerAddress + "</td>";
                            html += "       </tr>";
                            html += "       <tr>";
                            html += "           <td style=\"width:25%;\">Email</td>";
                            html += "           <td>" + data.CustomerEmail + "</td>";
                            html += "       </tr>";
                            html += "       <tr>";
                            html += "           <td style=\"width:25%;\">Zalo</td>";
                            html += "           <td>" + data.Zalo + "</td>";
                            html += "       </tr>";
                            html += "       <tr>";
                            html += "           <td style=\"width:25%;\">Facebook</td>";
                            html += "           <td>" + data.Facebook + "</td>";
                            html += "       </tr>";
                            html += "       <tr>";
                            html += "           <td style=\"width:25%;\">Nhân viên phục vụ</td>";
                            html += "           <td>" + data.CreatedBy + "</td>";
                            html += "       </tr>";
                            html += "       <tr>";
                            html += "           <td style=\"width:25%;\">Ngày tạo</td>";
                            html += "           <td>" + date + "</td>";
                            html += "       </tr>";
                            html += "   </thead>";
                            html += "</table>";
                            html += "</div>";

                            var htmlDiscount = "";
                            if (dataDiscout.length > 0) {
                                htmlDiscount += "<div class=\"responsive-table\">";
                                htmlDiscount += "<table class=\"table table-checkable table-product\">";
                                htmlDiscount += "       <tr>";
                                htmlDiscount += "           <td><strong>Tên nhóm</strong></td>";
                                htmlDiscount += "           <td><strong>Chiết khấu</strong></td>";
                                htmlDiscount += "       </tr>";
                                for (var i = 0; i < dataDiscout.length; i++) {
                                    htmlDiscount += "       <tr>";
                                    htmlDiscount += "           <td>" + dataDiscout[i].DiscountName + "</td>";
                                    htmlDiscount += "           <td>" + formatThousands(dataDiscout[i].DiscountAmount, ",") + " vnđ/sản phẩm</td>";
                                    htmlDiscount += "       </tr>";
                                }
                                htmlDiscount += "</table>";
                                htmlDiscount += "</div>";
                            } else {
                                htmlDiscount += "<div class=\"responsive-table\">";
                                htmlDiscount += "<table class=\"table table-checkable table-product\">";
                                htmlDiscount += "       <tr>";
                                htmlDiscount += "           <td><strong>Hiện tại khách hàng chưa được chiết khấu</strong></td>";
                                htmlDiscount += "       </tr>";
                                htmlDiscount += "</table>";
                                htmlDiscount += "</div>";
                            }

                            showPopup(html + htmlDiscount);
                        }
                    },
                    error: function(xmlhttprequest, textstatus, errorthrow) {
                        //alert('lỗi 1');
                    }
                });
            }

            // search Customer by name, nick, phone, zalo, facebook
            function searchCustomer() {
                var html = "";
                html += "<div class=\"form-group\">";
                html += "<label>Tìm khách hàng: </label>";
                html += "<input id=\"txtSearchCustomer\" class=\"form-control fjx\"></input>";
                html += "<a href=\"javascript: ;\" class=\"btn link- btn\" style=\"background-color:#f87703;float:right;color:#fff;\" onclick=\"showCustomerList()\">Tìm</a>";
                html += "</div>";
                html += "<div class=\"form-group findcust hide\">";
                html += "<div class=\"listcust\">";
                html += "</div>";
                html += "</div>";
                showPopup(html);
                $("#txtSearchCustomer").focus();
                $('#txtSearchCustomer').keydown(function(event) {
                    if (event.which === 13) {
                        showCustomerList();
                        event.preventDefault();
                        return false;
                    }
                });
            }

            // show customer list after search SKU
            function showCustomerList() {
                var textsearch = $("#txtSearchCustomer").val();
                if (!isBlank(textsearch)) {
                    $.ajax({
                        type: "POST",
                        url: "/pos.aspx/searchCustomerByText",
                        data: "{textsearch:'" + textsearch + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            var count = 0;
                            var data = JSON.parse(msg.d);
                            if (data.length > 0) {
                                var html = "";
                                var listGet = "";
                                html += ("<table class=\"table table-checkable table-product\">");
                                html += ("<thead>");
                                html += ("<tr>");
                                html += ("<td class=\"select-column\">Chọn</td>");
                                html += ("<td class=\"nick-column\">Nick</td>");
                                html += ("<td class=\"name-column\">Họ tên</td>");
                                html += ("<td class=\"phone-column\">Điện thoại</td>");
                                html += ("<td class=\"zalo-column\">Zalo</td>");
                                html += ("<td class=\"facebook-column\">Facebook</td>");
                                html += ("<td class=\"address-column\">Địa chỉ</td>");
                                html += ("<td class=\"province-column\">Tỉnh thành</td>");
                                html += ("</tr>");
                                html += ("</thead>");
                                html += ("<tbody>");
                                for (var i = 0; i < data.length; i++) {
                                    var item = data[i];
                                    html += ("<tr class=\"search-popup\" id=\"search-key\";>");
                                    html += ("<td>");
                                    html += ("<input id=\"" + item.ID + "\" name=\"cust\" type=\"radio\" class=\"check-popup select-column\"  />");
                                    html += ("</td>");

                                    if (!isBlank(item.Nick)) {
                                        html += ("<td class=\"nick nick-column\">" + item.Nick + "</td>");
                                    } else {
                                        html += ("<td class=\"nick nick-column\"></td>");
                                    }
                                    html += ("<td class=\"name name-column\">" + item.CustomerName + "</td>");
                                    html += ("<td class=\"phone phone-column\">" + item.CustomerPhone + "</td>");
                                    html += ("<td class=\"id\" style=\"display:none\">" + item.ID + "</td>");
                                    if (!isBlank(item.Zalo)) {
                                        html += ("<td class=\"zalo zalo-column\">" + item.Zalo + "</td>");
                                    } else {
                                        html += ("<td></td>");
                                    }
                                    if (!isBlank(item.Facebook)) {
                                        html += ("<td class=\"facebook\" data-value=\"" + item.Facebook + "\"><a class=\"link\" href=\"" + item.Facebook + "\" target=\"_blank\">Xem</a></td>");
                                    } else {
                                        html += ("<td></td>");
                                    }
                                    if (!isBlank(item.CustomerAddress)) {
                                        html += ("<td class=\"address address-column\">" + item.CustomerAddress + "</td>");
                                    } else {
                                        html += ("<td></td>");
                                    }
                                    if (!isBlank(item.Province)) {
                                        html += ("<td class=\"province province-column\">" + item.Province + "</td>");
                                    } else {
                                        html += ("<td></td>");
                                    }
                                    html += ("</tr>");
                                }
                                html += ("</tbody>");
                                html += ("</table>");
                                html += ("<div>");
                                html += ("<a href=\"javascript: ;\" class=\"btn link- btn\" style=\"background-color:#f87703;float:right;color:#fff;\" onclick=\"selectCustomer()\">Chọn</a>");
                                html += ("</div >");
                                $("#txtSearchCustomer").val("");
                                $(".listcust").html(html);
                                $(".findcust").removeClass('hide').addClass('show');
                            } else {
                                alert('Không tìm thấy khách hàng');
                            }
                        },
                        error: function(xmlhttprequest, textstatus, errorthrow) {
                            alert('lỗi');
                        }
                    });
                } else {
                    alert('Vui lòng nhập nội dung tìm kiếm');
                }
            }

            // select a customer after show list
            function selectCustomer() {
                $(".search-popup").each(function() {
                    if ($(this).find(".check-popup").is(':checked')) {
                        var phone = $(this).find("td.phone").html();
                        var name = $(this).find("td.name").html();
                        var nick = $(this).find("td.nick").html();
                        var address = $(this).find("td.address").html();
                        var id = $(this).find("td.id").html();
                        $("#<%=txtPhone.ClientID%>").val(phone).prop('disabled', true);
                        $("#<%=txtFullname.ClientID%>").val(name).prop('disabled', true);
                        $("#<%=txtNick.ClientID%>").val(nick).prop('disabled', true);
                        $("#<%=txtAddress.ClientID%>").val(address).prop('disabled', true);
                        $(".view-detail").html("<a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth\" onclick=\"viewCustomerDetail('" + id + "')\">Xem chi tiết</a><a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth clear-btn\" onclick=\"clearCustomerDetail()\">Bỏ qua</a>").show();
                        getCustomerDiscount(id);
                    }
                });
                closePopup();
            }

            // clear customer detail
            function clearCustomerDetail() {
                $("#<%=txtPhone.ClientID%>").val("").prop('disabled', false);
                $("#<%= txtFullname.ClientID%>").val("").prop('disabled', false);
                $("#<%= txtNick.ClientID%>").val("").prop('disabled', false);
                $("#<%= txtAddress.ClientID%>").val("").prop('disabled', false);
                $(".view-detail").html("").hide();
                $(".discount-info").html("").hide();
                $("#<%= txtFullname.ClientID%>").focus();
                getAllPrice();
            }
            // end Customer

            // search return order
            function searchReturnOrder() {
                var phone = $("#<%=txtPhone.ClientID%>").val();
                var name = $("#<%=txtFullname.ClientID%>").val();
                if (isBlank(phone) || isBlank(name)) {
                    alert("Nhập thông tin khác hàng trước!");
                } else {
                    var html = "";
                    html += "<div class=\"form-group\">";
                    html += "<label>Mã đơn hàng đổi trả: </label>";
                    html += "<input ID=\"txtOrderRefund\" class=\"form-control fjx\"></input>";
                    html += "<a href=\"javascript: ;\" class=\"btn link- btn\" style=\"background-color:#f87703;float:right;color:#fff;\" onclick=\"getReturnOrder()\">Tìm</a>";
                    html += "</div>";
                    showPopup(html);
                    $("#txtOrderRefund").focus();
                    $('#txtOrderRefund').keydown(function(event) {
                        if (event.which === 13) {
                            getReturnOrder();
                            event.preventDefault();
                            return false;
                        }
                    });
                }
            }

            // get return order
            function getReturnOrder() {
                var order = $("#txtOrderRefund").val();
                var name = $("#<%=txtFullname.ClientID%>").val();
                var phone = $("#<%=txtPhone.ClientID%>").val();
                if (!isBlank(order)) {
                    $.ajax({
                        type: "POST",
                        url: "/pos.aspx/getReturnOrder",
                        data: "{order:'" + order + "', remove:'0'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            if (msg.d != "null") {
                                var data = JSON.parse(msg.d);
                                if (data.CustomerName == name && data.CustomerPhone == phone) {
                                    $(".subtotal").removeClass("hide");
                                    $(".returnorder").removeClass("hide");
                                    $(".totalpriceorderall").removeClass("price-red");
                                    $(".totalpricedetail").addClass("price-red");
                                    $(".find3").removeClass("hide");
                                    $(".find1").addClass("hide");
                                    $(".find2").html("(Xem đơn hàng " + data.ID + ")");
                                    $(".find2").attr("onclick", "viewReturnOrder(" + data.ID + ")");
                                    $(".find2").removeClass("hide");
                                    var refundprice = 0;
                                    if (parseFloat($("#<%=hdfTotalPrice.ClientID%>").val() > 0)) {
                                        refundprice = parseFloat($("#<%=hdfTotalPrice.ClientID%>").val());
                                    }
                                    $(".totalpricedetail").html(formatThousands((refundprice - data.TotalPrice), ","));
                                    $("#<%=hdfDonHangTra.ClientID%>").val(data.TotalPrice);
                                    $(".refund").removeClass("hide");
                                    $(".totalpriceorderrefund").html(formatThousands(data.TotalPrice, ","));
                                    closePopup();
                                    getAllPrice();
                                } else {
                                    alert("Đơn hàng đổi trả không thuộc khách hàng này!");
                                }
                            } else {
                                alert("Đơn hàng đổi trả không tồn tại hoặc đã được trừ tiền!");
                            }
                        },
                        error: function(xmlhttprequest, textstatus, errorthrow) {
                            alert('lỗi');
                        }
                    });
                } else {
                    alert("Vui lòng nhập thông tin khách hàng!");
                }
            }

            // view return order by click button
            function viewReturnOrder(ID) {
                var win = window.open("/thong-tin-tra-hang.aspx?id=" + ID + "", '_blank');
                win.focus();
            }

            // delete return order
            function deleteReturnOrder() {
                $.ajax({
                    type: "POST",
                    url: "/pos.aspx/getReturnOrder",
                    data: "{order:'1', remove:'1'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        $(".find3").addClass("hide");
                        $(".find1").removeClass("hide");
                        $(".find2").addClass("hide");
                        $(".find2").html("");
                        $(".find2").removeAttr("onclick");
                        $(".totalpricedetail").html("0");
                        $("#<%=hdfDonHangTra.ClientID%>").val(0);
                        $(".refund").addClass("hide");
                        $(".totalpriceorderrefund").html("0");
                        $("#txtOrderRefund").val(0);
                        $(".returnorder").addClass("hide");
                        $(".totalpriceorderall").addClass("price-red");
                        $(".totalpricedetail").removeClass("price-red");
                        alert("Đã bỏ qua đơn hàng đổi trả này!");
                        getAllPrice();
                    },
                    error: function(xmlhttprequest, textstatus, errorthrow) {
                        alert('lỗi');
                    }
                });
            }
            //end return Order

            // show shipping input by click button
            function showShipping() {
                $(".subtotal").removeClass("hide");
                $(".shipping").removeClass("hide");
            }

            // show discount input by click button
            function showDiscount() {
                $(".subtotal").removeClass("hide");
                $(".discount").removeClass("hide");
            }

            // print invoice after submit order
            function printInvoice() {
                clearCustomerDetail();
                printDiv('printcontent');
            }

            // print div invoice
            function printDiv(divid) {
                var divToPrint = document.getElementById('' + divid + '');
                var newWin = window.open('', 'Print-Window');
                newWin.document.open();
                newWin.document.write('<html><head><link rel="stylesheet" href="/App_Themes/Ann/hoadon/hoadon.css" type="text/css"/><link rel="stylesheet" href="/App_Themes/Ann/barcode/style.css" type="text/css"/><link rel="stylesheet" href="/App_Themes/Ann/css/responsive.css" type="text/css"/></head><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
                newWin.document.close();
                setTimeout(function() {
                    newWin.close();
                }, 10);
            }

            // pay order on click button
            function payAll() {
                var phone = $("#<%=txtPhone.ClientID%>").val();
                var name = $("#<%= txtFullname.ClientID%>").val();
                var address = $("#<%= txtAddress.ClientID%>").val();
                if (phone != "" && name != "" && address != "") {
                    if ($(".product-result").length > 0) {
                        var list = "";
                        var count = 0;
                        var ordertype = $(".customer-type").val();
                        $(".product-result").each(function() {
                            var id = $(this).attr("data-id");
                            var sku = $(this).attr("data-sku");
                            var producttype = $(this).attr("data-producttype");
                            var productnariablename = $(this).attr("data-productnariablename");
                            var productvariablevalue = $(this).attr("data-productvariablevalue");
                            var quantity = $(this).find(".in-quanlity").val();
                            var productname = $(this).attr("data-productname");
                            var productimageorigin = $(this).attr("data-productimageorigin");
                            var productvariable = $(this).attr("data-productvariable");
                            var price = $(this).find(".gia-san-pham").attr("data-price");
                            var productvariablesave = $(this).attr("data-productvariablesave");
                            if (quantity > 0) {
                                list += id + "," + sku + "," + producttype + "," + productnariablename + "," + productvariablevalue + "," + quantity + "," +
                                    productname + "," + productimageorigin + "," + productvariablesave + "," + price + "," + productvariablesave + ";";
                                count++;
                            }
                        });
                        $("#<%=hdfOrderType.ClientID %>").val(ordertype);
                        $("#<%=hdfListProduct.ClientID%>").val(list);
                        $("#<%=btnOrder.ClientID%>").click();
                    } else {
                        alert("Vui lòng nhập sản phẩm!");
                        $("#txtSearch").focus();
                    }
                } else {
                    alert("Vui lòng nhập thông tin khách hàng!");
                    $("#<%= txtFullname.ClientID%>").focus();

                }
            }

            // count guest change
            function countGuestChange() {
                notEmpty();
                var totalrefund = 0;
                if (parseFloat($("#<%=hdfDonHangTra.ClientID%>").val()) > 0) {
                    totalrefund = parseFloat($("#<%=hdfDonHangTra.ClientID%>").val());
                }
                var gp1 = $("#<%=pGuestPaid.ClientID%>").val();
                var gp = parseFloat(gp1.replace(/\,/g, ''));
                if (gp > 0) {
                    var totalprice = parseFloat($("#<%= hdfTotalPrice.ClientID%>").val());
                    var leftchange = gp - totalprice + totalrefund;
                    $(".totalGuestChange").html(formatThousands(leftchange, ","));
                } else {
                    var totalprice = parseFloat($("#<%= hdfTotalPrice.ClientID%>").val());
                    var leftchange = -totalprice + totalrefund;
                    $(".totalGuestChange").html(formatThousands(leftchange, ","));
                }
            }

            // search product by SKU
            function searchProduct() {
                var textsearch = $("#txtSearch").val();
                $("#<%=hdfListSearch.ClientID%>").val(textsearch);
                var customerType = $(".customer-type").val();
                if (!isBlank(textsearch)) {
                    $.ajax({
                        type: "POST",
                        url: "/pos.aspx/getProduct",
                        data: "{textsearch:'" + textsearch + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            var count = 0;
                            var data = JSON.parse(msg.d);
                            if (data.length > 1) {
                                var html = "";
                                var listGet = "";
                                html += ("<table class=\"table table-checkable table-product\">");
                                html += ("<tr>");
                                html += ("<td class=\"order-item\">");
                                html += ("<input type=\"checkbox\" id=\"check-all\"onchange=\"check_all()\"/>");
                                html += ("</td>");
                                html += ("<td class=\"image-item\">Ảnh</td>");
                                html += ("<td class=\"name-item\">Sản phẩm</td>");
                                html += ("<td class=\"sku-item\">Mã</td>");
                                html += ("<td class=\"variable-item\">Thuộc tính</td>");
                                html += ("<td class=\"quantity-item\">Số lượng</td>");
                                html += ("</tr>");
                                for (var i = 0; i < data.length; i++) {
                                    var item = data[i];
                                    html += ("<tr class=\"search-popup\" id=\"search-key\";>");
                                    html += ("<td class=\"order-item\">");
                                    html += ("<input id=\"" + item.ID + "\" type=\"checkbox\" class=\"check-popup\" onchange=\"check($(this))\" />");
                                    html += ("</td>");
                                    html += ("<td class=\"image-item\">" + item.ProductImage + "</td>");
                                    html += ("<td class=\"name-item\">" + item.ProductName + "</td>");
                                    html += ("<td class=\"sku-item key\">" + item.SKU + "</td>");
                                    html += ("<td class=\"variable-item\">" + item.ProductVariable + "</td>");
                                    html += ("<td class=\"quantity-item\"><input class=\"quantity\" type=\"text\" min=\"1\"  style=\"width: 100%;\" value=\"1\"></td>");
                                    html += ("</tr>");
                                }
                                html += ("</table>");
                                html += ("<div>");
                                html += ("<a href=\"javascript: ;\" class=\"btn link- btn\" style=\"background-color:#f87703;float:right;color:#fff;\" onclick=\"selectProduct()\">Chọn</a>");
                                html += ("</div >");
                                $("#txtSearch").val("");
                                showPopup(html);
                            } else if (data.length == 1) {

                                var item = data[0];
                                var sku = item.SKU;
                                var check = false;
                                $(".product-result").each(function() {
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
                                    html += "   <td class=\"image-item\">" + item.ProductImage + "";
                                    html += "   <td class=\"name-item\">" + item.ProductName + "</td>";
                                    html += "   <td class=\"sku-item\">" + item.SKU + "</td>";
                                    html += "   <td class=\"variable-item\">" + item.ProductVariable + "</td>";
                                    if (customerType == 1) {
                                        if (item.Giabanle > 0)
                                            html += "   <td class=\"price-item gia-san-pham\" data-price=\"" + item.Giabanle + "\">" + item.stringGiabanle + "</td>";
                                        else
                                            html += "   <td class=\"price-item gia-san-pham\" data-price=\"" + item.Giabansi + "\">" + item.stringGiabansi + "</td>";
                                    } else {
                                        html += "   <td class=\"price-item gia-san-pham\" data-price=\"" + item.Giabansi + "\">" + item.stringGiabansi + "</td>";
                                    }

                                    html += "   <td class=\"quantity-item\"><input type=\"text\" min=\"0\"  class=\"form-control in-quanlity\" value=\"1\"  onkeyup=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";

                                    html += "<td class=\"total-item totalprice-view\">" + formatThousands(parseFloat(item.Giabansi), '.') + "</td>";
                                    html += "   <td class=\"trash-item\"><a href=\"javascript:;\" class=\"link-btn\" onclick=\"deleteRow($(this))\"><i class=\"fa fa-trash\"></i></a></td>";
                                    html += "</tr>";
                                } else if (check == true) {
                                    $(".product-result").each(function() {
                                        var existedSKU = $(this).attr("data-sku");
                                        if (sku == existedSKU) {
                                            var quantityinstock = parseFloat($(this).attr("data-quantityinstock"));
                                            var quantityCurrent = parseFloat($(this).find(".in-quanlity").val());
                                            var newquantity = quantityCurrent + 1;
                                            if (newquantity <= quantityinstock) {
                                                $(this).find(".in-quanlity").val(newquantity);
                                                var price = parseFloat(newquantity) * parseFloat(item.Giabansi);
                                                $(this).find(".totalprice-view").html(formatThousands(price, '.'));
                                                getAllPrice();
                                            }

                                        }
                                    });
                                }
                                count++;

                                $(".content-product").append(html);
                                $("#txtSearch").val("");
                                if (count > 0) {
                                    $(".excute-in").show();
                                }
                                getAllPrice();
                            } else {
                                alert('Không tìm thấy sản phẩm');
                            }
                        },
                        error: function(xmlhttprequest, textstatus, errorthrow) {
                            alert('lỗi');
                        }
                    });
                } else {
                    alert('Vui lòng nhập nội dung tìm kiếm');
                }

            }

            // select all variable product
            function check_all() {
                if ($('#check-all').is(":checked")) {
                    $(".check-popup").prop('checked', true);
                } else {
                    $(".check-popup").prop('checked', false);
                }

            }

            // checkbox a variable product
            function check(obj) {
                var temp = 0;
                var temp2 = 0;
                $(".search-popup").each(function() {
                    if ($(this).find(".check-popup").is(':checked')) {
                        temp++;
                    } else {
                        temp2++;
                    }
                    if (temp2 > 0) {
                        obj.parent().parent().parent().find("#check-all").prop('checked', false);
                    } else {
                        obj.parent().parent().parent().find("#check-all").prop('checked', true);
                    }
                });
            }

            // select a variable product
            function selectProduct() {
                var list = "";
                var value = "";
                $(".search-popup").each(function() {
                    if ($(this).find(".check-popup").is(':checked')) {
                        var sku = $(this).find("td.key").html();
                        var quantity = $(this).find("input.quantity").val();
                        value += quantity + "*";
                        list += sku + "*";
                    }
                });
                var item = list.split("*");
                var item2 = value.split("*");
                getProduct(item, item2);
                closePopup();
                $("#txtSearch").focus();
            }

            // get product when select multi variable
            function getProduct(list, list2) {
                var textsearch = $("#<%=hdfListSearch.ClientID%>").val();
                var customerType = $(".customer-type").val();
                $.ajax({
                    type: "POST",
                    url: "/pos.aspx/getProduct",
                    data: "{textsearch:'" + textsearch + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        var count = 0;
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
                                        $(".product-result").each(function() {
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
                                            html += "   <td class=\"image-item\">" + item.ProductImage + "";
                                            html += "   <td class=\"name-item\">" + item.ProductName + "</td>";
                                            html += "   <td class=\"sku-item\">" + item.SKU + "</td>";
                                            html += "   <td class=\"variable-item\">" + item.ProductVariable + "</td>";
                                            if (customerType == 1) {
                                                if (item.Giabanle > 0)
                                                    html += "   <td class=\"price-item gia-san-pham\" data-price=\"" + item.Giabanle + "\">" + item.stringGiabanle + "</td>";
                                                else
                                                    html += "   <td class=\"price-item gia-san-pham\" data-price=\"" + item.Giabansi + "\">" + item.stringGiabansi + "</td>";
                                            } else {
                                                html += "   <td class=\"price-item gia-san-pham\" data-price=\"" + item.Giabansi + "\">" + item.stringGiabansi + "</td>";
                                            }

                                            var t = 0;
                                            //if (list2[j] > item.QuantityInstock) {
                                            //    html += "   <td class=\"quantity-item\"><input type=\"text\" min=\"0\"  class=\"form-control in-quanlity\" value=\"" + item.QuantityInstock + "\"  onkeyup=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                                            //    t = parseFloat(item.QuantityInstock) * parseFloat(item.Giabansi);
                                            //} else {
                                                html += "   <td class=\"quantity-item\"><input type=\"text\" min=\"0\"  class=\"form-control in-quanlity\" value=\"" + list2[j] + "\"  onkeyup=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                                                t = parseFloat(list2[j]) * parseFloat(item.Giabansi);
                                            //}

                                            html += "<td class=\"total-item totalprice-view\">" + formatThousands(t, '.') + "</td>";

                                            html += "   <td class=\"trash-item\"><a href=\"javascript:;\" class=\"link-btn\" onclick=\"deleteRow($(this))\"><i class=\"fa fa-trash\"></i></a></td>";
                                            html += "</tr>";
                                        } else if (check == true) {
                                            $(".product-result").each(function() {
                                                var existedSKU = $(this).attr("data-sku");
                                                if (sku == existedSKU) {
                                                    var quantityinstock = parseFloat($(this).attr("data-quantityinstock"));
                                                    var quantityCurrent = parseFloat($(this).find(".in-quanlity").val());
                                                    var newquantity = quantityCurrent + parseInt(list2[j]);

                                                    $(this).find(".in-quanlity").val(newquantity);
                                                    var price = parseFloat(newquantity) * parseFloat(item.Giabansi);
                                                    $(this).find(".totalprice-view").html(formatThousands(price, '.'));
                                                    getAllPrice();

                                                }
                                            });
                                        }
                                        count++;
                                    }
                                }
                            }
                            $(".content-product").append(html);
                            $("#txtSearch").val("");
                            if (count > 0) {
                                $(".excute-in").show();
                            }
                            getAllPrice();
                        } else {
                            alert('Không tìm thấy sản phẩm');
                        }
                    },
                    error: function(xmlhttprequest, textstatus, errorthrow) {
                        alert('lỗi');
                    }
                });
            }
            //End

            // remove product form list
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

            // change in a row of list
            function inProduct() {
                if ($(".product-result").length > 0) {
                    var note = $("#txtnote").val();
                    var list = "";
                    var count = 0;
                    $(".product-result").each(function() {
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

                    } else {
                        alert('Vui lòng nhập số lượng để xuất kho!');
                    }
                } else {
                    alert("Vui lòng nhập sản phẩm!");
                }
            }

            // change quantity of product
            function checkQuantiy(obj) {
                //var instock = parseFloat(obj.parent().parent().attr("data-quantityinstock"));
                //var currentVal = parseFloat(obj.val());
                //var check = true;
                //if (currentVal == 0) {
                //    obj.val("1");
                //} else if (currentVal > instock) {
                //    obj.val("");
                //    obj.val(instock);
                //}
                getAllPrice();
            }

            // get all price
            function getAllPrice() {
                if ($(".product-result").length > 0) {

                    var totalprice = 0;
                    var productquantity = 0;
                    $(".product-result").each(function() {
                        var price = parseFloat($(this).find(".gia-san-pham").attr("data-price"));
                        var quantity = parseFloat($(this).find(".in-quanlity").val());

                        var total = price * quantity;
                        $(this).find(".totalprice-view").html(formatThousands(total, '.'));
                        productquantity += quantity;
                        totalprice += total;
                    });
                    $("#<%=hdfTotalPriceNotDiscount.ClientID%>").val(totalprice);
                    $(".totalproductQuantity").html(formatThousands(productquantity, ',') + " sản phẩm");
                    $("#<%=hdfTotalPriceNotDiscountNotFee.ClientID%>").val(totalprice);
                    $(".totalpriceorder").html(formatThousands(totalprice, ','));
                    $("#<%=hdfTotalQuantity.ClientID%>").val(productquantity);
                    var isDiscount = $("#<%=hdfIsDiscount.ClientID%>").val();
                    var totalDiscount = 0;
                    var totalleft = 0;
                    var totalck = 0;
                    var amount = 0;
                    var amountdiscount = 0;
                    if (isDiscount == 1) {
                        amountdiscount = parseFloat($("#<%=hdfDiscountAmount.ClientID%>").val());
                    }

                    var ChietKhau = document.getElementById('<%= hdfChietKhau.ClientID%>').defaultValue;

                    var listck = ChietKhau.split('|');
                    for (var i = 0; i < listck.length - 1; i++) {
                        var item = listck[i].split('-');
                        if (i < listck.length - 2) {
                            var item2 = listck[i + 1].split('-');
                            if (productquantity > (parseFloat(item[0]) - 1) && productquantity <= (parseFloat(item2[0]) - 1)) {
                                amount = parseFloat(item[1]);
                            }
                        } else {
                            if (productquantity > (parseFloat(item[0]) - 1)) {
                                amount = parseFloat(item[1]);
                            }
                        }
                    }

                    if (amountdiscount > 0) {
                        if (amount < amountdiscount) {
                            amount = amountdiscount;
                        }
                    }

                    if (amount > 0) {
                        totalDiscount = amount;
                        totalck = amount * productquantity;
                        totalleft = totalprice - totalck;
                        $(".subtotal").removeClass("hide");
                        $(".discount").removeClass("hide");
                    } else {
                        totalDiscount = 0;
                        totalleft = totalprice;
                    }

                    if ($("#<%=hdfcheck.ClientID%>").val() != 0) {
                        var dis = $("#<%=pDiscount.ClientID%>").val();
                        var discount = parseFloat(dis.replace(/\,/g, ''));
                        var totalck = discount * productquantity;
                        var totalleft = totalprice - totalck;
                        var totalDiscount = discount;
                    }
                    var fs = $("#<%=pFeeShip.ClientID%>").val();
                    var feeship = parseFloat(fs.replace(',', ''));
                    var feeship = parseFloat(fs.replace(/\,/g, ''));
                    var priceafterchietkhau = totalleft;
                    var totalmoney = totalleft + feeship;

                    $("#<%=pDiscount.ClientID%>").val(formatThousands(totalDiscount, ','));
                    $(".totalpriceorderall").html(formatThousands(totalmoney, ','));
                    $(".priceafterchietkhau").html(formatThousands(priceafterchietkhau, ','));
                    $("#<%=hdfTotalPrice.ClientID%>").val(totalmoney);
                    var refund = 0;
                    if (parseFloat($("#<%=hdfDonHangTra.ClientID%>").val()) > 0) {
                        refund = parseFloat($("#<%=hdfDonHangTra.ClientID%>").val());
                    }

                    $(".totalpricedetail").html(formatThousands((totalmoney - refund), ","));
                    $("#<%=hdfTongTienConLai.ClientID%>").val(totalmoney - refund);
                    countGuestChange();
                } else {

                    $(".totalproductQuantity").html(formatThousands(0, ',') + " sản phẩm");
                    $(".totalpriceorder").html(formatThousands(0, ','));
                    $(".totalGuestChange").html(formatThousands(0, ','));
                    $(".totalpriceorderall").html(formatThousands(0, ','));
                    $(".priceafterchietkhau").html(formatThousands(0, ','));
                }
            }

            // check empty
            function notEmpty() {
                if ($("#<%=pDiscount.ClientID%>").val() == '') {
                    var dis = 0;
                    $("#<%=pDiscount.ClientID%>").val(formatThousands(dis, ','));
                }
                if ($("#<%=pFeeShip.ClientID%>").val() == '') {
                    var fee = 0;
                    $("#<%=pFeeShip.ClientID%>").val(formatThousands(fee, ','));
                }
                if ($("#<%=pGuestPaid.ClientID%>").val() == '') {
                    var pain = 0;
                    $("#<%=pGuestPaid.ClientID%>").val(formatThousands(pain, ','));
                }

            }

            // count total order
            function countTotal() {
                var total = parseFloat($("#<%=hdfTotalPriceNotDiscount.ClientID%>").val());
                var quantity = parseFloat($("#<%=hdfTotalQuantity.ClientID%>").val());
                notEmpty();
                var dis = $("#<%=pDiscount.ClientID%>").val();
                var fs = $("#<%=pFeeShip.ClientID%>").val();

                var discount = parseFloat(dis.replace(/\,/g, ''));
                var feeship = parseFloat(fs.replace(/\,/g, ''));
                $("#<%=hdfcheck.ClientID%>").val(discount);
                var totalleft = total + feeship - discount * quantity;
                //alert(discount + " - " + feeship);
                var priceafterchietkhau = total - discount * quantity;

                $(".totalpriceorderall").html(formatThousands(totalleft, ','));
                $(".priceafterchietkhau").html(formatThousands(priceafterchietkhau, ','));

                var refund = 0;
                if (parseFloat($("#<%=hdfDonHangTra.ClientID%>").val()) > 0) {
                    refund = parseFloat($("#<%=hdfDonHangTra.ClientID%>").val());
                }

                $(".totalpricedetail").html(formatThousands((totalleft - refund), ","));
                $("#<%=hdfTongTienConLai.ClientID%>").val(totalleft - refund);
                $("#<%=hdfTotalPrice.ClientID%>").val(totalleft);
                countGuestChange();
            }

            // get product price
            function getProductPrice(obj) {
                var customertype = obj.val();
                if ($(".product-result").length > 0) {
                    var totalprice = 0;
                    $(".product-result").each(function() {
                        var giasi = $(this).attr("data-giabansi");
                        var giale = $(this).attr("data-giabanle");
                        if (customertype == 1) {
                            if (giale == 0)
                                giale = giasi;
                            $(this).find(".gia-san-pham").attr("data-price", giale).html(formatThousands(giale, ','));
                        } else {
                            $(this).find(".gia-san-pham").attr("data-price", giasi).html(formatThousands(giasi, ','));
                        }
                    });
                    getAllPrice();
                }
            }

            // show popup
            function showPopup(content) {
                var obj = $('body');
                $(obj).attr('onkeydown', 'keyclose_ms(event)');
                var bg = "<div id='bg_popup'></div>";
                var fr = "<div id='pupip' class=\"columns-container1\"><div class=\"container\" id=\"columns\"><div class='row'><div class=\"center_column col-xs-12 col-sm-8\" id=\"popup_content\"><a onclick='closePopup()' class='close_message'></a>";
                fr += "     <div class=\"changeavatar\">";
                fr += content;
                fr += "     </div>";
                fr += "   </div>";
                fr += "</div></div></div>";
                $(bg).appendTo($(obj)).show().animate({
                    "opacity": 0.7
                }, 0);
                $(fr).appendTo($(obj));
            }

            // close popup when press escape
            function keyclose_ms(e) {
                if (e.keyCode == 27) {
                    closePopup();
                }
            }

            // close popup
            function closePopup() {
                $("#pupip").remove();
                $("#bg_popup").remove();
            }

            // press key
            function keypress(e) {
                var keypressed = null;
                if (window.event) {
                    keypressed = window.event.keyCode; //IE
                } else {
                    keypressed = e.which; //NON-IE, Standard
                }
                if (keypressed < 48 || keypressed > 57) {
                    if (keypressed == 8 || keypressed == 127) {
                        return;
                    }
                    return false;
                }
            }

            // format price
            var formatThousands = function(n, dp) {
                var s = '' + (Math.floor(n)),
                    d = n % 1,
                    i = s.length,
                    r = '';
                while ((i -= 3) > 0) {
                    r = ',' + s.substr(i, 3) + r;
                }
                return s.substr(0, i + 3) + r +
                    (d ? '.' + Math.round(d * Math.pow(10, dp || 2)) : '');
            };
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
