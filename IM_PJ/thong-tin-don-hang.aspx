<%@ Page Title="Thông tin đơn hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="thong-tin-don-hang.aspx.cs" Inherits="IM_PJ.thong_tin_don_hang" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="parent" runat="server">
        <main id="main-wrap">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title left">Chỉnh sửa đơn hàng</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panelborderheading">
                            <div class="panel-heading clear">
                                <h3 class="page-title left not-margin-bot">Thông tin đơn hàng</h3>
                            </div>
                            <div class="panel-body">
                                <div class="row pad">
                                    <div class="col-md-2">
                                        <div class="left pad10">Mã đơn hàng: </div>
                                        <div class="orderid">
                                            <asp:Literal ID="ltrOrderID" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="left pad10">Nhân viên tạo đơn: </div>
                                        <div class="ordercreateby">
                                            <asp:Literal ID="ltrCreateBy" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="left pad10">Ngày tạo: </div>
                                        <div class="ordercreatedate">
                                            <asp:Literal ID="ltrCreateDate" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="left pad10">Ngày hoàn tất: </div>
                                        <div class="orderdatedone">
                                            <asp:Literal ID="ltrDateDone" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="row pad">
                                    <div class="col-md-2">
                                        <div class="left pad10">Loại đơn: </div>
                                        <div class="ordertype">
                                            <asp:Literal ID="ltrOrderType" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="left pad10">Số lượng: </div>
                                        <div class="orderquantity">
                                            <asp:Literal ID="ltrOrderQuantity" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="left pad10">Tổng tiền: </div>
                                        <div class="ordertotalprice">
                                            <asp:Literal ID="ltrOrderTotalPrice" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="left pad10">Trạng thái: </div>
                                        <div class="orderstatus">
                                            <asp:Literal ID="ltrOrderStatus" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="row pad">
                                    <div class="col-md-12">
                                        <div class="left pad10">Ghi chú: </div>
                                        <div class="ordernote">
                                            <asp:Literal ID="ltrOrderNote" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="row pad">
                                    <div class="col-md-12">
                                        <a href="javascript:;" class="btn primary-btn fw-btn not-fullwidth" style="float: left" onclick="printInvoice()">In hóa đơn</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panelborderheading">
                            <div class="panel-heading clear">
                                <h3 class="page-title left not-margin-bot">Thông tin khách hàng</h3>
                                <a href="javascript:;" class="search-customer" onclick="searchCustomer()"><i class="fa fa-search" aria-hidden="true"></i> Tìm khách hàng (F1)</a>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Họ tên</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullname" ErrorMessage="(*)" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtFullname" CssClass="form-control" runat="server" Enabled="false" placeholder="(F2)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Điện thoại</label>
                                            <asp:RequiredFieldValidator ID="re" runat="server" ControlToValidate="txtPhone" ErrorMessage="(*)" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Nick đặt hàng</label>
                                            <asp:TextBox ID="txtNick" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Địa chỉ</label>
                                            <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Zalo</label>
                                            <asp:TextBox ID="txtZalo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Facebook</label>
                                            <div class="row">
                                                <div class="col-md-10 fb">
                                                <asp:TextBox ID="txtFacebook" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="row">
                                                        <span class="link-facebook"><asp:Literal ID="ltrFb" runat="server"></asp:Literal></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row view-detail">
                                    <asp:Literal ID="ltrViewDetail" runat="server"></asp:Literal>
                                </div>
                                <div class="form-row discount-info">
                                    <asp:Literal ID="ltrDiscountInfo" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel-post">
                            <asp:Literal ID="ltrCustomerType" runat="server"></asp:Literal>
                            <div class="post-above clear">
                                <div class="search-box left">
                                    <input type="text" id="txtSearch" class="form-control" placeholder="SKU (F3)">
                                </div>
                                <div class="right">
                                    <a href="javascript:;" class="link-btn" onclick="searchProduct()"><i class="fa fa-search"></i></a>
                                </div>
                            </div>
                            <div class="post-body search-product-content clear">
                                <table class="table table-checkable table-product custom-font-size-12">
                                    <thead>
                                        <tr>
                                            <th class="order-item-header">#</th>
                                            <th class="image-item">Ảnh</th>
                                            <th class="name-item">Sản phẩm</th>
                                            <th class="sku-item">Mã</th>
                                            <th class="variable-item">Thuộc tính</th>
                                            <th class="price-item">Giá</th>
                                            <th class="quantity-item">Kho</th>
                                            <th class="quantity-item">Số lượng</th>
                                            <th class="total-item">Thành tiền</th>
                                            <th class="trash-item"></th>
                                        </tr>
                                    </thead>
                                </table>
                                <div class="search-product-content">
                                    <table class="table table-checkable table-product custom-font-size-12">
                                        <tbody class="content-product">
                                            <asp:Literal ID="ltrProducts" runat="server"></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Số lượng</div>
                                <div class="right totalproductQuantity">
                                    <asp:Literal ID="ltrProductQuantity" runat="server"></asp:Literal>
                                </div>

                            </div>
                            <div class="post-row clear">
                                <div class="left">Thành tiền</div>
                                <div class="right totalpriceorder">
                                    <asp:Literal ID="ltrTotalNotDiscount" runat="server"></asp:Literal>
                                </div>
                            </div>

                            <div class="post-row clear">
                                <div class="left">Chiết khấu</div>
                                <div class="right totalDiscount">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pDiscount" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0"
                                        oninput="countTotal()">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Sau chiết khấu</div>
                                <div class="right priceafterchietkhau">
                                    <asp:Literal ID="ltrTotalAfterCK" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="post-row clear">
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
                                <div class="right totalpriceorderall price-red">
                                    <asp:Literal ID="ltrTotalprice" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="post-row clear returnorder hide">
                                <div class="left">
                                    Đơn hàng trả
                                    <a href="javascript:;" class="find3 hide" style="text-decoration: underline; float: right; font-size: 12px; font-style: italic; padding-left: 10px;" onclick="searchReturnOrder()">(Tìm đơn khác)</a>
                                    <a href="javascript:;" class="find3 hide" style="text-decoration: underline; float: right; font-size: 12px; font-style: italic; padding-left: 10px;" onclick="deleteReturnOrder()">(Bỏ qua)</a>
                                    <a href="javascript:;" class="find2 hide" style="text-decoration: underline; float: right; font-size: 12px; font-style: italic; padding-left: 10px;"></a>
                                </div>
                                <div class="right totalpriceorderrefund"><asp:Literal runat="server" ID="ltrTotalPriceRefund"></asp:Literal></div>
                            </div>
                            <div class="post-row clear refund hide">
                                <div class="left">Tổng tiền còn lại</div>
                                <div class="right totalpricedetail">
                                    <asp:Literal runat="server" ID="ltrtotalpricedetail"></asp:Literal>
                                </div>
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
                                <div class="right totalGuestChange">
                                    <asp:Literal ID="ltrTotalchagne" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panelborderheading">
                            <div class="panel-heading clear">
                                <h3 class="page-title left not-margin-bot">Trạng thái đơn hàng</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-row">
                                    <div class="row-left">
                                        Trạng thái thanh toán
                                    </div>
                                    <div class="row-right">
                                        <asp:DropDownList ID="ddlPaymentStatus" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="Chưa thanh toán"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Thanh toán thiếu"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Đã thanh toán"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="row-left">
                                        Trạng thái xử lý
                                    </div>
                                    <div class="row-right">
                                        <asp:DropDownList ID="ddlExcuteStatus" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="Đang chờ xử lý"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Đã xử lý"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Đã hủy"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="row-left">
                                        Phương thức thanh toán
                                    </div>
                                    <div class="row-right">
                                        <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="Tiền mặt"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Chuyển khoản"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Thu hộ"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Công nợ"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="row-left">
                                        Phương thức giao hàng
                                    </div>
                                    <div class="row-right">
                                        <asp:DropDownList ID="ddlShippingType" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="Lấy trực tiếp"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Chuyển bưu điện"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Chuyển proship"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Chuyển xe"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="row-left">
                                        Ghi chú đơn hàng
                                    </div>
                                    <div class="row-right">
                                        <asp:TextBox ID="txtOrderNote" runat="server" CssClass="form-control" placeholder="Ghi chú"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="panel-post">
                                    <div class="post-table-links clear">
                                        <a href="javascript:;" class="btn link-btn" id="payall" style="background-color: #f87703; float: right" onclick="payAll()"><i class="fa fa-floppy-o"></i> Xác nhận</a>
                                        <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" Style="display: none" />
                                        <a href="javascript:;" class="btn link-btn" style="background-color: #ffad00; float: right;" onclick="searchReturnOrder()"><i class="fa fa-refresh"></i> Đổi trả</a>
                                    </div>
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
            <asp:HiddenField ID="hdfPaymentStatus" runat="server" />
            <asp:HiddenField ID="hdfExcuteStatus" runat="server" />
            <asp:HiddenField ID="hdfIsDiscount" runat="server" />
            <asp:HiddenField ID="hdfDiscountAmount" runat="server" />
            <asp:HiddenField ID="hdfIsMain" runat="server" />
            <asp:HiddenField ID="hdfTotalPriceNotDiscountNotFee" runat="server" />
            <asp:HiddenField ID="hdfListSearch" runat="server" />
            <asp:HiddenField ID="hdfTotalQuantity" runat="server" />
            <asp:HiddenField ID="hdfcheck" runat="server" />
            <asp:HiddenField ID="hdftotal" runat="server" />
            <asp:HiddenField ID="hdfCurrentValue" runat="server" />
            <asp:HiddenField ID="hdfDelete" runat="server" />
            <asp:HiddenField ID="hdfDele" runat="server" />
            <asp:HiddenField ID="hdfDonHangTra" runat="server" />
            <asp:HiddenField ID="hdfChietKhau" runat="server" />
            <asp:HiddenField ID="hdfTongTienConLai" runat="server" />
            <asp:HiddenField ID="hdfSoLuong" runat="server" />
            <asp:HiddenField runat="server" ID="hdfcheckR" />

            <div id="printcontent" style="display: none">
                <asp:Literal ID="ltrprint" runat="server"></asp:Literal>
            </div>
            <div id="printOrder" style="display: none">
                <asp:Literal ID="ltrPrintOrder" runat="server"></asp:Literal>

            </div>
        </main>
    </asp:Panel>
    <style>
        .search-product-content {
            background: #fff;
        }
        .search-box {
            width: 90%;
        }

        #txtSearch {
            width: 100%;
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
            padding: 20px;
            right: 0%;
            margin: 0 auto;
        }

        .pad {
            padding-bottom: 30px;
        }

        .pad10 {
            padding-right: 10px;
        }

        .padinfo {
            padding-bottom: 15px;
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
            // order of item list
            var orderItem = 0;

            // search Product by SKU
            $("#txtSearch").keydown(function(event) {
                if (event.which === 13) {
                    searchProduct();
                    event.preventDefault();
                    return false;
                }
            });

            // check data before close page or refresh page
            function stopNavigate(event) {
                $(window).off('beforeunload');
            }

            $(window).bind('beforeunload', function(e) {
                if ($("#payall").hasClass("payall-clicked")) {
                    e = null;
                } else {
                    if ($(".product-result").length > 0 || $("#<%=txtPhone.ClientID%>").val() != "" || $("#<%= txtFullname.ClientID%>").val() != "")
                        return true;
                    else
                        e = null;
                }
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

            // display return order after page load
            var returnorder = document.getElementById('<%= hdfcheckR.ClientID%>').defaultValue;
            if (returnorder != "") {
                $(".refund").removeClass("hide");
                var t = returnorder.split(',');
                $("#<%=hdfDonHangTra.ClientID%>").val(t[1]);
                $(".find3").removeClass("hide");
                $(".find1").addClass("hide");
                $(".find2").html("(Xem đơn hàng " + t[0] + ")");
                $(".find2").attr("onclick", "ViewOrder(" + t[0] + ")");
                $(".find2").removeClass("hide");
                $(".returnorder").removeClass("hide");
                $(".totalpriceorderall").removeClass("price-red");
                $(".totalpricedetail").addClass("price-red");
            }

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
                        var zalo = $(this).find("td.zalo").html();
                        var facebook = $(this).find("td.facebook").attr("data-value");
                        var id = $(this).find("td.id").html();
                        $("#<%=txtPhone.ClientID%>").val(phone).prop('disabled', true);
                        $("#<%= txtFullname.ClientID%>").val(name).prop('disabled', true);
                        $("#<%= txtNick.ClientID%>").val(nick).prop('disabled', true);
                        $("#<%= txtAddress.ClientID%>").val(address).prop('disabled', true);
                        $("#<%= txtZalo.ClientID%>").val(zalo).prop('disabled', true);
                        $("#<%= txtFacebook.ClientID%>").parent().removeClass("width-100");
                        $("#<%= txtFacebook.ClientID%>").val(facebook).prop('disabled', true);
                        if (facebook == null) {
                            $(".link-facebook").hide();
                            $("#<%= txtFacebook.ClientID%>").parent().addClass("width-100");
                        }
                        else {
                            $("#<%= txtFacebook.ClientID%>").parent().removeClass("width-100");
                            $(".link-facebook").html("<a href=\"" + facebook + "\" class=\"btn primary-btn fw-btn not-fullwidth\" target=\"_blank\">Xem</a>").show();
                        }
                        $(".view-detail").html("<a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth\" onclick=\"viewCustomerDetail('" + id + "')\">Xem chi tiết</a><a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth clear-btn\" onclick=\"clearCustomerDetail()\">Bỏ qua</a>").show();
                        getCustomerDiscount(id);
                    }
                });
                closePopup();
            }

            // clear customer detail
            function clearCustomerDetail() {
                $("#<%=hdfCheckCustomer.ClientID%>").val("0");
                $("#<%=txtPhone.ClientID%>").val("").prop('disabled', false);
                $("#<%= txtFullname.ClientID%>").val("").prop('disabled', false);
                $("#<%= txtNick.ClientID%>").val("").prop('disabled', false);
                $("#<%= txtAddress.ClientID%>").val("").prop('disabled', false);
                $("#<%= txtZalo.ClientID%>").val("").prop('disabled', false);
                $("#<%= txtFacebook.ClientID%>").val("").prop('disabled', false);
                $(".view-detail").html("").hide();
                $(".discount-info").html("").hide();
                $(".link-facebook").html("").hide();
                $("#<%= txtFacebook.ClientID%>").parent().addClass("width-100");
                $("#<%= txtFullname.ClientID%>").focus();
                getAllPrice();
            }

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
                var t = document.getElementById('<%= hdfcheckR.ClientID%>').defaultValue;
                var existorder = t.split(',');
                if (!isBlank(order)) {
                    $.ajax({
                        type: "POST",
                        url: "/thong-tin-don-hang.aspx/findReturnOrder",
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
                                    $(".find2").attr("onclick", "ViewOrder(" + data.ID + ")");
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
                            } else if (order == existorder[0]) {
                                alert("Đơn hàng đổi trả này đã thêm vào trước đó!\nHãy đổi về trạng thái 'Chưa trừ tiền' để thêm lại lần nữa!\nSau khi đổi trạng thái, trở lại giao diện này để thêm lại!");
                                ViewOrder(order);
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
                    url: "/thong-tin-don-hang.aspx/findReturnOrder",
                    data: "{order:'0', remove:'1'}",
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

            // print invoice after submit order
            function printInvoice2() {
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
                setTimeout(function () { newWin.close(); }, 10);
            }

            function printInvoice() {
                var html = "";

                $('link').each(function () { // find all <link tags that have
                    if ($(this).attr('rel').indexOf('stylesheet') != -1) { // rel="stylesheet"
                        html += '<link rel="stylesheet" href="/App_Themes/Ann/hoadon/hoadon.css" type="text/css"/><link rel="stylesheet" href="/App_Themes/Ann/barcode/style.css" type="text/css"/><link rel="stylesheet" href="/App_Themes/Ann/css/responsive.css" type="text/css"/>';
                    }
                });
                html += '<body onload="window.focus(); window.print()">' + $("#printOrder").html() + '</body>';
                var w = window.open("", "print");
                if (w) { w.document.write(html); w.document.close() }
            }

            // pay order on click button
            function payAll() {
                var phone = $("#<%=txtPhone.ClientID%>").val();
                var name = $("#<%= txtFullname.ClientID%>").val();
                var nick = $("#<%= txtNick.ClientID%>").val();
                var address = $("#<%= txtAddress.ClientID%>").val();
                if (phone != "" && name != "" && nick != "" && address != "") {
                    if ($(".product-result").length > 0) {
                        var list = "";
                        var count = 0;
                        var ordertype = $(".customer-type").val();
                        var checkoutin = false;
                        $(".product-result").each(function() {
                            var orderDetailID = $(this).attr("data-orderdetailid");
                            var id = $(this).attr("data-id");
                            var sku = $(this).attr("data-sku");
                            var producttype = $(this).attr("data-producttype");
                            var productnariablename = $(this).attr("data-productnariablename");
                            var productvariablevalue = $(this).attr("data-productvariablevalue");
                            var productname = $(this).attr("data-productname");
                            var productimageorigin = $(this).attr("data-productimageorigin");
                            var productvariable = $(this).attr("data-productvariable");
                            var price = $(this).find(".gia-san-pham").attr("data-price");
                            var productvariablesave = $(this).attr("data-productvariablesave");
                            var quantity = parseFloat($(this).find(".in-quanlity").val());
                            var quantityInstock = parseFloat($(this).attr("data-quantityinstock"));

                            if (quantity > 0) {
                                if (quantity > quantityInstock) {
                                    checkoutin = true;
                                }

                                list += id + "," + sku + "," + producttype + "," + productnariablename + "," + productvariablevalue + "," + quantity + "," +
                                    productname + "," + productimageorigin + "," + productvariablesave + "," + price + "," + productvariablesave + "," +
                                    orderDetailID + ";";
                                count++;
                            }
                        });
                        if (count > 0) {
                            $("#<%=hdfOrderType.ClientID %>").val(ordertype);
                            $("#<%=hdfListProduct.ClientID%>").val(list);
                            insertOrder();
                        } else {
                            alert("Vui lòng nhập sản phẩm!");
                            $("#txtSearch").focus();
                        }
                    } else {
                        alert("Vui lòng nhập sản phẩm!");
                        $("#txtSearch").focus();
                    }
                } else {
                    alert("Vui lòng nhập thông tin khách hàng!");
                    $("#<%= txtFullname.ClientID%>").focus();
                }
            }

            // insert order
            function addPayAllClicked() {
                $("#payall").addClass("payall-clicked");
            }

            // insert order
            function insertOrder() {
                var phone = $("#<%=txtPhone.ClientID%>").val();
                var fullname = $("#<%=txtFullname.ClientID%>").val();
                if (isBlank(phone) || isBlank(fullname)) {
                    alert("Vui lòng nhập thông tin khách hàng!");
                } else {
                    $("#<%=btnOrder.ClientID%>").click();
                }
            }

            // show popup Order status
            function showOrderStatus(content) {
                var obj = $('body');
                $(obj).attr('onkeydown', 'keyclose_ms(event)');
                var bg = "<div id='bg_popup'></div>";
                var fr = "<div id='pupip' class=\"columns-container1\"><div class=\"container\" id=\"columns\"><div class='row'>" +
                    "  <div class=\"center_column col-xs-12 col-sm-8\" id=\"popup_content\"><a style='cursor:pointer;right:5px;' onclick='close_popup_ms()' class='close_message'></a>";
                fr += "     <div class=\"changeavatar\">";
                fr += "         <div class=\"form-row\">";
                fr += "             <h2>Hoàn tất đơn hàng</h2>";
                fr += "         </div>";
                fr += "         <div class=\"form-row\">";
                fr += "             <div class=\"row-left\" style=\"width:30%;line-height:40px\">Trạng thái thanh toán:</div>";
                fr += "             <div class=\"row-right\" style=\"width:65%;\">"
                fr += "                 <select class=\"form-control payment-status\">";
                fr += "                     <option value=\"1\">Chưa thanh toán</option>";
                fr += "                     <option value=\"2\">Thanh toán thiếu</option>";
                fr += "                     <option value=\"3\">Đã thanh toán</option>";
                fr += "                 </select>";
                fr += "             </div>";
                fr += "         </div>";
                fr += "         <div class=\"form-row\">";
                fr += "             <div class=\"row-left\" style=\"width:30%;line-height:40px\">Trạng thái xử lý:</div>";
                fr += "             <div class=\"row-right\" style=\"width:65%;\">"
                if (content == true) {
                    fr += "                 <label style=\"line-height:40px;\">Đang chờ xử lý</label>";
                } else {
                    fr += "                 <select class=\"form-control excute-status\">";
                    fr += "                     <option value=\"1\">Đang chờ xử lý</option>";
                    fr += "                     <option value=\"2\">Đã xử lý</option>";
                    fr += "                     <option value=\"3\">Đã hủy</option>";
                    fr += "                 </select>";
                }
                fr += "             </div>";
                fr += "         </div>";
                fr += "         <div class=\"form-row\">";
                fr += "             <div class=\"row-left\" style=\"width:30%;line-height:40px\">Phương thức thanh toán:</div>";
                fr += "             <div class=\"row-right\" style=\"width:65%;\">"
                fr += "                 <select class=\"form-control payment-type\">";
                fr += "                     <option value=\"2\">Chuyển khoản</option>";
                fr += "                     <option value=\"1\">Tiền mặt</option>";
                fr += "                     <option value=\"3\">Thu hộ</option>";
                fr += "                     <option value=\"4\">Công nợ</option>";
                fr += "                 </select>";
                fr += "             </div>";
                fr += "         </div>";
                fr += "         <div class=\"form-row\">";
                fr += "             <div class=\"row-left\" style=\"width:30%;line-height:40px\">Phương thức giao hàng:</div>";
                fr += "             <div class=\"row-right\" style=\"width:65%;\">"
                fr += "                 <select class=\"form-control shipping-type\">";
                fr += "                     <option value=\"1\">Lấy trực tiếp</option>";
                fr += "                     <option value=\"2\">Chuyển bưu điện</option>";
                fr += "                     <option value=\"3\">Chuyển proship</option>";
                fr += "                     <option value=\"4\">Chuyển xe</option>";
                fr += "                 </select>";
                fr += "             </div>";
                fr += "         </div>";
                fr += "         <div class=\"clearfix\"></div>";
                fr += "         <div class=\"clearfix\"></div>";
                fr += "         <div class=\"btn-content\" style=\"text-align:center;\">";
                fr += "             <a class=\"btn primary-btn fw-btn not-fullwidth\" style=\"padding:10px 30px;margin:10px 0\" href=\"javascript:;\" onclick=\"insertOrder()\" >Tạo đơn hàng</a>";
                fr += "         </div>";
                fr += "     </div>";
                fr += "   </div>";
                fr += "</div></div></div>";
                $(bg).appendTo($(obj)).show().animate({
                    "opacity": 0.7
                }, 800);
                $(fr).appendTo($(obj));
                setTimeout(function() {
                    $('#pupip').show().animate({
                        "opacity": 1,
                        "top": 20 + "%"
                    }, 200);
                    $("#bg_popup").attr("onclick", "close_popup_ms()");
                }, 1000);
            }

            // count guest change
            function countGuestChange() {
                var totalrefund = 0;
                if (parseFloat($("#<%=hdfDonHangTra.ClientID%>").val()) > 0) {
                    totalrefund = parseFloat($("#<%=hdfDonHangTra.ClientID%>").val());
                }
                var gp1 = $("#<%=pGuestPaid.ClientID%>").val();

                var gp = parseFloat(gp1.replace(/\,/g, ''));
                if (gp > 0) {
                    var totalprice = parseFloat($("#<%= hdfTotalPrice.ClientID%>").val());
                    var leftchange = -gp + totalprice - totalrefund;
                    $(".totalGuestChange").html(formatThousands(-leftchange, ","));
                    <%-- $("#<%=hdfTotalPrice.ClientID%>
                    ").val(leftchange);--%>
                } else {
                    var totalprice = parseFloat($("#<%= hdfTotalPrice.ClientID%>").val());
                    var leftchange = totalprice - totalrefund;
                    $(".totalGuestChange").html(formatThousands(-leftchange, ","));
                    <%-- $("#<%=hdfTotalPrice.ClientID%>
                    ").val(leftchange);--%>
                }
            }

            // search product by SKU
            function searchProduct() {
                var textsearch = $("#txtSearch").val();
                var customerType = $(".customer-type").val();
                if (!isBlank(textsearch)) {
                    $.ajax({
                        type: "POST",
                        url: "/thong-tin-don-hang.aspx/getProduct",
                        data: "{textsearch:'" + textsearch + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            var count = 0;
                            var data = JSON.parse(msg.d);

                            if (data.length > 1) {
                                $("#<%=hdfListSearch.ClientID%>").val(textsearch);
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
                                    html += ("<td class=\"quantity-item\"><input class=\"quantity\" type=\"text\" min=\"1\" max=\"" + item.QuantityInstock + "\" value=\"1\"></td>");
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
                                    orderItem++;
                                    html += "<tr class=\"product-result\" data-giabansi=\"" + item.Giabansi + "\" data-giabanle=\"" + item.Giabanle + "\" " +
                                        "data-quantityinstock=\"" + item.QuantityInstock + "\" data-productimageorigin=\"" + item.ProductImageOrigin + "\" " +
                                        "data-productvariable=\"" + item.ProductVariable + "\" data-productname=\"" + item.ProductName + "\" " +
                                        "data-sku=\"" + item.SKU + "\" data-producttype=\"" + item.ProductType + "\" data-id=\"" + item.ID + "\" " +
                                        "data-productnariablename=\"" + item.ProductVariableName + "\" " +
                                        "data-productvariablevalue =\"" + item.ProductVariableValue + "\" " +
                                        "data-productvariablesave =\"" + item.ProductVariableSave + "\">";
                                    html += "   <td class=\"order-item\">" + orderItem + "</td>";
                                    html += "   <td class=\"image-item\">" + item.ProductImage + "</td>";
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

                                    //html += "   <td>" + item.QuantityMainInstockString + "</td>";
                                    html += "   <td class=\"quantity-item\">" + item.QuantityInstockString + "</td>";
                                    html += "   <td class=\"quantity-item\"><input type=\"text\" min=\"0\" max=\"" + item.QuantityInstock + "\" class=\"form-control in-quanlity\" value=\"1\"  onkeyup=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                                    var t = parseFloat(item.Giabansi);

                                    html += "<td class=\"total-item totalprice-view\">" + formatThousands(t, '.') + "</td>";
                                    html += "<td class=\"trash-item\"><a href=\"javascript:;\" class=\"link-btn\" onclick=\"deleteRow($(this))\"><i class=\"fa fa-trash\"></i></a></td>";
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
                                            } else {
                                                $(this).find(".in-quanlity").val(quantityinstock);
                                                var a = parseFloat(list2[j]);
                                                var price = parseFloat(quantityinstock) * parseFloat(item.Giabansi);
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
                GetProduct(item, item2);
                closePopup();
                $("#txtSearch").focus();
            }


            // get product when select multi variable
            function GetProduct(list, list2) {
                var textsearch = $("#<%=hdfListSearch.ClientID%>").val();
                var customerType = $(".customer-type").val();
                $.ajax({
                    type: "POST",
                    url: "/thong-tin-don-hang.aspx/getProduct",
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
                                            orderItem++
                                            var vl1 = item.QuantityMainInstockString;
                                            var vl2 = parseFloat(vl1.replace(/\,/g, ''));
                                            var soluong = vl2 - parseFloat(list2[j])
                                            html += "<tr class=\"product-result\" data-giabansi=\"" + item.Giabansi + "\" data-giabanle=\"" + item.Giabanle + "\" " +
                                                "data-quantityinstock=\"" + item.QuantityInstock + "\" data-productimageorigin=\"" + item.ProductImageOrigin + "\" " +
                                                "data-productvariable=\"" + item.ProductVariable + "\" data-productname=\"" + item.ProductName + "\" " +
                                                "data-sku=\"" + item.SKU + "\" data-producttype=\"" + item.ProductType + "\" data-id=\"" + item.ID + "\" " +
                                                "data-productnariablename=\"" + item.ProductVariableName + "\" " +
                                                "data-productvariablevalue =\"" + item.ProductVariableValue + "\" " +
                                                "data-productvariablesave =\"" + item.ProductVariableSave + "\">";
                                            html += "   <td class=\"order-item\">" + orderItem + "</td>";
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

                                            //html += "   <td class=\"quantity-item\">" + item.QuantityMainInstockString + "</td>";
                                            html += "   <td class=\"quantity-item soluong\">" + item.QuantityMainInstockString + "</td>";

                                            var t = 0;

                                            if (list2[j] > item.QuantityInstock) {
                                                html += "   <td class=\"quantity-item\"><input type=\"text\" min=\"1\" max=\"" + item.QuantityInstock + "\" class=\"form-control in-quanlity\" value=\"" + item.QuantityInstock + "\"  onkeyup=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                                                t = parseFloat(item.QuantityInstock) * parseFloat(item.Giabansi);
                                            } else {
                                                html += "   <td class=\"quantity-item\"><input type=\"text\" min=\"1\" max=\"" + (parseFloat(item.QuantityInstock) + parseFloat(list2[j])) + "\" class=\"form-control in-quanlity\" value=\"" + list2[j] + "\"  onkeyup=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                                                t = parseFloat(list2[j]) * parseFloat(item.Giabansi);
                                            }
                                            html += "<td class=\"total-item totalprice-view\">" + formatThousands(t, '.') + "</td>";
                                            html += "<td class=\"trash-item\"><a href=\"javascript:;\" class=\"link-btn\" onclick=\"deleteRow($(this))\"><i class=\"fa fa-trash\"></i></a></td>";
                                            html += "</tr>";
                                        } else if (check == true) {
                                            $(".product-result").each(function() {
                                                var existedSKU = $(this).attr("data-sku");
                                                if (sku == existedSKU) {
                                                    var quantityinstock = parseFloat($(this).attr("data-quantityinstock"));
                                                    var quantityCurrent = parseFloat($(this).find(".in-quanlity").val());
                                                    var quantityInstock = $(this).find(".soluong").html();
                                                    var vl1 = parseFloat(quantityInstock.replace(/\,/g, ''));
                                                    var soluong = vl1 - parseFloat(list2[j]);
                                                    var newquantity = quantityCurrent + parseInt(list2[j]);
                                                    if (newquantity <= quantityinstock) {
                                                        $(this).find(".in-quanlity").val(newquantity);
                                                        //$(this).find(".soluong").html(soluong);
                                                        var price = parseFloat(newquantity) * parseFloat(item.Giabansi);
                                                        $(this).find(".totalprice-view").html(formatThousands(price, '.'));
                                                        getAllPrice();
                                                    } else {
                                                        $(this).find(".in-quanlity").val(quantityinstock);
                                                        var a = parseFloat(list2[j]);
                                                        //$(this).find(".soluong").html(0);
                                                        var price = parseFloat(quantityinstock) * parseFloat(item.Giabansi);
                                                        $(this).find(".totalprice-view").html(formatThousands(price, '.'));
                                                        getAllPrice();
                                                    }
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

            // remove product form list
            function deleteRow(obj) {
                if ($("#<%=hdfDelete.ClientID%>").val() == "") {
                    var list = "";
                } else {
                    var list = $("#<%=hdfDelete.ClientID%>").val();
                }

                var c = confirm('Bạn muốn xóa sản phẩm này?');
                if (c) {
                    obj.parent().parent().remove();
                    var orderid = obj.parent().parent().attr("data-orderdetailid");
                    if (orderid > 0) {
                        var productnariablename = obj.parent().parent().attr("data-productnariablename");
                        var productvariablevalue = obj.parent().parent().attr("data-productvariablevalue");
                        var productimageorigin = obj.parent().parent().attr("data-productimageorigin");
                        var productname = obj.parent().parent().attr("data-productname");
                        var productvariablesave = obj.parent().parent().attr("data-productvariablesave");
                        var id = obj.parent().parent().attr("data-id");
                        list += obj.parent().parent().attr("data-orderdetailid") + "*" + obj.parent().parent().attr("data-sku") + "*" + obj.parent().parent().find(".in-quanlity").val() + "*" + productnariablename + "*" + productvariablevalue + "*" + productimageorigin + "*" + productname + "*" + productvariablesave + "*" + id + ";";
                        if ($(".product-result").length == 0) {
                            $(".excute-in").hide();
                        }
                    }
                }

                if (!isBlank(list)) {
                    $.ajax({
                        type: "POST",
                        url: "/thong-tin-don-hang.aspx/Delete",
                        data: "{list:'" + list + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            var count = 0;
                            var data = JSON.parse(msg.d);
                            if (data != null) {
                                swal("Xóa sản phẩm thành công");
                                getAllPrice();
                            }
                        }
                    })
                }
            }

            // delete all product by click button
            function deleteProduct() {
                var c = confirm("Bạn muốn xóa tất cả sản phẩm?");
                if (c == true) {
                    $(".product-result").remove();
                    getAllPrice();
                    $(".totalproductQuantity").html("0");
                    $(".totalpriceorder").html("0");
                    $("#<%=pDiscount.ClientID%>").val(0);
                    $(".priceafterchietkhau").html("0");
                    $("#<%=pFeeShip.ClientID%>").val(0);
                    $(".totalpriceorderall").html("0");

                    $("#<%=hdfTotalPriceNotDiscount.ClientID%>").val(0);
                    $("#<%=hdfTotalPrice.ClientID%>").val(0);
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
                        alert('Vui lòng nhập số lượng để xuất kho');
                    }
                } else {
                    alert("Vui lòng nhập sản phẩm");
                }
            }

            // change quantity of product
            function checkQuantiy(obj) {
                var mainInstock = parseFloat(obj.parent().parent().attr("data-quantitymaininstock"));
                var instock = parseFloat(obj.parent().parent().attr("data-quantityinstock"));
                var max = parseFloat(obj.attr("data-quantity"));
                var currentVal = parseFloat(obj.val());
                var ismain = $("#<%=hdfIsMain.ClientID%>").val();
                var check = true;
                if (currentVal > instock) {
                    if (ismain == 1) {
                        if (currentVal > instock) {
                            obj.val("");
                            obj.val(instock);
                        }
                    } else {
                        var neednum = currentVal - instock;
                        if (neednum <= mainInstock) {
                            obj.val("");
                            obj.val(currentVal);
                        } else {
                            var totalinstock = instock + mainInstock;
                            obj.val("");
                            obj.val(totalinstock);
                        }
                    }
                }
                getAllPrice();
            }

            function checkQuantiy1(obj) {

                var mainInstock = parseFloat(obj.parent().parent().attr("data-quantitymaininstock"));

                var instock = parseFloat(obj.parent().parent().attr("data-quantityinstock"));
                var max = parseFloat(obj.attr("data-quantity"));
                var num = max + instock;

                var currentVal = parseFloat(obj.val());
                var ismain = $("#<%=hdfIsMain.ClientID%>").val();
                var check = true;
                if (currentVal > num) {
                    if (ismain == 1) {
                        if (currentVal > num) {
                            obj.val("");
                            obj.val(num);
                        }
                    }
                    else {
                        var neednum = currentVal - instock;
                        if (neednum <= mainInstock) {
                            obj.val("");
                            obj.val(currentVal);
                        }
                        else {
                            var totalinstock = instock + mainInstock;
                            obj.val("");
                            obj.val(totalinstock);
                        }
                    }
                }
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
                    
                    $(".totalpriceorder").html(formatThousands(totalprice, ','));
                    $("#<%=hdfTotalPriceNotDiscountNotFee.ClientID%>").val(totalprice);
                    $("#<%=hdfTotalQuantity.ClientID%>").val(productquantity);
                    var isDiscount = $("#<%=hdfIsDiscount.ClientID%>").val();
                    var totalDiscount = 0;
                    var totalleft = 0;
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
                        var totalck = amount * productquantity;
                        totalleft = totalprice - totalck;
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
                    var feeship = parseFloat(fs.replace(/\,/g, ''));
                    var priceafterchietkhau = totalleft;
                    totalleft += feeship;
                    var totalmoney = totalleft + feeship;

                    $("#<%=pDiscount.ClientID%>").val(formatThousands(totalDiscount, ','));
                    $(".totalpriceorderall").html(formatThousands(totalleft, ','));
                    $(".priceafterchietkhau").html(formatThousands(priceafterchietkhau, ','));
                    $(".totalGuestChange").html(formatThousands(totalleft, ','));
                    $("#<%=hdfTotalPrice.ClientID%>").val(totalleft);
                    var refund = 0;
                    if (parseFloat($("#<%=hdfDonHangTra.ClientID%>").val()) > 0) {
                        refund = parseFloat($("#<%=hdfDonHangTra.ClientID%>").val());
                    }

                    $(".totalpricedetail").html(formatThousands((totalmoney - refund), ","));
                    $("#<%=hdfTongTienConLai.ClientID%>").val(totalmoney - refund);
                    countGuestChange();
                } else {
                    var c = confirm('Đơn hàng này sẽ được lưu ở trạng thái hủy');
                    if (c) {
                        $.ajax({
                            type: "POST",
                            url: "/thong-tin-don-hang.aspx/UpdateStatus",
                            data: "{}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function(msg) {
                                if (msg.d != null) {
                                    window.location.assign("/danh-sach-don-hang.aspx");
                                }
                            },
                            error: function(xmlhttprequest, textstatus, errorthrow) {
                                alert('lỗi');
                            }
                        });

                    } else {
                        $(".totalproductQuantity").html(formatThousands(0, ',') + " sản phẩm");
                        $(".totalpriceorder").html(formatThousands(0, ','));
                        $(".totalGuestChange").html(formatThousands(0, ','));
                        $(".totalpriceorderall").html(formatThousands(0, ','));
                        $(".priceafterchietkhau").html(formatThousands(0, ','));
                    }
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
                var quantity = 0;
                if (!isBlank($("#<%=hdfTotalQuantity.ClientID%>").val())) {
                    quantity = parseFloat($("#<%=hdfTotalQuantity.ClientID%>").val());
                }
                notEmpty();
                var dis = $("#<%=pDiscount.ClientID%>").val();
                var fs = $("#<%=pFeeShip.ClientID%>").val();
                var totalproduct = parseFloat($("#<%=hdftotal.ClientID%>").val());
                //$(".orderquantity").html(totalproduct);
                var discount = parseFloat(dis.replace(/\,/g, ''));
                var feeship = parseFloat(fs.replace(/\,/g, ''));
                $("#<%=hdfcheck.ClientID%>").val(discount);
                if (quantity > 0) {
                    var totalleft = total + feeship - discount * quantity;
                    var priceafterchietkhau = total - discount * quantity;
                    $("#<%=hdfTotalQuantity.ClientID%>").val(quantity);
                } else {
                    var totalleft = total + feeship - discount * totalproduct;
                    var priceafterchietkhau = total - discount * totalproduct;
                    $("#<%=hdfTotalQuantity.ClientID%>").val(totalproduct);
                }
                $(".totalpriceorderall").html(formatThousands(totalleft, ','));
                $(".priceafterchietkhau").html(formatThousands(priceafterchietkhau, ','));
                $(".totalGuestChange").html(formatThousands(totalleft, ','));

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
