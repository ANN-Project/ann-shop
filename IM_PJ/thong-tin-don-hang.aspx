<%@ Page Title="Thông tin đơn hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="thong-tin-don-hang.aspx.cs" Inherits="IM_PJ.thong_tin_don_hang" EnableSessionState="ReadOnly" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/App_Themes/Ann/js/search-customer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="parent" runat="server">
        <main id="main-wrap">
            <div class="container">
                <div id="infor-order" class="row">
                    <div class="col-md-12">
                        <div class="panel panelborderheading">
                            <div class="panel-heading clear">
                                <h3 class="page-title left not-margin-bot">Thông tin đơn hàng #<asp:Literal ID="ltrOrderID" runat="server"></asp:Literal></h3>
                            </div>
                            <div class="panel-body">
                                <div class="row pad">
                                    <div class="col-md-2">
                                        <label class="left pad10">Loại đơn: </label>
                                        <div class="ordertype">
                                            <asp:Literal ID="ltrOrderType" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="left pad10">Nhân viên tạo đơn: </label>
                                        <div class="ordercreateby">
                                            <asp:Literal ID="ltrCreateBy" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="left pad10">Ngày tạo: </label>
                                        <div class="ordercreatedate">
                                            <asp:Literal ID="ltrCreateDate" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label class="left pad10">Ngày hoàn tất: </label>
                                        <div class="orderdatedone">
                                            <asp:Literal ID="ltrDateDone" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="row pad">
                                    <div class="col-md-2">
                                        <label class="left pad10">Số lượng: </label>
                                        <div class="orderquantity">
                                            <asp:Literal ID="ltrOrderQuantity" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="left pad10">Tổng tiền: </label>
                                        <div class="ordertotalprice">
                                            <asp:Literal ID="ltrOrderTotalPrice" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="left pad10">Trạng thái: </label>
                                        <div class="orderstatus">
                                            <asp:Literal ID="ltrOrderStatus" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label class="left pad10">Ghi chú: </label>
                                        <div class="ordernote">
                                            <asp:Literal ID="ltrOrderNote" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Literal ID="ltrPrint" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="infor-customer" class="row">
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNick" ErrorMessage="(*)" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtNick" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Địa chỉ</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ErrorMessage="(*)" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                <div class="row">
                                    <div class="col-md-12 view-detail">
                                        <asp:Literal ID="ltrViewDetail" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 discount-info">
                                        <asp:Literal ID="ltrDiscountInfo" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="detail" class="row">
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
                                <div class="left">Đơn hàng trả
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
                <div id="status" class="row">
                    <div class="col-md-12">
                        <div class="panel panelborderheading">
                            <div class="panel-heading clear">
                                <h3 class="page-title left not-margin-bot">Trạng thái đơn hàng</h3>
                            </div>
                            <div class="panel-body">
                                <div id="row-payment-status" class="form-row">
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
                                <div id="row-excute-status" class="form-row">
                                    <div class="row-left">
                                        Trạng thái xử lý
                                    </div>
                                    <div class="row-right">
                                        <asp:DropDownList ID="ddlExcuteStatus" runat="server" CssClass="form-control" onchange="onChangeExcuteStatus()">
                                            <asp:ListItem Value="1" Text="Đang xử lý"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Đã hoàn tất"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Đã hủy"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="row-payment-type" class="form-row">
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
                                <div id="row-shipping-type" class="form-row">
                                    <div class="row-left">
                                        Phương thức giao hàng
                                    </div>
                                    <div class="row-right">
                                        <asp:DropDownList ID="ddlShippingType" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="Lấy trực tiếp"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Chuyển bưu điện"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Chuyển proship"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Chuyển xe"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Nhân viên giao hàng"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="row-transport-company" class="form-row transport-company">
                                    <asp:UpdatePanel ID="up" runat="server">
                                        <ContentTemplate>
                                            <div class="form-row">
                                                <div class="row-left">
                                                    Chành xe
                                                </div>
                                                <div class="row-right">
                                                    <asp:DropDownList ID="ddlTransportCompanyID" DataTextField="TransportCompanyID" DataValueField="ID" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlTransportCompanyID_SelectedIndexChanged" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="row-left">
                                                    Nơi nhận
                                                </div>
                                                <div class="row-right">
                                                    <asp:DropDownList ID="ddlTransportCompanySubID" DataTextField="TransportCompanySubID" DataValueField="ID" AppendDataBoundItems="True" AutoPostBack="false" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div id="row-shipping" class="form-row shipping-code hide">
                                    <div class="row-left">
                                        Mã vận đơn
                                    </div>
                                    <div class="row-right">
                                        <asp:TextBox ID="txtShippingCode" runat="server" CssClass="form-control" placeholder="Nhập mã vận đơn Bưu điện - Proship"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="row-order-note" class="form-row">
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
                                    <div id="img-out"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdfUsername" runat="server" />
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
            padding-bottom: 15px;
        }

        .pad10 {
            padding-right: 10px;
        }

        .padinfo {
            padding-bottom: 15px;
        }

        .disable {
            pointer-events: none;
            opacity: 0.4;
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
            // OrderDetailModel
            class OrderDetailModel {
                constructor(ID, SKU, ProductID, Quantity) {
                    this.ID = ID
                    this.SKU = SKU,
                    this.ProductID = ProductID,
                    this.Quantity = Quantity
                }

                stringJSON() {
                    return JSON.stringify(this);
                }
            }

            // orders detail remove
            var listOrderDetail = [];

            // order of item list
            var orderItem = $(".product-result").length;

            // search Product by SKU
            $("#txtSearch").keydown(function(event) {
                if (event.which === 13) {
                    searchProduct();
                    event.preventDefault();
                    return false;
                }
            });

            $(document).ready(function () {

                // hide shipping code

                if ($("#<%=ddlShippingType.ClientID%>").find(":selected").val() == 1) {
                    $(".transport-company").addClass("hide");
                }
                if ($("#<%=ddlShippingType.ClientID%>").find(":selected").val() == 2 || $("#<%=ddlShippingType.ClientID%>").find(":selected").val() == 3) {
                    $(".shipping-code").removeClass("hide");
                    $(".transport-company").addClass("hide");
                }

                if ($("#<%=ddlShippingType.ClientID%>").find(":selected").val() == 4) {
                    $(".transport-company").removeClass("hide");
                }

                $("#<%=ddlShippingType.ClientID%>").change(function () {
                    var selected = $(this).find(":selected").val();
                    switch(selected) {
                        case "1":
                            $(".shipping-code").addClass("hide");
                            $(".transport-company").addClass("hide");
                            $("#<%=txtShippingCode.ClientID%>").val("");
                            $("#<%=ddlTransportCompanyID.ClientID%>").val(0);
                            $("#<%=ddlTransportCompanySubID.ClientID%>").val(0);
                            break;
                        case "2":
                            $(".shipping-code").removeClass("hide");
                            $(".transport-company").addClass("hide");
                            $("#<%=ddlTransportCompanyID.ClientID%>").val(0);
                            $("#<%=ddlTransportCompanySubID.ClientID%>").val(0);
                            break;
                        case "3":
                            $(".shipping-code").removeClass("hide");
                            $(".transport-company").addClass("hide");
                            $("#<%=ddlTransportCompanyID.ClientID%>").val(0);
                            $("#<%=ddlTransportCompanySubID.ClientID%>").val(0);
                            break;
                        case "4":
                            $(".shipping-code").addClass("hide");
                            $(".transport-company").removeClass("hide");
                            $("#<%=txtShippingCode.ClientID%>").val("");
                            break;
                        case "5":
                            $(".shipping-code").addClass("hide");
                            $(".transport-company").addClass("hide");
                            $("#<%=txtShippingCode.ClientID%>").val("");
                            $("#<%=ddlTransportCompanyID.ClientID%>").val(0);
                            $("#<%=ddlTransportCompanySubID.ClientID%>").val(0);
                            break;
                    }
                });

                // add class full width for txtFacebook if it's null
                if ($("input[id$='_txtFacebook']").val() == "") {
                    $("input[id$='_txtFacebook']").parent().addClass("width-100");
                }

                // onchange drop down list excute status
                onChangeExcuteStatus();
            });

            // check data before close page or refresh page
            function stopNavigate(event) {
                $(window).off('beforeunload');
            }

            $(window).bind('beforeunload', function (e) {
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

            // pay order on click button
            function payAll() {

                var phone = $("#<%=txtPhone.ClientID%>").val();
                var name = $("#<%= txtFullname.ClientID%>").val();
                var nick = $("#<%= txtNick.ClientID%>").val();
                var address = $("#<%= txtAddress.ClientID%>").val();
                if (phone != "" && name != "" && nick != "" && address != "") {
                    if ($(".product-result").length > 0) {
                        var list = "";
                        var ordertype = $(".customer-type").val();
                        var checkoutin = false;

                        $(".product-result").each(function () {
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
                            }
                        });

                        let excuteStatus = Number($("#<%=ddlExcuteStatus.ClientID%>").val());

                        if (excuteStatus == 3) {
                            let c = confirm('Đơn hàng này sẽ được lưu ở trạng thái hủy');

                            if (!c)
                                return;
                        }

                        deleteOrder();

                        $("#<%=hdfOrderType.ClientID %>").val(ordertype);
                        $("#<%=hdfListProduct.ClientID%>").val(list);
                        insertOrder();
                    } else {
                        let excuteStatus = Number($("#<%=ddlExcuteStatus.ClientID%>").val());

                        if (excuteStatus == 3) {
                            let c = confirm('Đơn hàng này sẽ được lưu ở trạng thái hủy');

                            if (c) {
                                deleteOrder();

                                $.ajax({
                                    type: "POST",
                                    url: "/thong-tin-don-hang.aspx/UpdateStatus",
                                    data: "{}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (msg) {
                                        if (msg.d != null) {
                                            window.location.assign("/danh-sach-don-hang.aspx");
                                        }
                                    },
                                    error: function (xmlhttprequest, textstatus, errorthrow) {
                                        alert('lỗi');
                                    }
                                });

                            }
                        } else {
                            alert("Hãy nhập sản phẩm!");
                            $("#txtSearch").focus();
                        }
                    }
                } else {
                    if (name == "") {
                        alert("Hãy nhập tên khách hàng!");
                        $("#<%= txtFullname.ClientID%>").focus();
                    }
                    else if (phone == "") {
                        alert("Hãy nhập số điện thoại khách hàng!");
                        $("#<%= txtPhone.ClientID%>").focus();
                    }
                    else if (nick == "") {
                        alert("Hãy nhập Nick đặt hàng của khách hàng!");
                        $("#<%= txtNick.ClientID%>").focus();
                    }
                    else if (address == "") {
                        alert("Hãy nhập địa chỉ khách hàng!");
                        $("#<%= txtAddress.ClientID%>").focus();
                    }
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
                    loadingShow();
                    $("#<%=btnOrder.ClientID%>").click();
                }
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

            // reindex item order
            function reIndex() {
                var item = $(".order-item");
                for (var i = 0; i < item.length; i++) {
                    $(".order-item:eq(" + i + ")").html(i + 1);
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
                        data: "{textsearch:'" + textsearch + "', gettotal: 0 }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
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
                                    html += ("<td class=\"quantity-item\"><input class=\"quantity\" type=\"text\" value=\"1\"></td>");
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

                                // update stock which removed
                                updateTemplateStock(item);

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

                                    html += "   <td class=\"quantity-item\">" + item.QuantityInstockString + "</td>";
                                    html += "   <td class=\"quantity-item\"><input type=\"text\" class=\"form-control in-quanlity\" value=\"1\" onblur=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
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
                                            $(this).find(".in-quanlity").val(newquantity);

                                            var price = parseFloat(newquantity) * parseFloat(item.Giabansi);
                                            $(this).find(".totalprice-view").html(formatThousands(price, '.'));

                                            getAllPrice();
                                        }
                                    });
                                }

                                $(".content-product").prepend(html);
                                $("#txtSearch").val("");
                                getAllPrice();
                            } else {
                                alert("Không tìm thấy sản phẩm");
                                $("#txtSearch").select();
                            }
                        },
                        error: function(xmlhttprequest, textstatus, errorthrow) {
                            alert('lỗi');
                        }
                    });
                } else {
                    alert("Hãy nhập mã sản phẩm");
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
                    data: "{textsearch:'" + textsearch + "', gettotal: 1 }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        var data = JSON.parse(msg.d);
                        if (data.length > 0) {
                            var html = "";
                            for (var j = 0; j < list.length - 1; j++) {
                                var key = list[j];
                                for (var i = 0; i < data.length; i++) {
                                    var item = data[i];

                                    // update stock which removed
                                    updateTemplateStock(item);

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

                                            var t = 0;
                                            html += "   <td class=\"quantity-item soluong\">" + item.QuantityInstockString + "</td>";

                                            html += "   <td class=\"quantity-item\"><input type=\"text\" class=\"form-control in-quanlity\" value=\"" + list2[j] + "\" onblur=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                                            t = parseFloat(list2[j]) * parseFloat(item.Giabansi);

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
                                                    $(this).find(".in-quanlity").val(newquantity);

                                                    var price = parseFloat(newquantity) * parseFloat(item.Giabansi);
                                                    $(this).find(".totalprice-view").html(formatThousands(price, '.'));

                                                    getAllPrice();
                                                }
                                            });
                                        }
                                    }
                                }
                            }
                            $(".content-product").prepend(html);
                            $("#txtSearch").val("");
                            getAllPrice();
                        } else {
                            alert("Không tìm thấy sản phẩm");
                        }
                    },
                    error: function(xmlhttprequest, textstatus, errorthrow) {
                        alert('lỗi');
                    }
                });
            }

            // remove product form list
            function deleteRow(obj) {
                var c = confirm('Bạn muốn xóa sản phẩm này?');

                if (c) {
                    var row = obj.parent().parent();

                    if (row.attr("data-orderdetailid") > 0) {
                        var order = new OrderDetailModel(
                            ID = row.attr("data-orderdetailid"),
                            SKU = row.attr("data-sku"),
                            ProductID = row.attr("data-id"),
                            Quantity = row.find(".in-quanlity").val());
                        
                        listOrderDetail.push(order);
                    }

                    row.remove();

                    if ($(".product-result").length == 0) {
                        $("#<%=ddlExcuteStatus.ClientID%>").val(3);
                    }

                    getAllPrice();
                }

            }

            // update stock which removed
            function updateTemplateStock(orderServer){
                listOrderDetail.forEach(function (orderClient) {
                    if (orderClient.ID = orderServer.ID) {
                        orderServer.QuantityInstockString = (Number(orderServer.QuantityInstockString) + Number(orderClient.Quantity)).toString();
                    }
                });
            };

            // change quantity of product
            function checkQuantiy(obj) {
                var current = obj.val();
                if (current == 0 || current == "" || current == null) {
                    obj.val("1");
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

                    $(".totalproductQuantity").html(formatThousands(0, ',') + " sản phẩm");
                    $(".totalpriceorder").html(formatThousands(0, ','));
                    $(".totalGuestChange").html(formatThousands(0, ','));
                    $(".totalpriceorderall").html(formatThousands(0, ','));
                    $(".priceafterchietkhau").html(formatThousands(0, ','));

                }
                reIndex();
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

            function deleteOrder() {
                if (listOrderDetail.length > 0) {
                    let getDataJSON = function () {
                        let stringJSON = "{listOrderDetail: [";

                        for (index in listOrderDetail) {
                            if (index == 0) {
                                stringJSON += listOrderDetail[index].stringJSON();
                            } else {
                                stringJSON += ", " + listOrderDetail[index].stringJSON();
                            }
                        }

                        stringJSON += "]}";

                        return stringJSON;
                    };

                    $.ajax({
                        type: "POST",
                        url: "/thong-tin-don-hang.aspx/Delete",
                        data: getDataJSON(),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json"
                    })
                }
            }

            function onChangeExcuteStatus() {
                let excuteStatus = Number($("#<%=ddlExcuteStatus.ClientID%>").val());

                switch (excuteStatus) {
                    case 3:
                        $("#infor-order").addClass("disable");
                        $("#infor-customer").addClass("disable");
                        $("#detail").addClass("disable");
                        $("#status .panel-heading").addClass("disable");
                        $("#row-payment-status").addClass("disable");
                        $("#row-payment-type").addClass("disable");
                        $("#row-shipping-type").addClass("disable");
                        $("#row-transport-company").addClass("disable");
                        $("#row-shipping").addClass("disable");
                        $("#row-order-note").addClass("disable");

                        break;
                    default:
                        $("#infor-order").removeClass("disable");
                        $("#infor-customer").removeClass("disable");
                        $("#detail").removeClass("disable");
                        $("#status .panel-heading").removeClass("disable");
                        $("#row-payment-status").removeClass("disable");
                        $("#row-payment-type").removeClass("disable");
                        $("#row-shipping-type").removeClass("disable");
                        $("#row-transport-company").removeClass("disable");
                        $("#row-shipping").removeClass("disable");
                        $("#row-order-note").removeClass("disable");

                        break;
                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
