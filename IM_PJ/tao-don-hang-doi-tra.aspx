<%@ Page Title="Thêm đơn trả hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="tao-don-hang-doi-tra.aspx.cs" Inherits="IM_PJ.tao_don_hang_doi_tra" EnableSessionState="ReadOnly" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/App_Themes/Ann/js/search-customer.js"></script>
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
                                <a href="javascript:;" class="search-customer" onclick="searchCustomer2()"><i class="fa fa-search" aria-hidden="true"></i> Tìm khách hàng (F1)</a>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Họ tên</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullname" ErrorMessage="(*)" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtFullname" Enabled="false" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Điện thoại</label>
                                            <asp:RequiredFieldValidator ID="re" runat="server" ControlToValidate="txtPhone" ErrorMessage="(*)" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtPhone" Enabled="false" CssClass="form-control" runat="server" onchange="checkCustomer()" onpaste="checkCustomer()" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                </div> 
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Nick đặt hàng</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNick" ErrorMessage="(*)" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtNick" Enabled="false" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Địa chỉ</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ErrorMessage="(*)" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtAddress" Enabled="false" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                </div> 
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Zalo</label>
                                            <asp:TextBox ID="txtZalo" Enabled="false" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Facebook</label>
                                            <div class="row">
                                                <div class="col-md-10 fb width-100">
                                                <asp:TextBox ID="txtFacebook" Enabled="false" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="row">
                                                        <span class="link-facebook"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row view-detail" style="display: none">
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
                                    <input type="text" id="txtSearch" class="form-control sku-input" placeholder="SKU (F3)" autocomplete="off">
                                </div>
                                <div class="right">
                                    <a href="javascript:;" class="link-btn" onclick="searchProduct()"><i class="fa fa-search"></i></a>
                                </div>
                            </div>
                            <div class="post-body search-product-content clear">
                                <table class="table table-checkable table-product table-return-order">
                                    <thead>
                                        <tr>
                                            <th class="image-column">Ảnh</th>
                                            <th class="name-column">Sản phẩm</th>
                                            <th class="sku-column">Mã</th>
                                            <th class="price-column">Giá niêm yết</th>
                                            <th class="sold-price-column">Giá đã bán</th>
                                            <th class="quantity-column">Cần đổi</th>
                                            <th class="type-column">Hình thức</th>
                                            <th class="fee-column">Phí đổi hàng</th>
                                            <th class="total-column">Thành tiền</th>
                                            <th class="trash-column">Xóa</th>
                                        </tr>
                                    </thead>
                                    <tbody class="content-product">
                                    </tbody>
                                </table>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Tổng cộng</div>
                                <div class="right totalPriceOrder"></div>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Tổng số lượng sản phẩm</div>
                                <div class="right totalProductQuantity"></div>
                            </div>
                            <div class="post-row clear">
                                <div class="left">Phí đổi hàng</div>
                                <div class="right totalRefund"></div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panelborderheading">
                            <div class="panel-heading clear">
                                <h3 class="page-title left not-margin-bot">Thông tin trạng thái đơn hàng đổi trả</h3>
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
                                <div class="panel-post">
                                    <div class="post-table-links clear">
                                        <a href="javascript:;" class="btn link-btn" style="background-color: #f87703; float: right;" onclick="payall()"><i class="fa fa-floppy-o"></i> Xác nhận</a>
                                        <a href="javascript:;" class="btn link-btn" style="background-color: #F44336; float: right;" onclick="deleteProduct()"><i class="fa fa-times" aria-hidden="true"></i> Làm lại</a>
                                        <a href="javascript:;" class="btn link-btn minus-discount" style="background-color: #009688; float: right;" onclick="minusDiscount()"><i class="fa fa-arrow-down" aria-hidden="true"></i> Trừ chiết khấu</a>
                                        <a href="javascript:;" class="btn link-btn restore-discount hide" style="background-color: #009688; float: right;" onclick="restoreDiscount()"><i class="fa fa-arrow-up" aria-hidden="true"></i> Khôi phục giá bán cũ</a>
                                        <a href="javascript:;" class="btn link-btn" style="background-color: #607D8B; float: right;" onclick="changeFee()"><i class="fa fa-external-link" aria-hidden="true"></i> Nhập phí đổi hàng khác</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Style="display: none" />
            <asp:HiddenField ID="hdfUsername" runat="server" />
            <asp:HiddenField ID="hdfPhone" runat="server" />
            <asp:HiddenField ID="hdfTotalPrice" runat="server" Value="0" />
            <asp:HiddenField ID="hdfTotalQuantity" runat="server" Value="0" />
            <asp:HiddenField ID="hdfTotalRefund" runat="server" Value="0" />
            <asp:HiddenField ID="hdfListProduct" runat="server" />
        </main>
    </asp:Panel>
    <style>
        .search-product-content {
            min-height: 200px;
            background: #fff;
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
            // Create model entity
            class RefundDetailModel{
                constructor(RowIndex
                            , ProductID
                            , ProductVariableID
                            , ProductStyle
                            , ProductImage
                            , ProductTitle
                            , ParentSKU
                            , ChildSKU
                            , VariableValue
                            , Price
                            , ReducedPrice
                            , QuantityRefund
                            , ChangeType
                            , FeeRefund
                            , TotalFeeRefund) {
                    this.RowIndex = RowIndex;
                    this.ProductID = ProductID;
                    this.ProductVariableID = ProductVariableID;
                    this.ProductStyle = ProductStyle;
                    this.ProductImage = ProductImage;
                    this.ProductTitle = ProductTitle;
                    this.ParentSKU = ParentSKU;
                    this.ChildSKU = ChildSKU;
                    this.VariableValue = VariableValue;
                    this.Price = Price;
                    this.ReducedPrice = ReducedPrice;
                    this.QuantityRefund = QuantityRefund;
                    this.ChangeType = ChangeType;
                    this.FeeRefund = FeeRefund;
                    this.TotalFeeRefund = TotalFeeRefund;
                }

                isTarget(RowIndex, ProductID, ProductVariableID) {
                    return this.RowIndex == RowIndex && this.ProductID == ProductID && this.ProductVariableID == ProductVariableID;
                }
                
                stringJSON() {
                    return JSON.stringify(this);
                }
            }

            // Key for row in table product refund
            var rowIndexMax = Number(0);

            // Create model
            var productRefunds = [];
            var productDeleteRefunds = [];

            function redirectTo(ID) {
                window.location.href = "/xem-don-hang-doi-tra?id=" + ID;
            }

            function minusDiscount() {
                swal({
                    title: "Trừ chiết khấu",
                    text: 'Nhập số tiền cần trừ:',
                    type: 'input',
                    showCancelButton: true,
                    closeOnConfirm: true,
                    cancelButtonText: "Để em xem lại",
                    confirmButtonText: "OK sếp!!",
                }, function (discount) {
                    
                    $("input.reducedPrice").each(function (index) {
                        oldValue = $(this).val().replace(/,/g, "");

                        if (parseInt(discount) > 0) {
                            newValue = formatThousands(parseInt(oldValue) - parseInt(discount));
                        }
                        else {
                            newValue = formatThousands(parseInt(oldValue) + parseInt(discount));
                        }
                        
                        $(this).val(newValue);
                        changeRow($(this));
                    });

                    $(".minus-discount").addClass("hide");
                    $(".restore-discount").removeClass("hide");
                });
            }

            function restoreDiscount() {
                swal({
                    title: "Khôi phục lại giá bán",
                    text: "Giá bán sẽ khôi phục lại như lúc đầu (giống giá niêm yết).. OK không?",
                    type: 'warning',
                    showCancelButton: true,
                    closeOnConfirm: true,
                    cancelButtonText: "Để em coi lại..",
                    confirmButtonText: "OK sếp !!!",
                }, function (isConfirm) {
                    if (isConfirm) {
                        $("input.reducedPrice").each(function (index) {
                            oldValue = $(this).parent().parent().find("td.Price").html();

                            $(this).val(oldValue);
                            changeRow($(this));
                        });

                        $(".minus-discount").removeClass("hide");
                        $(".restore-discount").addClass("hide");
                    }
                });
            }

            function changeFee() {
                swal({
                    title: "Thay đổi phí đổi hàng",
                    text: "Nhập phí mới cho <strong>sản phẩm đổi mẫu khác</strong> trong đơn hàng này:",
                    type: "input",
                    showCancelButton: true,
                    closeOnConfirm: true,
                    cancelButtonText: "Để em coi lại..",
                    confirmButtonText: "Nhập thôi !!!",
                    html: true
                }, function (newFee) {
                    $("input.reducedPrice").each(function (index) {
                        oldFee = $(this).parent().parent().attr("data-feerefund");
                        if (oldFee != "") {
                            $(this).parent().parent().attr("data-feerefund", newFee);
                            $(this).parent().parent().find(".feeRefund").html(formatThousands(newFee));
                            changeRow($(this));
                        }
                    });

                    $(".minus-discount").removeClass("hide");
                    $(".restore-discount").addClass("hide");
                });
            }

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
            });
            
            $('#txtSearch').keydown(function (event) {
                if (event.which === 13) {
                    searchProduct();
                    event.preventDefault();
                    return false;
                }
            });

            function searchCustomer2() {
                searchCustomer();
            }

            function checkCustomer() {
                var txtPhone = $("#<%=txtPhone.ClientID%>").val();

                $.ajax({
                    type: "POST",
                    url: "/tao-don-hang-doi-tra.aspx/checkphone",
                    data: "{phonefullname:'" + txtPhone + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d == "nocustomer") {
                            alert('Không tìm thấy khách hàng trong hệ thống');
                        }
                        else {
                            $("#<%=hdfPhone.ClientID%>").val(txtPhone);
                        }
                    },
                    error: function (xmlhttprequest, textstatus, errorthrow) {
                        alert('lỗi');
                    }
                });
            }

            function getAllPrice() {
                let totalPrice = 0;
                let productQuantity = 0;
                let totalRefund = 0;

                productRefunds.forEach(function(item){
                    totalPrice += item.TotalFeeRefund;
                    productQuantity += item.QuantityRefund;

                    if (item.ChangeType == 2){
                        totalRefund += item.FeeRefund * item.QuantityRefund;
                    }
                    else{
                        totalRefund += 0;
                    }
                });

                $(".totalPriceOrder").html(formatThousands(totalPrice, ","));
                $(".totalProductQuantity").html(formatThousands(productQuantity, ","));
                $(".totalRefund").html(formatThousands(totalRefund, ","));

                $("#<%=hdfTotalPrice.ClientID%>").val(totalPrice);
                $("#<%=hdfTotalQuantity.ClientID%>").val(productQuantity);
                $("#<%=hdfTotalRefund.ClientID%>").val(totalRefund);
            }

            function changeRow(obj)
            {
                let row = obj.parent().parent();
                let RowIndex = parseInt(row.attr("data-rowIndex"));
                let ProductID = parseInt(row.attr("data-productID"));
                let ProductVariableID = parseInt(row.attr("data-productVariableID"));
                let Price = parseFloat(row.find(".Price").html().replace(/,/g, ""));
                let ReducedPrice = parseFloat(row.find(".reducedPrice").val().replace(/,/g, ""));
                let Quantity = parseFloat(row.find(".quantityRefund").val().replace(/,/g, ""));
                let ChangeType = row.find(".changeType").val();
                let FeeRefund = parseFloat(row.attr("data-feeRefund"));
                let TotalFeeRefund = 0;

                // Ruler Price - ReducedPrice >= 10,000 VND
                if ((Price - ReducedPrice) > 10000) {
                    alert("Giá đã bán không thể giảm hơn 10,000đ..");
                    row.find(".reducedPrice").val(formatThousands(Price, ","));
                    return;
                }

                if (ChangeType == 2) {
                    TotalFeeRefund = (ReducedPrice - FeeRefund) * Quantity;

                    row.find(".feeRefund").html(formatThousands(FeeRefund, ","));
                    row.find(".totalFeeRefund").html(formatThousands(TotalFeeRefund, ","));
                }
                else {
                    TotalFeeRefund = ReducedPrice * Quantity;

                    row.find(".feeRefund").html(0);
                    row.find(".totalFeeRefund").html(formatThousands(TotalFeeRefund, ","));
                }

                productRefunds.forEach(function(item){
                    if (item.isTarget(RowIndex, ProductID, ProductVariableID)) {
                        item.QuantityRefund = Quantity;
                        item.ChangeType = ChangeType;
                        item.TotalFeeRefund = TotalFeeRefund;
                        item.ReducedPrice = ReducedPrice;
                        item.FeeRefund = FeeRefund;
                        item.DiscountPricePerProduct = Price - ReducedPrice;
                    }
                });

                getAllPrice();
            }

            function addHtmlProductResult(item) {
                let html = "";

                html += "<tr class='product-result' "
                                + "data-rowIndex='" + item.RowIndex + "' "
                                + "data-productID='" + item.ProductID + "' "
                                + "data-productVariableID='" + item.ProductVariableID + "' "
                                + "data-productStyle='" + item.ProductStyle + "' "
                                + "data-productImage='" + item.ProductImage + "' "
                                + "data-productTitle='" + item.ProductTitle + "' "
                                + "data-parentSKU='" + item.ParentSKU + "' "
                                + "data-childSKU='" + item.ChildSKU + "' "
                                + "data-variableValue='" + item.VariableValue + "' "
                                + "data-price='" + item.Price + "' "
                                + "data-feeRefund='" + item.FeeRefund + "' >\n";
                html += "    <td><img src='" + item.ProductImage + "''></td>\n";
                html += "    <td>" + item.ProductTitle + "</td>\n";
                if (item.ProductStyle == 1) {
                    html += "    <td>" + item.ParentSKU + "</td>\n";
                }
                else if (item.ProductStyle == 2) {
                    html += "    <td>" + item.ChildSKU + "</td>\n";
                }
                html += "    <td class='Price'>" + formatThousands(item.Price, ",") + "</td>\n";
                html += "    <td>\n";
                html += "           <input type='text' class='form-control reducedPrice' min='1' value='" + formatThousands(item.ReducedPrice, ",") + "' onblur='changeRow($(this))' onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>\n";
                html += "    </td>\n";
                html += "    <td>\n";
                html += "           <input type='text' class='form-control quantityRefund' min='1' value='" + formatThousands(item.QuantityRefund, ",") + "' onblur='changeRow($(this))' onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>\n";
                html += "    </td>\n";
                html += "    <td>\n";
                html += "           <select class='form-control changeType' onchange='changeRow($(this))'>\n";
                if (item.ChangeType == 1) {
                    html += "               <option value='1' selected>Đổi size</option>\n";
                    html += "               <option value='2'>Đổi sản phẩm khác</option>\n";
                    html += "               <option value='3'>Đổi hàng lỗi</option>\n";
                }
                else if (item.ChangeType == 2) {
                    html += "               <option value='1'>Đổi size</option>\n";
                    html += "               <option value='2' selected>Đổi sản phẩm khác</option>\n";
                    html += "               <option value='3'>Đổi hàng lỗi</option>\n";
                }
                else {
                    html += "               <option value='1'>Đổi size</option>\n";
                    html += "               <option value='2'>Đổi sản phẩm khác</option>\n";
                    html += "               <option value='3' selected>Đổi hàng lỗi</option>\n";
                }
                
                html += "           </select>\n";
                html += "    </td>\n";
                if (item.ChangeType == 2) {
                    html += "   <td class='feeRefund'>" + formatThousands(item.FeeRefund) + "</td>\n";
                }
                else {
                    html += "   <td class='feeRefund'>0</td>\n";
                }
                html += "   <td class='totalFeeRefund'>" + formatThousands(item.TotalFeeRefund) + "</td>\n";
                html += "   <td class='trash-column'><a href='javascript:;' class='link-btn' onclick='deleteRow($(this))'><i class='fa fa-trash'></i></a></td>\n";
                html += "</tr>\n";

                $(".content-product").prepend(html);
            }

            // select a variable product
            function selectProduct() {
                $(".search-popup").each(function (index, element) {
                    if ($(this).find(".check-popup").is(':checked')) {
                        let sku = $(this).find("td.key").html();
                        let quantity = parseInt($(this).find("input.quantity").val());

                        let productTarget = productVariableSearch.filter(function (x) { return x.ChildSKU == sku })[0];

                        // get quantity new
                        productTarget.QuantityRefund = quantity;

                        // update total price
                        productTarget.TotalFeeRefund = (productTarget.ReducedPrice - productTarget.FeeRefund) * productTarget.QuantityRefund;

                        // remove dangerous Request.Form
                        productTarget.VariableValue = ""; 

                        productRefunds.push(productTarget);
                        addHtmlProductResult(productTarget);
                    }
                });

                getAllPrice();
                closePopup();
                $("#txtSearch").focus();
            }

            // select all variable product
            function check_all() {
                if ($('#check-all').is(":checked")) {
                    $(".check-popup").prop('checked', true);
                } else {
                    $(".check-popup").prop('checked', false);
                }
            }

            // Show list product variable
            function showProductVariable(productVariables){
                var html = "";
                // Header Popup
                html += "<table class='table table-checkable table-product'>\n";
                html += "<tr>\n";
                html += "   <td class='order-item'>\n";
                html += "       <input type='checkbox' id='check-all'onchange='check_all()'/>\n";
                html += "   </td>\n";
                html += "   <td class='image-item'>Ảnh</td>\n";
                html += "   <td class='name-item'>Sản phẩm</td>\n";
                html += "   <td class='sku-item'>Mã</td>\n";
                html += "   <td class='variable-item'>Thuộc tính</td>\n";
                html += "   <td class='quantity-item'>Số lượng</td>\n";
                html += "</tr>\n";

                // Body Popup
                productVariables.forEach(function(item) {
                    html += "<tr class='search-popup' id='search-key';>\n";
                    html += "   <td class='order-item'>\n";
                    html += "       <input id='" + item.ProductVariableID + "' type='checkbox' class='check-popup' />\n";
                    html += "   </td>\n";
                    html += "   <td class='image-item'><img src='" + item.ProductImage + "'></td>\n";
                    html += "   <td class='namer-item'>" + item.ProductTitle + "</td>\n";
                    html += "   <td class='sku-item key'>" + item.ChildSKU + "</td>\n";
                    html += "   <td class='variable-item'>" + item.VariableValue + "</td>\n";
                    html += "   <td class='quantity-item'><input class='quantity' type='text' value='1' onkeypress='return event.charCode >= 48 && event.charCode <= 57'></td>\n";
                    html += "</tr>\n";
                });

                // Footer Popup
                html += "</table>\n";
                html += "<div>\n";
                html += "   <a href='javascript: ;' class='btn link-btn' style='background-color:#f87703;float:right;color:#fff;' onclick='selectProduct()'>Chọn</a>\n";
                html += "</div >\n";

                $("#txtSearch").val("");
                showPopup(html);
            }

            function searchProduct() {
                let txtPhone = $("#<%=txtPhone.ClientID%>").val();
                let txtSearch = $("#txtSearch").val();
                var product = null;

                productVariableSearch = [];

                if (isBlank(txtPhone)) {
                    
                    swal({
                        title: "Từ từ nè",
                        text: "Tìm khách hàng trước đã!<br><br>Nếu chưa có thì phải tạo khách hàng trước nha!",
                        type: "warning",
                        showCancelButton: true,
                        closeOnConfirm: false,
                        confirmButtonText: "Để em tìm",
                        cancelButtonText: "Tạo khách hàng",
                        html: true,
                    }, function (isConfirm) {
                        if (isConfirm) {
                            swal.close();
                            searchCustomer();
                        }
                        else
                        {
                            searchCustomer();
                            window.open("/them-moi-khach-hang", "_blank");
                        }
                    });
                    return;
                }

                if (isBlank(txtSearch)) {
                    swal({
                        title: "Ủa Ủa",
                        text: "Sao chưa nhập gì hết mà!",
                        type: "warning",
                        showCancelButton: false,
                        closeOnConfirm: false,
                        confirmButtonText: "Hehe em quên!",
                    });
                    return;
                }

                productDeleteRefunds.forEach(function (item) {
                    if (item.ProductStyle == 1 && item.ParentSKU.toUpperCase() == txtSearch.toUpperCase()) {
                        product = item;
                    }
                    else if (item.ProductStyle == 2 && item.ChildSKU.toUpperCase() == txtSearch.toUpperCase()) {
                        product = item;
                    }
                });

                if (product != null) {
                    // remove product by SKU 
                    productDeleteRefunds = productDeleteRefunds.filter(function (item) {
                        return !(item.ParentSKU = product.ParentSKU && item.ChildSKU == product.ChildSKU)
                    });

                    productRefunds.push(product);

                    addHtmlProductResult(product);

                    $("#txtSearch").val("");
                    getAllPrice();
                }
                else {
                    $.ajax({
                        type: "POST",
                        url: "/tao-don-hang-doi-tra.aspx/getProduct",
                        data: "{sku:'" + txtSearch + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            let data = JSON.parse(msg.d);

                            if (data != null && data.length > 0) {
                                if (data.length > 1) {
                                    data.forEach(function (item) {
                                        rowIndexMax = rowIndexMax + 1;

                                        let productVariable = new RefundDetailModel(
                                            RowIndex = rowIndexMax
                                            , ProductID = item.ProductID
                                            , ProductVariableID = item.ProductVariableID
                                            , ProductStyle = item.ProductStyle
                                            , ProductImage = item.ProductImage
                                            , ProductTitle = item.ProductTitle
                                            , ParentSKU = item.ParentSKU
                                            , ChildSKU = item.ChildSKU
                                            , VariableValue = item.VariableValue
                                            , Price = item.Price
                                            , ReducedPrice = item.ReducedPrice
                                            , QuantityRefund = item.QuantityRefund
                                            , ChangeType = item.ChangeType
                                            , FeeRefund = item.FeeRefund
                                            , TotalFeeRefund = item.TotalFeeRefund
                                        );

                                        productVariableSearch.push(productVariable);
                                    });

                                    showProductVariable(productVariableSearch);
                                }
                                else {
                                    rowIndexMax = rowIndexMax + 1;

                                    product = new RefundDetailModel(
                                        RowIndex = rowIndexMax
                                        , ProductID = data[0].ProductID
                                        , ProductVariableID = data[0].ProductVariableID
                                        , ProductStyle = data[0].ProductStyle
                                        , ProductImage = data[0].ProductImage
                                        , ProductTitle = data[0].ProductTitle
                                        , ParentSKU = data[0].ParentSKU
                                        , ChildSKU = data[0].ChildSKU
                                        , VariableValue = data[0].VariableValue
                                        , Price = data[0].Price
                                        , ReducedPrice = data[0].ReducedPrice
                                        , QuantityRefund = data[0].QuantityRefund
                                        , ChangeType = data[0].ChangeType
                                        , FeeRefund = data[0].FeeRefund
                                        , TotalFeeRefund = data[0].TotalFeeRefund - data[0].FeeRefund
                                    );

                                    productRefunds.push(product);

                                    addHtmlProductResult(product);

                                    $("#txtSearch").val("");
                                    getAllPrice();
                                }
                            }
                            else {
                                alert('Không tìm thấy sản phẩm');
                            }
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            let msg = '';

                            if (jqXHR.status == 500) {
                                msg = jqXHR.responseJSON.Message;
                            } else {
                                msg = 'lỗi'
                            }

                            alert(msg);
                            return;
                        }
                    });
                }
            }

            function deleteRow(obj) {
                let c = confirm('Bạn muốn xóa sản phẩm này?');

                if (c) {
                    let row = obj.parent().parent();
                    let RowIndex = parseFloat(row.attr("data-rowIndex"));
                    let ProductID = parseFloat(row.attr("data-productID"));
                    let ProductVariableID = parseFloat(row.attr("data-productVariableID"));

                    productRefunds.forEach(function (product) {
                        if (product.isTarget(RowIndex, ProductID, ProductVariableID)) {
                            product.QuantityRefund = 1; // return default
                            product.ChangeType = 1; // return default
                            product.TotalFeeRefund = product.Price; // return default
                            productDeleteRefunds.push(product);
                        }
                    });

                    productRefunds = productRefunds.filter(function (product) {
                        return !product.isTarget(RowIndex, ProductID, ProductVariableID);
                    });

                    row.remove();
                    getAllPrice();
                }
            }

            function deleteProduct() {
                let c = confirm("Bạn muốn xóa tất cả sản phẩm?");

                if (c) {
                    productDeleteRefunds = productRefunds;
                    productRefunds = [];

                    $(".product-result").remove();

                    getAllPrice();
                }
            }

            function payall() {
                if (productRefunds.length > 0) {
                    let dataJSON = "{ 'RefundDetails' : ["

                    productRefunds.forEach(function (item) {
                        dataJSON += item.stringJSON() + ","
                    });

                    dataJSON = dataJSON.replace(/.$/, "") + "]}";

                    $("#<%=hdfListProduct.ClientID%>").val(dataJSON);
                    $("#<%=btnSave.ClientID%>").click();
                }
                else {
                    alert('Vui lòng chọn sản phẩm đổi trả');
                }
            }

            var formatThousands = function (n, dp) {
                var s = '' + (Math.floor(n)), d = n % 1, i = s.length, r = '';
                while ((i -= 3) > 0) { r = ',' + s.substr(i, 3) + r; }
                return s.substr(0, i + 3) + r +
                    (d ? '.' + Math.round(d * Math.pow(10, dp || 2)) : '');
            };

            $(document).ready(function () {
                let dataJSON = $("#<%=hdfListProduct.ClientID%>").val();

                if (!isBlank(dataJSON)) {
                    let refundGoodModel = jQuery.parseJSON(dataJSON);

                    // Init header search Customer
                    $("#<%=txtFullname.ClientID%>").val(refundGoodModel.CustomerName);
                    $("#<%=txtPhone.ClientID%>").val(refundGoodModel.CustomerPhone);
                    $("#<%=txtNick.ClientID%>").val(refundGoodModel.CustomerNick);
                    $("#<%=txtAddress.ClientID%>").val(refundGoodModel.CustomerAddress);
                    $("#<%=txtZalo.ClientID%>").val(refundGoodModel.CustomerZalo);
                    $("#<%=txtFacebook.ClientID%>").val(refundGoodModel.CustomerFacebook);

                    // Init detail refund product
                    let rowIndexMax = 0
                    refundGoodModel.RefundDetails.reverse().forEach(function (item) {
                        rowIndexMax = rowIndexMax + 1;

                        let product = new RefundDetailModel(
                                        RowIndex = rowIndexMax
                                        , ProductID = item.ProductID
                                        , ProductVariableID = item.ProductVariableID
                                        , ProductStyle = item.ProductStyle
                                        , ProductImage = item.ProductImage
                                        , ProductTitle = item.ProductTitle
                                        , ParentSKU = item.ParentSKU
                                        , ChildSKU = item.ChildSKU
                                        , VariableValue = item.VariableValue
                                        , Price = item.Price
                                        , ReducedPrice = item.ReducedPrice
                                        , QuantityRefund = item.QuantityRefund
                                        , ChangeType = item.ChangeType
                                        , FeeRefund = item.FeeRefund
                                        , TotalFeeRefund = item.TotalFeeRefund
                                    );

                        productRefunds.push(product);

                        addHtmlProductResult(product);

                        getAllPrice();
                    });

                    // Init total refund product
                    $(".totalPriceOrder").html(formatThousands(refundGoodModel.TotalPrice, ","));
                    $(".totalProductQuantity").html(formatThousands(refundGoodModel.TotalQuantity, ","));
                    $(".totalRefund").html(formatThousands(refundGoodModel.TotalFreeRefund, ","));

                    // Init footer status
                    $("#<%=ddlRefundStatus.ClientID%>").val(refundGoodModel.Status);
                    $("#<%=txtRefundsNote.ClientID%>").val(refundGoodModel.Note);

                    // Init hiden footer
                    $("#<%=hdfPhone.ClientID%>").val(refundGoodModel.CustomerPhone);
                    $("#<%=hdfTotalPrice.ClientID%>").val(refundGoodModel.TotalPrice);
                    $("#<%=hdfTotalQuantity.ClientID%>").val(refundGoodModel.TotalQuantity);
                    $("#<%=hdfTotalRefund.ClientID%>").val(refundGoodModel.TotalFreeRefund);
                }
            });
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
